using System.Collections.Generic;
using System.IO;
using CodeBlacks.BusinessRules;
using CommandLine;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace CodeBlacks.Console
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Options options = new Options();
            Parser.Default.ParseArgumentsStrict(args, options);
            string pathToOldCodeCoverageReportDirectory = Path.Combine(options.PathToCodeCoverageReportDirectory, "old");
            string pathToNewCodeCoverageReportDirectory = Path.Combine(options.PathToCodeCoverageReportDirectory, "new");
            RunCodeCoverage(options, pathToOldCodeCoverageReportDirectory, pathToNewCodeCoverageReportDirectory);
            CodeCoverageComparison comparison = new CodeCoverageComparison();
            IEnumerable<FileDifferences> differences = comparison.CompareDirectories(
                pathToOldCodeCoverageReportDirectory,
                pathToNewCodeCoverageReportDirectory);
            string differenceText = FileDifferencesSerializer.ToString(differences);
            SaveToFile(differenceText, options);
            SaveToAzure(differenceText, options);
        }

        private static void RunCodeCoverage(
            Options options,
            string pathToOldCodeCoverageReportDirectory,
            string pathToNewCodeCoverageReportDirectory)
        {
            (new CodeCoverageRunner()
            {
                PathToOpenCover = options.PathToOpenCover,
                PathToReportGenerator = options.PathToReportGenerator,
                PathToTestRunner = options.PathToTestRunner,
                TestRunnerArguments = options.OldTestRunnerArguments,
                PathToCodeCoverageXmlFile = Path.Combine(options.PathToCodeCoverageReportDirectory, "old.xml"),
                PathToCodeCoverageReportDirectory = pathToOldCodeCoverageReportDirectory,
                CodeCoverageFilter = options.CodeCoverageFilter
            }).RunCodeCoverage();
            (new CodeCoverageRunner()
            {
                PathToOpenCover = options.PathToOpenCover,
                PathToReportGenerator = options.PathToReportGenerator,
                PathToTestRunner = options.PathToTestRunner,
                TestRunnerArguments = options.NewTestRunnerArguments,
                PathToCodeCoverageXmlFile = Path.Combine(options.PathToCodeCoverageReportDirectory, "new.xml"),
                PathToCodeCoverageReportDirectory = pathToNewCodeCoverageReportDirectory,
                CodeCoverageFilter = options.CodeCoverageFilter
            }).RunCodeCoverage();
        }

        private static void SaveToFile(string differenceText, Options options)
        {
            if (!string.IsNullOrWhiteSpace(options.OutputFile))
            {
                File.WriteAllText(options.OutputFile, differenceText);
            }
        }

        private static void SaveToAzure(string differenceText, Options options)
        {
            if (!string.IsNullOrWhiteSpace(options.AzureAccountName) &&
                !string.IsNullOrWhiteSpace(options.AzureAccountKey) &&
                !string.IsNullOrWhiteSpace(options.AzureFileName))
            {
                string connectionString = string.Format(
                    "DefaultEndpointsProtocol=https;AccountName={0};AccountKey={1}",
                    options.AzureAccountName,
                    options.AzureAccountKey);
                CloudStorageAccount storageAccount = CloudStorageAccount.Parse(connectionString);
                CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
                CloudBlobContainer testComparisonContainer = blobClient.GetContainerReference("testzips");
                CloudBlockBlob blob = testComparisonContainer.GetBlockBlobReference(options.AzureFileName);
                blob.UploadText(differenceText);
            }
        }
    }
}

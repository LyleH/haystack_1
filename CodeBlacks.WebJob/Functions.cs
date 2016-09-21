using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using CodeBlacks.BusinessRules;
using Microsoft.Azure.WebJobs;
using Microsoft.WindowsAzure.Storage.Blob;

namespace CodeBlacks.WebJob
{
    public static class Functions
    {
        public static void RunAndCompareTests(
        [QueueTrigger("run-and-compare-tests")] TestComparisonRequest request,
        [Blob("testzips/{TestComparisonId}.zip", FileAccess.Read)] Stream testZip,
        [Blob("testcomparisons/{TestComparisonId}.json")] CloudBlockBlob outputBlob)
        {
            string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string testDirectory = Path.Combine(currentDirectory, request.TestComparisonId);
            ExtractTestZip(testZip, testDirectory);
            string pathToTestDll = Path.Combine(testDirectory, "old", request.TestDll);
            string pathToOldCoverage = Path.Combine(testDirectory, "OldCoverage");
            string pathToNewCoverage = Path.Combine(testDirectory, "NewCoverage");
            CodeCoverageRunner runner = CreateRunner(currentDirectory, request);
            runner.TestRunnerArguments = string.Format("\"\"{0}\"\" -method {1} -noshadow", pathToTestDll, request.TestToRun);
            runner.PathToCodeCoverageXmlFile = Path.Combine(testDirectory, "old.xml");
            runner.PathToCodeCoverageReportDirectory = Path.Combine(testDirectory, "OldCoverage");
            runner.RunCodeCoverage();
            pathToTestDll = Path.Combine(testDirectory, "new", request.TestDll);
            runner.TestRunnerArguments = string.Format("\"\"{0}\"\" -method {1} -noshadow", pathToTestDll, request.TestToRun);
            runner.PathToCodeCoverageXmlFile = Path.Combine(testDirectory, "new.xml");
            runner.PathToCodeCoverageReportDirectory = Path.Combine(testDirectory, "NewCoverage");
            runner.RunCodeCoverage();
            IEnumerable<FileDifferences> differences = new CodeCoverageComparison().CompareDirectories(pathToOldCoverage, pathToNewCoverage);
            outputBlob.UploadText(FileDifferencesSerializer.ToString(differences));
            Directory.Delete(testDirectory, true);
        }

        private static void ExtractTestZip(Stream testZip, string testDirectory)
        {
            using (ZipArchive zip = new ZipArchive(testZip))
            {
                zip.ExtractToDirectory(testDirectory);
            }
        }

        private static CodeCoverageRunner CreateRunner(string currentDirectory, TestComparisonRequest request)
        {
            return new CodeCoverageRunner()
            {
                PathToOpenCover = Path.Combine(currentDirectory, @"OpenCover.4.5.3723\OpenCover.Console.exe"),
                PathToReportGenerator = Path.Combine(currentDirectory, @"ReportGenerator.2.1.4.0\ReportGenerator.exe"),
                PathToTestRunner = Path.Combine(currentDirectory, @"xunit.runner.console.2.0.0\tools\xunit.console.exe"),
                CodeCoverageFilter = request.CodeCoverageFilter
            };
        }
    }
}

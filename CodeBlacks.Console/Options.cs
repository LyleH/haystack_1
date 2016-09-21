using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlacks.Console
{
    public sealed class Options
    {
        [Option(Required = true)]
        public string PathToOpenCover { get; set; }

        [Option(Required = true)]
        public string PathToReportGenerator { get; set; }

        [Option(Required = true)]
        public string PathToTestRunner { get; set; }

        [Option(Required = true)]
        public string OldTestRunnerArguments { get; set; }

        [Option(Required = true)]
        public string NewTestRunnerArguments { get; set; }
        
        [Option(Required = true)]
        public string PathToCodeCoverageReportDirectory { get; set; }

        [Option(Required = true)]
        public string CodeCoverageFilter { get; set; }

        [Option]
        public string AzureAccountName { get; set; }

        [Option]
        public string AzureAccountKey { get; set; }

        [Option]
        public string AzureFileName { get; set; }

        [Option]
        public string OutputFile { get; set; }
    }
}

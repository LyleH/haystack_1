using System.Collections.Generic;
using System.IO;
using System.Xml;
using Microsoft.Build.BuildEngine;
using Microsoft.Build.Construction;
using Microsoft.Build.Evaluation;
using Microsoft.Build.Execution;
using Microsoft.Build.Framework;

namespace CodeBlacks.BusinessRules
{
    public sealed class CodeCoverageRunner
    {
        public string PathToOpenCover { get; set; }

        public string PathToReportGenerator { get; set; }

        public string PathToTestRunner { get; set; }

        public string TestRunnerArguments { get; set; }

        public string PathToCodeCoverageXmlFile { get; set; }

        public string PathToCodeCoverageReportDirectory { get; set; }

        public string CodeCoverageFilter { get; set; }
 
        public void RunCodeCoverage()
        {
            IDictionary<string, string> properties = new Dictionary<string, string>()
            {
                { "PathToOpenCover", PathToOpenCover },
                { "PathToReportGenerator", PathToReportGenerator },
                { "PathToTestRunner", PathToTestRunner },
                { "TestRunnerArguments", TestRunnerArguments },
                { "PathToCodeCoverageXmlFile", PathToCodeCoverageXmlFile },
                { "PathToCodeCoverageReportDirectory", PathToCodeCoverageReportDirectory },
                { "CodeCoverageFilter", CodeCoverageFilter }
            };
            using (TextReader textReader = new StringReader(CodeCoverage.CodeCoverageScript))
            {
                using (XmlReader xmlReader = XmlReader.Create(textReader))
                {
                    ProjectRootElement rootElement = ProjectRootElement.Create(xmlReader);
                    ProjectCollection projectCollection = ProjectCollection.GlobalProjectCollection;
                    ProjectInstance project = new ProjectInstance(rootElement, properties, null, projectCollection);
                    BuildParameters buildParameters = new BuildParameters(projectCollection)
                    {
                        Loggers = new ILogger[] { new ConsoleLogger() }
                    };
                    BuildManager.DefaultBuildManager.Build(buildParameters, new BuildRequestData(project, new string[0]));
                }
            }
        }
    }
}

#HAYSTACK ● Finding the needle

##Synopsis
A web based Development Operations tool to inspect, bisect and to narrow down portion of code that has caused a particular integration test to fail by comparing the failed code coverage report with the successful report. We endevour to improve a developer's investigation and diagnostic time on broken tests by 50%.

##Motivation
Integration testing covers many layers/modules of the application in a single run. It is far more complex when compared to the simplistic unit test. Developers spends a large amount of time diagnosing why integration tests have broken. Sometimes this can be days. A large chuck is spent identifying portion of code where the code coverage of the failed run differs from the passing run. 

##Tools used
- .NET Framework 4.6
- Visual Studio 2015 RC
- Azure Web Apps
- Azure Web Jobs
- Azure Storage
- Azure Queues
- draw.io

##Installation
This is a cloud solution so installation should only need to be done once. Because of this, it is a reasonably manual process.

- Create an Azure storage account
- Create an Azure blob container called testzips
- Create an Azure queue called run-and-compare-tests
- Create an Azure blob container called testcomparisons
- Add the following line to the web.config file in the CodeBlacks.Web directory and the app.config file in the CodeBlacks.WebJob directory. It must contain the connection string of the created Azure storage account with the name "TestComparisonStorage". The file should look something like this:
```xml
<connectionStrings>
    <add name="TestComparisonStorage" value="[connection string to Azure storage account]"/>
</connectionStrings>
```
The connection string can be found in the properties of the storage account in Visual Studio.
- Open Visual Studio and rebuild it.
- Right-click CodeBlacks.Web and select Publish. Follow the wizard to publish it to a new or existing Azure web app.
- Right-click CodeBlacks.WebJob and select Publish to an Azure WebJob. Follow the wizard to publish it to a new or existing Azure WebJob

##Outside code
- OpenCover (Code coverage for .Net)
- Report Generator (Converts xml to output from code coverage to a readable format)
- Diffplex (Generates textual differences between files)
- MSBuild 14
- Bootstrap
- Bootstrap cyborg (Bootstrap theme)
- JQuery
- JSRender (HTML templates)
- Animate.css
- Moq (Mocking for unit testing)

##Contributors
- Alven Lee
- Jeremy Beavon
- Andrew Hawken
- Chris Flores
- Lyle Henkeman

##API Reference
POST api/testcomparison
Requires a zip file containing 2 directories of DLLs. One must be called "old" and the other one "new".
Returns a request id.

GET api/testcomparison/requestId
Returns JSON of the comparison results. 


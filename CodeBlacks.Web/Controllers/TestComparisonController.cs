using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;
using CodeBlacks.BusinessRules;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.Queue;
using Newtonsoft.Json;

namespace CodeBlacks.Web.Controllers
{
    public class TestComparisonController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public HttpResponseMessage Get(string id)
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(ConfigurationManager.ConnectionStrings["TestComparisonStorage"].ToString());
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
            CloudBlobContainer testComparisonContainer = blobClient.GetContainerReference("testcomparisons");
            CloudBlockBlob blob = testComparisonContainer.GetBlockBlobReference(id + ".json");
            string text = blob.DownloadText();
            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(text, Encoding.UTF8, "application/json");
            return response;
        }
        
        // POST api/values
        public string Post(string testToRun, HttpPostedFileBase zipFile)
        {
            string requestId = Guid.NewGuid().ToString("N");
            string blobName = requestId + ".zip";
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(ConfigurationManager.ConnectionStrings["TestComparisonStorage"].ToString());
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
            CloudBlobContainer testComparisonContainer = blobClient.GetContainerReference("testzips");
            CloudBlockBlob blob = testComparisonContainer.GetBlockBlobReference(blobName);
            blob.UploadFromStream(zipFile.InputStream);
            CloudQueueClient queueClient = storageAccount.CreateCloudQueueClient();
            CloudQueue queue = queueClient.GetQueueReference("run-and-compare-tests");
            TestComparisonRequest request = new TestComparisonRequest()
            {
                TestComparisonId = requestId,
                TestToRun = testToRun
            };
            queue.AddMessage(new CloudQueueMessage(JsonConvert.SerializeObject(request)));
            return requestId;
        }
    }
}

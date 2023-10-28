using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Diagnostics;


//https://functionapp120231012101939.azurewebsites.net/api/HttpTrigger_codespaces001
//https://functionapp120231012101939.azurewebsites.net/api/HttpTrigger_codespaces005?clientId=blobs_extension
namespace Company.Function
{
    public static class HttpTrigger_codespaces001
    {
        [FunctionName("HttpTrigger_codespaces005")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
Trace.WriteLine("---------------------------------------------------00000");            
            log.LogInformation("C# HTTP trigger function processed a request.");

            string name = req.Query["name"];

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            name = name ?? data?.name;


            string responseMessage = string.IsNullOrEmpty(name)

                ? $"{DateTime.Now.ToString("yyyyMMdd HHmmss.sss")}--【CodespaceでつくってデプロイしてみたHttpTrigger_codespaces--------------Connect_db6666】This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response."
                : $"Hello, {name}. This HTTP triggered function executed successfully.";
                
Trace.WriteLine("---------------------------------------------------00001");
            return new OkObjectResult(responseMessage);


        }
    }
}

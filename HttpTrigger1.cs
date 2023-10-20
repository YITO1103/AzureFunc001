using System.IO;
using System.Threading.Tasks;
using System.Diagnostics;
using Microsoft.Azure.WebJobs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;

// GetAllEmployees: [GET,POST] http://localhost:7071/api/GetAllEmployees のホストをポートタブの7071に置き換えて実行
// https://literate-giggle-wvxgggx6q6f9x7r-7071.app.github.dev/api/GetAllEmployees

//https://functionapp120231012101939.azurewebsites.net/api/GetAllEmployees?code=OebUmPMeRN8aSHyXWXN_eJyHCdSe2IrL1mreUG_Z96IAAzFu6gfVRA==&clientId=blobs_extension

//https://literate-giggle-wvxgggx6q6f9x7r-7071.app.github.dev/



namespace Company.Function
{
    public static class HttpTrigger1
    {
        [FunctionName("GetAllEmployees")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {

Trace.WriteLine("---------------------------------------------------00000");            
            log.LogInformation("C# GetAllEmployees 888888888888.");

            string name = req.Query["name"];

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            name = name ?? data?.name;

            string responseMessage = string.IsNullOrEmpty(name)

                ? $"{DateTime.Now.ToLocalTime().ToString("yyyyMMdd HHmmss.sss")}--【Connect_db９９】This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response."
                : $"Hello, {name}. This HTTP triggered function executed successfully.";
                
object? res="初期値"; 

try{
/*
var sDbConnectionString = Environment.GetEnvironmentVariable("DbConnectionString");
if(string.IsNullOrEmpty(sDbConnectionString)){
    throw new Exception("DbConnectionString is null");
}
*/

            var employeeService = new EmployeeService();
            res = employeeService.GetEmployees();
}
catch(Exception e){
            res = e;
}

            //var employeeService = new EmployeeService();
            //var employees = employeeService.GetEmployees();

Trace.WriteLine("---------------------------------------------------00001");
            //return new OkObjectResult(responseMessage);

            return new OkObjectResult(
                new {
                    status=0,
                    msg=responseMessage,
                    data=res
                }
            );

#if XXXXXX

         try{
            log.LogInformation("C# HTTP trigger function processed a request.");

            string name = req.Query["name"];

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            name = name ?? data?.name;

            string responseMessage = string.IsNullOrEmpty(name)
                ? "【GetAllEmployees333】This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response."
                : $"Hello, {name}. This HTTP triggered function executed successfully.";

            var employeeService = new EmployeeService();
            var employees = employeeService.GetEmployees();

            //return new OkObjectResult(responseMessage);
            //return new OkObjectResult(employees);
            return new OkObjectResult(
                new {
                    status=0,
                    msg="OKです。",
                    data=employees
                }
            );
         }
         catch(Exception e){
           return new OkObjectResult(
                new {
                    status=-1,
                    msg="NGです。",
                    Exception=e
                }

           );
         }
#endif
           
        }
    }
}

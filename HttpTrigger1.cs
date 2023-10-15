using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

// https://literate-giggle-wvxgggx6q6f9x7r-7071.app.github.dev/api/GetAllEmployees
namespace Company.Function
{
    public static class HttpTrigger1
    {
        [FunctionName("GetAllEmployees")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
         
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
    }
}

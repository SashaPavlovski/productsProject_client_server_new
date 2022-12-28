using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using ClientServerAuth0SQLDbProject.Model;


namespace ClientServerAuth0SQLDbProject.MiniServer
{
    public static class Function1
    {

        [FunctionName("Products")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            JsonConvert.DeserializeObject(requestBody);

            List<Product> productList = Entites.MainManager.INSTANCE.Init();
            string responseMessage = System.Text.Json.JsonSerializer.Serialize(productList);

            //string name = req.Query["name"];
         


           // dynamic data = JsonConvert.DeserializeObject(requestBody);
            //name = name ?? data?.name;

            return new OkObjectResult(responseMessage);
        }
    }

}

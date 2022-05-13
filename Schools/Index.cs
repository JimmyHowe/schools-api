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
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Table;

namespace SkillsDevelopmentScotland.Functions.Schools
{
    public static class Index
    {
        [FunctionName("Index")]
        public static async Task<IActionResult> RunAsync(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "schools")] HttpRequest request,
            ILogger log)
        {
            log.LogInformation("Index");

            SchoolRepository schoolRepository = new TableStorageSchoolRepository();

            return new OkObjectResult(await schoolRepository.GetAll());
        }
    }
}

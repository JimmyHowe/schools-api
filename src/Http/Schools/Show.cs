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
    public static class Show
    {
        [FunctionName("Show")]
        public static async Task<IActionResult> RunAsync(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "schools/{id}")] HttpRequest request,
            string id,
            ILogger log)
        {
            log.LogInformation($"Showing School [{id}]");

            SchoolRepository schoolRepository = RepositoryFactory.buildSchoolRepository();

            SchoolEntity schoolEntity = await schoolRepository.Get(id);

            log.LogInformation(schoolEntity.ToString());

            return new OkObjectResult(schoolEntity);
        }
    }
}

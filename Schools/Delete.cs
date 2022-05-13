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

namespace SkillsDevelopmentScotland.Functions.Schools
{
    public static class Delete
    {
        [FunctionName("Delete")]
        public static async Task<IActionResult> RunAsync(
            [HttpTrigger(AuthorizationLevel.Anonymous, "delete", Route = "schools/{id}")] HttpRequest request,
            string id,
            ILogger log)
        {
            log.LogInformation($"Delete {id}");

            bool worked = await RepositoryFactory.buildSchoolRepository().Delete(id);

            return new OkObjectResult(worked);
        }
    }
}

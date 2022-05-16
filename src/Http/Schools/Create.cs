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
    internal class Passed
    {
        public string level;
        public string name;
    }

    public static class Create
    {
        [FunctionName("Create")]
        public static async Task<IActionResult> RunAsync(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "schools/create")] HttpRequest request,
            ILogger log)
        {
            log.LogInformation("Creating School...");

            Passed passed = await FunHelpers.getPostDataAsync<Passed>(request);

            bool worked = await RepositoryFactory.buildSchoolRepository().Save(new SchoolEntity(passed.level, passed.name));

            return new OkObjectResult(worked);
        }
    }
}

using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace SkillsDevelopmentScotland.Functions.Schools
{
    public static class Update
    {
        [FunctionName("Update")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "put", Route = "schools/{id}")] HttpRequest request,
            string id,
            ILogger log)
        {
            log.LogInformation("UPDATE.");

            SchoolRepository schoolRepository = RepositoryFactory.buildSchoolRepository();

            // if(!schoolRepository.hasId())
            // {
            //     return new UnprocessableEntityResult(); /422
            // }

            dynamic content = await new StreamReader(request.Body).ReadToEndAsync();

            Passed passed = JsonConvert.DeserializeObject<Passed>(content);

            bool worked = await schoolRepository.Update(id, new SchoolEntity(passed.level, passed.name));

            return new OkObjectResult(worked);
        }
    }
}

using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace SkillsDevelopmentScotland.Functions.Schools
{
    public static class FunHelpers
    {
        public static async Task<T> getPostDataAsync<T>(HttpRequest request)
        {
            return JsonConvert.DeserializeObject<T>(
                await new StreamReader(request.Body).ReadToEndAsync()
            );
        }
    }
}
using CognizantCaseStudy.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;

namespace CognizantCaseStudy.DB.Services
{
    public class CodeChallengeSubmitterService : ICodeChallengeSubmitterService
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }

        public CodeChallengeSubmitterService(string clientId, string clientSecret)
        {
            ClientId = clientId;
            ClientSecret = clientSecret;
        }

        public async Task<string> Submit(string script, string args)
        {
            var language = "csharp";
            var versionIndex = "0";

            var input = new CodeSubmitModel(
                                            args,
                                            ClientId,
                                            ClientSecret,
                                            script,
                                            language,
                                            versionIndex
                                           );

            string result;

            using (var httpClient = new HttpClient() { BaseAddress = new Uri("https://api.jdoodle.com/v1/execute") })
            {
                var content = new StringContent(JsonConvert.SerializeObject(input), Encoding.UTF8, "application/json");
                var resultResponse = await httpClient.PostAsync("", content);
                result = JObject.Parse(await resultResponse.Content.ReadAsStringAsync())["output"].ToString();
            }

            return result;
        }
    }
}

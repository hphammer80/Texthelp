using IdentityModel.Client;
using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;

namespace TexthelpAPI.Services;

public class WordPredictionsWSService
{
    private const string token = "MjAyMi0wOS0wOA==.aHAuaGFtbWVyLjgwQGdtYWlsLmNvbQ==.MWI0YmRkZGI1OTIyNDQwMDNmNGJiYTliYWM1MzJiODA=";
    private const string serviceURL = "https://services.lingapps.dk/misc/getPredictions";

    internal static async Task<List<string>> GetWordPredictions(string locale, string text)
    {
        var result = new List<string>();

        using (HttpClient client = new HttpClient())
        {
            client.SetBearerToken(token);

            var query = new Dictionary<string, string?>()
            {
                ["locale"] = locale,
                ["text"] = text
            };

            var uri = QueryHelpers.AddQueryString(serviceURL, query);
            var response = await client.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<List<string>>(content);
            }
            else
            {
                throw new Exception($"Service call failed: {response.ReasonPhrase}");
            }
        }

        return result ?? new List<string>();
    }
}

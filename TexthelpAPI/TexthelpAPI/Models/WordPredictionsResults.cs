using Newtonsoft.Json;

namespace TexthelpAPI.Models;

public class WordPredictionsResults
{
    [JsonProperty("wsResults")]
    public List<string> WordPredictions { get; set; } = new List<string>();

    [JsonProperty("dbResults")]
    public List<string> DictionaryItems { get; set; } = new List<string>();
}

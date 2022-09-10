using Microsoft.AspNetCore.Mvc;
using TexthelpAPI.Models;
using TexthelpAPI.Repositories;
using TexthelpAPI.Services;

namespace TexthelpAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class TexthelpController : Controller
{
    [HttpGet()]
    public async Task<IActionResult> Get([FromQuery] string text, [FromQuery] string locale)
    {
        switch (locale)
        {
            case "da-DK":
            case "en-GB":
                break;
            default:
                return BadRequest($"Invalid locale: {locale}");
        }

        var result = new WordPredictionsResults();

        if (string.IsNullOrWhiteSpace(text))
        {
            return Accepted(result);
        }

        result.WordPredictions = await WordPredictionsWSService.GetWordPredictions(locale, text);

        var repository = new DictionaryDBRepository();
        result.DictionaryItems = repository.GetMatchingWords(text);

        return Ok(result);
    }
}

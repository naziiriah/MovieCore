using Microsoft.AspNetCore.Mvc;

namespace MovieCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public MovieController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet("{movieName}")]
        public async Task<IActionResult> GetMovie(string movieName)
        {
            try
            {
                var client = _httpClientFactory.CreateClient();

                client.BaseAddress = new Uri("https://www.omdbapi.com/");

                var apiKey = "33d9857e";
                var requestUri = $"?t={movieName}&plot=full&apikey={apiKey}";

                var response = await client.GetAsync(requestUri);
                response.EnsureSuccessStatusCode();

                var responseBody = await response.Content.ReadAsStringAsync();

                return Ok(responseBody);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error fetching movie details: {ex.Message}");
            }
        }
    }

}

using Azure;
using LearningHub.Core.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace LearningHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        [HttpGet("weather/{city}")]
        public async Task<Weather> weather(string city)
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync($"http://api.openweathermap.org/data/2.5/weather?q={city}&appid=c5eef62d932d1c1e7b583e0d0daf4a0c");
                var stringResult = await response.Content.ReadAsStringAsync();
                var weatherResult = JsonConvert.DeserializeObject<Weather>(stringResult);
                return weatherResult;
            }
        }
    }

}

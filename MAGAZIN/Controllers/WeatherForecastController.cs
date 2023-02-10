using Microsoft.AspNetCore.Mvc;

namespace MAGAZIN.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static List<string> Summaries = new()
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }
        [HttpGet("sort")]
        public IActionResult GetAll(int? sort)
        {
            if (!sort.HasValue)
            {
                return Ok(Summaries);
            }
            else if (sort.Value == 1)
            {
                Summaries.Sort();
                return Ok(Summaries);
            }
            else if (sort.Value == -1)
            {
                Summaries.Sort();
                Summaries.Reverse();
                return Ok(Summaries);
            }
            else return BadRequest("Некорректное значение параметра sortStrategy!");
        }
        [HttpGet]
        public List<string> Get()
        {
            return Summaries;
        }
        
        [HttpPost]
        public IActionResult Add(string name)
        {
            Summaries.Add(name);
            return Ok();
        }
        [HttpPut]
        public IActionResult Update(int index, string name)
        {
            if (index < 0 || index >= Summaries.Count)
            {
                return BadRequest("Такой индекс неверный!!!!");
            }


            Summaries[index] = name;
            return Ok();
        }
        [HttpDelete]
        public IActionResult Delete(int index)
        {
            Summaries.RemoveAt(index);
            return Ok();
        }
        [HttpGet("{index}")]
        public IActionResult GetIndex(int index)
        {
            if (index < 0 || index > Summaries.Count)
            {
                return BadRequest("Такого индекса не существует!");
            }
            string name = Summaries[index];
            return Ok(name);
        }
        [HttpGet("name")]
        public IActionResult GetByName(string name)
        {
            string[] r = new string[Summaries.Count];
            for(int i = 0; i < Summaries.Count; i++)
            {
                if (Summaries[i].ToLower().Contains(name.ToLower()))
                {
                    r[i] = Summaries[i];
                }
            }
            r = r.Where(x => x != null).ToArray();
            return Ok(r);
        }
    }
}
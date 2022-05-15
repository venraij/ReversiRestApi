using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ReversiRestApiMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using ReversiRestApiMVC.Hubs;

namespace ReversiRestApiMVC.Controllers
{
    [Route("api/spel")]
    [ApiController]
    public class SpelController : ControllerBase
    {
        private readonly ISpelRepository iRepository;
        public SpelController(ISpelRepository repository)
        {
            iRepository = repository;
        }

        // GET api/spel
        [HttpGet]
        public ActionResult<IEnumerable<Spel>> GetSpellen()
        {
            IEnumerable<Spel> spellen = iRepository.GetSpellen();

            return Content(JsonConvert.SerializeObject(spellen, Formatting.Indented));
        }
        
        // GET api/spel/token
        [HttpGet("{token}")]
        public ActionResult<Spel> GetSpelBySpelToken(string token)
        {
            Spel spel = iRepository.GetSpel(token);

            if (spel.Token == null)
            {
                spel = iRepository.GetSpelBySpeler(token);
            }
            
            return Ok(JsonConvert.SerializeObject(spel, Formatting.Indented));
        }

        // POST api/spel
        [HttpPost]
        public ActionResult<SpelJson> PostSpel([FromBody] SpelJson spelJson)
        {
            Spel spel = new Spel();
            spel.Omschrijving = spelJson.Omschrijving;
            spel.Speler1Token = spelJson.Speler1Token;
            spelJson.Bord = JsonConvert.SerializeObject(spel.Bord);
            
            spel.Token = Guid.NewGuid().ToString();
            spelJson.Token = spel.Token;

            iRepository.AddSpel(spel);

            return CreatedAtAction(nameof(PostSpel), JsonConvert.SerializeObject(spelJson));
        }

        // GET api/spel/beurt/token
        [HttpGet("beurt/{token}")]
        public ActionResult<Kleur> GetSpelerAanDeBeurt(string token)
        {
            Spel spel = iRepository.GetSpel(token);
            return Content(JsonConvert.SerializeObject(spel.AandeBeurt, Formatting.Indented));
        }

        // PUT api/spel/zet/pas
        [HttpPut("zet/pas")]
        public ActionResult<string> Pas([FromHeader] string spelerToken, [FromHeader] string spelToken)
        {
            iRepository.GetSpel(spelToken).Pas();

            return Content("Gepast");
        }

        // PUT api/spel/opgeven
        [HttpPut]
        public ActionResult<string> Opgeven([FromBody] string[] tokens)
        {
            return Content("Opgegeven");
        }
        
        // GET api/spel/afgelopen
        [HttpGet("afgelopen/{token}")]
        public ActionResult<SpelJson> GetSpelAlsAfgelopen(string token)
        {
            Spel spel = iRepository.GetSpel(token);
            
            if (spel.Token == null)
            {
                spel = iRepository.GetSpelBySpeler(token);
            }
            
            if (spel.Afgelopen())
            {
                return Ok(JsonConvert.SerializeObject(spel, Formatting.Indented));
            }

            return Ok("Niet afgelopen");
        }
    }
}

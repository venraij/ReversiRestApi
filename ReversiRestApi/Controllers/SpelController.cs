using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ReversiRestApi.Models;
using System;
using System.Collections.Generic;

namespace ReversiRestApi.Controllers
{
    [Route("api/[controller]")]
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

            if (spel.Token == null && token != "" && token != null)
            {
                spel = iRepository.GetSpelBySpeler(token);
            }
            else
            {
                return BadRequest();
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
        
        // PATCH api/spel/meespelen
        [HttpPatch("meespelen")]
        public ActionResult<SpelJson> JoinSpel([FromBody] SpelJson spelJson)
        {
            if (spelJson.Token == null)
            {
                return BadRequest("Geef een token mee aan het spel.");
            }
            
            Spel spel = iRepository.GetSpel(spelJson.Token);

            if (spel.Speler2Token == "")
            {
                spel.Speler2Token = spelJson.Speler2Token;
                iRepository.SaveSpel(spel);
                return Ok(JsonConvert.SerializeObject(spel));
            } 
            
            if (spel.Speler2Token != "")
            {
                return BadRequest("Er is al een speler 2.");
            }
            
            if (spel.Speler1Token == spelJson.Speler2Token)
            {
                return BadRequest("Je kan niet speler 2 zijn voor je eigen spel.");
            }

            return BadRequest("Er is een onbekende fout opgetreden.");
        }
        
        // DELETE api/spel/speler
        [HttpDelete("Speler")]
        public ActionResult<SpelJson> DeleteSpel([FromQuery] string spelerToken)
        {
            if (spelerToken == null)
            {
                return BadRequest("Geef een spelertoken mee.");
            }
            
            Spel spel = iRepository.GetSpelBySpeler(spelerToken);

            if (spel == null)
            {
                return Ok("Speler is niet in actieve spellen.");
            }
            
            iRepository.RemoveSpel(spel.Token);
            return Ok();
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
        public ActionResult GetSpelAlsAfgelopen(string token)
        {
            Spel spel = iRepository.GetSpel(token);
            
            if (spel.Token == null)
            {
                spel = iRepository.GetSpelBySpeler(token);
            }
            
            if (spel.Afgelopen())
            {
                var spelString = JsonConvert.SerializeObject(spel, Formatting.Indented);
                iRepository.RemoveSpel(spel.Token);
                return Ok(spelString);
            }

            return Ok(JsonConvert.SerializeObject("Niet afgelopen", Formatting.Indented));
        }
    }
}

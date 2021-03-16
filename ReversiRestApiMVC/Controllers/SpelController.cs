using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReversiRestApiMVC.Controllers
{
    [Route("api/Spel")]
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
        public ActionResult<IEnumerable<string>> GetSpelOmschrijvingenVanSpellenMetWachtendeSpeler()
        {
            return Content(iRepository.GetSpellen().Find(spel => spel.Speler2Token == null).Omschrijving);
        }
        
        // GET api/spel
        [HttpGet("{token}")]
        public ActionResult<Spel> GetSpelBySpelToken(string token)
        {
            Spel spel = iRepository.GetSpel(token);

            if (spel == null)
            {
                spel = iRepository.GetSpellen().Find(spel => spel.Speler1Token == token);

                if (spel == null)
                {
                    spel = iRepository.GetSpellen().Find(spel => spel.Speler2Token == token);
                }
            }

            return Content(JsonConvert.SerializeObject(spel, Formatting.Indented).ToString());
        }

        // POST api/spel
        [HttpPost]
        public ActionResult<string> PostSpel(string spelerToken, string omschrijving)
        {
            Spel spel = new Spel();
            spel.Speler1Token = spelerToken;
            spel.Omschrijving = omschrijving;
            spel.Token = Guid.NewGuid().ToString();

            iRepository.AddSpel(spel);

            return Content(spel.Token);
        }

        // GET api/spel/beurt
        [HttpGet("beurt/{spelToken}")]
        public ActionResult<Kleur> GetSpelerAanDeBeurt(string spelToken)
        {
            return Content(JsonConvert.SerializeObject(iRepository.GetSpel(spelToken).AandeBeurt, Formatting.Indented));
        }

        // PUT api/spel/zet
        [HttpPut("zet/{veld}")]
        public ActionResult<string> Zet([FromHeader] string spelerToken, [FromHeader] string spelToken, int[] veld)
        {
            Spel spel = iRepository.GetSpel(spelToken);
            string statusZet;

            if(spel.ZetMogelijk(veld[0], veld[1]) == true)
            {
                spel.DoeZet(veld[0], veld[1]);
                statusZet = "Succeeded";
            } else
            {
                statusZet = "Failed";
            }

            return Content(statusZet);
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
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReversiRestApi.Controllers
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

        // Get api/spel/beurt
        [HttpGet("Beurt/{spelToken}")]
        public ActionResult<Kleur> GetSpelerAanDeBeurt(string spelToken)
        {
            return Content(JsonConvert.SerializeObject(iRepository.GetSpel(spelToken).AandeBeurt, Formatting.Indented));
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
        // ...

        // POST api/spel
        [HttpPost]
        public ActionResult<Guid> NieuwSpelToevoegen(string spelerToken, string omschrijving)
        {
            Spel spel = new Spel();
            spel.Speler1Token = spelerToken;
            spel.Omschrijving = omschrijving;
            spel.Token = Guid.NewGuid().ToString();

            iRepository.AddSpel(spel);

            return Content(spel.Token);
        }
    }
}

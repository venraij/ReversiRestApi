using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NUnit.Framework;
using ReversiRestApiMVC;
using ReversiRestApiMVC.Controllers;

namespace NUnitTestProjectReversiSpel
{
    [TestFixture]
    class SpelControllerTest
    {
        private SpelController spelController;
        private ISpelRepository iRepository;

        [SetUp]
        public void Setup()
        {
            iRepository = new SpelRepository();
            spelController = new SpelController(iRepository);
        }

        [Test]
        public void NieuwSpelToevoegen_NieuwSpel_ReturnAddedSpelToken()
        {
            spelController.PostSpel("testing", "test omschrijving");
            Assert.AreEqual("test omschrijving", iRepository.GetSpellen()[iRepository.GetSpellen().Count - 1].Omschrijving);
            Assert.AreEqual("testing", iRepository.GetSpellen()[iRepository.GetSpellen().Count - 1].Speler1Token);
        }

        [Test]
        public void GetSpelByToken_SpelerToken_ReturnSpel()
        {
            spelController.PostSpel("testing", "test omschrijving").ToString();
            var result = (ContentResult)spelController.GetSpelBySpelToken("testing").Result;

            Assert.AreEqual("test omschrijving", JsonConvert.DeserializeObject<Spel>(result.Content).Omschrijving);
        }

        [Test]
        public void GetSpelByToken_SpelToken_ReturnSpel()
        {
            var nieuwSpel = (ContentResult)spelController.PostSpel("testing", "test omschrijving").Result;
            string spelToken = nieuwSpel.Content;

            var result = (ContentResult)spelController.GetSpelBySpelToken(spelToken).Result;

            Assert.AreEqual("test omschrijving", JsonConvert.DeserializeObject<Spel>(result.Content).Omschrijving);
        }

        [Test]
        public void GetSpelerAanDeBeurt_NieuwSpel_ReturnGeen()
        {
            var nieuwSpel = (ContentResult)spelController.PostSpel("testing", "test omschrijving").Result;
            string spelToken = nieuwSpel.Content;

            var result = (ContentResult)spelController.GetSpelerAanDeBeurt(spelToken).Result;
            Assert.AreEqual(Kleur.Geen, JsonConvert.DeserializeObject<Kleur>(result.Content));
        }

    }
}

using NUnit.Framework;
using ReversiRestApi;
using ReversiRestApi.Controllers;

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
            spelController.NieuwSpelToevoegen("testing", "test omschrijving").ToString();
            Assert.AreEqual("test omschrijving", iRepository.GetSpellen()[iRepository.GetSpellen().Count - 1].Omschrijving);
            Assert.AreEqual("testing", iRepository.GetSpellen()[iRepository.GetSpellen().Count - 1].Speler1Token);
        }
    }
}

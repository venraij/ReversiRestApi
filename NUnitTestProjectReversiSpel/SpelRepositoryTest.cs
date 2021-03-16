using NUnit.Framework;
using ReversiRestApiMVC;

namespace NUnitTestProjectReversiSpel
{
    [TestFixture]
    public class SpelRepositoryTest
    {
        private ISpelRepository iRepository;

        [SetUp]
        public void Setup()
        {
            iRepository = new SpelRepository();
        }

        [Test]
        public void AddSpell_ThreeSpellen_ReturnAddedSpel()
        {
            Spel spel = new Spel();
            iRepository.AddSpel(spel);
            Assert.AreEqual(spel, iRepository.GetSpellen()[iRepository.GetSpellen().Count - 1]);
        }

        [Test]
        public void GetSpel_TokenUnitTest_ReturnSpelWithToken()
        {
            Spel spel = new Spel();
            spel.Token = "UnitTest";
            iRepository.AddSpel(spel);

            Assert.AreEqual(spel, iRepository.GetSpel("UnitTest"));
        }

        [Test]
        public void GetSpel_TokenDoesntExist_ReturnNull()
        {
            Assert.IsNull(iRepository.GetSpel("IDontExist"));
        }

        [Test]
        public void GetSpellen_ThreeSpellen_ReturnsThreeSpellen()
        {
            Assert.AreEqual(3, iRepository.GetSpellen().Count);

            foreach(Spel spel in iRepository.GetSpellen())
            {
                Assert.IsInstanceOf<Spel>(spel);
            }   
        }
    }
}

using NUnit.Framework;
using ReversiRestApi;

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
            Assert.That(spel, Is.EqualTo(iRepository.GetSpellen()[iRepository.GetSpellen().Count - 1]));
        }

        [Test]
        public void GetSpel_TokenUnitTest_ReturnSpelWithToken()
        {
            Spel spel = new Spel();
            spel.Token = "UnitTest";
            iRepository.AddSpel(spel);

            Assert.That(spel, Is.EqualTo(iRepository.GetSpel("UnitTest")));
        }

        [Test]
        public void GetSpel_TokenDoesntExist_ReturnNull()
        {
            Assert.That(iRepository.GetSpel("IDontExist"), Is.Null);
        }

        [Test]
        public void GetSpellen_ThreeSpellen_ReturnsThreeSpellen()
        {
            Assert.That(3, Is.EqualTo(iRepository.GetSpellen().Count));

            foreach(Spel spel in iRepository.GetSpellen())
            {
                Assert.That(spel, Is.InstanceOf<Spel>());
            }   
        }
    }
}

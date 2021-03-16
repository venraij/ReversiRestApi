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
        public void AddSpell_ReturnNieuwSpel()
        {
            int oldLength = iRepository.GetSpellen().Count;
            iRepository.AddSpel(new Spel());
            Assert.AreNotEqual(oldLength, iRepository.GetSpellen().Count);
        }
    }
}

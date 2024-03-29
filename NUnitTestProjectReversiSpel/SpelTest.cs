using NUnit.Framework;
using ReversiRestApi;

namespace NUnitTestProjectReversiSpel
{
    [TestFixture]
    public class SpelTest
    {
        // geen kleur = 0
        // Wit = 1
        // Zwart = 2

        [Test]
        public void ZetMogelijk_BuitenBord_ReturnFalse()
        {
            // Arrange
            Spel spel = new Spel();
            //     0 1 2 3 4 5 6 7
            //                     v
            // 0   0 0 0 0 0 0 0 0  
            // 1   0 0 0 0 0 0 0 0
            // 2   0 0 0 0 0 0 0 0
            // 3   0 0 0 1 2 0 0 0
            // 4   0 0 0 2 1 0 0 0
            // 5   0 0 0 0 0 0 0 0
            // 6   0 0 0 0 0 0 0 0
            // 7   0 0 0 0 0 0 0 0
            //                     1 <
            // Act
            spel.AandeBeurt = Kleur.Wit;
            var actual = spel.ZetMogelijk(8, 8);
            // Assert
            Assert.That(actual, Is.False);
        }

        [Test]
        public void ZetMogelijk_StartSituatieZet23Zwart_ReturnTrue()
        {
            // Arrange
            Spel spel = new Spel();
            //     0 1 2 3 4 5 6 7
            //           v
            // 0   0 0 0 0 0 0 0 0  
            // 1   0 0 0 0 0 0 0 0
            // 2   0 0 0 2 0 0 0 0  <
            // 3   0 0 0 1 2 0 0 0
            // 4   0 0 0 2 1 0 0 0
            // 5   0 0 0 0 0 0 0 0
            // 6   0 0 0 0 0 0 0 0
            // 7   0 0 0 0 0 0 0 0

            // Act
            spel.AandeBeurt = Kleur.Zwart;
            var actual = spel.ZetMogelijk(2, 3);
            // Assert
            Assert.That(actual, Is.True);
        }

        [Test]
        public void ZetMogelijk_StartSituatieZet23Wit_ReturnFalse()
        {
            // Arrange
            Spel spel = new Spel();
            //     0 1 2 3 4 5 6 7
            //           v
            // 0   0 0 0 0 0 0 0 0  
            // 1   0 0 0 0 0 0 0 0
            // 2   0 0 0 1 0 0 0 0 <
            // 3   0 0 0 1 2 0 0 0
            // 4   0 0 0 2 1 0 0 0
            // 5   0 0 0 0 0 0 0 0
            // 6   0 0 0 0 0 0 0 0
            // 7   0 0 0 0 0 0 0 0

            // Act
            spel.AandeBeurt = Kleur.Wit;
            var actual = spel.ZetMogelijk(2, 3);
            // Assert
            Assert.That(actual, Is.False);
        }


        [Test]
        public void ZetMogelijk_ZetAanDeRandBoven_ReturnTrue()
        {
            // Arrange
            Spel spel = new Spel();
            spel.Bord[1, 3] = Kleur.Wit;
            spel.Bord[2, 3] = Kleur.Wit;
            //     0 1 2 3 4 5 6 7
            //           v
            // 0   0 0 0 2 0 0 0 0  <
            // 1   0 0 0 1 0 0 0 0
            // 2   0 0 0 1 0 0 0 0
            // 3   0 0 0 1 2 0 0 0
            // 4   0 0 0 2 1 0 0 0
            // 5   0 0 0 0 0 0 0 0
            // 6   0 0 0 0 0 0 0 0
            // 7   0 0 0 0 0 0 0 0
            // Act
            spel.AandeBeurt = Kleur.Zwart;
            var actual = spel.ZetMogelijk(0, 3);
            // Assert
            Assert.That(actual, Is.True);
        }

        [Test]
        public void ZetMogelijk_ZetAanDeRandBoven_ReturnFalse()
        {
            // Arrange
            Spel spel = new Spel();
            spel.Bord[1, 3] = Kleur.Wit;
            spel.Bord[2, 3] = Kleur.Wit;
            //     0 1 2 3 4 5 6 7
            //           v
            // 0   0 0 0 1 0 0 0 0  <
            // 1   0 0 0 1 0 0 0 0
            // 2   0 0 0 1 0 0 0 0
            // 3   0 0 0 1 2 0 0 0
            // 4   0 0 0 2 1 0 0 0
            // 5   0 0 0 0 0 0 0 0
            // 6   0 0 0 0 0 0 0 0
            // 7   0 0 0 0 0 0 0 0

            // Act
            spel.AandeBeurt = Kleur.Wit;
            var actual = spel.ZetMogelijk(0, 3);
            // Assert
            Assert.That(actual, Is.False);
        }

        [Test]
        public void ZetMogelijk_ZetAanDeRandBovenEnTotBenedenReedsGevuld_ReturnTrue()
        {
            // Arrange
            Spel spel = new Spel();
            spel.Bord[1, 3] = Kleur.Wit;
            spel.Bord[2, 3] = Kleur.Wit;
            spel.Bord[3, 3] = Kleur.Wit;
            spel.Bord[4, 3] = Kleur.Wit;
            spel.Bord[5, 3] = Kleur.Wit;
            spel.Bord[6, 3] = Kleur.Wit;
            spel.Bord[7, 3] = Kleur.Zwart;
            //     0 1 2 3 4 5 6 7
            //           v
            // 0   0 0 0 2 0 0 0 0  <
            // 1   0 0 0 1 0 0 0 0
            // 2   0 0 0 1 0 0 0 0
            // 3   0 0 0 1 2 0 0 0
            // 4   0 0 0 1 1 0 0 0
            // 5   0 0 0 1 0 0 0 0
            // 6   0 0 0 1 0 0 0 0
            // 7   0 0 0 2 0 0 0 0

            // Act
            spel.AandeBeurt = Kleur.Zwart;
            var actual = spel.ZetMogelijk(0, 3);
            // Assert
            Assert.That(actual, Is.True);
        }

        [Test]
        public void ZetMogelijk_ZetAanDeRandBovenEnTotBenedenReedsGevuld_ReturnFalse()
        {
            // Arrange
            Spel spel = new Spel();
            spel.Bord[1, 3] = Kleur.Wit;
            spel.Bord[2, 3] = Kleur.Wit;
            spel.Bord[3, 3] = Kleur.Wit;
            spel.Bord[4, 3] = Kleur.Wit;
            spel.Bord[5, 3] = Kleur.Wit;
            spel.Bord[6, 3] = Kleur.Wit;
            spel.Bord[7, 3] = Kleur.Wit;
            //     0 1 2 3 4 5 6 7
            //           v
            // 0   0 0 0 2 0 0 0 0  <
            // 1   0 0 0 1 0 0 0 0
            // 2   0 0 0 1 0 0 0 0
            // 3   0 0 0 1 2 0 0 0
            // 4   0 0 0 1 1 0 0 0
            // 5   0 0 0 1 0 0 0 0
            // 6   0 0 0 1 0 0 0 0
            // 7   0 0 0 1 0 0 0 0

            // Act
            spel.AandeBeurt = Kleur.Zwart;
            var actual = spel.ZetMogelijk(0, 3);
            // Assert
            Assert.That(actual, Is.False);
        }

        [Test]
        public void ZetMogelijk_ZetAanDeRandRechts_ReturnTrue()
        {
            // Arrange
            Spel spel = new Spel();
            spel.Bord[4, 5] = Kleur.Wit;
            spel.Bord[4, 6] = Kleur.Wit;
            //     0 1 2 3 4 5 6 7
            //                   v
            // 0   0 0 0 2 0 0 0 0  
            // 1   0 0 0 1 0 0 0 0
            // 2   0 0 0 1 0 0 0 0
            // 3   0 0 0 1 2 0 0 0
            // 4   0 0 0 2 1 1 1 2 <
            // 5   0 0 0 0 0 0 0 0
            // 6   0 0 0 0 0 0 0 0
            // 7   0 0 0 0 0 0 0 0
            // Act
            spel.AandeBeurt = Kleur.Zwart;
            var actual = spel.ZetMogelijk(4, 7);
            // Assert
            Assert.That(actual, Is.True);
        }

        [Test]
        public void ZetMogelijk_ZetAanDeRandRechts_ReturnFalse()
        {
            // Arrange
            Spel spel = new Spel();
            spel.Bord[4, 5] = Kleur.Wit;
            spel.Bord[4, 6] = Kleur.Wit;
            //     0 1 2 3 4 5 6 7
            //                   v
            // 0   0 0 0 1 0 0 0 0  
            // 1   0 0 0 1 0 0 0 0
            // 2   0 0 0 1 0 0 0 0
            // 3   0 0 0 1 2 0 0 0
            // 4   0 0 0 2 1 1 1 1 <
            // 5   0 0 0 0 0 0 0 0
            // 6   0 0 0 0 0 0 0 0
            // 7   0 0 0 0 0 0 0 0

            // Act
            spel.AandeBeurt = Kleur.Wit;
            var actual = spel.ZetMogelijk(4, 7);
            // Assert
            Assert.That(actual, Is.False);
        }

        [Test]
        public void ZetMogelijk_ZetAanDeRandRechtsEnTotLinksReedsGevuld_ReturnTrue()
        {
            // Arrange
            Spel spel = new Spel();
            spel.Bord[4, 0] = Kleur.Zwart;
            spel.Bord[4, 1] = Kleur.Wit;
            spel.Bord[4, 2] = Kleur.Wit;
            spel.Bord[4, 3] = Kleur.Wit;
            spel.Bord[4, 4] = Kleur.Wit;
            spel.Bord[4, 5] = Kleur.Wit;
            spel.Bord[4, 6] = Kleur.Wit;
            //     0 1 2 3 4 5 6 7
            //                   v
            // 0   0 0 0 0 0 0 0 0  
            // 1   0 0 0 0 0 0 0 0
            // 2   0 0 0 0 0 0 0 0
            // 3   0 0 0 1 2 0 0 0 
            // 4   2 1 1 1 1 1 1 2 <
            // 5   0 0 0 0 0 0 0 0
            // 6   0 0 0 0 0 0 0 0
            // 7   0 0 0 0 0 0 0 0

            // Act
            spel.AandeBeurt = Kleur.Zwart;
            var actual = spel.ZetMogelijk(4, 7);
            // Assert
            Assert.That(actual, Is.True);
        }

        [Test]
        public void ZetMogelijk_ZetAanDeRandRechtsEnTotLinksReedsGevuld_ReturnFalse()
        {
            // Arrange
            Spel spel = new Spel();
            spel.Bord[4, 0] = Kleur.Zwart;
            spel.Bord[4, 1] = Kleur.Wit;
            spel.Bord[4, 2] = Kleur.Wit;
            spel.Bord[4, 3] = Kleur.Wit;
            spel.Bord[4, 4] = Kleur.Wit;
            spel.Bord[4, 5] = Kleur.Wit;
            spel.Bord[4, 6] = Kleur.Wit;
            //     0 1 2 3 4 5 6 7
            //                   v
            // 0   0 0 0 0 0 0 0 0  

            // 1   0 0 0 0 0 0 0 0
            // 2   0 0 0 0 0 0 0 0
            // 3   0 0 0 1 2 0 0 0
            // 4   2 1 1 1 1 1 1 1 <
            // 5   0 0 0 0 0 0 0 0
            // 6   0 0 0 0 0 0 0 0
            // 7   0 0 0 0 0 0 0 0

            // Act
            spel.AandeBeurt = Kleur.Wit;
            var actual = spel.ZetMogelijk(4, 7);
            // Assert
            Assert.That(actual, Is.False);
        }

        //     0 1 2 3 4 5 6 7
        //                     
        // 0   0 0 0 0 0 0 0 0  
        // 1   0 0 0 0 0 0 0 0
        // 2   0 0 0 0 0 0 0 0
        // 3   0 0 0 1 2 0 0 0
        // 4   0 0 0 2 1 0 0 0
        // 5   0 0 0 0 0 0 0 0
        // 6   0 0 0 0 0 0 0 0
        // 7   0 0 0 0 0 0 0 0
        [Test]
        public void ZetMogelijk_StartSituatieZet22Wit_ReturnFalse()
        {
            // Arrange
            Spel spel = new Spel();
            //     0 1 2 3 4 5 6 7
            //         v
            // 0   0 0 0 0 0 0 0 0  
            // 1   0 0 0 0 0 0 0 0
            // 2   0 0 1 0 0 0 0 0 <
            // 3   0 0 0 1 2 0 0 0
            // 4   0 0 0 2 1 0 0 0
            // 5   0 0 0 0 0 0 0 0
            // 6   0 0 0 0 0 0 0 0
            // 7   0 0 0 0 0 0 0 0

            // Act
            spel.AandeBeurt = Kleur.Wit;
            var actual = spel.ZetMogelijk(2, 2);
            // Assert
            Assert.That(actual, Is.False);
        }
        
        [Test]
        public void ZetMogelijk_StartSituatieZet22Zwart_ReturnFalse()
        {
            // Arrange
            Spel spel = new Spel();
            //     0 1 2 3 4 5 6 7
            //         v
            // 0   0 0 0 0 0 0 0 0  
            // 1   0 0 0 0 0 0 0 0
            // 2   0 0 2 0 0 0 0 0 <
            // 3   0 0 0 1 2 0 0 0
            // 4   0 0 0 2 1 0 0 0
            // 5   0 0 0 0 0 0 0 0
            // 6   0 0 0 0 0 0 0 0
            // 7   0 0 0 0 0 0 0 0

            // Act
            spel.AandeBeurt = Kleur.Zwart;
            var actual = spel.ZetMogelijk(2, 2);
            // Assert
            Assert.That(actual, Is.False);
        }

        [Test]
        public void ZetMogelijk_ZetAanDeRandRechtsBoven_ReturnTrue()
        {
            // Arrange
            Spel spel = new Spel();
            spel.Bord[2, 5] = Kleur.Zwart;
            spel.Bord[1, 6] = Kleur.Zwart;
            spel.Bord[5, 2] = Kleur.Wit;
            //     0 1 2 3 4 5 6 7
            //                   v
            // 0   0 0 0 0 0 0 0 1  <
            // 1   0 0 0 0 0 0 2 0
            // 2   0 0 0 0 0 2 0 0
            // 3   0 0 0 1 2 0 0 0
            // 4   0 0 0 2 1 0 0 0
            // 5   0 0 1 0 0 0 0 0
            // 6   0 0 0 0 0 0 0 0
            // 7   0 0 0 0 0 0 0 0
            // Act
            spel.AandeBeurt = Kleur.Wit;
            var actual = spel.ZetMogelijk(0, 7);
            // Assert
            Assert.That(actual, Is.True);
        }

        [Test]
        public void ZetMogelijk_ZetAanDeRandRechtsBoven_ReturnFalse()
        {
            // Arrange
            Spel spel = new Spel();
            spel.Bord[2, 5] = Kleur.Zwart;
            spel.Bord[1, 6] = Kleur.Zwart;
            spel.Bord[5, 2] = Kleur.Wit;
            //     0 1 2 3 4 5 6 7
            //                   v
            // 0   0 0 0 0 0 0 0 2  <
            // 1   0 0 0 0 0 0 2 0
            // 2   0 0 0 0 0 2 0 0
            // 3   0 0 0 1 2 0 0 0
            // 4   0 0 0 2 1 0 0 0
            // 5   0 0 1 0 0 0 0 0
            // 6   0 0 0 0 0 0 0 0
            // 7   0 0 0 0 0 0 0 0
            // Act
            spel.AandeBeurt = Kleur.Zwart;
            var actual = spel.ZetMogelijk(0, 7);
            // Assert
            Assert.That(actual, Is.False);
        }

        [Test]
        public void ZetMogelijk_ZetAanDeRandRechtsOnder_ReturnTrue()
        {
            // Arrange
            Spel spel = new Spel();
            spel.Bord[2, 2] = Kleur.Zwart;
            spel.Bord[5, 5] = Kleur.Wit;
            spel.Bord[6, 6] = Kleur.Wit;
            //     0 1 2 3 4 5 6 7
            //                   v
            // 0   0 0 0 0 0 0 0 0  
            // 1   0 0 0 0 0 0 0 0
            // 2   0 0 2 0 0 0 0 0
            // 3   0 0 0 1 2 0 0 0
            // 4   0 0 0 2 1 0 0 0
            // 5   0 0 0 0 0 1 0 0
            // 6   0 0 0 0 0 0 1 0
            // 7   0 0 0 0 0 0 0 2 <
            // Act
            spel.AandeBeurt = Kleur.Zwart;
            var actual = spel.ZetMogelijk(7, 7);
            // Assert
            Assert.That(actual, Is.True);
        }

        [Test]
        public void ZetMogelijk_ZetAanDeRandRechtsOnder_ReturnFalse()
        {
            // Arrange
            Spel spel = new Spel();
            spel.Bord[2, 2] = Kleur.Zwart;
            spel.Bord[5, 5] = Kleur.Wit;
            spel.Bord[6, 6] = Kleur.Wit;
            //     0 1 2 3 4 5 6 7
            //                   v
            // 0   0 0 0 0 0 0 0 0  <
            // 1   0 0 0 0 0 0 0 0
            // 2   0 0 2 0 0 0 0 0
            // 3   0 0 0 1 2 0 0 0
            // 4   0 0 0 2 1 0 0 0
            // 5   0 0 0 0 0 1 0 0
            // 6   0 0 0 0 0 0 1 0
            // 7   0 0 0 0 0 0 0 1
            // Act
            spel.AandeBeurt = Kleur.Wit;
            var actual = spel.ZetMogelijk(7, 7);
            // Assert
            Assert.That(actual, Is.False);
        }

        [Test]
        public void ZetMogelijk_ZetAanDeRandLinksBoven_ReturnTrue()
        {
            // Arrange
            Spel spel = new Spel();
            spel.Bord[1, 1] = Kleur.Wit;
            spel.Bord[2, 2] = Kleur.Wit;
            spel.Bord[5, 5] = Kleur.Zwart;
            //     0 1 2 3 4 5 6 7
            //     v
            // 0   2 0 0 0 0 0 0 0  <
            // 1   0 1 0 0 0 0 0 0
            // 2   0 0 1 0 0 0 0 0
            // 3   0 0 0 1 2 0 0 0
            // 4   0 0 0 2 1 0 0 0
            // 5   0 0 0 0 0 2 0 0
            // 6   0 0 0 0 0 0 0 0
            // 7   0 0 0 0 0 0 0 0 
            // Act
            spel.AandeBeurt = Kleur.Zwart;
            var actual = spel.ZetMogelijk(0, 0);
            // Assert
            Assert.That(actual, Is.True);
        }

        [Test]
        public void ZetMogelijk_ZetAanDeRandLinksBoven_ReturnFalse()
        {
            // Arrange
            Spel spel = new Spel();
            spel.Bord[1, 1] = Kleur.Wit;
            spel.Bord[2, 2] = Kleur.Wit;
            spel.Bord[5, 5] = Kleur.Zwart;
            //     0 1 2 3 4 5 6 7
            //     v
            // 0   1 0 0 0 0 0 0 0  <
            // 1   0 1 0 0 0 0 0 0
            // 2   0 0 1 0 0 0 0 0
            // 3   0 0 0 1 2 0 0 0
            // 4   0 0 0 2 1 0 0 0
            // 5   0 0 0 0 0 2 0 0
            // 6   0 0 0 0 0 0 0 0
            // 7   0 0 0 0 0 0 0 0          
            // Act
            spel.AandeBeurt = Kleur.Wit;
            var actual = spel.ZetMogelijk(0, 0);
            // Assert
            Assert.That(actual, Is.False);
        }

        [Test]
        public void ZetMogelijk_ZetAanDeRandLinksOnder_ReturnTrue()
        {
            // Arrange
            Spel spel = new Spel();
            spel.Bord[2, 5] = Kleur.Wit;
            spel.Bord[5, 2] = Kleur.Zwart;
            spel.Bord[6, 1] = Kleur.Zwart;
            //     0 1 2 3 4 5 6 7
            //     v
            // 0   0 0 0 0 0 0 0 0  
            // 1   0 0 0 0 0 0 0 0
            // 2   0 0 0 0 0 1 0 0
            // 3   0 0 0 1 2 0 0 0
            // 4   0 0 0 2 1 0 0 0
            // 5   0 0 2 0 0 0 0 0
            // 6   0 2 0 0 0 0 0 0
            // 7   1 0 0 0 0 0 0 0 <
            // Act
            spel.AandeBeurt = Kleur.Wit;
            var actual = spel.ZetMogelijk(7, 0);
            // Assert
            Assert.That(actual, Is.True);
        }

        [Test]
        public void ZetMogelijk_ZetAanDeRandLinksOnder_ReturnFalse()
        {
            // Arrange
            Spel spel = new Spel();
            spel.Bord[2, 5] = Kleur.Wit;
            spel.Bord[5, 2] = Kleur.Zwart;
            spel.Bord[6, 1] = Kleur.Zwart;
            //     0 1 2 3 4 5 6 7
            //                   v
            // 0   0 0 0 0 0 0 0 0  <
            // 1   0 0 0 0 0 0 0 0
            // 2   0 0 0 0 0 1 0 0
            // 3   0 0 0 1 2 0 0 0
            // 4   0 0 0 2 1 0 0 0
            // 5   0 0 2 0 0 0 0 0
            // 6   0 2 0 0 0 0 0 0
            // 7   2 0 0 0 0 0 0 0
            // Act
            spel.AandeBeurt = Kleur.Zwart;
            var actual = spel.ZetMogelijk(7, 0);
            // Assert
            Assert.That(actual, Is.False);
        }

        //---------------------------------------------------------------------------
        [Test]
        public void DoeZet_BuitenBord_ReturnFalse()
        {
            // Arrange
            Spel spel = new Spel();
            //     0 1 2 3 4 5 6 7
            //                     v
            // 0   0 0 0 0 0 0 0 0  
            // 1   0 0 0 0 0 0 0 0
            // 2   0 0 0 0 0 0 0 0
            // 3   0 0 0 1 2 0 0 0
            // 4   0 0 0 2 1 0 0 0
            // 5   0 0 0 0 0 0 0 0
            // 6   0 0 0 0 0 0 0 0
            // 7   0 0 0 0 0 0 0 0
            //                     1 <
            // Act
            spel.AandeBeurt = Kleur.Wit;
            var actual = spel.DoeZet(8, 8);
            // Assert
            Assert.That(actual, Is.False);
            Assert.That(Kleur.Wit, Is.EqualTo(spel.Bord[3, 3]));
            Assert.That(Kleur.Wit, Is.EqualTo(spel.Bord[4, 4]));
            Assert.That(Kleur.Zwart, Is.EqualTo(spel.Bord[3, 4]));
            Assert.That(Kleur.Zwart, Is.EqualTo(spel.Bord[4, 3]));

            Assert.That(Kleur.Wit, Is.EqualTo(spel.AandeBeurt));
        }

        [Test]
        public void DoeZet_StartSituatieZet23Zwart_ReturnTrue()
        {
            // Arrange
            Spel spel = new Spel();
            //     0 1 2 3 4 5 6 7
            //           v
            // 0   0 0 0 0 0 0 0 0  
            // 1   0 0 0 0 0 0 0 0
            // 2   0 0 0 2 0 0 0 0  <
            // 3   0 0 0 1 2 0 0 0
            // 4   0 0 0 2 1 0 0 0
            // 5   0 0 0 0 0 0 0 0
            // 6   0 0 0 0 0 0 0 0
            // 7   0 0 0 0 0 0 0 0

            // Act
            spel.AandeBeurt = Kleur.Zwart;
            var actual = spel.DoeZet(2, 3);
            // Assert
            Assert.That(actual, Is.True);
            Assert.That(Kleur.Zwart, Is.EqualTo(spel.Bord[2, 3]));
            Assert.That(Kleur.Zwart, Is.EqualTo(spel.Bord[3, 3]));
            Assert.That(Kleur.Zwart, Is.EqualTo(spel.Bord[4, 3]));

            Assert.That(Kleur.Wit, Is.EqualTo(spel.AandeBeurt));
        }

        [Test]
        public void DoeZet_StartSituatieZet23Wit_ReturnFalse()
        {
            // Arrange
            Spel spel = new Spel();
            //     0 1 2 3 4 5 6 7
            //           v
            // 0   0 0 0 0 0 0 0 0  
            // 1   0 0 0 0 0 0 0 0
            // 2   0 0 0 1 0 0 0 0 <
            // 3   0 0 0 1 2 0 0 0
            // 4   0 0 0 2 1 0 0 0
            // 5   0 0 0 0 0 0 0 0
            // 6   0 0 0 0 0 0 0 0
            // 7   0 0 0 0 0 0 0 0

            // Act
            spel.AandeBeurt = Kleur.Wit;
            var actual = spel.DoeZet(2, 3);
            // Assert
            Assert.That(actual, Is.False);
            Assert.That(Kleur.Wit, Is.EqualTo(spel.Bord[3, 3]));
            Assert.That(Kleur.Wit, Is.EqualTo(spel.Bord[4, 4]));
            Assert.That(Kleur.Zwart, Is.EqualTo(spel.Bord[3, 4]));
            Assert.That(Kleur.Zwart, Is.EqualTo(spel.Bord[4, 3]));

            Assert.That(Kleur.Geen, Is.EqualTo(spel.Bord[2, 3]));

            Assert.That(Kleur.Wit, Is.EqualTo(spel.AandeBeurt));
        }


        [Test]
        public void DoeZet_ZetAanDeRandBoven_ReturnTrue()
        {
            // Arrange
            Spel spel = new Spel();
            spel.Bord[1, 3] = Kleur.Wit;
            spel.Bord[2, 3] = Kleur.Wit;
            //     0 1 2 3 4 5 6 7
            //           v
            // 0   0 0 0 2 0 0 0 0  <
            // 1   0 0 0 1 0 0 0 0
            // 2   0 0 0 1 0 0 0 0
            // 3   0 0 0 1 2 0 0 0
            // 4   0 0 0 2 1 0 0 0
            // 5   0 0 0 0 0 0 0 0
            // 6   0 0 0 0 0 0 0 0
            // 7   0 0 0 0 0 0 0 0
            // Act
            spel.AandeBeurt = Kleur.Zwart;
            var actual = spel.DoeZet(0, 3);
            // Assert
            Assert.That(actual, Is.True);
            Assert.That(Kleur.Zwart, Is.EqualTo(spel.Bord[0, 3]));
            Assert.That(Kleur.Zwart, Is.EqualTo(spel.Bord[1, 3]));
            Assert.That(Kleur.Zwart, Is.EqualTo(spel.Bord[2, 3]));
            Assert.That(Kleur.Zwart, Is.EqualTo(spel.Bord[3, 3]));
            Assert.That(Kleur.Zwart, Is.EqualTo(spel.Bord[4, 3]));

            Assert.That(Kleur.Wit, Is.EqualTo(spel.AandeBeurt));
        }

        [Test]
        public void DoeZet_ZetAanDeRandBoven_ReturnFalse()
        {
            // Arrange
            Spel spel = new Spel();
            spel.Bord[1, 3] = Kleur.Wit;
            spel.Bord[2, 3] = Kleur.Wit;
            //     0 1 2 3 4 5 6 7
            //           v
            // 0   0 0 0 1 0 0 0 0  <
            // 1   0 0 0 1 0 0 0 0
            // 2   0 0 0 1 0 0 0 0
            // 3   0 0 0 1 2 0 0 0
            // 4   0 0 0 2 1 0 0 0
            // 5   0 0 0 0 0 0 0 0
            // 6   0 0 0 0 0 0 0 0
            // 7   0 0 0 0 0 0 0 0

            // Act
            spel.AandeBeurt = Kleur.Wit;
            var actual = spel.DoeZet(0, 3);
            // Assert
            Assert.That(actual, Is.False);
            Assert.That(Kleur.Wit, Is.EqualTo(spel.Bord[3, 3]));
            Assert.That(Kleur.Wit, Is.EqualTo(spel.Bord[4, 4]));
            Assert.That(Kleur.Zwart, Is.EqualTo(spel.Bord[3, 4]));
            Assert.That(Kleur.Zwart, Is.EqualTo(spel.Bord[4, 3]));

            Assert.That(Kleur.Wit, Is.EqualTo(spel.Bord[1, 3]));
            Assert.That(Kleur.Wit, Is.EqualTo(spel.Bord[2, 3]));

            Assert.That(Kleur.Geen, Is.EqualTo(spel.Bord[0, 3]));

        }

        [Test]
        public void DoeZet_ZetAanDeRandBovenEnTotBenedenReedsGevuld_ReturnTrue()
        {
            // Arrange
            Spel spel = new Spel();
            spel.Bord[1, 3] = Kleur.Wit;
            spel.Bord[2, 3] = Kleur.Wit;
            spel.Bord[3, 3] = Kleur.Wit;
            spel.Bord[4, 3] = Kleur.Wit;
            spel.Bord[5, 3] = Kleur.Wit;
            spel.Bord[6, 3] = Kleur.Wit;
            spel.Bord[7, 3] = Kleur.Zwart;
            //     0 1 2 3 4 5 6 7
            //           v
            // 0   0 0 0 2 0 0 0 0  <
            // 1   0 0 0 1 0 0 0 0
            // 2   0 0 0 1 0 0 0 0
            // 3   0 0 0 1 2 0 0 0
            // 4   0 0 0 1 1 0 0 0
            // 5   0 0 0 1 0 0 0 0
            // 6   0 0 0 1 0 0 0 0
            // 7   0 0 0 2 0 0 0 0

            // Act
            spel.AandeBeurt = Kleur.Zwart;
            var actual = spel.DoeZet(0, 3);
            // Assert
            Assert.That(actual, Is.True);
            Assert.That(Kleur.Zwart, Is.EqualTo(spel.Bord[0, 3]));
            Assert.That(Kleur.Zwart, Is.EqualTo(spel.Bord[1, 3]));
            Assert.That(Kleur.Zwart, Is.EqualTo(spel.Bord[2, 3]));
            Assert.That(Kleur.Zwart, Is.EqualTo(spel.Bord[3, 3]));
            Assert.That(Kleur.Zwart, Is.EqualTo(spel.Bord[4, 3]));
            Assert.That(Kleur.Zwart, Is.EqualTo(spel.Bord[5, 3]));
            Assert.That(Kleur.Zwart, Is.EqualTo(spel.Bord[6, 3]));
            Assert.That(Kleur.Zwart, Is.EqualTo(spel.Bord[7, 3]));

        }

        [Test]
        public void DoeZet_ZetAanDeRandBovenEnTotBenedenReedsGevuld_ReturnFalse()
        {
            // Arrange
            Spel spel = new Spel();
            spel.Bord[1, 3] = Kleur.Wit;
            spel.Bord[2, 3] = Kleur.Wit;
            spel.Bord[3, 3] = Kleur.Wit;
            spel.Bord[4, 3] = Kleur.Wit;
            spel.Bord[5, 3] = Kleur.Wit;
            spel.Bord[6, 3] = Kleur.Wit;
            spel.Bord[7, 3] = Kleur.Wit;
            //     0 1 2 3 4 5 6 7
            //           v
            // 0   0 0 0 2 0 0 0 0  <
            // 1   0 0 0 1 0 0 0 0
            // 2   0 0 0 1 0 0 0 0
            // 3   0 0 0 1 2 0 0 0
            // 4   0 0 0 1 1 0 0 0
            // 5   0 0 0 1 0 0 0 0
            // 6   0 0 0 1 0 0 0 0
            // 7   0 0 0 1 0 0 0 0

            // Act
            spel.AandeBeurt = Kleur.Zwart;
            var actual = spel.DoeZet(0, 3);
            // Assert
            Assert.That(actual, Is.False);
            Assert.That(Kleur.Wit, Is.EqualTo(spel.Bord[3, 3]));
            Assert.That(Kleur.Wit, Is.EqualTo(spel.Bord[4, 4]));
            Assert.That(Kleur.Zwart, Is.EqualTo(spel.Bord[3, 4]));
            Assert.That(Kleur.Wit, Is.EqualTo(spel.Bord[4, 3]));

            Assert.That(Kleur.Wit, Is.EqualTo(spel.Bord[1, 3]));
            Assert.That(Kleur.Wit, Is.EqualTo(spel.Bord[2, 3]));
            Assert.That(Kleur.Geen, Is.EqualTo(spel.Bord[0, 3]));
        }

        [Test]
        public void DoeZet_ZetAanDeRandRechts_ReturnTrue()
        {
            // Arrange
            Spel spel = new Spel();
            spel.Bord[4, 5] = Kleur.Wit;
            spel.Bord[4, 6] = Kleur.Wit;
            //     0 1 2 3 4 5 6 7
            //                   v
            // 0   0 0 0 0 0 0 0 0  
            // 1   0 0 0 0 0 0 0 0
            // 2   0 0 0 0 0 0 0 0
            // 3   0 0 0 1 2 0 0 0
            // 4   0 0 0 2 1 1 1 2 <
            // 5   0 0 0 0 0 0 0 0
            // 6   0 0 0 0 0 0 0 0
            // 7   0 0 0 0 0 0 0 0
            // Act
            spel.AandeBeurt = Kleur.Zwart;
            var actual = spel.DoeZet(4, 7);
            // Assert
            Assert.That(actual, Is.True);

            Assert.That(Kleur.Zwart, Is.EqualTo(spel.Bord[4, 3]));
            Assert.That(Kleur.Zwart, Is.EqualTo(spel.Bord[4, 4]));
            Assert.That(Kleur.Zwart, Is.EqualTo(spel.Bord[4, 5]));
            Assert.That(Kleur.Zwart, Is.EqualTo(spel.Bord[4, 6]));
            Assert.That(Kleur.Zwart, Is.EqualTo(spel.Bord[4, 7]));
        }

        [Test]
        public void DoeZet_ZetAanDeRandRechts_ReturnFalse()
        {
            // Arrange
            Spel spel = new Spel();
            spel.Bord[4, 5] = Kleur.Wit;
            spel.Bord[4, 6] = Kleur.Wit;
            //     0 1 2 3 4 5 6 7
            //                   v
            // 0   0 0 0 1 0 0 0 0  
            // 1   0 0 0 1 0 0 0 0
            // 2   0 0 0 1 0 0 0 0
            // 3   0 0 0 1 2 0 0 0
            // 4   0 0 0 2 1 1 1 1 <
            // 5   0 0 0 0 0 0 0 0
            // 6   0 0 0 0 0 0 0 0
            // 7   0 0 0 0 0 0 0 0

            // Act
            spel.AandeBeurt = Kleur.Wit;
            var actual = spel.DoeZet(4, 7);
            // Assert
            Assert.That(actual, Is.False);
            Assert.That(Kleur.Wit, Is.EqualTo(spel.Bord[3, 3]));
            Assert.That(Kleur.Wit, Is.EqualTo(spel.Bord[4, 4]));
            Assert.That(Kleur.Zwart, Is.EqualTo(spel.Bord[3, 4]));
            Assert.That(Kleur.Zwart, Is.EqualTo(spel.Bord[4, 3]));

            Assert.That(Kleur.Wit, Is.EqualTo(spel.Bord[4, 5]));
            Assert.That(Kleur.Wit, Is.EqualTo(spel.Bord[4, 6]));
            Assert.That(Kleur.Geen, Is.EqualTo(spel.Bord[4, 7]));
        }

        [Test]
        public void DoeZet_ZetAanDeRandRechtsEnTotLinksReedsGevuld_ReturnTrue()
        {
            // Arrange
            Spel spel = new Spel();
            spel.Bord[4, 0] = Kleur.Zwart;
            spel.Bord[4, 1] = Kleur.Wit;
            spel.Bord[4, 2] = Kleur.Wit;
            spel.Bord[4, 3] = Kleur.Wit;
            spel.Bord[4, 4] = Kleur.Wit;
            spel.Bord[4, 5] = Kleur.Wit;
            spel.Bord[4, 6] = Kleur.Wit;
            //     0 1 2 3 4 5 6 7
            //                   v
            // 0   0 0 0 0 0 0 0 0  
            // 1   0 0 0 0 0 0 0 0
            // 2   0 0 0 0 0 0 0 0
            // 3   0 0 0 1 2 0 0 0 
            // 4   2 1 1 1 1 1 1 2 <
            // 5   0 0 0 0 0 0 0 0
            // 6   0 0 0 0 0 0 0 0
            // 7   0 0 0 0 0 0 0 0

            // Act
            spel.AandeBeurt = Kleur.Zwart;
            var actual = spel.DoeZet(4, 7);
            // Assert
            Assert.That(actual, Is.True);
            Assert.That(Kleur.Zwart, Is.EqualTo(spel.Bord[4, 0]));
            Assert.That(Kleur.Zwart, Is.EqualTo(spel.Bord[4, 1]));
            Assert.That(Kleur.Zwart, Is.EqualTo(spel.Bord[4, 2]));
            Assert.That(Kleur.Zwart, Is.EqualTo(spel.Bord[4, 3]));
            Assert.That(Kleur.Zwart, Is.EqualTo(spel.Bord[4, 4]));
            Assert.That(Kleur.Zwart, Is.EqualTo(spel.Bord[4, 5]));
            Assert.That(Kleur.Zwart, Is.EqualTo(spel.Bord[4, 6]));
            Assert.That(Kleur.Zwart, Is.EqualTo(spel.Bord[4, 7]));
        }

        [Test]
        public void DoeZet_ZetAanDeRandRechtsEnTotLinksReedsGevuld_ReturnFalse()
        {
            // Arrange
            Spel spel = new Spel();
            spel.Bord[4, 0] = Kleur.Zwart;
            spel.Bord[4, 1] = Kleur.Wit;
            spel.Bord[4, 2] = Kleur.Wit;
            spel.Bord[4, 3] = Kleur.Wit;
            spel.Bord[4, 4] = Kleur.Wit;
            spel.Bord[4, 5] = Kleur.Wit;
            spel.Bord[4, 6] = Kleur.Wit;
            //     0 1 2 3 4 5 6 7
            //                   v
            // 0   0 0 0 0 0 0 0 0  

            // 1   0 0 0 0 0 0 0 0
            // 2   0 0 0 0 0 0 0 0
            // 3   0 0 0 1 2 0 0 0
            // 4   2 1 1 1 1 1 1 1 <
            // 5   0 0 0 0 0 0 0 0
            // 6   0 0 0 0 0 0 0 0
            // 7   0 0 0 0 0 0 0 0

            // Act
            spel.AandeBeurt = Kleur.Wit;
            var actual = spel.DoeZet(4, 7);
            // Assert
            Assert.That(actual, Is.False);
            Assert.That(Kleur.Wit, Is.EqualTo(spel.Bord[3, 3]));
            Assert.That(Kleur.Wit, Is.EqualTo(spel.Bord[4, 4]));
            Assert.That(Kleur.Zwart, Is.EqualTo(spel.Bord[3, 4]));
            Assert.That(Kleur.Wit, Is.EqualTo(spel.Bord[4, 3]));

            Assert.That(Kleur.Zwart, Is.EqualTo(spel.Bord[4, 0]));
            Assert.That(Kleur.Wit, Is.EqualTo(spel.Bord[4, 1]));
            Assert.That(Kleur.Wit, Is.EqualTo(spel.Bord[4, 2]));

            Assert.That(Kleur.Wit, Is.EqualTo(spel.Bord[4, 5]));
            Assert.That(Kleur.Wit, Is.EqualTo(spel.Bord[4, 6]));
            Assert.That(Kleur.Geen, Is.EqualTo(spel.Bord[4, 7]));
        }


        //     0 1 2 3 4 5 6 7
        //                     
        // 0   0 0 0 0 0 0 0 0  
        // 1   0 0 0 0 0 0 0 0
        // 2   0 0 0 0 0 0 0 0
        // 3   0 0 0 1 2 0 0 0
        // 4   0 0 0 2 1 0 0 0
        // 5   0 0 0 0 0 0 0 0
        // 6   0 0 0 0 0 0 0 0
        // 7   0 0 0 0 0 0 0 0



        [Test]
        public void DoeZet_StartSituatieZet22Wit_ReturnFalse()
        {
            // Arrange
            Spel spel = new Spel();
            //     0 1 2 3 4 5 6 7
            //         v
            // 0   0 0 0 0 0 0 0 0  
            // 1   0 0 0 0 0 0 0 0
            // 2   0 0 1 0 0 0 0 0 <
            // 3   0 0 0 1 2 0 0 0
            // 4   0 0 0 2 1 0 0 0
            // 5   0 0 0 0 0 0 0 0
            // 6   0 0 0 0 0 0 0 0
            // 7   0 0 0 0 0 0 0 0

            // Act
            spel.AandeBeurt = Kleur.Wit;
            var actual = spel.DoeZet(2, 2);
            // Assert
            Assert.That(actual, Is.False);
            Assert.That(Kleur.Wit, Is.EqualTo(spel.Bord[3, 3]));
            Assert.That(Kleur.Wit, Is.EqualTo(spel.Bord[4, 4]));
            Assert.That(Kleur.Zwart, Is.EqualTo(spel.Bord[3, 4]));
            Assert.That(Kleur.Zwart, Is.EqualTo(spel.Bord[4, 3]));

            Assert.That(Kleur.Geen, Is.EqualTo(spel.Bord[2, 2]));
        }

        [Test]
        public void DoeZet_StartSituatieZet22Zwart_ReturnFalse()
        {
            // Arrange
            Spel spel = new Spel();
            //     0 1 2 3 4 5 6 7
            //         v
            // 0   0 0 0 0 0 0 0 0  
            // 1   0 0 0 0 0 0 0 0
            // 2   0 0 2 0 0 0 0 0 <
            // 3   0 0 0 1 2 0 0 0
            // 4   0 0 0 2 1 0 0 0
            // 5   0 0 0 0 0 0 0 0
            // 6   0 0 0 0 0 0 0 0
            // 7   0 0 0 0 0 0 0 0

            // Act
            spel.AandeBeurt = Kleur.Zwart;
            var actual = spel.DoeZet(2, 2);
            // Assert
            Assert.That(actual, Is.False);
            Assert.That(Kleur.Wit, Is.EqualTo(spel.Bord[3, 3]));
            Assert.That(Kleur.Wit, Is.EqualTo(spel.Bord[4, 4]));
            Assert.That(Kleur.Zwart, Is.EqualTo(spel.Bord[3, 4]));
            Assert.That(Kleur.Zwart, Is.EqualTo(spel.Bord[4, 3]));

            Assert.That(Kleur.Geen, Is.EqualTo(spel.Bord[2, 2]));
        }


        [Test]
        public void DoeZet_ZetAanDeRandRechtsBoven_ReturnTrue()
        {
            // Arrange
            Spel spel = new Spel();
            spel.Bord[2, 5] = Kleur.Zwart;
            spel.Bord[1, 6] = Kleur.Zwart;
            spel.Bord[5, 2] = Kleur.Wit;
            //     0 1 2 3 4 5 6 7
            //                   v
            // 0   0 0 0 0 0 0 0 1  <
            // 1   0 0 0 0 0 0 2 0
            // 2   0 0 0 0 0 2 0 0
            // 3   0 0 0 1 2 0 0 0
            // 4   0 0 0 2 1 0 0 0
            // 5   0 0 1 0 0 0 0 0
            // 6   0 0 0 0 0 0 0 0
            // 7   0 0 0 0 0 0 0 0
            // Act
            spel.AandeBeurt = Kleur.Wit;
            var actual = spel.DoeZet(0, 7);
            // Assert
            Assert.That(actual, Is.True);
            Assert.That(Kleur.Wit, Is.EqualTo(spel.Bord[5, 2]));
            Assert.That(Kleur.Wit, Is.EqualTo(spel.Bord[4, 3]));
            Assert.That(Kleur.Wit, Is.EqualTo(spel.Bord[3, 4]));
            Assert.That(Kleur.Wit, Is.EqualTo(spel.Bord[2, 5]));
            Assert.That(Kleur.Wit, Is.EqualTo(spel.Bord[1, 6]));
            Assert.That(Kleur.Wit, Is.EqualTo(spel.Bord[0, 7]));
        }

        [Test]
        public void DoeZet_ZetAanDeRandRechtsBoven_ReturnFalse()
        {
            // Arrange
            Spel spel = new Spel();
            spel.Bord[2, 5] = Kleur.Zwart;
            spel.Bord[1, 6] = Kleur.Zwart;
            spel.Bord[5, 2] = Kleur.Wit;
            //     0 1 2 3 4 5 6 7
            //                   v
            // 0   0 0 0 0 0 0 0 2  <
            // 1   0 0 0 0 0 0 2 0
            // 2   0 0 0 0 0 2 0 0
            // 3   0 0 0 1 2 0 0 0
            // 4   0 0 0 2 1 0 0 0
            // 5   0 0 1 0 0 0 0 0
            // 6   0 0 0 0 0 0 0 0
            // 7   0 0 0 0 0 0 0 0
            // Act
            spel.AandeBeurt = Kleur.Zwart;
            var actual = spel.DoeZet(0, 7);
            // Assert
            Assert.That(actual, Is.False);
            Assert.That(Kleur.Wit, Is.EqualTo(spel.Bord[3, 3]));
            Assert.That(Kleur.Wit, Is.EqualTo(spel.Bord[4, 4]));
            Assert.That(Kleur.Zwart, Is.EqualTo(spel.Bord[3, 4]));
            Assert.That(Kleur.Zwart, Is.EqualTo(spel.Bord[4, 3]));

            Assert.That(Kleur.Zwart, Is.EqualTo(spel.Bord[1, 6]));
            Assert.That(Kleur.Zwart, Is.EqualTo(spel.Bord[2, 5]));

            Assert.That(Kleur.Wit, Is.EqualTo(spel.Bord[5, 2]));

            Assert.That(Kleur.Geen, Is.EqualTo(spel.Bord[0, 7]));
        }

        [Test]
        public void DoeZet_ZetAanDeRandRechtsOnder_ReturnTrue()
        {
            // Arrange
            Spel spel = new Spel();
            spel.Bord[2, 2] = Kleur.Zwart;
            spel.Bord[5, 5] = Kleur.Wit;
            spel.Bord[6, 6] = Kleur.Wit;
            //     0 1 2 3 4 5 6 7
            //                   v
            // 0   0 0 0 0 0 0 0 0  
            // 1   0 0 0 0 0 0 0 0
            // 2   0 0 2 0 0 0 0 0
            // 3   0 0 0 1 2 0 0 0
            // 4   0 0 0 2 1 0 0 0
            // 5   0 0 0 0 0 1 0 0
            // 6   0 0 0 0 0 0 1 0
            // 7   0 0 0 0 0 0 0 2 <
            // Act
            spel.AandeBeurt = Kleur.Zwart;
            var actual = spel.DoeZet(7, 7);
            // Assert
            Assert.That(actual, Is.True);

            Assert.That(Kleur.Zwart, Is.EqualTo(spel.Bord[2, 2]));
            Assert.That(Kleur.Zwart, Is.EqualTo(spel.Bord[3, 3]));
            Assert.That(Kleur.Zwart, Is.EqualTo(spel.Bord[4, 4]));
            Assert.That(Kleur.Zwart, Is.EqualTo(spel.Bord[5, 5]));
            Assert.That(Kleur.Zwart, Is.EqualTo(spel.Bord[6, 6]));
            Assert.That(Kleur.Zwart, Is.EqualTo(spel.Bord[7, 7]));
        }

        [Test]
        public void DoeZet_ZetAanDeRandRechtsOnder_ReturnFalse()
        {
            // Arrange
            Spel spel = new Spel();
            spel.Bord[2, 2] = Kleur.Zwart;
            spel.Bord[5, 5] = Kleur.Wit;
            spel.Bord[6, 6] = Kleur.Wit;
            //     0 1 2 3 4 5 6 7
            //                   v
            // 0   0 0 0 0 0 0 0 0  
            // 1   0 0 0 0 0 0 0 0
            // 2   0 0 2 0 0 0 0 0
            // 3   0 0 0 1 2 0 0 0
            // 4   0 0 0 2 1 0 0 0
            // 5   0 0 0 0 0 1 0 0
            // 6   0 0 0 0 0 0 1 0
            // 7   0 0 0 0 0 0 0 1 <
            // Act
            spel.AandeBeurt = Kleur.Wit;
            var actual = spel.DoeZet(7, 7);
            // Assert
            Assert.That(actual, Is.False);
            Assert.That(Kleur.Wit, Is.EqualTo(spel.Bord[3, 3]));
            Assert.That(Kleur.Wit, Is.EqualTo(spel.Bord[4, 4]));
            Assert.That(Kleur.Zwart, Is.EqualTo(spel.Bord[3, 4]));
            Assert.That(Kleur.Zwart, Is.EqualTo(spel.Bord[4, 3]));

            Assert.That(Kleur.Zwart, Is.EqualTo(spel.Bord[2, 2]));
            Assert.That(Kleur.Wit, Is.EqualTo(spel.Bord[5, 5]));
            Assert.That(Kleur.Wit, Is.EqualTo(spel.Bord[6, 6]));

            Assert.That(Kleur.Geen, Is.EqualTo(spel.Bord[7, 7]));
        }

        [Test]
        public void DoeZet_ZetAanDeRandLinksBoven_ReturnTrue()
        {
            // Arrange
            Spel spel = new Spel();
            spel.Bord[1, 1] = Kleur.Wit;
            spel.Bord[2, 2] = Kleur.Wit;
            spel.Bord[5, 5] = Kleur.Zwart;
            //     0 1 2 3 4 5 6 7
            //     v
            // 0   2 0 0 0 0 0 0 0  <
            // 1   0 1 0 0 0 0 0 0
            // 2   0 0 1 0 0 0 0 0
            // 3   0 0 0 1 2 0 0 0
            // 4   0 0 0 2 1 0 0 0
            // 5   0 0 0 0 0 2 0 0
            // 6   0 0 0 0 0 0 0 0
            // 7   0 0 0 0 0 0 0 0 
            // Act
            spel.AandeBeurt = Kleur.Zwart;
            var actual = spel.DoeZet(0, 0);
            // Assert
            Assert.That(actual, Is.True);
            Assert.That(Kleur.Zwart, Is.EqualTo(spel.Bord[0, 0]));
            Assert.That(Kleur.Zwart, Is.EqualTo(spel.Bord[1, 1]));
            Assert.That(Kleur.Zwart, Is.EqualTo(spel.Bord[2, 2]));
            Assert.That(Kleur.Zwart, Is.EqualTo(spel.Bord[3, 3]));
            Assert.That(Kleur.Zwart, Is.EqualTo(spel.Bord[4, 4]));
            Assert.That(Kleur.Zwart, Is.EqualTo(spel.Bord[5, 5]));
        }

        [Test]
        public void DoeZet_ZetAanDeRandLinksBoven_ReturnFalse()
        {
            // Arrange
            Spel spel = new Spel();
            spel.Bord[1, 1] = Kleur.Wit;
            spel.Bord[2, 2] = Kleur.Wit;
            spel.Bord[5, 5] = Kleur.Zwart;
            //     0 1 2 3 4 5 6 7
            //     v
            // 0   1 0 0 0 0 0 0 0  <
            // 1   0 1 0 0 0 0 0 0
            // 2   0 0 1 0 0 0 0 0
            // 3   0 0 0 1 2 0 0 0
            // 4   0 0 0 2 1 0 0 0
            // 5   0 0 0 0 0 2 0 0
            // 6   0 0 0 0 0 0 0 0
            // 7   0 0 0 0 0 0 0 0          
            // Act
            spel.AandeBeurt = Kleur.Wit;
            var actual = spel.DoeZet(0, 0);
            // Assert
            Assert.That(actual, Is.False);
            Assert.That(Kleur.Wit, Is.EqualTo(spel.Bord[3, 3]));
            Assert.That(Kleur.Wit, Is.EqualTo(spel.Bord[4, 4]));
            Assert.That(Kleur.Zwart, Is.EqualTo(spel.Bord[3, 4]));
            Assert.That(Kleur.Zwart, Is.EqualTo(spel.Bord[4, 3]));

            Assert.That(Kleur.Wit, Is.EqualTo(spel.Bord[1, 1]));
            Assert.That(Kleur.Wit, Is.EqualTo(spel.Bord[2, 2]));

            Assert.That(Kleur.Zwart, Is.EqualTo(spel.Bord[5, 5]));

            Assert.That(Kleur.Geen, Is.EqualTo(spel.Bord[0, 0]));
        }

        [Test]
        public void DoeZet_ZetAanDeRandLinksOnder_ReturnTrue()
        {
            // Arrange
            Spel spel = new Spel();
            spel.Bord[2, 5] = Kleur.Wit;
            spel.Bord[5, 2] = Kleur.Zwart;
            spel.Bord[6, 1] = Kleur.Zwart;
            //     0 1 2 3 4 5 6 7
            //     v
            // 0   0 0 0 0 0 0 0 0  
            // 1   0 0 0 0 0 0 0 0
            // 2   0 0 0 0 0 1 0 0
            // 3   0 0 0 1 2 0 0 0
            // 4   0 0 0 2 1 0 0 0
            // 5   0 0 2 0 0 0 0 0
            // 6   0 2 0 0 0 0 0 0
            // 7   1 0 0 0 0 0 0 0 <
            // Act
            spel.AandeBeurt = Kleur.Wit;
            var actual = spel.DoeZet(7, 0);
            // Assert
            Assert.That(actual, Is.True);
            Assert.That(Kleur.Wit, Is.EqualTo(spel.Bord[7, 0]));
            Assert.That(Kleur.Wit, Is.EqualTo(spel.Bord[6, 1]));
            Assert.That(Kleur.Wit, Is.EqualTo(spel.Bord[5, 2]));
            Assert.That(Kleur.Wit, Is.EqualTo(spel.Bord[4, 3]));
            Assert.That(Kleur.Wit, Is.EqualTo(spel.Bord[3, 4]));
            Assert.That(Kleur.Wit, Is.EqualTo(spel.Bord[2, 5]));
        }

        [Test]
        public void DoeZet_ZetAanDeRandLinksOnder_ReturnFalse()
        {
            // Arrange
            Spel spel = new Spel();
            spel.Bord[2, 5] = Kleur.Wit;
            spel.Bord[5, 2] = Kleur.Zwart;
            spel.Bord[6, 1] = Kleur.Zwart;
            //     0 1 2 3 4 5 6 7
            //     v
            // 0   0 0 0 0 0 0 0 0  
            // 1   0 0 0 0 0 0 0 0
            // 2   0 0 0 0 0 1 0 0
            // 3   0 0 0 1 2 0 0 0
            // 4   0 0 0 2 1 0 0 0
            // 5   0 0 2 0 0 0 0 0
            // 6   0 2 0 0 0 0 0 0
            // 7   2 0 0 0 0 0 0 0 <
            // Act
            spel.AandeBeurt = Kleur.Zwart;
            var actual = spel.DoeZet(7, 0);
            // Assert
            Assert.That(actual, Is.False);
            Assert.That(Kleur.Wit, Is.EqualTo(spel.Bord[3, 3]));
            Assert.That(Kleur.Wit, Is.EqualTo(spel.Bord[4, 4]));
            Assert.That(Kleur.Zwart, Is.EqualTo(spel.Bord[3, 4]));
            Assert.That(Kleur.Zwart, Is.EqualTo(spel.Bord[4, 3]));

            Assert.That(Kleur.Wit, Is.EqualTo(spel.Bord[2, 5]));
            Assert.That(Kleur.Zwart, Is.EqualTo(spel.Bord[5, 2]));
            Assert.That(Kleur.Zwart, Is.EqualTo(spel.Bord[6, 1]));

            Assert.That(Kleur.Geen, Is.EqualTo(spel.Bord[7, 7]));

            Assert.That(Kleur.Geen, Is.EqualTo(spel.Bord[7, 0]));
        }

        [Test]
        public void Pas_ZwartAanZetGeenZetMogelijk_ReturnTrueEnWisselBeurt()
        {
            // Arrange  (zowel wit als zwart kunnen niet meer)
            Spel spel = new Spel();
            spel.Bord[0, 0] = Kleur.Wit;
            spel.Bord[0, 1] = Kleur.Wit;
            spel.Bord[0, 2] = Kleur.Wit;
            spel.Bord[0, 3] = Kleur.Wit;
            spel.Bord[0, 4] = Kleur.Wit;
            spel.Bord[0, 5] = Kleur.Wit;
            spel.Bord[0, 6] = Kleur.Wit;
            spel.Bord[0, 7] = Kleur.Wit;
            spel.Bord[1, 0] = Kleur.Wit;
            spel.Bord[1, 1] = Kleur.Wit;
            spel.Bord[1, 2] = Kleur.Wit;
            spel.Bord[1, 3] = Kleur.Wit;
            spel.Bord[1, 4] = Kleur.Wit;
            spel.Bord[1, 5] = Kleur.Wit;
            spel.Bord[1, 6] = Kleur.Wit;
            spel.Bord[1, 7] = Kleur.Wit;
            spel.Bord[2, 0] = Kleur.Wit;
            spel.Bord[2, 1] = Kleur.Wit;
            spel.Bord[2, 2] = Kleur.Wit;
            spel.Bord[2, 3] = Kleur.Wit;
            spel.Bord[2, 4] = Kleur.Wit;
            spel.Bord[2, 5] = Kleur.Wit;
            spel.Bord[2, 6] = Kleur.Wit;
            spel.Bord[2, 7] = Kleur.Wit;
            spel.Bord[3, 0] = Kleur.Wit;
            spel.Bord[3, 1] = Kleur.Wit;
            spel.Bord[3, 2] = Kleur.Wit;
            spel.Bord[3, 3] = Kleur.Wit;
            spel.Bord[3, 4] = Kleur.Wit;
            spel.Bord[3, 5] = Kleur.Wit;
            spel.Bord[3, 6] = Kleur.Wit;
            spel.Bord[3, 7] = Kleur.Geen;
            spel.Bord[4, 0] = Kleur.Wit;
            spel.Bord[4, 1] = Kleur.Wit;
            spel.Bord[4, 2] = Kleur.Wit;
            spel.Bord[4, 3] = Kleur.Wit;
            spel.Bord[4, 4] = Kleur.Wit;
            spel.Bord[4, 5] = Kleur.Wit;
            spel.Bord[4, 6] = Kleur.Geen;
            spel.Bord[4, 7] = Kleur.Geen;
            spel.Bord[5, 0] = Kleur.Wit;
            spel.Bord[5, 1] = Kleur.Wit;
            spel.Bord[5, 2] = Kleur.Wit;
            spel.Bord[5, 3] = Kleur.Wit;
            spel.Bord[5, 4] = Kleur.Wit;
            spel.Bord[5, 5] = Kleur.Wit;
            spel.Bord[5, 6] = Kleur.Geen;
            spel.Bord[5, 7] = Kleur.Zwart;
            spel.Bord[6, 0] = Kleur.Wit;
            spel.Bord[6, 1] = Kleur.Wit;
            spel.Bord[6, 2] = Kleur.Wit;
            spel.Bord[6, 3] = Kleur.Wit;
            spel.Bord[6, 4] = Kleur.Wit;
            spel.Bord[6, 5] = Kleur.Wit;
            spel.Bord[6, 6] = Kleur.Wit;
            spel.Bord[6, 7] = Kleur.Geen;
            spel.Bord[7, 0] = Kleur.Wit;
            spel.Bord[7, 1] = Kleur.Wit;
            spel.Bord[7, 2] = Kleur.Wit;
            spel.Bord[7, 3] = Kleur.Wit;
            spel.Bord[7, 4] = Kleur.Wit;
            spel.Bord[7, 5] = Kleur.Wit;
            spel.Bord[7, 6] = Kleur.Wit;
            spel.Bord[7, 7] = Kleur.Wit;

            //     0 1 2 3 4 5 6 7
            //     v
            // 0   1 1 1 1 1 1 1 1  
            // 1   1 1 1 1 1 1 1 1
            // 2   1 1 1 1 1 1 1 1
            // 3   1 1 1 1 1 1 1 0
            // 4   1 1 1 1 1 1 0 0
            // 5   1 1 1 1 1 1 0 2
            // 6   1 1 1 1 1 1 1 0
            // 7   1 1 1 1 1 1 1 1
            // Act
            spel.AandeBeurt = Kleur.Zwart;
            var actual = spel.Pas();
            // Assert
            Assert.That(actual, Is.True);
            Assert.That(Kleur.Wit, Is.EqualTo(spel.AandeBeurt));
        }

        [Test]
        public void Pas_WitAanZetGeenZetMogelijk_ReturnTrueEnWisselBeurt()
        {
            // Arrange  (zowel wit als zwart kunnen niet meer)
            Spel spel = new Spel();
            spel.Bord[0, 0] = Kleur.Wit;
            spel.Bord[0, 1] = Kleur.Wit;
            spel.Bord[0, 2] = Kleur.Wit;
            spel.Bord[0, 3] = Kleur.Wit;
            spel.Bord[0, 4] = Kleur.Wit;
            spel.Bord[0, 5] = Kleur.Wit;
            spel.Bord[0, 6] = Kleur.Wit;
            spel.Bord[0, 7] = Kleur.Wit;
            spel.Bord[1, 0] = Kleur.Wit;
            spel.Bord[1, 1] = Kleur.Wit;
            spel.Bord[1, 2] = Kleur.Wit;
            spel.Bord[1, 3] = Kleur.Wit;
            spel.Bord[1, 4] = Kleur.Wit;
            spel.Bord[1, 5] = Kleur.Wit;
            spel.Bord[1, 6] = Kleur.Wit;
            spel.Bord[1, 7] = Kleur.Wit;
            spel.Bord[2, 0] = Kleur.Wit;
            spel.Bord[2, 1] = Kleur.Wit;
            spel.Bord[2, 2] = Kleur.Wit;
            spel.Bord[2, 3] = Kleur.Wit;
            spel.Bord[2, 4] = Kleur.Wit;
            spel.Bord[2, 5] = Kleur.Wit;
            spel.Bord[2, 6] = Kleur.Wit;
            spel.Bord[2, 7] = Kleur.Wit;
            spel.Bord[3, 0] = Kleur.Wit;
            spel.Bord[3, 1] = Kleur.Wit;
            spel.Bord[3, 2] = Kleur.Wit;
            spel.Bord[3, 3] = Kleur.Wit;
            spel.Bord[3, 4] = Kleur.Wit;
            spel.Bord[3, 5] = Kleur.Wit;
            spel.Bord[3, 6] = Kleur.Wit;
            spel.Bord[3, 7] = Kleur.Geen;
            spel.Bord[4, 0] = Kleur.Wit;
            spel.Bord[4, 1] = Kleur.Wit;
            spel.Bord[4, 2] = Kleur.Wit;
            spel.Bord[4, 3] = Kleur.Wit;
            spel.Bord[4, 4] = Kleur.Wit;
            spel.Bord[4, 5] = Kleur.Wit;
            spel.Bord[4, 6] = Kleur.Geen;
            spel.Bord[4, 7] = Kleur.Geen;
            spel.Bord[5, 0] = Kleur.Wit;
            spel.Bord[5, 1] = Kleur.Wit;
            spel.Bord[5, 2] = Kleur.Wit;
            spel.Bord[5, 3] = Kleur.Wit;
            spel.Bord[5, 4] = Kleur.Wit;
            spel.Bord[5, 5] = Kleur.Wit;
            spel.Bord[5, 6] = Kleur.Geen;
            spel.Bord[5, 7] = Kleur.Zwart;
            spel.Bord[6, 0] = Kleur.Wit;
            spel.Bord[6, 1] = Kleur.Wit;
            spel.Bord[6, 2] = Kleur.Wit;
            spel.Bord[6, 3] = Kleur.Wit;
            spel.Bord[6, 4] = Kleur.Wit;
            spel.Bord[6, 5] = Kleur.Wit;
            spel.Bord[6, 6] = Kleur.Wit;
            spel.Bord[6, 7] = Kleur.Geen;
            spel.Bord[7, 0] = Kleur.Wit;
            spel.Bord[7, 1] = Kleur.Wit;
            spel.Bord[7, 2] = Kleur.Wit;
            spel.Bord[7, 3] = Kleur.Wit;
            spel.Bord[7, 4] = Kleur.Wit;
            spel.Bord[7, 5] = Kleur.Wit;
            spel.Bord[7, 6] = Kleur.Wit;
            spel.Bord[7, 7] = Kleur.Wit;

            //     0 1 2 3 4 5 6 7
            //     v
            // 0   1 1 1 1 1 1 1 1  
            // 1   1 1 1 1 1 1 1 1
            // 2   1 1 1 1 1 1 1 1
            // 3   1 1 1 1 1 1 1 0
            // 4   1 1 1 1 1 1 0 0
            // 5   1 1 1 1 1 1 0 2
            // 6   1 1 1 1 1 1 1 0
            // 7   1 1 1 1 1 1 1 1
            // Act
            spel.AandeBeurt = Kleur.Wit;
            var actual = spel.Pas();
            // Assert
            Assert.That(actual, Is.True);
            Assert.That(Kleur.Zwart, Is.EqualTo(spel.AandeBeurt));
        }

        [Test]
        public void Afgelopen_GeenZetMogelijk_ReturnTrue()
        {
            // Arrange  (zowel wit als zwart kunnen niet meer)
            Spel spel = new Spel();
            spel.Bord[0, 0] = Kleur.Wit;
            spel.Bord[0, 1] = Kleur.Wit;
            spel.Bord[0, 2] = Kleur.Wit;
            spel.Bord[0, 3] = Kleur.Wit;
            spel.Bord[0, 4] = Kleur.Wit;
            spel.Bord[0, 5] = Kleur.Wit;
            spel.Bord[0, 6] = Kleur.Wit;
            spel.Bord[0, 7] = Kleur.Wit;
            spel.Bord[1, 0] = Kleur.Wit;
            spel.Bord[1, 1] = Kleur.Wit;
            spel.Bord[1, 2] = Kleur.Wit;
            spel.Bord[1, 3] = Kleur.Wit;
            spel.Bord[1, 4] = Kleur.Wit;
            spel.Bord[1, 5] = Kleur.Wit;
            spel.Bord[1, 6] = Kleur.Wit;
            spel.Bord[1, 7] = Kleur.Wit;
            spel.Bord[2, 0] = Kleur.Wit;
            spel.Bord[2, 1] = Kleur.Wit;
            spel.Bord[2, 2] = Kleur.Wit;
            spel.Bord[2, 3] = Kleur.Wit;
            spel.Bord[2, 4] = Kleur.Wit;
            spel.Bord[2, 5] = Kleur.Wit;
            spel.Bord[2, 6] = Kleur.Wit;
            spel.Bord[2, 7] = Kleur.Wit;
            spel.Bord[3, 0] = Kleur.Wit;
            spel.Bord[3, 1] = Kleur.Wit;
            spel.Bord[3, 2] = Kleur.Wit;
            spel.Bord[3, 3] = Kleur.Wit;
            spel.Bord[3, 4] = Kleur.Wit;
            spel.Bord[3, 5] = Kleur.Wit;
            spel.Bord[3, 6] = Kleur.Wit;
            spel.Bord[3, 7] = Kleur.Geen;
            spel.Bord[4, 0] = Kleur.Wit;
            spel.Bord[4, 1] = Kleur.Wit;
            spel.Bord[4, 2] = Kleur.Wit;
            spel.Bord[4, 3] = Kleur.Wit;
            spel.Bord[4, 4] = Kleur.Wit;
            spel.Bord[4, 5] = Kleur.Wit;
            spel.Bord[4, 6] = Kleur.Geen;
            spel.Bord[4, 7] = Kleur.Geen;
            spel.Bord[5, 0] = Kleur.Wit;
            spel.Bord[5, 1] = Kleur.Wit;
            spel.Bord[5, 2] = Kleur.Wit;
            spel.Bord[5, 3] = Kleur.Wit;
            spel.Bord[5, 4] = Kleur.Wit;
            spel.Bord[5, 5] = Kleur.Wit;
            spel.Bord[5, 6] = Kleur.Geen;
            spel.Bord[5, 7] = Kleur.Zwart;
            spel.Bord[6, 0] = Kleur.Wit;
            spel.Bord[6, 1] = Kleur.Wit;
            spel.Bord[6, 2] = Kleur.Wit;
            spel.Bord[6, 3] = Kleur.Wit;
            spel.Bord[6, 4] = Kleur.Wit;
            spel.Bord[6, 5] = Kleur.Wit;
            spel.Bord[6, 6] = Kleur.Wit;
            spel.Bord[6, 7] = Kleur.Geen;
            spel.Bord[7, 0] = Kleur.Wit;
            spel.Bord[7, 1] = Kleur.Wit;
            spel.Bord[7, 2] = Kleur.Wit;
            spel.Bord[7, 3] = Kleur.Wit;
            spel.Bord[7, 4] = Kleur.Wit;
            spel.Bord[7, 5] = Kleur.Wit;
            spel.Bord[7, 6] = Kleur.Wit;
            spel.Bord[7, 7] = Kleur.Wit;

            //     0 1 2 3 4 5 6 7
            //     v
            // 0   1 1 1 1 1 1 1 1  
            // 1   1 1 1 1 1 1 1 1
            // 2   1 1 1 1 1 1 1 1
            // 3   1 1 1 1 1 1 1 0
            // 4   1 1 1 1 1 1 0 0
            // 5   1 1 1 1 1 1 0 2
            // 6   1 1 1 1 1 1 1 0
            // 7   1 1 1 1 1 1 1 1
            // Act
            spel.AandeBeurt = Kleur.Wit;
            var actual = spel.Afgelopen();
            // Assert
            Assert.That(actual, Is.True);
        }

        [Test]
        public void Afgelopen_GeenZetMogelijkAllesBezet_ReturnTrue()
        {
            // Arrange  (zowel wit als zwart kunnen niet meer)
            Spel spel = new Spel();
            spel.Bord[0, 0] = Kleur.Wit;
            spel.Bord[0, 1] = Kleur.Wit;
            spel.Bord[0, 2] = Kleur.Wit;
            spel.Bord[0, 3] = Kleur.Wit;
            spel.Bord[0, 4] = Kleur.Wit;
            spel.Bord[0, 5] = Kleur.Wit;
            spel.Bord[0, 6] = Kleur.Wit;
            spel.Bord[0, 7] = Kleur.Wit;
            spel.Bord[1, 0] = Kleur.Wit;
            spel.Bord[1, 1] = Kleur.Wit;
            spel.Bord[1, 2] = Kleur.Wit;
            spel.Bord[1, 3] = Kleur.Wit;
            spel.Bord[1, 4] = Kleur.Wit;
            spel.Bord[1, 5] = Kleur.Wit;
            spel.Bord[1, 6] = Kleur.Wit;
            spel.Bord[1, 7] = Kleur.Wit;
            spel.Bord[2, 0] = Kleur.Wit;
            spel.Bord[2, 1] = Kleur.Wit;
            spel.Bord[2, 2] = Kleur.Wit;
            spel.Bord[2, 3] = Kleur.Wit;
            spel.Bord[2, 4] = Kleur.Wit;
            spel.Bord[2, 5] = Kleur.Wit;
            spel.Bord[2, 6] = Kleur.Wit;
            spel.Bord[2, 7] = Kleur.Wit;
            spel.Bord[3, 0] = Kleur.Wit;
            spel.Bord[3, 1] = Kleur.Wit;
            spel.Bord[3, 2] = Kleur.Wit;
            spel.Bord[3, 3] = Kleur.Wit;
            spel.Bord[3, 4] = Kleur.Wit;
            spel.Bord[3, 5] = Kleur.Wit;
            spel.Bord[3, 6] = Kleur.Wit;
            spel.Bord[3, 7] = Kleur.Wit;
            spel.Bord[4, 0] = Kleur.Wit;
            spel.Bord[4, 1] = Kleur.Wit;
            spel.Bord[4, 2] = Kleur.Wit;
            spel.Bord[4, 3] = Kleur.Wit;
            spel.Bord[4, 4] = Kleur.Wit;
            spel.Bord[4, 5] = Kleur.Wit;
            spel.Bord[4, 6] = Kleur.Zwart;
            spel.Bord[4, 7] = Kleur.Zwart;
            spel.Bord[5, 0] = Kleur.Wit;
            spel.Bord[5, 1] = Kleur.Wit;
            spel.Bord[5, 2] = Kleur.Wit;
            spel.Bord[5, 3] = Kleur.Wit;
            spel.Bord[5, 4] = Kleur.Wit;
            spel.Bord[5, 5] = Kleur.Wit;
            spel.Bord[5, 6] = Kleur.Zwart;
            spel.Bord[5, 7] = Kleur.Zwart;
            spel.Bord[6, 0] = Kleur.Wit;
            spel.Bord[6, 1] = Kleur.Wit;
            spel.Bord[6, 2] = Kleur.Wit;
            spel.Bord[6, 3] = Kleur.Wit;
            spel.Bord[6, 4] = Kleur.Wit;
            spel.Bord[6, 5] = Kleur.Wit;
            spel.Bord[6, 6] = Kleur.Wit;
            spel.Bord[6, 7] = Kleur.Zwart;
            spel.Bord[7, 0] = Kleur.Wit;
            spel.Bord[7, 1] = Kleur.Wit;
            spel.Bord[7, 2] = Kleur.Wit;
            spel.Bord[7, 3] = Kleur.Wit;
            spel.Bord[7, 4] = Kleur.Wit;
            spel.Bord[7, 5] = Kleur.Wit;
            spel.Bord[7, 6] = Kleur.Wit;
            spel.Bord[7, 7] = Kleur.Wit;

            //     0 1 2 3 4 5 6 7
            //     v
            // 0   1 1 1 1 1 1 1 1  
            // 1   1 1 1 1 1 1 1 1
            // 2   1 1 1 1 1 1 1 1
            // 3   1 1 1 1 1 1 1 2
            // 4   1 1 1 1 1 1 2 2
            // 5   1 1 1 1 1 1 2 2
            // 6   1 1 1 1 1 1 1 2
            // 7   1 1 1 1 1 1 1 1
            // Act
            spel.AandeBeurt = Kleur.Wit;
            var actual = spel.Afgelopen();
            // Assert
            Assert.That(actual, Is.True);
        }

        [Test]
        public void Afgelopen_WelZetMogelijk_ReturnFalse()
        {
            // Arrange
            Spel spel = new Spel();
            //     0 1 2 3 4 5 6 7
            //                     
            // 0   0 0 0 0 0 0 0 0  
            // 1   0 0 0 0 0 0 0 0
            // 2   0 0 0 0 0 0 0 0
            // 3   0 0 0 1 2 0 0 0
            // 4   0 0 0 2 1 0 0 0
            // 5   0 0 0 0 0 0 0 0
            // 6   0 0 0 0 0 0 0 0
            // 7   0 0 0 0 0 0 0 0
            //                     
            // Act
            spel.AandeBeurt = Kleur.Wit;
            var actual = spel.Afgelopen();
            // Assert
            Assert.That(actual, Is.False);
        }



        [Test]
        public void OverwegendeKleur_Gelijk_ReturnKleurGeen()
        {
            // Arrange
            Spel spel = new Spel();
            //     0 1 2 3 4 5 6 7
            //                     
            // 0   0 0 0 0 0 0 0 0  
            // 1   0 0 0 0 0 0 0 0
            // 2   0 0 0 0 0 0 0 0
            // 3   0 0 0 1 2 0 0 0
            // 4   0 0 0 2 1 0 0 0
            // 5   0 0 0 0 0 0 0 0
            // 6   0 0 0 0 0 0 0 0
            // 7   0 0 0 0 0 0 0 0
            //                     
            // Act
            var actual = spel.OverwegendeKleur();
            // Assert
            Assert.That(Kleur.Geen, Is.EqualTo(actual));
        }

        [Test]
        public void OverwegendeKleur_Zwart_ReturnKleurZwart()
        {
            // Arrange
            Spel spel = new Spel();
            spel.Bord[2, 3] = Kleur.Zwart;
            spel.Bord[3, 3] = Kleur.Zwart;
            spel.Bord[4, 3] = Kleur.Zwart;
            spel.Bord[3, 4] = Kleur.Zwart;
            spel.Bord[4, 4] = Kleur.Wit;

            //     0 1 2 3 4 5 6 7
            //                     
            // 0   0 0 0 0 0 0 0 0  
            // 1   0 0 0 0 0 0 0 0
            // 2   0 0 0 2 0 0 0 0
            // 3   0 0 0 2 2 0 0 0
            // 4   0 0 0 2 1 0 0 0
            // 5   0 0 0 0 0 0 0 0
            // 6   0 0 0 0 0 0 0 0
            // 7   0 0 0 0 0 0 0 0
            //                     
            // Act
            var actual = spel.OverwegendeKleur();
            // Assert
            Assert.That(Kleur.Zwart, Is.EqualTo(actual));
        }

        [Test]
        public void OverwegendeKleur_Wit_ReturnKleurWit()
        {
            // Arrange
            Spel spel = new Spel();
            spel.Bord[2, 3] = Kleur.Wit;
            spel.Bord[3, 3] = Kleur.Wit;
            spel.Bord[4, 3] = Kleur.Wit;
            spel.Bord[3, 4] = Kleur.Wit;
            spel.Bord[4, 4] = Kleur.Zwart;


            //     0 1 2 3 4 5 6 7
            //                     
            // 0   0 0 0 0 0 0 0 0  
            // 1   0 0 0 0 0 0 0 0
            // 2   0 0 0 1 0 0 0 0
            // 3   0 0 0 1 1 0 0 0
            // 4   0 0 0 1 2 0 0 0
            // 5   0 0 0 0 0 0 0 0
            // 6   0 0 0 0 0 0 0 0
            // 7   0 0 0 0 0 0 0 0
            //                     
            // Act
            var actual = spel.OverwegendeKleur();
            // Assert
            Assert.That(Kleur.Wit, Is.EqualTo(actual));
        }
    }
}
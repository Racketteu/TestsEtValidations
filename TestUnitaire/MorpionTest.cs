
using MorpionApp;

namespace TestUnitaire
{
    public class MorpionTest
    {
        [Fact]
        public void VerifVictoire_LigneHorizontale()
        {
            // Arrange
            var jeu = new Morpion();
            jeu.grille = new char[,]
            {
            { 'X', 'X', 'X' },
            { ' ', ' ', ' ' },
            { ' ', ' ', ' ' }
            };

            // Act
            var result = jeu.verifVictoire('X');

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void VerifVictoire_LigneVertical()
        {
            // Arrange
            var jeu = new Morpion();
            jeu.grille = new char[,]
            {
            { 'X', ' ', ' ' },
            { 'X', ' ', ' ' },
            { 'X', ' ', ' ' }
            };

            // Act
            var result = jeu.verifVictoire('X');

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void VerifVictoire_Daigonal1()
        {
            // Arrange
            var jeu = new Morpion();
            jeu.grille = new char[,]
            {
            { 'X', ' ', ' ' },
            { ' ', 'X', ' ' },
            { ' ', ' ', 'X' }
            };

            // Act
            var result = jeu.verifVictoire('X');

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void VerifVictoire_Daigonal2() 
        { 
            // Arrange
            var jeu = new Morpion();
            jeu.grille = new char[,]
            {
            { ' ', ' ', 'X' },
            { ' ', 'X', ' ' },
            { 'X', ' ', ' ' }
            };

            // Act
            var result = jeu.verifVictoire('X');

            // Assert
            Assert.True(result);
        }


        [Fact]
        public void VerifEgalite()
        {
            // Arrange
            var jeu = new Morpion();
            jeu.grille = new char[,]
            {
            { 'X', 'O', 'X' },
            { 'O', 'O', 'X' },
            { 'X', 'X', 'O' } 
            };

            // Act
            var result = jeu.verifEgalite();

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void VerifPasDeVictoirePasEgalité()
        {
            // Arrange
            var jeu = new Morpion();
            jeu.grille = new char[,]
            {
            { 'X', 'O', 'X' },
            { ' ', ' ', ' ' },
            { ' ', ' ', ' ' }
            };

            // Act
            var resultegalite = jeu.verifEgalite();
            var resultvictoire = jeu.verifEgalite();

            // Assert
            Assert.False(resultegalite && resultvictoire);
        }
    }
}
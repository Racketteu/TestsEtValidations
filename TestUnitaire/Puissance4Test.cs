using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestUnitaire
{
    using MorpionApp;

    public class PuissanceQuatreTests
    {
        [Fact]
        public void VerifVictoire_VictoireVerticale()
        {
            // Arrange
            var jeu = new PuissanceQuatre();
            jeu.grille[0, 0] = 'X';
            jeu.grille[1, 0] = 'X';
            jeu.grille[2, 0] = 'X';
            jeu.grille[3, 0] = 'X';

            // Act
            var resultat = jeu.verifVictoire('X');

            // Assert
            Assert.True(resultat);
        }

        [Fact]
        public void VerifVictoire_VictoireColonne()
        {
            // Arrange
            var jeu = new PuissanceQuatre();
            jeu.grille[0, 1] = 'X';
            jeu.grille[0, 2] = 'X';
            jeu.grille[0, 3] = 'X';
            jeu.grille[0, 4] = 'X';

            // Act
            var resultat = jeu.verifVictoire('X');

            // Assert
            Assert.True(resultat);
        }

        [Fact]
        public void VerifVictoire_PasDeVictoire()
        {
            // Arrange
            var jeu = new PuissanceQuatre();
            jeu.grille[0, 0] = 'X';
            jeu.grille[1, 0] = 'O';
            jeu.grille[2, 0] = 'X';
            jeu.grille[3, 0] = 'X';

            
            var resultat = jeu.verifVictoire('X');

            // Assert
            Assert.False(resultat);
        }


        [Fact]
        public void VerifVictoire_Egalite()
        {
            // Arrange
            var jeu = new PuissanceQuatre();
            jeu.grille = new char[4, 7]
            {
                    { 'X', 'X', 'X', 'O', 'X', 'X', 'X'},
                    { 'O', 'O', 'O', 'X', 'O', 'O', 'O'},
                    { 'X', 'X', 'X', 'O', 'X', 'X', 'X'},
                    { 'O', 'O', 'O', 'X', 'O', 'O', 'O'},
            };


            var resultat = jeu.verifEgalite();

            // Assert
            Assert.True(resultat);
        }

        [Fact]
        public void TestVictoireDiagonaleDescendante()
        {
            // Arrange
            var jeu = new PuissanceQuatre();

            jeu.grille = new char[4, 7]
            {
                    { ' ', ' ', ' ', 'X', ' ', ' ', ' '},
                    { ' ', ' ', ' ', ' ', 'X', ' ', ' '},
                    { ' ', ' ', ' ', ' ', ' ', 'X', ' '},
                    { ' ', ' ', ' ', ' ', ' ', ' ', 'X'},
            };

            // Act
            var resultat = jeu.verifVictoire('X');

            // Assert
            Assert.True(resultat);
        }

        [Fact]
        public void TestVictoireDiagonaleAscendante()
        {
            // Arrange
            var jeu = new PuissanceQuatre();

            jeu.grille = new char[4, 7]
            {
                    { ' ', ' ', ' ', ' ', ' ', ' ', 'O'},
                    { ' ', ' ', ' ', ' ', ' ', 'O', ' '},
                    { ' ', ' ', ' ', ' ', 'O', ' ', ' '},
                    { ' ', ' ', ' ', 'O', ' ', ' ', ' '},
            };

            // Act
            var resultat = jeu.verifVictoire('O');

            // Assert
            Assert.True(resultat);
        }
    }
}

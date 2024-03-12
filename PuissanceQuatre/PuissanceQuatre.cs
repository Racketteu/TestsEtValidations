using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorpionApp
{
    public class PuissanceQuatre
    {
        public bool quiterJeu = false;
        public bool tourDuJoueur = true;
        public Grille grille;
        private Joueur _joueur1;
        private Joueur _joueur2;

        public PuissanceQuatre()
        {
            _joueur1 = new Joueur('X', "Joueur 1");
            _joueur2 = new Joueur('O', "Joueur 2");
            grille = new Grille(4, 7);
        }

        public void BoucleJeu()
        {
            while (!quiterJeu)
            {
                while (!quiterJeu)
                {
                    if (tourDuJoueur)
                    {
                        tourJoueur(_joueur1.GetPion());
                        if (VerifVictoire(_joueur1.GetPion()))
                        {
                            finPartie(_joueur1.GetName() + " à gagné !");
                            break;
                        }
                    }
                    else
                    {
                        tourJoueur(_joueur2.GetPion());
                        if (VerifVictoire(_joueur2.GetPion()))
                        {
                            finPartie(_joueur2.GetName() + " à gagné !");
                            break;
                        }
                    }
                    tourDuJoueur = !tourDuJoueur;
                    if (verifEgalite())
                    {
                        finPartie("Aucun vainqueur, la partie se termine sur une égalité.");
                        break;
                    }
                }
                if (!quiterJeu)
                {
                    Console.WriteLine("Appuyer sur [Echap] pour quitter, [Entrer] pour rejouer.");
                GetKey:
                    switch (Console.ReadKey(true).Key)
                    {
                        case ConsoleKey.Enter:
                            break;
                        case ConsoleKey.Escape:
                            quiterJeu = true;
                            Console.Clear();
                            break;
                        default:
                            goto GetKey;
                    }
                }

            }
        }

        public void tourJoueur(char pionUser)
        {
            var (row, column) = (0, 0);
            bool moved = false;

            while (!quiterJeu && !moved)
            {
                Console.Clear();
                grille.AfficherGrille();
                Console.WriteLine();
                Console.WriteLine("Choisir une case valide est appuyer sur [Entrer]");
                Console.SetCursorPosition(column * 6 + 1, row * 4 + 1);

                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.Escape:
                        quiterJeu = true;
                        Console.Clear();
                        break;

                    case ConsoleKey.RightArrow:
                        if (column >= 6)
                        {
                            column = 0;
                        }
                        else
                        {
                            column = column + 1;
                        }
                        break;

                    case ConsoleKey.LeftArrow:
                        if (column <= 0)
                        {
                            column = 6;
                        }
                        else
                        {
                            column = column - 1;
                        }
                        break;

                    case ConsoleKey.Enter:
                        while (row <= 3)
                        {
                            row = row + 1;
                            if (row >= 3)
                            {
                                break;
                            }
                        }
                        while (grille._grille[row, column] is 'X' or 'O')
                        {
                            if (row == 0)
                            {
                                break;
                            }

                            row = row - 1;
                        }
                        if(grille._grille[row, column] is ' ')
                        {
                            grille._grille[row, column] = pionUser;
                            moved = true;
                            quiterJeu = false;
                        }
                        break;
                }
            }
        }


        public bool VerifVictoire(char joueur)
        {
            if ((grille._grille[0,0] == joueur && grille._grille[0,1] == joueur && grille._grille[0,2] == joueur && grille._grille[0,3] == joueur) ||
                  (grille._grille[0,1] == joueur && grille._grille[0,2] == joueur && grille._grille[0,3] == joueur && grille._grille[0,4] == joueur) ||
                  (grille._grille[0,2] == joueur && grille._grille[0,3] == joueur && grille._grille[0,4] == joueur && grille._grille[0,5] == joueur) ||
                  (grille._grille[0,3] == joueur && grille._grille[0,4] == joueur && grille._grille[0,5] == joueur && grille._grille[0,6] == joueur) ||
                  (grille._grille[1,0] == joueur && grille._grille[1,1] == joueur && grille._grille[1,2] == joueur && grille._grille[1,3] == joueur) ||
                  (grille._grille[1,1] == joueur && grille._grille[1,2] == joueur && grille._grille[1,3] == joueur && grille._grille[1,4] == joueur) ||
                  (grille._grille[1,2] == joueur && grille._grille[1,3] == joueur && grille._grille[1,4] == joueur && grille._grille[1,5] == joueur) ||
                  (grille._grille[1,3] == joueur && grille._grille[1,4] == joueur && grille._grille[1,5] == joueur && grille._grille[1,6] == joueur) ||
                  (grille._grille[2,0] == joueur && grille._grille[2,1] == joueur && grille._grille[2,2] == joueur && grille._grille[2,3] == joueur) ||
                  (grille._grille[2,1] == joueur && grille._grille[2,2] == joueur && grille._grille[2,3] == joueur && grille._grille[2,4] == joueur) ||
                  (grille._grille[2,2] == joueur && grille._grille[2,3] == joueur && grille._grille[2,4] == joueur && grille._grille[2,5] == joueur) ||
                  (grille._grille[2,3] == joueur && grille._grille[2,4] == joueur && grille._grille[2,5] == joueur && grille._grille[2,6] == joueur) ||
                  (grille._grille[3,0] == joueur && grille._grille[3,1] == joueur && grille._grille[3,2] == joueur && grille._grille[3,3] == joueur) ||
                  (grille._grille[3,1] == joueur && grille._grille[3,2] == joueur && grille._grille[3,3] == joueur && grille._grille[3,4] == joueur) ||
                  (grille._grille[3,2] == joueur && grille._grille[3,3] == joueur && grille._grille[3,4] == joueur && grille._grille[3,5] == joueur) ||
                  (grille._grille[3,3] == joueur && grille._grille[3,4] == joueur && grille._grille[3,5] == joueur && grille._grille[3,6] == joueur) ||

                  // Victoires Verticales
                  (grille._grille[0,0] == joueur && grille._grille[1,0] == joueur && grille._grille[2,0] == joueur && grille._grille[3,0] == joueur) ||
                  (grille._grille[0,1] == joueur && grille._grille[1,1] == joueur && grille._grille[2,1] == joueur && grille._grille[3,1] == joueur) ||
                  (grille._grille[0,2] == joueur && grille._grille[1,2] == joueur && grille._grille[2,2] == joueur && grille._grille[3,2] == joueur) ||
                  (grille._grille[0,3] == joueur && grille._grille[1,3] == joueur && grille._grille[2,3] == joueur && grille._grille[3,3] == joueur) ||
                  (grille._grille[0,4] == joueur && grille._grille[1,4] == joueur && grille._grille[2,4] == joueur && grille._grille[3,4] == joueur) ||
                  (grille._grille[0,5] == joueur && grille._grille[1,5] == joueur && grille._grille[2,5] == joueur && grille._grille[3,5] == joueur) ||
                  (grille._grille[0,6] == joueur && grille._grille[1,6] == joueur && grille._grille[2,6] == joueur && grille._grille[3,6] == joueur) ||

                  // Victoires Diagonales (de haut-gauche à bas-droite)
                  (grille._grille[0,0] == joueur && grille._grille[1,1] == joueur && grille._grille[2,2] == joueur && grille._grille[3,3] == joueur) ||
                  (grille._grille[0,1] == joueur && grille._grille[1,2] == joueur && grille._grille[2,3] == joueur && grille._grille[3,4] == joueur) ||
                  (grille._grille[0,2] == joueur && grille._grille[1,3] == joueur && grille._grille[2,4] == joueur && grille._grille[3,5] == joueur) ||
                  (grille._grille[0,3] == joueur && grille._grille[1,4] == joueur && grille._grille[2,5] == joueur && grille._grille[3,6] == joueur) ||

                  // Victoires Diagonales (de bas-gauche à haut-droite)
                  (grille._grille[3,0] == joueur && grille._grille[2,1] == joueur && grille._grille[1,2] == joueur && grille._grille[0,3] == joueur) ||
                  (grille._grille[3,1] == joueur && grille._grille[2,2] == joueur && grille._grille[1,3] == joueur && grille._grille[0,4] == joueur) ||
                  (grille._grille[3,2] == joueur && grille._grille[2,3] == joueur && grille._grille[1,4] == joueur && grille._grille[0,5] == joueur) ||
                  (grille._grille[3,3] == joueur && grille._grille[2,4] == joueur && grille._grille[1,5] == joueur && grille._grille[0,6] == joueur))
            {
                return true; // Victoire détectée
            }
            return false; // Pas de victoire
        }


        public bool verifEgalite()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    if (grille._grille[i, j] == ' ')
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public void finPartie(string msg)
        {
            Console.Clear();
            grille.AfficherGrille();
            Console.WriteLine(msg);
        }
    }
}

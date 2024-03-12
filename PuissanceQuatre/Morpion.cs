using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorpionApp
{
    public class Morpion
    {
        public bool quiterJeu = false;
        public bool tourDuJoueur = true;
        public Grille grille;
        private Joueur _joueur1;
        private Joueur _joueur2;

        public Morpion()
        {
            grille = new Grille(3, 3);
            _joueur1 = new Joueur('X',"Joueur 1");
            _joueur2 = new Joueur('O',"Joueur 2");
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
                        if (verifVictoire(_joueur1.GetPion()))
                        {
                            finPartie(_joueur1.GetName() + " à gagné !");
                            break;
                        }
                    }
                    else
                    {
                        tourJoueur(_joueur2.GetPion());
                        if (verifVictoire(_joueur2.GetPion()))
                        {
                            finPartie(_joueur2.GetName() + " à gagné !");
                            break;
                        }
                    }
                    tourDuJoueur = !tourDuJoueur;
                    if (verifEgalite())
                    {
                        finPartie("Aucun vainqueur, égalité.");
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
                        if (column >= 2)
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
                            column = 2;
                        }
                        else
                        {
                            column = column - 1;
                        }
                        break;

                    case ConsoleKey.UpArrow:
                        if (row <= 0)
                        {
                            row = 2;
                        }
                        else
                        {
                            row = row - 1;
                        }
                        break;

                    case ConsoleKey.DownArrow:
                        if (row >= 2)
                        {
                            row = 0;
                        }
                        else
                        {
                            row = row + 1;
                        }
                        break;
                    case ConsoleKey.Enter:
                        if (grille._grille[row, column] == ' ')
                        {
                            grille._grille[row, column] = pionUser;
                            moved = true;
                            quiterJeu = false;
                        }
                        break;
                }

            }
        }

        public bool verifVictoire(char c)
        {
            // Vérification des lignes et des colonnes
            for (int i = 0; i < 3; i++)
            {
                if ((grille._grille[i, 0] == c && grille._grille[i, 1] == c && grille._grille[i, 2] == c) ||
                    (grille._grille[0, i] == c && grille._grille[1, i] == c && grille._grille[2, i] == c))
                {
                    return true;
                }
            }

            // Vérification des diagonales
            if ((grille._grille[0, 0] == c && grille._grille[1, 1] == c && grille._grille[2, 2] == c) ||
                (grille._grille[2, 0] == c && grille._grille[1, 1] == c && grille._grille[0, 2] == c))
            {
                return true;
            }

            return false;
        }

        public bool verifEgalite()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
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

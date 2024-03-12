using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorpionApp
{
    public class Grille
    {
        private int _ligne;
        private int _colonne;
        public char[,] _grille;

        public Grille(int colonne , int ligne) 
        { 
            _ligne = ligne;
            _colonne = colonne;
            _grille = new char[colonne, ligne];
            InitialisationGrille();
        }

        public void AfficherGrille()
        {
            Console.WriteLine();
            int rows = _grille.GetLength(0);
            int columns = _grille.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                Console.Write(" ");
                for (int j = 0; j < columns; j++)
                {
                    Console.Write($"  {_grille[i, j]}  ");
                    if (j < columns - 1)
                    {
                        Console.Write("|");
                    }
                }
                Console.WriteLine();
                Console.WriteLine();

                if (i < rows - 1)
                {
                    Console.Write(" ");
                    for (int k = 0; k < columns; k++)
                    {
                        Console.Write("-----");
                        if (k < columns - 1)
                        {
                            Console.Write("+");
                        }
                    }
                    Console.WriteLine();
                    Console.WriteLine();
                }
            }
        }

        private void InitialisationGrille() 
        { 
            for (int i =0; i < _colonne; i++) 
            { 
                for (int j = 0; j < _ligne; j++) 
                {
                    _grille[i, j] = ' ';
                }
            }
        }

        public int GetLigne()
        {
            return _ligne;
        }

        public int GetColonne()
        {
            return _colonne;
        }
    }
}

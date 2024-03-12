using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorpionApp
{
    public class Joueur
    {
        private char pionJoueur { get; set; }
        private string Name { get; set; }

        public Joueur(char pion, string name) 
        {
            pionJoueur = pion;
            Name = name;
        }

        public string GetName()
        {
            return Name;
        }

        public char GetPion()
        {
            return pionJoueur;
        }
    }
}

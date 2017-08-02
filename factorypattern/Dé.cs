using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuDeDes
{
    public abstract class Dé : IJeuDeDés
    {
        private Random rnd;
        protected int facteur_gain { get; set; }
        protected int facteur_perte { get; set; }
        internal protected int nombre_coté { get; set; }

        public void InitialiserDé(int seed)
        {
            rnd = new Random(seed);
        }

        public int LancerDé()
        {
            return rnd.Next(1, nombre_coté + 1) + rnd.Next(1, nombre_coté + 1);
        }
        

        public decimal[] Calculer(int valeur, decimal crédit, decimal mise)
        {
            decimal[] result = new decimal[2];


            if (valeur == 0)
            {
                result[GlobalVariables.GAIN_PERTE] = facteur_gain * mise;
                result[GlobalVariables.CREDIT] = crédit + result[GlobalVariables.GAIN_PERTE]; 
            }
            else if (valeur < 0)
            {
                result[GlobalVariables.GAIN_PERTE] = 0;
                result[GlobalVariables.CREDIT] = crédit;
            }
            else {
                result[GlobalVariables.GAIN_PERTE] = facteur_perte * mise;
                result[GlobalVariables.CREDIT] = crédit - result[GlobalVariables.GAIN_PERTE];
            }
            return result;
        }
    }
}

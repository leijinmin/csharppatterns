using System;
using System.Linq;

namespace JeuDeDes
{
    internal static class Validation
    {
        internal static string ErreursDe(this string[] champs, Dé dé)
        {            
            string choix = champs[GlobalVariables.CHOIX];
            string crédit = champs[GlobalVariables.CREDIT];
            string mise = champs[GlobalVariables.MISE];
           
            if (champs.videChampsErreurs())
                return "Entrez les valeurs dans tous les champs 'Choix', 'Crédit' et 'Mise'.";
            if (choix.intervalleErreur(dé))
                return "'Votre choix' n'est pas valide.";
            if (crédit.argumentErreur("Crédit"))
                return "Le 'Crédit' doit être decimal et positif.";
            if (mise.argumentErreur("Mise"))
                return  "La 'Mise' doit être decimale et positive.";
            if (decimal.Parse(crédit).plusPetitQue(decimal.Parse(mise)))
                return "La mise ne peut pas être plus grande que le crédit.";

            return null;
        }

        private static bool videChampsErreurs(this string[] champs)
        {
            //var y = champs.FirstOrDefault(x => { return String.IsNullOrEmpty(x); });
            if (champs.Where(x => { return String.IsNullOrEmpty(x); }).Count()>0)
                return true;

            return false;           
        }

        private static bool intervalleErreur(this string valeur, Dé dé)
        {
            int parseInt;            
            int seuil = dé.nombre_coté * 2;

            if (int.TryParse(valeur, out parseInt) && (parseInt < 2 || parseInt > seuil))
                return true;
            
            return false;
        }

        private static bool argumentErreur(this string valeur,string nom)
        {
            decimal parseDecimal;

            if (!decimal.TryParse(valeur, out parseDecimal) || parseDecimal <= 0)
                return true;

            return false;
        }

        private static bool plusPetitQue(this decimal crédit, decimal mise)
        {            
            if (crédit < mise)
                return true;

            return false;
        }
    }
}

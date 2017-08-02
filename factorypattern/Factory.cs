using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuDeDes
{
    public static class Factory
    {
        public static Dé ObtenirInstance(string déType)
        {
            Dé unDé;
            if (déType == "SixCotés")
                unDé = DéSixCotés.Instance();           
            else 
                unDé = DéDouzeCotés.Instance();
           
            return unDé;          
        }


    }
}

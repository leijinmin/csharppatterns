using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuDeDes
{
    public class DéDouzeCotés : Dé
    {
        private static DéDouzeCotés dé;

        private DéDouzeCotés()
        {
            InitialiserDé((int)DateTime.Now.Ticks);
            base.facteur_gain = 20;
            base.facteur_perte = 5;
            base.nombre_coté = 12;
        }
        public static DéDouzeCotés Instance()
        {
            if (dé == null)
                dé = new DéDouzeCotés();

            return dé;
        }
    }
}

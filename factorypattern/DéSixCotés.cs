using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuDeDes
{
    public class DéSixCotés : Dé
    {
        private static DéSixCotés dé;

        private DéSixCotés()
        {
            InitialiserDé((int)DateTime.Now.Ticks);
            base.facteur_gain = 10;
            base.facteur_perte = 4;
            base.nombre_coté = 6;
        }
        public static DéSixCotés Instance()
        {
            if (dé == null)
                dé = new DéSixCotés();

            return dé;
        }
    }
}

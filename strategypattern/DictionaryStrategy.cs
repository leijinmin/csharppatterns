using System.Collections.Generic;
using System.Linq;


namespace StrategyPattern
{
    class DictionaryStrategy : AbstractStructureStrategy
    {
        private Dictionary<string, string> hash = new Dictionary<string, string>();

        public override void Add(string nom, string courriel)
        {
            hash.Add(nom, courriel);
        }
        public override string Sort()
        {
            return convertToArray().Sort();
        }
        public override string ShowAll()
        {
            return convertToArray().ShowAll();
        }

        public override string SearchByName(string champ)
        {
            return convertToArray().SearchByName(champ);
                   
        }
        public override string SearchByEmail(string champ)
        {
            return convertToArray().SearchByEmail(champ);
        }

        private NameEmail[] convertToArray()
        {
            return hash.Select(x => new NameEmail(x.Key, x.Value)).ToArray();                            
        }
        public override bool IsEmpty()
        {
            return hash.Count == 0;
        }

    }
}

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

        protected override NameEmail[] convertToArray()
        {
            return hash.Select(x => new NameEmail(x.Key, x.Value)).ToArray();                            
        }
    }
}

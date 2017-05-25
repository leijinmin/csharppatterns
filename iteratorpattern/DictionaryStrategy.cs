using System.Collections.Generic;
using System.Linq;


namespace IteratorPattern
{
    class DictionaryStrategy : AbstractStructureStrategy
    {
        private Dictionary<string, string> hash = new Dictionary<string, string>();

        public override void Add(string nom, string courriel)
        {
            hash.Add(nom, courriel);
        }

        protected override IEnumerable<KeyValuePair<string, string>> getInstance()
        {
            return (IEnumerable<KeyValuePair<string, string>>)hash;
        }
    }
}

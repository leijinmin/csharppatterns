using System.Collections.Generic;
using System.Linq;

namespace IteratorPattern
{
    abstract public class AbstractStructureStrategy 
    {
        abstract public void Add(string name, string email);
        public virtual string ShowAll()
        {
            return getInstance().ShowAll();
        }
        public virtual string Sort()
        {
            return getInstance().Sort();
        }
        virtual public string SearchByName(string field)
        {
            return getInstance().SearchByName(field);
        }
        virtual public string SearchByEmail(string field)
        {
            return getInstance().SearchByEmail(field);
        }
        virtual public bool IsEmpty()
        {
            return getInstance().ToDictionary(x => x.Key, x => x.Value).Count == 0;
        }
        public bool Contains(string name, string email)
        {
            return SearchByName(name) != "" || SearchByEmail(email) != "";
        }
        abstract protected IEnumerable<KeyValuePair<string,string>> getInstance();
    }
}

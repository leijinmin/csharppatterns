using System.Collections.Generic;
using System.Linq;

namespace StrategyPattern
{
    abstract public class AbstractStructureStrategy
    {
        abstract public void Add(string name, string email);
        abstract protected NameEmail[] convertToArray();

        virtual public string Sort()
        {
            IEnumerable<NameEmail> resultat = convertToArray().OrderBy(x => x.Name);
            return string.Join("", resultat.Select(x => string.Format("Name: {0}\tEmail: {1}\n", x.Name, x.Email)));
        }
        virtual public string ShowAll()
        {
            return string.Join("", convertToArray().Select(x => string.Format("Name: {0}\tEmail: {1}\n", x.Name, x.Email)));
        }
        virtual public string SearchByName(string field)
        {
            return string.Join("", convertToArray().Where(x => field.ToLower().Equals(x.Name.ToLower()))
                                              .Select(x => string.Format("Name: {0}\tEmail: {1}\n", x.Name, x.Email)));
        }
        virtual public string SearchByEmail(string field)
        {
            return string.Join("", convertToArray().Where(x => field.ToLower().Equals(x.Email.ToLower()))
                                             .Select(x => string.Format("Name: {0}\tEmail: {1}\n", x.Name, x.Email)));
        }
        public bool Contains(string name, string email)
        {
            return SearchByName(name) != "" || SearchByEmail(email) != "";
        }



}
}

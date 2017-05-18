using System.Collections.Generic;
using System.Linq;


namespace StrategyPattern
{
    /// <summary>
    /// The extension methods for all strategies
    /// </summary>
    static class ExtensionMethods
    {
        public static string SearchByName(this NameEmail[] nameEmails, string field)
        {
            return string.Join("", nameEmails.Where(x => field.ToLower().Equals(x.Name.ToLower()))
                                             .Select(x => string.Format("Name: {0}\tEmail: {1}\n", x.Name, x.Email)));

        }
        public static string SearchByEmail(this NameEmail[] nameEmails, string field)
        {
            return string.Join("", nameEmails.Where(x => field.ToLower().Equals(x.Email.ToLower()))
                                             .Select(x => string.Format("Name: {0}\tEmail: {1}\n", x.Name, x.Email)));
        }
        public static string ShowAll(this NameEmail[] nameEmails)
        {
            return string.Join("", nameEmails.Select(x => string.Format("Name: {0}\tEmail: {1}\n", x.Name, x.Email)));
        }
        public static string Sort(this NameEmail[] nameEmails)
        {
            IEnumerable<NameEmail> resultat = nameEmails.OrderBy(x => x.Name);
            return string.Join("", resultat.Select(x => string.Format("Name: {0}\tEmail: {1}\n", x.Name, x.Email)));
        }
    }
}

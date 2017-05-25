using System.Linq;
using System.Collections.Generic;


namespace IteratorPattern
{
    /// <summary>
    /// The extension methods for all strategies
    /// </summary>
    static class ExtensionMethods
    {
        public static string SearchByName(this IEnumerable<KeyValuePair<string, string>> strategy, string field)
        {
            return string.Join("", strategy.Where(x => field.ToLower().Equals(x.Key.ToLower()))
                                           .Select(x => string.Format("Name: {0}\tEmail: {1}\n", x.Key, x.Value)));
        }
        public static string SearchByEmail(this IEnumerable<KeyValuePair<string, string>> strategy, string field)
        {
            return string.Join("", strategy.Where(x => field.ToLower().Equals(x.Value.ToLower()))
                                           .Select(x => string.Format("Name: {0}\tEmail: {1}\n", x.Key, x.Value)));
        }
        public static string ShowAll(this IEnumerable<KeyValuePair<string, string>> strategy)
        {
            return string.Join("", strategy.Select(x => string.Format("Name: {0}\tEmail: {1}\n", x.Key, x.Value)));
        }
        public static string Sort(this IEnumerable<KeyValuePair<string, string>> strategy)
        {           
            return string.Join("", new SortedList<string,string>(strategy.ToDictionary(x => x.Key, x => x.Value))
                         .Select(x => string.Format("Name: {0}\tEmail: {1}\n", x.Key, x.Value)));
        }
    }
}

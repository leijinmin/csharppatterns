namespace StrategyPattern
{
    abstract public class AbstractStructureStrategy
    {
        abstract public void Add(string name, string email);
        abstract public string Sort();
        abstract public string ShowAll();
        abstract public string SearchByName(string field);
        abstract public string SearchByEmail(string field);
        abstract public bool IsEmpty();
        public bool Contains(string name, string email)
        {
            return SearchByName(name) != "" || SearchByEmail(email) != "";
        }
}
}

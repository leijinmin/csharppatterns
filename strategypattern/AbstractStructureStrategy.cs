namespace StrategyPattern
{
    abstract public class AbstractStructureStrategy
    {
        abstract public void Add(string name, string email);
        virtual public string Sort()
        {
            return convertToArray().Sort();
        }
        virtual public string ShowAll()
        {
            return convertToArray().ShowAll();
        }
        virtual public string SearchByName(string field)
        {
            return convertToArray().SearchByName(field);
        }
        virtual public string SearchByEmail(string field)
        {
            return convertToArray().SearchByEmail(field);
        }
        virtual public bool IsEmpty()
        {
            return convertToArray().Length == 0;
        }
        public bool Contains(string name, string email)
        {
            return SearchByName(name) != "" || SearchByEmail(email) != "";
        }
        abstract protected NameEmail[] convertToArray();
}
}

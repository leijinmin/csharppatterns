using System.Linq;


namespace StrategyPattern
{
    public class ArrayStrategy : AbstractStructureStrategy
    {
        private uint length = 100; // The array length by default. The dimension may change afterwards
        private string[,] array = new string[100, 2]; 
        private int index = 0; 
        

        public override void Add(string nom, string courriel)
        {
            array[index, 0] = nom;
            array[index, 1] = courriel;

            if (index >= length - 1)
            {
                string[,] temp = new string[length * 2, 2];
                for (int i = 0; i < length; i++)
                {
                    temp[i, 0] = array[i, 0];
                    temp[i, 1] = array[i, 1];
                }
                length *= 2;
                array = new string[length,2];
                array = temp;                
            }
            index += 1;
        }
        public override string SearchByName(string field)
        {
            return index == 0 ? "" : convertToArray().SearchByName(field);
        
        }
        public override string SearchByEmail(string field)
        {
            return index == 0 ? "" : convertToArray().SearchByEmail(field);
        }
        protected override NameEmail[] convertToArray()
        {
            return Enumerable.Range(0, index)
                             .Select(i => new NameEmail(array[i, 0], array[i, 1])).ToArray();
        }

    }
}

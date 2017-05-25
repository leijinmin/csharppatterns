using System.Collections;
using System.Collections.Generic;


namespace IteratorPattern
{
    public class ArrayStrategy : AbstractStructureStrategy, IEnumerable<KeyValuePair<string, string>>
    {
        private uint length = 0; // The array length by default. The dimension may change afterwards
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
        protected override IEnumerable<KeyValuePair<string, string>> getInstance()
        {
            return this;
        }
        public IEnumerator<KeyValuePair<string, string>> GetEnumerator()
        {
            for(int i=0; i<index; i++)
            {
                yield return new KeyValuePair<string, string>(array[i, 0], array[i, 1]);
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

    }
}

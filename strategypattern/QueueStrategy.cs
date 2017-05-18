using System.Collections.Generic;

namespace StrategyPattern
{
    class QueueStrategy : AbstractStructureStrategy
    {
        private Queue<NameEmail> queue = new Queue<NameEmail>();

        public override void Add(string nom, string courriel)
        {
            queue.Enqueue(new NameEmail(nom, courriel));
        }
        /// <summary>
        /// Convert the structure to Array
        /// </summary>
        /// <returns>The array</returns>
        protected override NameEmail[] convertToArray()
        {
            NameEmail[] nameEmails = new NameEmail[queue.Count];
            queue.CopyTo(nameEmails, 0);
            return nameEmails; 
        }
    }
}

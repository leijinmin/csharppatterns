using System.Collections.Generic;


namespace StrategyPattern
{
    class StackStrategy : AbstractStructureStrategy
    {
        private Stack<NameEmail> stack = new Stack<NameEmail>();

        public override void Add(string name, string email)
        {
            stack.Push(new NameEmail(name, email));
        }
        /// <summary>
        /// Convert the structure to Array
        /// </summary>
        /// <returns>The array</returns>
        protected override NameEmail[] convertToArray()
        {
            NameEmail[] nameEmails = new NameEmail[stack.Count];
            stack.CopyTo(nameEmails, 0);
            return nameEmails;
        }
    }
}

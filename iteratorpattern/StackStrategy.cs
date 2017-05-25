using System.Collections.Generic;
using System.Collections;

namespace IteratorPattern
{
    class StackStrategy : AbstractStructureStrategy, IEnumerable<KeyValuePair<string, string>>
    {
        private Stack<NameEmail> stack = new Stack<NameEmail>();

        public override void Add(string name, string email)
        {
            stack.Push(new NameEmail(name, email));
        }
        protected override IEnumerable<KeyValuePair<string, string>> getInstance()
        {
            return this;
        }
        public IEnumerator<KeyValuePair<string, string>> GetEnumerator()
        {
            foreach (NameEmail o in stack)
            {
                if (o.Equals(default(NameEmail)))
                {
                    break;
                }
                yield return new KeyValuePair<string, string>(o.Name, o.Email);
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}

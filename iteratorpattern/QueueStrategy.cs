using System.Collections.Generic;
using System.Collections;
using System;

namespace IteratorPattern
{
    class QueueStrategy : AbstractStructureStrategy, IEnumerable<KeyValuePair<string,string>>
    {
        private Queue<NameEmail> queue = new Queue<NameEmail>();

        public override void Add(string nom, string courriel)
        {
            queue.Enqueue(new NameEmail(nom, courriel));
        }
        protected override IEnumerable<KeyValuePair<string, string>> getInstance()
        {
            return this;
        }

        public IEnumerator<KeyValuePair<string, string>> GetEnumerator()
        {
            foreach (NameEmail o in queue)
            {
                if (o.Equals(default(NameEmail)))
                {
                    break;
                }
                yield return new KeyValuePair<string,string>(o.Name, o.Email);
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}

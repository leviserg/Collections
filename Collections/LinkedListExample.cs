using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    public class LinkedListExample : IStruct
    {

        private List<string> _names;
        public LinkedListExample(List<string> names)
        {
            _names = names;
        }
        public void Run()
        {

            Console.WriteLine("==== LinkedList structure ====");

            LinkedList<Person> persons = new LinkedList<Person>();

            LinkedListNode<Person> tomNode = persons.AddLast(new Person() { Name = _names[0] });

            persons.AddLast(new Person() { Name = _names[1] });
            persons.AddFirst(new Person() { Name = _names[2] });

            LinkedListNode<Person> getNextAfterTomNode = tomNode.Next;

            Console.WriteLine("Element previous for " + _names[0] + " is " + tomNode.Previous.Value.Name);
            Console.WriteLine("Element next for  "+ _names[0] + " is " + tomNode.Next.Value.Name);

            Console.WriteLine("Node value after " + _names[0] + "'s node is " + getNextAfterTomNode.Value.Name);
        }

    }
}

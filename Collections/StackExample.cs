using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    public class StackExample
    {

        private List<string> _names;
        public StackExample(List<string> names)
        {
            _names = names;
        }
        public void Run()
        {

            Console.WriteLine("==== Stack structure ====");

            Stack<Person> personsStack = new Stack<Person>();

            foreach (string name in _names)
            {
                personsStack.Push(new Person() { Name = name });
            }

            int i = 1;
            foreach (Person p in personsStack)
            {
                Console.WriteLine("Pushed person " + i + " : " + p.Name);
                i++;
            }

            Console.WriteLine($"There are {personsStack.Count} persons in the queue");

            // get first element from queue without removing
            Person peekedPerson = personsStack.Peek();
            Console.WriteLine("Peeked person (1-st element) w/o removing from queue is " + peekedPerson.Name);

            while (personsStack.Count > 0)
            {
                Person poppedPerson = personsStack.Pop();
                Console.WriteLine($"Dequeued person is {poppedPerson.Name}. Persons left in queue : {personsStack.Count}.");
            }

        }
    }
}

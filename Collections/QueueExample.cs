using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    public class QueueExample : IStruct
    {
        private List<string> _names;
        public QueueExample(List<string> names)
        {
            _names = names;
        }
        public void Run()
        {

            Console.WriteLine("==== Queue structure ====");

            Queue<Person> personsQueue = new Queue<Person>();
            foreach(string name in _names)
            {
                personsQueue.Enqueue(new Person() { Name = name });
            }

            int i = 1;
            foreach (Person p in personsQueue)
            {
                Console.WriteLine("Enqueued person " + i + " : " + p.Name);
                i++;
            }

            Console.WriteLine($"There are {personsQueue.Count} persons in the queue");

            // get first element from queue without removing
            Person peekedPerson = personsQueue.Peek();
            Console.WriteLine("Peeked person (1-st element) w/o removing from queue is " + peekedPerson.Name);

            while(personsQueue.Count > 0)
            {
                Person dequeuedPerson = personsQueue.Dequeue();
                Console.WriteLine($"Dequeued person is {dequeuedPerson.Name}. Persons left in queue : {personsQueue.Count}.");
            }
        }

    }
}

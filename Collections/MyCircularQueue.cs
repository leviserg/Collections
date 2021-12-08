using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    class MyCircularQueue
    {

        // https://leetcode.com/explore/learn/card/queue-stack/228/first-in-first-out-data-structure/1337/

        private Queue<int> _queue;
        private int _limit;
        public MyCircularQueue(int k)
        {
            _queue = new Queue<int>(k);
            _limit = k;
        }

        public bool EnQueue(int value)
        {
            if (!IsFull())
            {
                _queue.Enqueue(value);
                return true;
            }
            return false;
        }

        public bool DeQueue()
        {
            if (!IsEmpty())
            {
                _queue.Dequeue();
                return true;
            }
            return false;
        }

        public int Front()
        {
            return (!IsEmpty()) ? _queue.First() : -1;
        }

        public int Rear()
        {
            return (!IsEmpty()) ? _queue.Last() : -1;
        }

        public bool IsEmpty()
        {
            return (_queue.Count == 0) ? true : false;
        }

        public bool IsFull()
        {
            return (_queue.Count == _limit) ? true : false;
        }
    }
}

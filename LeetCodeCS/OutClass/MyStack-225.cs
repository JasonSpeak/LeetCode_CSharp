using System.Collections.Generic;
using System.Linq;

namespace LeetCodeCS.OutClass
{
    public class MyStack_225
    {
        private Queue<int> q;

        /** Initialize your data structure here. */
        public MyStack_225()
        {
            q = new Queue<int>();
            
        }   

        /** Push element x onto stack. */
        public void Push(int x)
        {
            var queue = new Queue<int>();
            queue.Enqueue(x);
            foreach (var elemet in q)
            {
                queue.Enqueue(elemet);
            }
            q = queue;
        }

        /** Removes the element on top of the stack and returns that element. */
        public int Pop()
        {
            return q.Dequeue();
        }

        /** Get the top element. */
        public int Top()
        {
            return q.First();
        }

        /** Returns whether the stack is empty. */
        public bool Empty()
        {
            return !q.Any();
        }

    }
}
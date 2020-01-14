using System.Collections.Generic;

namespace LeetCodeCS.OutClass
{
    public class MyQueue_232
    {
        private Stack<int> s1;
        private Stack<int> s2;
        private int front;

        public MyQueue_232()
        {
            s1 = new Stack<int>();
            s2 = new Stack<int>();
        }

        public void Push(int x)
        {
            if (s1.Count == 0)
                front = x;
            s1.Push(x);
        }

        public int Pop()
        {
            if (s2.Count == 0)
            {
                while (s1.Count != 0)
                {
                    s2.Push(s1.Pop());
                }
            }

            return s2.Pop();
        }

        public int Peek()
        {
            if (s2.Count != 0)
            {
                return s2.Peek();
            }

            return front;
        }

        public bool Empty()
        {
            return s1.Count == 0 && s2.Count == 0;
        }
    }
}
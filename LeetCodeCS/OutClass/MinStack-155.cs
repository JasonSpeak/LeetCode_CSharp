using System.Collections.Generic;

namespace LeetCodeCS.OutClass
{
    public class MinStack
    {
        /** initialize your data structure here. */
        private Stack<int> _data;
        private Stack<int> _helper;
        public MinStack()
        {
            _data = new Stack<int>();
            _helper = new Stack<int>();
        }

        public void Push(int x)
        {
            _data.Push(x);
            if (_helper.Count == 0 || x <= _helper.Peek())
            {
                _helper.Push(x);
            }
            else
            {
                _helper.Push(_helper.Peek());
            }
        }

        public void Pop()
        {
            _data.Pop();
            _helper.Pop();
        }

        public int Top()
        {
            return _data.Peek();
        }

        public int GetMin()
        {
            return _helper.Peek();
        }
    }
}
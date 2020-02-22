using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeCS.OutClass
{
    //LeetCodeCN-1352
    class ProductOfNumbers
    {
        private List<int> _nums;
        public ProductOfNumbers()
        {
            _nums = new List<int>();
            _nums.Add(1);
        }

        public void Add(int num)
        {
            if(num==0)
            {
                _nums = new List<int>();
                _nums.Add(1);
            }
            else
            {
                _nums.Add(_nums[_nums.Count - 1] * num);
            }
        }

        public int GetProduct(int k)
        {
            if (_nums.Count <= k)
            {
                return 0;
            }
            return _nums[_nums.Count - 1] / _nums[_nums.Count - 1 - k];
        }

    }
}

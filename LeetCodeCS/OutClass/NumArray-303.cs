namespace LeetCodeCS.OutClass
{
    public class NumArray_303
    {
        #region 暴力计算

        //private int[] numArray;
        //public NumArray_303(int[] nums)
        //{
        //    numArray = nums;
        //}

        //public int SumRange(int i, int j)
        //{
        //    int res = 0;
        //    for (int k = i; k <= j; k++)
        //    {
        //        res += numArray[k];
        //    }

        //    return res;
        //}

        #endregion

        #region 动态规划+缓存

        private int[] sums;

        public NumArray_303(int[] nums)
        {
            sums = new int[nums.Length + 1];
            for (int i = 0; i < nums.Length; i++)
            {
                sums[i + 1] = sums[i] + nums[i];
            }
        }

        public int sumRange(int i, int j)
        {
            return sums[j + 1] - sums[i];
        }

        #endregion

    }
}
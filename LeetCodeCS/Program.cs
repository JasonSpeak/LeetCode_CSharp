using LeetCodeCS.DataStructure;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCodeCS
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            int[] nums = {-1};
            Rotate(nums, 2);
            
            Console.ReadLine();
        }

        #region LeetCodeCN-20
        private static bool IsValid(string s)
        {
            if (s.Length == 0)
            {
                return true;
            }

            if (s.Length == 1)
            {
                return false;
            }
            while (true)
            {
                if (s.Length == 0)
                {
                    return true;
                }
                if (s.IndexOf("()") >= 0 || s.IndexOf("{}") >= 0 || s.IndexOf("[]") >= 0)
                {
                    s = s.Replace("()", "");
                    s = s.Replace("[]", "");
                    s = s.Replace("{}", "");
                }
                else
                {
                    return false;
                }
            }
        }
        #endregion

        #region LeetCodeCN-21
        //Definition for singly-linked list.

        public static ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            if (l1 == null)
            {
                return l2;
            }
            if (l2 == null)
            {
                return l1;
            }

            if (l1.Val < l2.Val)
            {
                l1.Next = MergeTwoLists(l1.Next, l2);
                return l1;
            }
            else
            {
                l2.Next = MergeTwoLists(l1, l2.Next);
                return l2;
            }
        }

        #endregion

        #region LeetCodeCN-26

        public static int RemoveDuplicates(int[] nums)
        {
            if (nums.Length == 0)
            {
                return 0;
            }

            int i = 0;
            for (int j = i+1; j < nums.Length; j++)
            {
                if (nums[j] != nums[i])
                {
                    nums[i + 1] = nums[j];
                    i = i + 1;
                }
            }

            return i + 1;
        }

        #endregion

        #region LeetCodeCN-27

        public static int RemoveElement(int[] nums, int val)
        {
            if (nums.Length == 0)
            {
                return 0;
            }

            int i = 0;
            for (int j = 0; j < nums.Length; j++)
            {
                if (nums[j] != val)
                {
                    nums[i] = nums[j];
                    i++;
                }
            }

            foreach (var num in nums)
            {
                Console.WriteLine(num);
            }
            return i;

        }

        #endregion

        #region LeetCodeCN-28

        public static int StrStr(string haystack, string needle)
        {
            int strCount = haystack.Length;
            int subCount = needle.Length;
            if (subCount == 0)
            {
                return 0;
            }

            if (strCount == 0)
            {
                return -1;
            }
            int[,] FSM = new int[subCount,256];
            int X = 0;
            int match = 0;
            for (int i = 0; i < subCount; i++)
            {
                match = (int) needle[i];
                for (int j = 0; j < 256; j++)
                {
                    FSM[i,j] = FSM[X,j];
                }

                FSM[i,match] = i + 1;
                if (i > 0)
                {
                    X = FSM[X,match];
                }
            }

            int state = 0;
            for (int i = 0; i < strCount; i++)
            {
                state = FSM[state,haystack[i]];
                if (state == subCount)
                {
                    return i - subCount + 1;
                }
            }

            return -1;
        }

        #endregion

        #region LeetCodeCN-35

        public static int SearchInsert(int[] nums, int target)
        {
            int low = 0;
            int high = nums.Length - 1;
            while (low <= high)
            {
                int middle = (low + high) / 2;
                if (target == nums[middle])
                {
                    return middle;
                }
                if (target > nums[middle])
                {
                    low = middle + 1;
                }
                else
                {
                    high = middle - 1;
                }
            }
            return low;
        }

        #endregion

        #region LeetCodeCN-38

        public static string CountAndSay(int n)
        {
            if (n == 1)
            {
                return "1";
            }

            if (n==2)
            {
                return "11";
            }
            string res = "";
            string index = "11";
            for (int k = 0; k < n - 2; k++)
            {

                
                int i = 0;
                int count = 0;
                for (int j = 0; j < index.Length; j++)
                {
                    Console.WriteLine(j);
                    if (index[i] == index[j])
                    {
                        count++;
                    }

                    if (index[i] != index[j] || j == index.Length - 1)
                    {
                        res = res + count + index[i];
                        i = j;
                    }
                }

                index = res;
            }

            return index;

        }

        #endregion

        #region LeetCodeCN-69

        public static int MySqrt(int x)
        {
            if (x == 0)
            {
                return 0;
            }
            long left = 1;
            long right = x / 2;
            while (left < right)
            {
                long mid = left + (right - left + 1) / 2;
                long square = mid * mid;
                if (square > x)
                {
                    right = mid - 1;
                }
                else
                {
                    left = mid;
                }
            }
            return (int)left;
        }

        #endregion

        #region LeetCodeCN-66
        //199
        //99
        //int.Max
        public static int[] PlusOne(int[] digits)
        {
            int count = digits.Length;
            if (digits[count - 1] != 9)
            {
                digits[count - 1]++;
                return digits;
            }
            else
            {
                for (int i = count-1; i >= 0; i--)
                {
                    if (digits[i] == 9)
                    {
                        digits[i] = 0;
                    }
                    else
                    {
                        digits[i]++;
                        
                    }
                }

                return digits;
            }
        }

        #endregion

        #region LeetCodeCN-107

        public static IList<IList<int>> LevelOrderBottom(TreeNode root)
        {
            Queue<TreeNode> tempQueue = new Queue<TreeNode>();
            IList<IList<int>> result = new List<IList<int>>();
            if (root == null)
                return result;
            tempQueue.Enqueue(root);
            while (tempQueue.Count!=0)
            {
                IList<int> currentLevel = new List<int>();
                int n = tempQueue.Count;
                for (int i = 0; i < n; i++)
                {
                    TreeNode node = tempQueue.Dequeue();
                    currentLevel.Add(node.val);
                    if(node.left!=null)
                        tempQueue.Enqueue(node.left);
                    if (node.right != null)
                        tempQueue.Enqueue(node.right);
                }
                result.Add(currentLevel);
            }

            result = result.Reverse().ToList();
            return result;
        }

        #endregion

        #region LeetCodeCN-108

        public static TreeNode SortedArrayToBST(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return null;
            return CreateTree(nums, 0, nums.Length - 1);
        }

        private static TreeNode CreateTree(int[] nums, int start, int end)
        {
            if (start > end)
            {
                return null;
            }
            int mid = (start + end) / 2;
            TreeNode root = new TreeNode(nums[mid]);
            root.left = CreateTree(nums, start, mid - 1);
            root.right = CreateTree(nums, mid + 1, end);
            return root;
        }

        #endregion

        #region LeetCodeCN-110

        public static bool IsBalanced(TreeNode root)
        {
            if (root == null)
                return true;
            return Depth(root) != -1;
        }

        private static int Depth(TreeNode root)
        {
            if (root == null)
                return 0;
            int left = Depth(root.left);
            if (left == -1)
                return -1;
            int right = Depth(root.right);
            if (right == -1)
                return -1;
            return Math.Abs(left - right) < 2 ? Math.Max(left, right) + 1 : -1;
        }
        #endregion

        #region LeetCodeCN-111

        public static int MinDepth(TreeNode root)
        {
            if (root == null)
                return 0;
            int left = MinDepth(root.left);
            int right = MinDepth(root.right);
            return (root.left == null || root.right == null) ? left + right + 1 : Math.Min(left, right) + 1;
        }

        #endregion

        #region LeetCodeCN-112

        public static bool HasPathSum(TreeNode root, int sum)
        {
            if (root == null)
                return false;
            if (root.left == null && root.right == null && sum - root.val == 0)
                return true;
            return HasPathSum(root.left, sum - root.val) || HasPathSum(root.right, sum - root.val);
        }

        #endregion

        #region LeetCodeCN-118

        public static IList<IList<int>> Generate(int numRows)
        {
            if (numRows == 0)
            {
                return new List<IList<int>>();
            }

            if (numRows == 1)
            {
                return new List<IList<int>>(){new List<int>(){1}};
            }

            if (numRows == 2)
            {
                return new List<IList<int>>() { new List<int>() { 1 },new List<int>(){1,1} };
            }

            List<IList<int>> result = new List<IList<int>>() { new List<int>() { 1 }, new List<int>() { 1, 1 } };
            for (var i = 2; i < numRows; i++)
            {
                IList<int> tempLevel = new List<int>();
                tempLevel.Add(1);
                for (int j = 1; j < i; j++)
                {
                    tempLevel.Add(result[i - 1][j - 1] + result[i - 1][j]);
                }

                tempLevel.Add(1);
                result.Add(tempLevel);
            }

            return result;
        }

        #endregion

        #region LeetCodeCN-119

        public static IList<int> GetRow(int rowIndex)
        {
            if (rowIndex == 0)
            {
                return new List<int>() { 1 };
            }

            if (rowIndex == 1)
            {
                return new List<int>() { 1, 1 };
            }

            List<int> preLevel = new List<int>() { 1, 1 };
            List<int> currentLevel = new List<int>();
            for (int i = 2; i < rowIndex + 1; i++)
            {
                currentLevel = new List<int>();
                currentLevel.Add(1);
                for (int j = 1; j < i; j++)
                {
                    currentLevel.Add(preLevel[j - 1] + preLevel[j]);
                }
                currentLevel.Add(1);
                preLevel = new List<int>(currentLevel);
            }

            return currentLevel;
        }

        #endregion

        #region LeetCodeCN-121

        public static int MaxProfit(int[] prices)
        {
            #region 暴力枚举 O(N^2)

            //int maxProfit = 0;
            //int tempMax = 0;
            //int currentDay = 0;
            //while (currentDay<prices.Length)
            //{
            //    for (int i = currentDay; i < prices.Length; i++)
            //    {
            //        int currentMax = prices[i] - prices[currentDay];
            //        tempMax = tempMax > currentMax ? tempMax : currentMax;
            //    }

            //    maxProfit = maxProfit > tempMax ? maxProfit : tempMax;
            //    tempMax = 0;
            //    currentDay++;
            //}
            //return maxProfit;

            #endregion

            #region 优化枚举一趟 O(N)

            if (prices.Length < 2)
            {
                return 0;
            }

            int maxProfit = 0;
            int currentMin = prices[0];

            for (int i = 1; i < prices.Length; i++)
            {
                maxProfit = maxProfit > prices[i] - currentMin ? maxProfit : prices[i] - currentMin;
                currentMin = currentMin < prices[i] ? currentMin : prices[i];
            }

            return maxProfit;

            #endregion

        }

        #endregion

        #region LeetCodeCN-122

        public static int MaxProfit_122(int[] prices)
        {
            #region 优化版动态规划--只保存前次值

            //int n = prices.Length;
            //if (n == 0)
            //    return 0;

            //int dp_i_0 = 0, dp_i_1 = int.MinValue;
            //for (int i = 0; i < n; i++)
            //{
            //    int temp = dp_i_0;
            //    dp_i_0 = Math.Max(dp_i_0, dp_i_1 + prices[i]);
            //    dp_i_1 = Math.Max(dp_i_1, temp - prices[i]);
            //}

            //return dp_i_0;

            #endregion

            #region 常规动态规划

            int n = prices.Length;
            if (n == 0)
            {
                return 0;
            }

            var dp = new int[n,2];
            dp[0, 0] = 0;
            dp[0, 1] = -prices[0];
            for (int i = 1; i < n; i++)
            {
                dp[i, 0] = Math.Max(dp[i - 1, 0], dp[i - 1, 1] + prices[i]);
                dp[i, 1] = Math.Max(dp[i - 1, 1], dp[i - 1, 0] - prices[i]);
            }

            return dp[n - 1, 0];

            #endregion

        }

        #endregion

        #region LeetCodeCN-125

        public static bool IsPalindrome(string s)
        {
            int left = 0, right = s.Length-1;
            while (left<=right)
            {
                if (!IsInRange(s[left]))
                {
                    left++;
                    continue;
                }

                if (!IsInRange(s[right]))
                {
                    right--;
                    continue;
                }

                if (s[left] != s[right] && !IsSameChar(s[left], s[right]))
                {
                    return false;
                }

                left++;
                right--;
            }

            return true;
        }

        private static bool IsInRange(char c)
        {
            if ((c>=48&&c<=57)||(c>=65&&c<=90)||(c>=97&&c<=122))
            {
                return true;
            }

            return false;
        }

        private static bool IsSameChar(char a, char b)
        {
            if ((a >= 48 && a <= 57) || (b >= 48 && b <= 57))
            {
                return false;
            }
            return a > b ? a == (b + 32) : a == (b - 32);
        }

        #endregion

        #region LeetCodeCN-136

        public static int SingleNumber(int[] nums)
        {
            int result = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                result = result ^ nums[i];
            }

            return result;
        }

        #endregion

        #region LeetCodeCN-141

        public static bool HasCycle(ListNode head)
        {
            if (head?.Next == null)
            {
                return false;
            }

            ListNode point1 = head;
            ListNode point2 = head.Next.Next;
            while (true)
            {
                if (point1 == point2)
                {
                    return true;
                }

                if (point2?.Next == null)
                {
                    return false;
                }

                point1 = point1.Next;
                point2 = point2.Next.Next;
            }
        }

        #endregion

        #region LeetCodeCN-155

        //外部类

        #endregion

        #region LeetCodeCN-160

        public static ListNode GetIntersectionNode(ListNode headA, ListNode headB)
        {
            if (headA == null || headB == null)
            {
                return null;
            }
            ListNode pA = headA;
            ListNode pB = headB;
            while (pA != pB)
            {
                pA = pA == null ? headB : pA.Next;
                pB = pB == null ? headA : pB.Next;
            }
            return pA;
        }

        #endregion

        #region LeetCodeCN-168

        public static string ConvertToTitle(int n)
        {
            //26进制转换
            StringBuilder sb = new StringBuilder();
            while (n > 0)
            {
                int c = n % 26;
                if (c == 0)
                {
                    c = 26;
                    n -= 1;
                }
                sb.Insert(0, (char)('A' + c - 1));
                n /= 26;
            }
            return sb.ToString();
        }

        #endregion

        #region LeetCodeCN-169

        public static int MajorityElement(int[] nums)
        {
            #region 排序取中值

            //Array.Sort(nums);
            //return nums[(nums.Length - 1) / 2];

            #endregion

            #region 哈希表统计

            //var map = new Hashtable();

            //foreach (var num in nums)
            //{
            //    if (map.Count == 0 || !map.ContainsKey(num))
            //    {
            //        map.Add(num, 1);
            //    }

            //    map[num] = (int) map[num] + 1;
            //}

            //int count = 0;
            //int max = int.MinValue;
            //foreach (DictionaryEntry item in map)
            //{
            //    if ((int)item.Value >= count)
            //    {
            //        count = (int)item.Value;
            //        max = (int)item.Key;
            //    }
            //}

            //return max;

            #endregion

            #region 摩尔投票(Best)

            int countFlag = 0;
            int result = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                //初次默认第一个。后续每次判断当countFlag为0，意味着之前元素抵消完成。
                if (countFlag == 0)
                {
                    //赋值新元素作为即将可能要返回的值
                    result = nums[i];
                }
                // 即将可能返回的值给当前比，相等+1，不相等-1，累计为0重新赋值新坐标元素。
                countFlag += (result == nums[i]) ? 1 : -1;
            }
            return result;

            #endregion
        }

        #endregion

        #region LeetCodeCN-171

        public static int TitleToNumber(string s)
        {
             var baseMap = new Hashtable();
             for (int i = 0; i < 26; i++)
             {
                 baseMap.Add((char)('A' + i), i + 1);
             }

             int result = 0;
            for (int i = 0; i < s.Length; i++)
            {
                result += (int)Math.Pow(26, s.Length - 1 - i)*(int)baseMap[s[i]];
            }

            return result;
        }

        #endregion

        #region LeetCodeCN-172

        public static int TrailingZeroes(int n)
        {
            int fiveCount = 0;
            while (n > 0)
            {
                fiveCount += n / 5;
                n = n / 5;
            }

            return fiveCount;
        }

        #endregion

        #region LeetCodeCN-189

        public static void Rotate(int[] nums, int k)
        {
            k %= nums.Length;
            Console.WriteLine(k);
            Reverse(nums, 0, nums.Length - 1);
            Reverse(nums, 0, k - 1);
            Reverse(nums, k, nums.Length - 1);
        }

        private static void Reverse(int[] nums, int index, int end)
        {
            while(index<end)
            {
                int temp = nums[index];
                nums[index] = nums[end];
                nums[end] = temp;
                index++;
                end--;
            }
        }

        #endregion

        #region LeetCodeCN-190

        public static uint reverseBits(uint n)
        {
            int result = 0;
            int count = 32;
            while (count > 0)
            {
                result <<= 1;
                result |= (int)(n & 1);
                n >>= 1;
                count--;
            }

            return (uint)result;
        }

        #endregion

        #region LeetCodeCN-191

        public static int HammingWeight(uint n)
        {
            int count = 32;
            int result = 0;
            while (count > 0)
            {
                result += (int) (n & 1);
                n >>= 1;
                count--;
            }

            return result;
        }

        #endregion

        #region LeetCodeCN-198

        public static int Rob(int[] nums)
        {

        }

        #endregion
    }
}

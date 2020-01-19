using LeetCodeCS.DataStructure;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Mail;
using System.Text;

namespace LeetCodeCS
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var a = HammingDistance(1, 4);
            Console.WriteLine(a);

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
            if (nums.Length == 0)
            {
                return 0;
            }
            int[] dp = new int[nums.Length + 1];
            dp[0] = 0;
            dp[1] = nums[0];
            for (int i = 2; i <= nums.Length; i++)
            {
                dp[i] = Math.Max(dp[i - 1], dp[i - 2] + nums[i - 1]);
            }

            return dp[nums.Length];
        }

        #endregion

        #region LeetCodeCN-202

        public static bool IsHappy(int n)
        {
            while (n >= 10)
            {
                int temp = 0;
                while(n>0)
                {
                    temp += (int)Math.Pow(n % 10, 2);
                    n = n / 10;
                }
                n = temp;
            }

            return n == 1 || n == 7;
        }

        #endregion

        #region LeetCodeCN-203
        //关键在头尾节点的处理
        public  static ListNode RemoveElements(ListNode head, int val)
        {
            //使用哨兵节点
            ListNode sentinel = new ListNode(0);
            sentinel.Next = head;

            ListNode prev = sentinel, curr = head;
            while (curr != null)
            {
                if (curr.Val == val) prev.Next = curr.Next;
                else prev = curr;
                curr = curr.Next;
            }
            return sentinel.Next;


        }

        #endregion

        #region LeetCodeCN-204

        public static int CountPrimes(int n)
        {
            if (n < 2) return 0;
            int count = 0;
            // 元素设置标记
            bool[] nums = new bool[n];

            for (int i = 2; i * i < n; i++)
            {
                // 用 ! 判断，就不用循环遍历设置数组元素都为ture
                if (!nums[i])
                {

                    for (int j = i * i; j < n; j += i)
                    {

                        // 判断是为了去重(i=2,j=12; i=3,j=12),提高效率
                        if (nums[j])
                            continue;

                        // 这里递增，可以直接得到非质数的数量
                        count++;

                        // 非质数标记清除
                        nums[j] = true;
                    }
                }
            }
            // 排除 0 和 1 ，所以要-2
            return n - count - 2;
        }

        #endregion

        #region LeetCodeCN-205  

        public static bool IsIsomorphic(string s, string t)
        {
            return Isomorphic(s, t) && Isomorphic(t, s);
        }

        private static bool Isomorphic(string s, string t)
        {
            var kv = new Hashtable();
            int count = s.Length;
            for (int i = 0; i < count; i++)
            {
                var cs = s[i];
                var ts = t[i];
                if (kv.ContainsKey(cs))
                {
                    if ((char) kv[cs] != ts)
                    {
                        return false;
                    }
                }
                else
                {
                    kv.Add(cs, ts);
                }
            }

            return true;
        }

        #endregion

        #region LeetCodeCN-206

        public static ListNode ReverseList(ListNode head)
        {
            ListNode pre = null;
            ListNode cur = head;
            ListNode tmp = null;

            while (cur!=null)
            {
                tmp = cur.Next;
                cur.Next = pre;
                pre = cur;
                cur = tmp;
            }

            return pre;
        }

        #endregion

        #region LeetCodeCN-217

        public static bool ContainsDuplicate(int[] nums)
        {
            var kv = new Hashtable();
            for (int i = 0; i < nums.Length; i++)
            {
                if (kv.ContainsKey(nums[i]))
                {
                    return true;
                }
                kv.Add(nums[i],i);
            }

            return false;
        }

        #endregion

        #region LeetCodeCN-219

        public static bool ContainsNearbyDuplicate(int[] nums, int k)
        {
            if (nums.Length < 2)
            {
                return false;
            }
            var kv = new Hashtable();
            int res = int.MaxValue;
            for (int i = 0; i < nums.Length; i++)
            {
                if (kv.ContainsKey(nums[i]))
                {
                    res = i - (int) kv[nums[i]];
                    if (res <= k)
                    {
                        return true;
                    }
                    kv[nums[i]] = i;
                }
                else
                {
                    kv.Add(nums[i],i);
                }
            }

            return false;
        }

        #endregion

        #region LeetCodeCN-225

        //Out Class

        #endregion

        #region LeetCodeCN-226 

        public static TreeNode InvertTree(TreeNode root)
        {
            if (root == null)
            {
                return null;
            }
            TreeNode tmp = root.right;
            root.right = root.left;
            root.left = tmp;

            InvertTree(root.right);
            InvertTree(root.left);
            return root;
        }

        #endregion

        #region LeetCodeCN-231

        public static bool IsPowerOfTwo(int n)
        {
            return n > 0 && (n & (n - 1)) == 0;
        }

        #endregion

        #region LeetCodeCN-232

        //Out Class

        #endregion

        #region LeetCodeCn-234

        public static bool IsPalindrome(ListNode head)
        {
            #region 存入数组对比

            //if (head == null || head.Next == null)
            //{
            //    return true;
            //}

            //List<int> tmp = new List<int>();
            //var point = head;
            //while (point!=null)
            //{
            //    tmp.Add(point.Val);
            //    point = point.Next;
            //}

            //for (int i = 0; i < tmp.Count/2; i++)
            //{
            //    if (tmp[i] != tmp[tmp.Count - 1 - i])
            //    {
            //        return false;
            //    }
            //}

            //return true;

            #endregion

            #region 双指针

            if (head == null || head.Next == null)
            {
                return true;
            }

            var fast = head;
            var slow = head;
            ListNode mid = null;
            while (fast != null && fast.Next != null)
            {
                fast = fast.Next.Next;
                var tmp = mid;
                mid = slow;
                slow = slow.Next;
                mid.Next = tmp;
            }

            ListNode left = null;
            ListNode right = null;

            if (fast == null)
            {
                right = slow;
                left = mid;
            }
            else
            {
                right = slow.Next;
                left = mid;
            }

            while (right!=null)
            {
                if (right.Val != left.Val)
                {
                    return false;
                }
                
                right = right.Next;
                left = left.Next;
            }

            return true;

            #endregion
        }

        #endregion

        #region LeetCodeCN-235

        public static TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            if (p.val < root.val && q.val < root.val)
                return LowestCommonAncestor(root.left, p, q);
            if (p.val > root.val && q.val > root.val)
                return LowestCommonAncestor(root.right, p, q);
            return root;
        }

        #endregion

        #region LeetCodeCN-237

        public static void DeleteNode(ListNode node)
        {
            node.Val = node.Next.Val;
            node.Next = node.Next.Next;
        }

        #endregion

        #region LeetCodeCN-242

        public static bool IsAnagram(string s, string t)
        {
            if (s.Length != t.Length)
                return false;
            int[] alpha = new int[26];
            for (int i = 0; i < s.Length; i++)
            {
                alpha[s[i] - 'a']++;
                alpha[t[i] - 'a']--;
            }
            for (int i = 0; i < 26; i++)
                if (alpha[i] != 0)
                    return false;
            return true;

        }

        #endregion

        #region LeetCodeCN-257

        public static IList<string> BinaryTreePaths(TreeNode root)
        {
            IList<string> res = new List<string>();
            ConstructPaths(root, "", res);
            return res;
        }

        private static void ConstructPaths(TreeNode root, string path, IList<string> paths)
        {
            if (root != null)
            {
                path += root.val.ToString();
                if (root.left==null&&root.right==null)
                {
                    paths.Add(path);
                }
                else
                {
                    path += "->";
                    ConstructPaths(root.left,path,paths);
                    ConstructPaths(root.right,path,paths);
                }
            }
        }

        #endregion

        #region LeetCodeCN-258

        public static int AddDigits(int num)
        {
            #region 循环解法

            //while (num >= 10)
            //{
            //    int tmp = num;
            //    int res = 0;
            //    while (tmp>0)
            //    {
            //        res += tmp % 10;
            //        tmp = tmp / 10;
            //    }

            //    num = res;
            //}

            //return num;

            #endregion

            #region 不使用循环递归，时间复杂度O(1),数学方法归纳

            return (num - 1) % 9 + 1;

            #endregion
        }

        #endregion

        #region LeetCodeCN-263

        public static bool IsUgly(int num)
        {
            if (num <= 0) return false;
            while (num != 1)
            {
                if (num % 2 == 0) num /= 2;
                else if (num % 3 == 0) num /= 3;
                else if (num % 5 == 0) num /= 5;
                else return false;
            }
            return true;
        }

        #endregion

        #region LeetCodeCN-268

        public static int MissingNumber(int[] nums)
        {
            int[] flags = new int[nums.Length];

            foreach (var t in nums)
            {
                flags[t] = 1;
            }

            for (int i = 0; i < flags.Length; i++)
            {
                if (flags[i] != 1)
                {
                    return i;
                }
            }

            return -1;
        }

        #endregion

        #region LeetCodeCN-278

        private static bool IsBadVersion(int version)
        {
            return false;
        }

        public static int FirstBadVersion(int n)
        {
            int left = 1;
            int right = n;
            while (left < right)
            {
                int mid = left + (right - left) / 2;
                if (IsBadVersion(mid))
                {
                    right = mid;
                }
                else
                {
                    left = mid + 1;
                }
            }
            return left;
        }

        #endregion

        #region LeetCodeCN-283

        public static void MoveZeroes(int[] nums)
        {
            int notZeroPoint = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != 0)
                {
                    nums[notZeroPoint] = nums[i];
                    notZeroPoint++;
                }
            }

            for (int j = notZeroPoint; j < nums.Length; j++)
            {
                nums[j] = 0;
            }
        }

        #endregion

        #region LeetCodeCN-290

        public static bool WordPattern(string pattern, string str)
        {
            if (pattern.Length != str.Split(' ').Length)
            {
                return false;
            }

            return IsSameWord(pattern, str);
        }

        private static bool IsSameWord(string pattern, string str)
        {
            Hashtable kv = new Hashtable();
            for (int i = 0; i < pattern.Length; i++)
            {
                var p = pattern[i];
                var s = str.Split(' ')[i];
                if (!kv.ContainsKey(p))
                {
                    if (kv.ContainsValue(s))
                    {
                        return false;
                    }
                    kv.Add(p, s);
                }
                else
                {
                    if ((string) kv[p] != s)
                        return false;
                }
            }

            return true;
        }

        #endregion

        #region LeetCodeCN-292
        public static bool CanWinNim(int n)
        {
            return (n % 4 != 0);
        }


        #endregion

        #region LeetCodeCN-299

        public static string GetHint(string secret, string guess)
        {
            int[] kv = new int[10];
            int a = 0, b = 0;
            for (int i = 0; i < secret.Length; i++)
            {
                if (secret[i] == guess[i])
                {
                    a++;
                    continue;
                }

                //既不是公牛也不是母牛的数字最后出现次数为正
                kv[secret[i] - '0']++;
                kv[guess[i] - '0']--;
            }

            for (int i = 0; i < 10; i++)
            {
                if (kv[i] >= 0)
                {
                    b += kv[i];//既不是公牛也不是母牛的数量
                }
            }

            b = secret.Length - a - b;
            return $"{a}A{b}B";
        }

        #endregion

        #region LeetCodeCN-303

        //Out Class

        #endregion

        #region LeetCodeCN-326

        public static bool IsPowerOfThree(int n)
        {
            return n > 0 && 1162261467 % n == 0;
        }

        #endregion

        #region LeetCodeCN-342

        public static bool IsPowerOfFour(int num)
        {
            return (num > 0) && ((num & (num - 1)) == 0) && (num % 3 == 1);
        }

        #endregion

        #region LeetCodeCN-344

        public static void ReverseString(char[] s)
        {
            int left = 0, right = s.Length-1;
            while (left<=right)
            {
                char tmp = s[left];
                s[left] = s[right];
                s[right] = tmp;
                left++;
                right--;
            }
        }

        #endregion

        #region LeetCodeCN-345

        public static string ReverseVowels(string s)
        {
            List<char> vowels = new List<char>()
            {
                'a',
                'e',
                'i',
                'o',
                'u',
                'A',
                'E',
                'I',
                'O',
                'U'
            };
            StringBuilder res = new StringBuilder(s);
            int left = 0, right = s.Length - 1;
            while (left<=right)
            {
                if (!vowels.Contains(res[left]))
                {
                    left++;
                    continue;
                }

                if (!vowels.Contains(res[right]))
                {
                    right--;
                    continue;
                }

                var tmp = res[left];
                res[left] = res[right];
                res[right] = tmp;
                left++;
                right--;
            }

            return res.ToString();
        }

        #endregion

        #region LeetCodeCN-349

        public static int[] Intersection(int[] nums1, int[] nums2)
        {
            var set1 = new HashSet<int>();
            var set2 = new HashSet<int>();
            foreach (var i in nums1)
            {
                set1.Add(i);
            }

            foreach (var i in nums2)
            {
                set2.Add(i);
            }
            set1.IntersectWith(set2);

            int[] res = new int[set1.Count];
            int index = 0;
            foreach (var i in set1)
            {
                res[index] = i;
                index++;
            }

            return res;
        }


        #endregion

        #region LeetCodeCN-367

        public static bool IsPerfectSquare(int num)
        {
            if (num < 2)
            {
                return true;
            }

            long left = 2, right = num / 2, x, guessSquared;
            while (left <= right)
            {
                x = left + (right - left) / 2;
                guessSquared = x * x;
                if (guessSquared == num)
                {
                    return true;
                }
                if (guessSquared > num)
                {
                    right = x - 1;
                }
                else
                {
                    left = x + 1;
                }
            }
            return false;
        }

        #endregion

        #region LeetCodeCN-371

        public static int GetSum(int a, int b)
        {
            while (b != 0)
            {
                int temp = a ^ b;
                b = (a & b) << 1;
                a = temp;
            }
            return a;
        }

        #endregion

        #region LeetCodeCN-383

        public static bool CanConstruct(string ransomNote, string magazine)
        {
            if (ransomNote.Length > magazine.Length)
            {
                return false;
            }
            int[] table = new int[26];

            foreach (var c in magazine)
            {
                table[c - 'a']++;
            }

            foreach (var c in ransomNote)
            {
                table[c - 'a']--;
            }

            if (table.Any(i => i < 0))
            {
                return false;
            }

            return true;
        }

        #endregion

        #region LeetCodeCN-387

        public static int FirstUniqChar(string s)
        {
            int[] flag = new int[26];
            foreach (var c in s)
            {
                flag[c - 'a']++;
            }

            for (int i = 0; i < s.Length; i++)
            {
                if (flag[s[i] - 'a'] == 1)
                {
                    return i;
                }
            }

            return -1;
        }

        #endregion

        #region LeetCodeCN-389

        public static char FindTheDifference(string s, string t)
        {
            int[] flag = new int[26];
            foreach (var c in s)
            {
                flag[c - 'a']++;
            }

            foreach (var c in t)
            {
                flag[c - 'a']--;
            }

            for (int i = 0; i < 26; i++)
            {
                if (flag[i] < 0)
                {
                    return (char)('a' + i);
                }
            }

            return 'a';
        }

        #endregion

        #region LeetCodeCN-392

        public static bool IsSubsequence(string s, string t)
        {
            int s_index = 0, t_index = 0;
            while (s_index < s.Length && t_index < t.Length)
            {
                if (s[s_index] == t[t_index])
                {
                    s_index++;
                    t_index++;
                }
                else
                {
                    t_index++;
                }
            }

            return s_index == s.Length;
        }

        #endregion

        #region LeetCodeCN-401

        public static IList<string> ReadBinaryWatch(int num)
        {
            var dictA = new Dictionary<int, List<int>>();
            var res = new List<string>();
            for (var i = 0; i < 12; i++)
            {
                var t = BitCount(i);
                if (dictA.ContainsKey(t))
                {
                    dictA[t].Add(i);
                }
                else
                {
                    dictA[t] = new List<int> { i };
                }
            }

            var dictB = new Dictionary<int, List<int>>();
            for (var i = 0; i < 60; i++)
            {
                var t = BitCount(i);
                if (dictB.ContainsKey(t))
                {
                    dictB[t].Add(i);
                }
                else
                {
                    dictB[t] = new List<int> { i };
                }
            }
            for (var i = 0; i <= 4 && dictA.ContainsKey(i); i++)
            {
                var j = num - i;
                if (j >= 0 && dictB.ContainsKey(j))
                {
                    foreach (var a in dictA[i])
                    {
                        foreach (var b in dictB[j])
                        {
                            if (b < 10)
                            {
                                res.Add($"{a}:0{b}");
                            }
                            else
                            {
                                res.Add($"{a}:{b}");
                            }
                        }
                    }

                }
            }
            return res;
        }

        #endregion

        #region LeetCodeCN-404

        public static int SumOfLeftLeaves(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }

            int sum = 0;
            if (root.left != null && (root.left.left == null && root.left.right == null))
            {
                sum += root.left.val;
            }
            else
            {
                sum += SumOfLeftLeaves(root.left);
            }

            sum += SumOfLeftLeaves(root.right);
            return sum;
        }

        #endregion

        #region LeetCodeCN-405

        //Pass

        #endregion

        #region LeetCodeCN-409

        public static int LongestPalindrome(string s)
        {
            var kv = new Hashtable();
            for (int i = 0; i < s.Length; i++)
            {
                if (kv.ContainsKey(s[i]))
                {
                    kv[s[i]] = (int) kv[s[i]] + 1;
                }
                else
                {
                    kv.Add(s[i],1);
                }
            }

            int maxLength = 0;
            foreach (DictionaryEntry entry in kv)
            {
                if ((int) entry.Value >= 2)
                {
                    maxLength += (int) entry.Value / 2 * 2;
                }
            }

            return maxLength==s.Length ? maxLength : maxLength + 1;
        }

        #endregion

        #region LeetCodeCN-412

        public static IList<string> FizzBuzz(int n)
        {
            var result = new List<string>();
            for (int i = 1; i <= n; i++)
            {
                if (i % 3 == 0 && i % 5 == 0)
                {
                    result.Add("FizzBuzz");
                    continue;
                }

                if (i % 5 == 0)
                {
                    result.Add("Buzz");
                    continue;
                }

                if (i % 3 == 0)
                {
                    result.Add("Fizz");
                    continue;
                }
                result.Add(i.ToString());
            }

            return result;
        }

        #endregion

        #region LeetCodeCN-414

        public static int ThirdMax(int[] nums)
        {
            int max1 = int.MinValue, max2 = int.MinValue, max3 = int.MinValue, n = nums.Length, cnt = 0;
            for (int i = 0; i < n; i++)
            {
                max1 = Math.Max(max1, nums[i]);
            }
            for (int i = 0; i < n; i++)
            {
                if (nums[i] != max1) max2 = Math.Max(max2, nums[i]);
            }
            for (int i = 0; i < n; i++)
            {
                if (nums[i] != max1 && nums[i] != max2)
                {
                    if (nums[i] >= max3)
                    {
                        max3 = nums[i];
                        cnt++;
                    }
                }
            }
            return (cnt == 0) ? max1 : max3;
        }

        #endregion

        #region LeetCodeCN-415

        public static string AddStrings(string num1, string num2)
        {
            int point1 = num1.Length - 1;
            int point2 = num2.Length - 1;
            var result = string.Empty;
            int addNum = 0;
            while (point1>=0&&point2>=0)
            {
                var cNum1 = num1[point1] - '0';
                var cNum2 = num2[point2] - '0';
                var tmpRes = cNum1 + cNum2 + addNum;
                if (tmpRes > 9)
                {
                    addNum = 1;
                    tmpRes = tmpRes % 10;
                }
                else
                {
                    addNum = 0;
                }

                result += tmpRes;
                point1--;
                point2--;
            }

            if (point1 < 0 && point2>=0)
            {
                for (int i = point2; i >=0; i--)
                {
                    var tmpRes = num2[i] - '0' + addNum;
                    if (tmpRes > 9)
                    {
                        addNum = 1;
                        tmpRes = tmpRes % 10;
                    }
                    else
                    {
                        addNum = 0;
                    }
                    result += tmpRes;
                }
            }

            if (point1 >= 0 && point2 < 0)
            {
                for (int i = point1; i >= 0; i--)
                {
                    var tmpRes = num1[i] - '0' + addNum;
                    if (tmpRes > 9)
                    {
                        addNum = 1;
                        tmpRes = tmpRes % 10;
                    }
                    else
                    {
                        addNum = 0;
                    }
                    result += tmpRes;
                }
            }

            if (addNum == 1)
            {
                result += 1;
            }

            return new string(result.Reverse().ToArray());

        }

        #endregion

        #region LeetCodeCN-434

        public static int CountSegments(string s)
        {
            if (string.IsNullOrWhiteSpace(s))
            {
                return 0;
            }

            int count = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if ((i == 0 || s[i - 1] == ' ') && s[i] != ' ')
                {
                    count++;
                }
            }

            return count;
        }

        #endregion

        #region LeetCodeCN-437

        public static int PathSum(TreeNode root, int sum)
        {
            return GetPathSum(root, sum, new int[1000], 0);
        }

        /// <summary>
        /// 递归获取每条路径上的列表存入array，并在每次递归中，从后向前循环array的和寻找是否存在和为sum的组合，p为当前递归深度，即array列表的元素数量
        /// </summary>
        /// <param name="root">当前递归节点</param>
        /// <param name="sum">寻找的和 </param>
        /// <param name="array">存储树上的路径</param>
        /// <param name="p">递归深度</param>
        /// <returns>和为sum的路径数量</returns>
        private static int GetPathSum(TreeNode root, int sum, int[] array, int p)
        {
            if (root == null)
            {
                return 0;
            }

            array[p] = root.val;
            int tmp = 0;
            int n = 0;
            for (int i = p; i >=0 ; i--)
            {
                tmp += array[i];
                if (tmp == sum)
                {
                    n++;
                }
            }

            int left = GetPathSum(root.left, sum, array, p + 1);
            int right = GetPathSum(root.right, sum, array, p + 1);
            return n + left + right;
        }

        #endregion

        #region LeetCodeCN-441

        public static int ArrangeCoins(int n)
        {
            #region 暴力循环一路加上去（超时）

            //if (n == 0)
            //{
            //    return 0;
            //}
            //int sum = 0;
            //int level = 1;
            //while (sum < n)
            //{
            //    sum += level;
            //    level++;
            //}

            //return sum == n ? level - 1 : level - 2;

            #endregion

            #region 利用公式计算
            //求和公式k(k+1) /2 = n，则正数解 k = sqrt(2n+1/4) - 1/2

            return (int)(Math.Sqrt(2) * Math.Sqrt(n + 0.125) - 0.5);

            #endregion

        }

        #endregion

        #region LeetCodeCN-443

        /// <summary>
        /// 三个指针，遍历读写
        /// </summary>
        /// <param name="chars"></param>
        /// <returns></returns>
        public static int Compress(char[] chars)
        {
            int anchor = 0, write = 0;
            for (int read = 0; read < chars.Length; read++)
            {
                if (read + 1 == chars.Length || chars[read + 1] != chars[read])
                {
                    chars[write] = chars[anchor];
                    write++;
                    if (read > anchor)
                    {
                        foreach(char c in (read-anchor+1).ToString())
                        {
                            chars[write] = c;
                            write++;
                        }
                    }

                    anchor = read + 1;
                }

            }

            return write;
        }

        #endregion

        #region LeetCodeCN-447

        public static int NumberOfBoomerangs(int[][] points)
        {
            var kv = new Hashtable();
            int result = 0;
            for (int i = 0; i < points.Length; i++)
            {
                kv.Clear();
                for (int j = 0; j < points.Length; j++)
                {
                    if (i == j)
                    {
                        continue;
                    }

                    int distance = (points[i][0] - points[j][0]) * (points[i][0] - points[j][0]) +
                                   (points[i][1] - points[j][1]) * (points[i][1] - points[j][1]);

                    if (kv.ContainsKey(distance))
                    {
                        result += (int) kv[distance] * 2;
                        kv[distance] = (int) kv[distance] + 1;
                    }
                    else
                    {
                        kv.Add(distance,1);
                    }
                }
            }

            return result;

        }

        #endregion

        #region LeetCodeCN-448

        public static IList<int> FindDisappearedNumbers(int[] nums)
        {

            #region 空间复杂度O(1) 时间复杂度O(n)
            //for (int i = 0; i < nums.Length; i++)
            //{
            //    int newIndex = Math.Abs(nums[i])-1;
            //    if (nums[newIndex] > 0)
            //    {
            //        nums[newIndex] *= -1;
            //    }
            //}

            //IList<int> res = new List<int>();

            //for (int i = 1; i <= nums.Length; i++)
            //{
            //    if (nums[i - 1] > 0)
            //    {
            //        res.Add(i);
            //    }
            //}

            //return res;
            #endregion

            #region 空间复杂度O(n)时间复杂度O(n)

            var kv = new Hashtable();
            for (int i = 0; i < nums.Length; i++)
            {
                if(!kv.ContainsKey(nums[i]))
                    kv.Add(nums[i],true);
            }

            IList<int> res = new List<int>();

            for (int i = 1; i <= nums.Length; i++)
            {
                if (!kv.ContainsKey(i))
                {
                    res.Add(i);
                }
            }

            return res;

            #endregion
        }

        #endregion

        #region LeetCodeCN-453(数学规律题，无意义)

        public static int MinMoves(int[] nums)
        {
            int moves = 0, min = int.MaxValue;
            foreach (var t in nums)
            {
                min = Math.Min(min, t);
            }
            foreach (var t in nums)
            {
                moves += t - min;
            }
            return moves;
        }

        #endregion

        #region LeetCodeCN-455

        /// <summary>
        /// 贪心算法，先对两个数组排序，然后从小到大依次比较满足
        /// </summary>
        /// <param name="g"></param>
        /// <param name="s"></param>
        /// <returns></returns>
        public static int FindContentChildren(int[] g, int[] s)
        {
            if (g.Length == 0 || s.Length == 0)
                return 0;
            Array.Sort(g);
            Array.Sort(s);

            int gIndex = 0, sIndex = 0;
            while (gIndex < g.Length && sIndex < s.Length)
            {
                if (g[gIndex] <= s[sIndex])
                {
                    gIndex++;
                }

                sIndex++;
            }

            return gIndex;
        }

        #endregion

        #region LeetCodeCN-459
        //https://leetcode-cn.com/problems/repeated-substring-pattern/solution/guan-yu-gou-zao-ssjin-xing-pan-duan-de-zheng-ming-/
        public static bool RepeatedSubstringPattern(string s)
        {
            var str = s + s;
            return str.Substring(1, str.Length - 2).Contains(s); 
        }

        #endregion

        #region LeetCodeCN-461

        public static int HammingDistance(int x, int y)
        {
            return BitCount(x ^ y);
        }


        private static int BitCount(int i)
        {
            int count = 0;
            while (i != 0)
            {
                count++;
                i = (i - 1) & i;
            }
            return count;
        }
        #endregion

        #region LeetCodeCN-463
        //https://leetcode-cn.com/problems/island-perimeter/solution/chang-gui-jie-fa-javashi-xian-by-lyl0724-2/
        public static int IslandPerimeter(int[][] grid)
        {
            int sum = 0;
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[0].Length; j++)
                {
                    if (grid[i][j] == 1)
                    {
                        int lines = 4;
                        //判断这个岛旁边连接了多少个岛
                        if (i > 0 && grid[i - 1][j] == 1) lines--;
                        if (i < grid.Length - 1 && grid[i + 1][j] == 1) lines--;
                        if (j > 0 && grid[i][j - 1] == 1) lines--;
                        if (j < grid[0].Length - 1 && grid[i][j + 1] == 1) lines--;
                        sum += lines;
                    }
                }
            }
            return sum;

        }

        #endregion
    }
}

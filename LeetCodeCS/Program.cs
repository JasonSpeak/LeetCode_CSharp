using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using LeetCodeCS.DataStructure;

namespace LeetCodeCS
{
    public static class Program
    {
        public static void Main(string[] args)
        {

            int[] nums = {1, 3, 5, 6};
            int target = 7;

            Console.WriteLine($"res is {CountAndSay(4)}");
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
        public class ListNode
        {
            public int Val;
            public ListNode Next;

            public ListNode(int x)
            {
                Val = x;
            }
        }

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
    }
}

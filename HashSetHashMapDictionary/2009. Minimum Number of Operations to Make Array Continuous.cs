//Leetcode 2009. Minimum Number of Operations to Make Array Continuous hard
//题意：给定一个整数数组 nums，每次操作可以用任意整数替换数组中的任意一个元素。如果数组 nums 满足以下条件，则被视为连续：
//数组中的所有元素都是唯一的。
//数组中的最大元素与最小元素之间的差值等于数组长度减 1。
//例如，nums = [4, 2, 5, 3] 是连续的，但 nums = [1, 2, 3, 5, 6] 不是连续的。
//返回使连续 的最小操作数。nums
//思路：hashtable，先把nums找出不重复的，然后sort
//根据每个i num[i] 找到j num[j] newNums[j] - newNums[i] = n -1
//然后找到最小值
//时间复杂度：O(n)
//空间复杂度：O(n)
        public int MinOperations_2009(int[] nums)
        {
            int n = nums.Length;
            int ans = n;

            HashSet<int> unique = new HashSet<int>();
            foreach (int num in nums)
            {
                unique.Add(num);
            }

            int[] newNums = new int[unique.Count];
            int index = 0;

            foreach (int num in unique)
            {
                newNums[index++] = num;
            }

            Array.Sort(newNums);

            int j = 0;
            for (int i = 0; i < newNums.Length; i++)
            {
                while (j < newNums.Length && newNums[j] < newNums[i] + n)
                {
                    j++;
                }

                int count = j - i;
                ans = Math.Min(ans, n - count);
            }

            return ans;
        }
//Leetcode 442. Find All Duplicates in an Array med
//题意：nums给定一个长度为 的整数数组n，其中 的所有整数都nums在范围内[1, n]，
//且每个整数最多出现 两次，返回出现两次的所有整数的数组。
//你必须编写一个按时运行O(n)且仅使用恒定辅助空间的算法，不包括存储输出所需的空间
//思路：用array存入每个数字出现个数，然后counts[i] == 2
//时间复杂度:  O(n)
//空间复杂度： O(1)
        public IList<int> FindDuplicates(int[] nums)
        {
            List<int> res = new List<int>();
            int n = nums.Length;
            int[] counts = new int[n + 1];
            foreach (int num in nums)
            {
                counts[num]++;
            }
            for (int i = 1; i < n + 1; i++)
            {
                if (counts[i] == 2)
                    res.Add(i);
            }
            return res;
        }
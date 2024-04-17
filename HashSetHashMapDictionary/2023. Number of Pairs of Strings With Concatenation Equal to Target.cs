//Leetcode 2023. Number of Pairs of Strings With Concatenation Equal to Target med
//题意：给定一个由数字字符串组成的数组 nums 和一个数字字符串 target，要求计算有多少对下标 (i, j)（其中 i != j），使得 nums[i] 和 nums[j] 的连接等于 target。
//思路：hashtable 用string.Concat 将每个string.Concat(nums[i], nums[j]); 或者 string.Concat(nums[j], nums[i]);
//然后只要满足条件就++；
//时间复杂度：O(n^2)
//空间复杂度：O(1)
        public int NumOfPairs(string[] nums, string target)
        {
            int result = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = 0; j < nums.Length && j != i; j++)
                {
                    string concated = string.Concat(nums[i], nums[j]);
                    if (concated == target)
                    {
                        result++;

                    }
                    concated = string.Concat(nums[j], nums[i]);
                    if (concated == target)
                    {
                        result++;
                    }
                }

            }
            return result;
        }
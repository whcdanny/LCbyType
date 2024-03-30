//Leetcode 2913. Subarrays Distinct Element Sum of Squares I ez
//题意：要求计算数组 nums 的所有子数组的不同元素数量的平方和
//思路：hashtable，用hashset存不同出现的数，然后从头一个一个找每个区间拥有不同元素的数量，然后平方；
//时间复杂度：O(n^2)
//空间复杂度：O(n)
        public int SumCounts(IList<int> nums)
        {
            int res = 0;
            for (int i = 0; i < nums.Count(); i++)
            {
                var hashset = new HashSet<int>();
                for (int j = i; j < nums.Count(); j++)
                {
                    hashset.Add(nums[j]);
                    res += hashset.Count() * hashset.Count();
                }
            }
            return res;
        }
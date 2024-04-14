//Leetcode 2261. K Divisible Elements Subarrays med
//题意：给定一个整数数组 nums 和两个整数 k 和 p，返回最多有 k 个元素被 p 整除的不同子数组的数量。
//两个数组 nums1 和 nums2 被认为是不同的，如果：
//它们的长度不同，或者
//至少存在一个索引 i，使得 nums1[i] != nums2[i]。
//子数组被定义为数组中连续的非空元素序列。
//思路：hashtable 从头开始，找k个满足被p整除的数组，然后组成string，然后用hashset存入，只留不重复的；        
//时间复杂度：O(n^2)
//空间复杂度：O(1)
        public int CountDistinct(int[] nums, int k, int p)
        {
            HashSet<string> hashSet = new HashSet<string>();

            for (int i = 0; i < nums.Length; i++)
            {
                StringBuilder sb = new StringBuilder();
                int count = 0;

                for (int j = i; j < nums.Length; j++)
                {
                    if (nums[j] % p == 0)
                    {
                        count++;
                    }

                    if (count > k)
                        break;

                    sb.Append(nums[j]).Append(",");
                    hashSet.Add(sb.ToString());
                }
            }

            return hashSet.Count;
        }
//Leetcode 2588. Count the Number of Beautiful Subarrays med
//题意：给定一个整数数组 nums（下标从 0 开始），每次操作可以选择数组中的两个不同下标 i 和 j（0 <= i, j < nums.length），
//然后选择一个非负整数 k，使得 nums[i] 和 nums[j] 的二进制表示中的第 k 位为 1，
//然后从 nums[i] 和 nums[j] 中减去 2^k。如果经过若干次操作后，一个子数组中的所有元素都变为 0，则称这个子数组为“beautiful”。
//思路：hashtable, 看code    
//时间复杂度：O(n))
//空间复杂度：O(n)
        public long BeautifulSubarrays(int[] nums)
        {
            int[] prefix = new int[nums.Length + 1];
            //存储前缀异或结果。在循环中，通过异或运算 prefix[i + 1] = prefix[i] ^ nums[i] 来计算前缀异或数组。
            for (int i = 0; i < nums.Length; ++i)
                prefix[i + 1] = prefix[i] ^ nums[i];
            //使用 LINQ 查询对前缀异或数组进行处理。它首先使用 GroupBy 方法按照异或值对前缀数组进行分组，然后对每个分组进行计数，得到该异或值出现的次数
            return prefix.GroupBy(item => item).Select(group => (long)group.Count()).Sum(count => count * (count - 1) / 2);
        }
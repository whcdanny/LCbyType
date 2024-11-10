//Leetcode 3162. Find the Number of Good Pairs I ez
//题目：你有两个整数数组 nums1 和 nums2，它们的长度分别是 n 和 m。你还得到一个正整数 k。
//定义一对(i, j) 为“好对”当且仅当 nums1[i] 能被 nums2[j] * k 整除（即 nums1[i] % (nums2[j] * k) == 0），其中 0 <= i <= n - 1 且 0 <= j <= m - 1。
//要求返回“好对”的总数。
//思路: 遍历所有可能的配对：由于题目要求每个 nums1[i] 和 nums2[j] 之间进行配对，所以我们可以使用双重循环遍历所有 (i, j) 对。
//检查整除条件：对于每个(i, j) 对，判断 nums1[i] 是否能被 nums2[j] * k 整除，即验证 nums1[i] % (nums2[j] * k) == 0。
//时间复杂度：O(n * m)，其中 n 是 nums1 的长度，m 是 nums2 的长度
//空间复杂度：O(1)
        public int NumberOfPairs(int[] nums1, int[] nums2, int k)
        {
            int goodPairsCount = 0;

            // 遍历 nums1 和 nums2 中的每个元素，找到满足条件的配对
            for (int i = 0; i < nums1.Length; i++)
            {
                for (int j = 0; j < nums2.Length; j++)
                {
                    // 检查 nums1[i] 是否可以被 nums2[j] * k 整除
                    if (nums1[i] % (nums2[j] * k) == 0)
                    {
                        goodPairsCount++;
                    }
                }
            }

            return goodPairsCount;
        }
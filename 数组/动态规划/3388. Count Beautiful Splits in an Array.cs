//Leetcode 3388. Count Beautiful Splits in an Array med
//题意：给定一个数组 nums，我们需要统计它的**美丽分割（beautiful splits）**的数量。
//美丽分割的定义：
//将数组 nums 分割成三个非空子数组 nums1，nums2 和 nums3，使得 nums = nums1 + nums2 + nums3。
//满足以下两个条件之一：
//子数组 nums1 是 nums2 的前缀。
//子数组 nums2 是 nums3 的前缀。
//要求：返回可以形成美丽分割的方法总数。
//思路：动态规划（Dynamic Programming）
//longestMatch[i, j] 表示从位置 i 开始到位置 j 开始的最长公共前缀长度
//动态转移:位置 i-1 和 j-1 的最长公共前缀已知为 longestMatch[i - 1, j - 1]，
//并且 nums[i] == nums[j]，则 longestMatch[i, j] = longestMatch[i - 1, j - 1] + 1。
//遍历每一个可能的分割点 i 和 j，将数组分割成三部分：
//nums1 = nums[0:i]，长度为 len1 = i。
//nums2 = nums[i:j]，长度为 len2 = j - i。
//nums3 = nums[j:n]，长度为 len3 = n - j。
//判断是否满足美丽分割条件：
//条件 1: 如果 nums1 是 nums2 的前缀，则需要验证 nums[0:i] 和 nums[i:j] 的前缀匹配长度是否等于 len1，即 longestMatch[i - 1, i - 1 + len1] == len1。
//条件 2: 如果 nums2 是 nums3 的前缀，则需要验证 nums[i:j] 和 nums[j:n] 的前缀匹配长度是否大于等于 len2，即 longestMatch[j - 1, j - 1 + len2] >= len2
//时间复杂度:  O(n^2)
//空间复杂度： O(n^2)
        public int BeautifulSplits(int[] nums)
        {
            int n = nums.Length;
            int[,] longestMatch = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if (nums[i] != nums[j])
                    {
                        continue;
                    }
                    longestMatch[i, j] = 1;
                    if (i > 0)
                    {
                        longestMatch[i, j] += longestMatch[i - 1, j - 1];
                    }
                }
            }
            int result = 0;
            for (int i = 1; i < n - 1; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    int len1 = i;
                    int len2 = j - i;
                    int len3 = n - j;
                    if (
                        (len1 <= len2 && longestMatch[i - 1, i - 1 + len1] == len1) ||
                        (len2 <= len3 && longestMatch[j - 1, j - 1 + len2] >= len2))
                    {
                        result++;
                    }
                }
            }
            return result;
        }
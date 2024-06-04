//Leetcode 2968. Apply Operations to Maximize Frequency Score hard
//题意：给定一个整数数组 nums 和一个整数 k，你可以对数组中的任意一个元素执行以下操作之一：
//将其增加 1
//将其减少 1
//不做任何操作
//你的目标是通过执行操作，使得数组中某个整数的频率（出现次数）尽可能高。返回可能的最高频率。
//思路：二分搜索法 + 滑窗 
//通过有限的操作得到更多相等的元素，我们必然会将这些操作集中在原本已经接近的元素上。
//所以我们将nums排序之后，必然是选取其中的一段subarray，将其变成同一个数。
//显然，由中位数的性质，想将一个数组中的所有元素变成同一个元素，那么变成他们的中位数median能够使得改动之和最小。
//二分搜索最大的subarray长度len。
//对于选定的len，我们在nums上走一遍固定长度的滑窗。
//对于每一个滑窗范围[i:j]，根据median性质，我们将其变为nums[(i + j) / 2] 是最高效的做法。
//令中位数的index是m，那么我们就可以知道区间[i:j] 所需要的改动就是两部分之和 
//sum[m:j]-nums[m]*(j-m+1) + nums[m]*(m-i+1)-sum[i:m]. 其中区间和可以用前缀和数组来实现。
//如果存在一个滑窗使得其需要的改动小于等于k，那么说明len是可行的。
//我们可以再尝试更大的滑窗，否则尝试更小的滑窗。
//时间复杂度：O(NLogn)
//空间复杂度：O(n)
        public int MaxFrequencyScore(int[] nums, long k)
        {
            int n = nums.Length;
            Array.Sort(nums);
            int[] newNums = new int[n + 1];
            newNums[0] = 0;
            for(int i = 1; i < n + 1; i++)
            {
                newNums[i] = nums[i - 1];
            }
            long[] preSum = new long[n+1];
            for(int i = 1; i <= n; i++)
            {
                preSum[i] = preSum[i - 1] + newNums[i];
            }
            int left = 1, right = n;
            while (left < right)
            {
                int mid = right - (right - left) / 2;
                if (isOK_MaxFrequencyScore(newNums, preSum, k, mid))
                    left = mid;
                else
                    right = mid - 1;
            }
            return left;
        }

        private bool isOK_MaxFrequencyScore(int[] nums, long[] preSum, long k, int len)
        {
            int n = nums.Length - 1;
            for(int i = 1; i + len - 1 <= n; i++)
            {
                long m = i + len / 2;
                long j = i + len - 1;
                long sum1 = nums[m] * (m - i + 1) - (preSum[m] - preSum[i - 1]);
                long sum2 = (preSum[j] - preSum[m - 1]) - nums[m] * (j - m + 1);
                if (sum1 + sum2 <= k)
                    return true;
            }
            return false;
        }
        //思路：动态滑窗 
        //通过有限的操作得到更多相等的元素，我们必然会将这些操作集中在原本已经接近的元素上。
        //所以我们将nums排序之后，必然是选取其中的一段subarray，将其变成同一个数。
        //显然，由中位数的性质，想将一个数组中的所有元素变成同一个元素，那么变成他们的中位数median能够使得改动之和最小。
        //固定左边界i之后，我们可以右移右边界j，直至区间[i:j] 所需要的改动大于k。
        //此时j-i就是一个可行的区间长度。然后再移动一格左边界i，找到下一个合适的j。
        //对于每一个滑窗范围[i:j]，根据median性质，我们将其变为nums[(i + j) / 2] 是最高效的做法。
        //令中位数的index是m，那么我们就可以知道区间[i:j] 所需要的改动就是两部分之和 
        //sum[m:j]-nums[m]*(j-m+1) + nums[m]*(m-i+1)-sum[i:m]. 其中区间和可以用前缀和数组来实现。
        //如果存在一个滑窗使得其需要的改动小于等于k，那么说明j可行；
        //我们可以再尝试更大的滑窗，否则尝试更小的滑窗。
        //时间复杂度：O(n)
        //空间复杂度：O(n)
        public int MaxFrequencyScore1(int[] nums, long k)
        {
            int n = nums.Length;
            Array.Sort(nums);
            int[] newNums = new int[n + 1];
            newNums[0] = 0;
            for (int i = 1; i < n + 1; i++)
            {
                newNums[i] = nums[i - 1];
            }
            long[] preSum = new long[n + 1];
            for (int i = 1; i <= n; i++)
            {
                preSum[i] = preSum[i - 1] + newNums[i];
            }
            int j = 1;
            int res = 0;
            for(int i = 1; i <= n; i++)
            {
                while(j<=n&& isOK_MaxFrequencyScore1(newNums, preSum, i, j, k))
                {
                    res = Math.Max(res, j - i + 1);
                    j++;
                }
            }
            return res;
        }

        private bool isOK_MaxFrequencyScore1(int[] nums, long[] preSum, int i, int j, long k)
        {
            int m = (i + j) / 2;
            long sum1 = nums[m] * (m - i + 1) - (preSum[m] - preSum[i - 1]);
            long sum2 = (preSum[j] - preSum[m - 1]) - nums[m] * (j - m + 1);
            return sum1 + sum2 <= k;
        }
//Leetcode 1498. Number of Subsequences That Satisfy the Given Sum Condition med
//题意：给定一个整数数组 nums 和一个整数 target。
//返回满足以下条件的 nums 子序列的数量：子序列中最小和最大元素的和小于或等于 target。由于答案可能太大，返回它对 10^9 + 7 取模的结果。
//思路：双指针，先排序，两个指针 left 和 right 分别指向数组的两端。
//循环条件是 left 小于数组长度，即还有元素可选。
//如果当前最小元素和最大元素的和小于或等于 target，则更新结果，并将 left 右移（考虑下一个最小元素）。
//否则，将 right 左移（考虑较小的最大元素）。
//要算出每一个位置的可能性，也就是说在区间中每个元素存在选或者不选所以是2^(j-i);
//时间复杂度：O(max(N, M))，其中 N 和 M 分别是两个数组的长度。
//空间复杂度：O(1)
        public int NumSubseq(int[] nums, int target)
        {
            Array.Sort(nums);
            int n = nums.Length;
            long M = 1000000007;
            long ret = 0;
            long[] power = new long[n + 1];
            power[0] = 1;

            //2^(j-i)
            for (int i = 1; i <= n; i++)
            {
                power[i] = (power[i - 1] * 2) % M;
            }

            int j = n - 1;
            for (int i = 0; i < n; i++)
            {
                while (j >= 0 && nums[i] + nums[j] > target)
                {
                    j--;
                }

                if (j < i)
                {
                    break;
                }

                ret = (ret + power[j - i]) % M;
            }

            return (int)ret;
        }
        //思路：两个指针 left 和 right 分别指向数组的两端。
        //循环条件是 left 小于数组长度，即还有元素可选。
        //如果当前最小元素和最大元素的和小于或等于 target，则更新结果，并将 left 右移（考虑下一个最小元素）。
        //否则，将 right 左移（考虑较小的最大元素）。
        public int NumSubseq1(int[] nums, int target)
        {
            Array.Sort(nums);
            long mod = 1000000007;
            long result = 0;
            long left = 0, right = nums.Length - 1;

            while (left <= right)
            {
                if (nums[left] + nums[right] <= target)
                {
                    result = (result + Pow_NumSubseq(2, right - left, mod)) % mod;
                    left++;
                }
                else
                {
                    right--;
                }
            }

            return (int)result;
        }
        private long Pow_NumSubseq(long x, long y, long mod)
        {
            long result = 1;
            while (y > 0)
            {
                if (y % 2 == 1)
                {
                    result = (result * x) % mod;
                }
                x = (x * x) % mod;
                y /= 2;
            }
            return result;
        }
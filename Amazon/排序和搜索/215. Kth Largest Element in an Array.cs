//215. Kth Largest Element in an Array med
//题目：给定一个整数数组nums和一个整数k，返回数组中最大的元素 。kth
//请注意，它是排序顺序中最大的元素，而不是不同的元素。kthkth
//不经过排序你能解决吗？
//思路：最简单就是排序然后找nums.Length - k
//时间复杂度:O(logn)
//空间复杂度： O(1)
	public int FindKthLargest(int[] nums, int k) {
        Array.Sort(nums);
        return nums[nums.Length - k];
    }
        public int FindKthLargest1(int[] nums, int k)
        {
            int lo = 0, hi = nums.Length - 1;
            // 转化成「排名第 k 的元素」
            k = nums.Length - k;
            while (lo <= hi)
            {
                // 在 nums[lo..hi] 中选一个分界点
                int p = partition(nums, lo, hi);
                if (p < k)
                {
                    // 第 k 大的元素在 nums[p+1..hi] 中
                    lo = p + 1;
                }
                else if (p > k)
                {
                    // 第 k 大的元素在 nums[lo..p-1] 中
                    hi = p - 1;
                }
                else
                {
                    // 找到第 k 大元素
                    return nums[p];
                }
            }
            return -1;
        }
        // 对 nums[lo..hi] 进行切分
        public static int partition(int[] nums, int lo, int hi)
        {
            int pivot = nums[lo];
            // 关于区间的边界控制需格外小心，稍有不慎就会出错
            // 我这里把 i, j 定义为开区间，同时定义：
            // [lo, i) <= pivot；(j, hi] > pivot
            // 之后都要正确维护这个边界区间的定义
            int i = lo + 1, j = hi;
            // 当 i > j 时结束循环，以保证区间 [lo, hi] 都被覆盖
            while (i <= j)
            {
                while (i < hi && nums[i] <= pivot)
                {
                    i++;
                    // 此 while 结束时恰好 nums[i] > pivot
                }
                while (j > lo && nums[j] > pivot)
                {
                    j--;
                    // 此 while 结束时恰好 nums[j] <= pivot
                }
                // 此时 [lo, i) <= pivot && (j, hi] > pivot

                if (i >= j)
                {
                    break;
                }
                swap(nums, i, j);
            }
            // 将 pivot 放到合适的位置，即 pivot 左边元素较小，右边元素较大
            swap(nums, lo, j);
            return j;
        }

        // 原地交换数组中的两个元素
        public static void swap(int[] nums, int i, int j)
        {
            int temp = nums[i];
            nums[i] = nums[j];
            nums[j] = temp;
        }
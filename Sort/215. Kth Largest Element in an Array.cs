//215. Kth Largest Element in an Array med
//找出所给的乱序数组中 倒数第k个大的；
//思路：快速选择算法，找倒数第k个就是找正数nums.Length - K；所以根据快速排序的逻辑，选出的数的位置左边都是小于这个数，反之右边都是大于的；然后将这个得到的位置跟我们要找的nums.Length - K去比较；
		public int FindKthLargest(int[] nums, int k)
        {                        
            int lo = 0, hi = nums.Length - 1;
            // 转化成「排名第 k 的元素」
            k = nums.Length - k;
            while (lo <= hi)
            {
                // 在 nums[lo..hi] 中选一个分界点
                int p = Quick.partition(nums, lo, hi);
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
		
		class Quick
        {

            public static void sort(int[] nums)
            {
                // 为了避免出现耗时的极端情况，先随机打乱
                shuffle(nums);
                // 排序整个数组（原地修改）
                sort(nums, 0, nums.Length - 1);
            }

            private static void sort(int[] nums, int lo, int hi)
            {
                if (lo >= hi)
                {
                    return;
                }
                // 对 nums[lo..hi] 进行切分
                // 使得 nums[lo..p-1] <= nums[p] < nums[p+1..hi]
                int p = partition(nums, lo, hi);

                sort(nums, lo, p - 1);
                sort(nums, p + 1, hi);
            }

            // 对 nums[lo..hi] 进行切分
            private static int partition(int[] nums, int lo, int hi)
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

            // 洗牌算法，将输入的数组随机打乱
            private static void shuffle(int[] nums)
            {
                Random rand = new Random();
                int n = nums.Length;
                for (int i = 0; i < n; i++)
                {
                    // 生成 [i, n - 1] 的随机数
                    int r = i + rand.Next(n - i);
                    swap(nums, i, r);
                }
            }

            // 原地交换数组中的两个元素
            private static void swap(int[] nums, int i, int j)
            {
                int temp = nums[i];
                nums[i] = nums[j];
                nums[j] = temp;
            }
        }
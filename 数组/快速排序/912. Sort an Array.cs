//912. Sort an Array med
//给一个不规律数组，让你从小到大排序
//思路：类似二叉树的二分法，将整个二分一直二分到个位，然后进行排序，然后进行合并，合并时用到双指针
		class Merge
        {

            // 用于辅助合并有序数组
            private static int[] temp;

            public static void sort(int[] nums)
            {
                // 先给辅助数组开辟内存空间
                temp = new int[nums.Length];
                // 排序整个数组（原地修改）
                sort(nums, 0, nums.Length - 1);
            }

            // 定义：将子数组 nums[lo..hi] 进行排序
            private static void sort(int[] nums, int lo, int hi)
            {
                if (lo == hi)
                {
                    // 单个元素不用排序
                    return;
                }
                // 这样写是为了防止溢出，效果等同于 (hi + lo) / 2
                int mid = lo + (hi - lo) / 2;
                // 先对左半部分数组 nums[lo..mid] 排序
                sort(nums, lo, mid);
                // 再对右半部分数组 nums[mid+1..hi] 排序
                sort(nums, mid + 1, hi);
                // 将两部分有序数组合并成一个有序数组
                merge(nums, lo, mid, hi);
            }

            // 将 nums[lo..mid] 和 nums[mid+1..hi] 这两个有序数组合并成一个有序数组
            private static void merge(int[] nums, int lo, int mid, int hi)
            {
                // 先把 nums[lo..hi] 复制到辅助数组中
                // 以便合并后的结果能够直接存入 nums
                for (int k = lo; k <= hi; k++)
                {
                    temp[k] = nums[k];
                }

                // 数组双指针技巧，合并两个有序数组
                int i = lo, j = mid + 1;
                for (int p = lo; p <= hi; p++)
                {
                    if (i == mid + 1)
                    {
                        // 左半边数组已全部被合并
                        nums[p] = temp[j++];
                    }
                    else if (j == hi + 1)
                    {
                        // 右半边数组已全部被合并
                        nums[p] = temp[i++];
                    }
                    else if (temp[i] > temp[j])
                    {
                        nums[p] = temp[j++];
                    }
                    else
                    {
                        nums[p] = temp[i++];
                    }
                }
            }
        }

        public int[] SortArray(int[] nums)
        {
            Merge.sort(nums);
            return nums;
        }
		
//快速排序方法：根据选出来的数，通过搜索和比较大小来switch得到左边全部小于，右边全部大于，这样就找到了分割数，然后再递归；		
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
        public int[] SortArray(int[] nums)
        {
            Quick.sort(nums);
            return nums;
        }
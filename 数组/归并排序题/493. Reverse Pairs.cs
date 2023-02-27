//493. Reverse Pairs hard
//给一个数组，如果i<j 并且 nums[i]>2*nums[j]就是pairs，输出pairs个数；
//思路：还是在二分排序的过程中，然后从右侧区间里找右侧区间满足条件的；
		// 记录「翻转对」的个数
        int count1 = 0;
        public int ReversePairs(int[] nums)
        {
            // 执行归并排序
            sort(nums);
            return count1;
        }
        private int[] temp1;

        public void sort(int[] nums)
        {
            temp1 = new int[nums.Length];
            sort(nums, 0, nums.Length - 1);
        }

        // 归并排序
        private void sort(int[] nums, int lo, int hi)
        {
            if (lo == hi)
            {
                return;
            }
            int mid = lo + (hi - lo) / 2;
            sort(nums, lo, mid);
            sort(nums, mid + 1, hi);
            merge(nums, lo, mid, hi);
        }    
        private void merge(int[] nums, int lo, int mid, int hi)
        {
            for (int k = lo; k <= hi; k++)
            {
                temp1[k] = nums[k];
            }

            // 进行效率优化，维护左闭右开区间 [mid+1, end) 中的元素乘 2 小于 nums[i]
            // 为什么 end 是开区间？因为这样的话可以保证初始区间 [mid+1, mid+1) 是一个空区间
            int end = mid + 1;
            for (int l = lo; l <= mid; l++)
            {
                // nums 中的元素可能较大，乘 2 可能溢出，所以转化成 long
                while (end <= hi && (long)nums[l] > (long)nums[end] * 2)
                {
                    end++;
                }
                count1 += end - (mid + 1);
            }

            // 数组双指针技巧，合并两个有序数组
            int i = lo, j = mid + 1;
            for (int p = lo; p <= hi; p++)
            {
                if (i == mid + 1)
                {
                    nums[p] = temp1[j++];
                }
                else if (j == hi + 1)
                {
                    nums[p] = temp1[i++];
                }
                else if (temp1[i] > temp1[j])
                {
                    nums[p] = temp1[j++];
                }
                else
                {
                    nums[p] = temp1[i++];
                }
            }
        }
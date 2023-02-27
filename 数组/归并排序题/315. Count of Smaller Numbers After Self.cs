//315. Count of Smaller Numbers After Self hard
//算出右侧小于自己的数的个数；
//思路：还是按照二分法排序，只不过在比较大小时，如果下于或者右半边的数都存入之和左半边还有数，这种情况下证明有比当前数小的数，数值为j - mid - 1；思路能理解但是还是很难算出来
		class Pair
        {
            public int val, id;
            public Pair(int val, int id)
            {
                // 记录数组的元素值
                this.val = val;
                // 记录元素在数组中的原始索引
                this.id = id;
            }
        }

        // 归并排序所用的辅助数组
        private Pair[] temp;
        // 记录每个元素后面比自己小的元素个数
        private int[] count;

        // 主函数
        public IList<int> CountSmaller(int[] nums)
        {
            int n = nums.Length;
            count = new int[n];
            temp = new Pair[n];
            Pair[] arr = new Pair[n];
            // 记录元素原始的索引位置，以便在 count 数组中更新结果
            for (int i = 0; i < n; i++)
                arr[i] = new Pair(nums[i], i);

            // 执行归并排序，本题结果被记录在 count 数组中
            sort(arr, 0, n - 1);

            List<int> res = new List<int>();
            foreach (int c in count) res.Add(c);
            return res;
        }

        // 归并排序
        private void sort(Pair[] arr, int lo, int hi)
        {
            if (lo == hi) return;
            int mid = lo + (hi - lo) / 2;
            sort(arr, lo, mid);
            sort(arr, mid + 1, hi);
            merge(arr, lo, mid, hi);
        }

        // 合并两个有序数组
        private void merge(Pair[] arr, int lo, int mid, int hi)
        {
            for (int K = lo; K <= hi; K++)
            {
                temp[K] = arr[K];
            }

            int i = lo, j = mid + 1;
            for (int p = lo; p <= hi; p++)
            {
                if (i == mid + 1)
                {
                    arr[p] = temp[j++];
                }
                else if (j == hi + 1)
                {
                    arr[p] = temp[i++];
                    // 更新 count 数组
                    count[arr[p].id] += j - mid - 1;
                }
                else if (temp[i].val > temp[j].val)
                {
                    arr[p] = temp[j++];
                }
                else
                {
                    arr[p] = temp[i++];
                    // 更新 count 数组
                    count[arr[p].id] += j - mid - 1;
                }
            }
        }
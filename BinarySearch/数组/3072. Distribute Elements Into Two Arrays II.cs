//Leetcode 3072. Distribute Elements Into Two Arrays II hard
//题目：给定一个 1-索引 的整数数组 nums，其长度为 n。
//定义一个函数 greaterCount(arr, val)，其返回值是 arr 中严格大于 val 的元素个数。
//需要通过 n 次操作，将 nums 的所有元素分配到两个数组 arr1 和 arr2 中，分配规则如下：
//第一次操作：将 nums[1] 添加到 arr1。
//第二次操作：将 nums[2] 添加到 arr2。
//从第 3 次操作起：    
//如果 greaterCount(arr1, nums[i]) > greaterCount(arr2, nums[i])，将 nums[i] 添加到 arr1。
//如果 greaterCount(arr1, nums[i]) < greaterCount(arr2, nums[i])，将 nums[i] 添加到 arr2。
//如果两者相等，则将 nums[i] 添加到元素较少的数组。
//如果数组大小也相等，将 nums[i] 添加到 arr1。
//最终，将 arr1 和 arr2 拼接成结果数组 result 并返回。
//思路: 二分搜索，用两个list存入arr1和arr2的相对应位置和对应数字，
//当读取nums[i]的时候，用二分搜索找出在arr1和arr2对应的位置，
//表示找出比nums[i]大的个数，
//然后如果val1 > val2 arr1放入，反之arr2，如果位置一样，那么就插入个数最少的arr
//时间复杂度：O(n)
//空间复杂度：O(n)
        public int[] ResultArray1(int[] nums)
        {
            var arr1 = new List<(int idx, int val)>();
            var arr2 = new List<(int idx, int val)>();

            arr1.Add((0, nums[0]));
            arr2.Add((0, nums[1]));
            int size1 = 1, size2 = 1;

            int n = nums.Length;
            for (int i = 2; i < n; i++)
            {
                int idx1 = bsCounter(arr1, nums[i], size1);
                int idx2 = bsCounter(arr2, nums[i], size2);
                //用二分搜索找出比nums[i]大的个数
                int val1 = size1 - idx1;
                int val2 = size2 - idx2;

                if (val1 > val2)
                {
                    arr1.Insert(idx1, (size1, nums[i]));
                    size1++;
                }
                else if (val1 < val2)
                {
                    arr2.Insert(idx2, (size2, nums[i]));
                    size2++;
                }
                else
                {
                    if (size1 <= size2)
                    {
                        arr1.Insert(idx1, (size1, nums[i]));
                        size1++;
                    }
                    else
                    {
                        arr2.Insert(idx2, (size2, nums[i]));
                        size2++;
                    }
                }
            }

            int[] res = new int[n];            
            foreach (var curr in arr1)
            {
                res[curr.idx] = curr.val;
            }
            foreach (var curr in arr2)
            {
                res[size1 + curr.idx] = curr.val;
            }

            return res;
        }
        private int bsCounter(List<(int idx, int val)> list, int val, int size)
        {
            int res = size, left = 0, right = size - 1;
            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                var curr = list[mid];
                if (curr.val > val)
                {
                    res = mid;
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }
            return res;
        }
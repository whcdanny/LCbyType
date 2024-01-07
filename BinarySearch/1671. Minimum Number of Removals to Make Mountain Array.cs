//Leetcode 1671. Minimum Number of Removals to Make Mountain Array hard
//题意：题目要求判断一个数组是否可以通过移除一些元素，使得剩余的数组成为“山脉数组”（Mountain Array）。山脉数组的定义是：存在一个索引 i，使得 0 < i < n-1，并且满足：
//arr[0] < arr[1] < ... < arr[i - 1] < arr[i]
//arr[i] > arr[i + 1] > ... > arr[arr.length - 1]
//其中，arr 是给定的数组，n 是数组的长度。
//思路：用二分法：这题是找到这个i，然后确定i左半部分为递增，i右半部分为递减，
//算左半部的，如果插入当前数，如果比我们现有的list大，就直接接在后面，然后存入当前递增的个数，如果没有最后一个大，用二分法，然后找到第一个大于等于当前数nums[i]，然后更换list的值，然后存入当前递增的个数；
//算右半部分，从右往左，算法跟左半部分一样；
//然后再历遍i，然后找到最大现有的最多的递增和递减的数量，然后总长度-这个最大，然后就是最小；        
//时间复杂度: O(N log N)，其中 N 是数组的长度
//空间复杂度：O(n)
        public int MinimumMountainRemovals(int[] nums)
        {
            int n = nums.Length;
            int[] leftList = new int[n], rightList = new int[n];
            List<int> list = new List<int>();
            list.Add(nums[0]);

            for (int i = 1; i < n; i++)
            {
                if (nums[i] > list[list.Count - 1])
                {
                    list.Add(nums[i]);
                    leftList[i] = list.Count;
                }
                else
                {
                    int idx = lowerBound_MinimumMountainRemovals(list, nums[i]);
                    list[idx]= nums[i];
                    leftList[i] = idx + 1;
                }
            }
            list.Clear();
            list.Add(nums[n - 1]);

            for (int i = n - 2; i >= 0; i--)
            {
                if (nums[i] > list[list.Count - 1])
                {
                    list.Add(nums[i]);
                    rightList[i] = list.Count;
                }
                else
                {
                    int idx = lowerBound_MinimumMountainRemovals(list, nums[i]);
                    list[idx] = nums[i];
                    rightList[i] = idx + 1;
                }
            }

            int ans = 0;
            for (int i = 1; i < n - 1; i++)
            {
                if (leftList[i] > 1 && rightList[i] > 1)
                {
                    ans = Math.Max(ans, leftList[i] + rightList[i] - 1);
                }
            }

            return nums.Length - ans;
        }

        private int lowerBound_MinimumMountainRemovals(List<int> list, int target)
        {
            int left = 0, right = list.Count;
            while (left < right)
            {
                int m = (left + right) / 2;
                if (list[m] < target)
                    left = m + 1;
                else
                    right = m;
            }
            return left;            
        }
        //思路：由于要移除最少的元素，我们可以考虑对每一个可能的山脉顶点 i 进行分析，然后计算需要移除的元素数目。
        //对于每个可能的山脉顶点 i，我们可以通过左右两边的递增和递减序列来计算需要移除的元素数目。
        //用二分查找的方式寻找可能的山脉顶点，然后对每个可能的山脉顶点 i 进行计算，得到最小的移除元素数目。  
        //时间复杂度: O(n^2)，其中 N 是数组的长度
        //空间复杂度：O(n)
        public int MinimumMountainRemovals1(int[] nums)
        {
            int n = nums.Length;
            int[] lis = new int[n];
            int[] lds = new int[n];

            Array.Fill(lis, 1);
            Array.Fill(lds, 1);

            // Calculate Longest Increasing Subsequence (LIS)
            for (int i = 1; i < n; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (nums[i] > nums[j])
                    {
                        lis[i] = Math.Max(lis[i], lis[j] + 1);
                    }
                }
            }

            // Calculate Longest Decreasing Subsequence (LDS)
            for (int i = n - 2; i >= 0; i--)
            {
                for (int j = n - 1; j > i; j--)
                {
                    if (nums[i] > nums[j])
                    {
                        lds[i] = Math.Max(lds[i], lds[j] + 1);
                    }
                }
            }

            int result = n;

            // Iterate through possible mountain top indices
            for (int i = 1; i < n - 1; i++)
            {
                // Check if nums[i] is a possible mountain top
                if (lis[i] > 1 && lds[i] > 1)
                {
                    // Calculate total elements to remove
                    int removals = n - (lis[i] + lds[i] - 1);
                    result = Math.Min(result, removals);
                }
            }

            return result;
        }
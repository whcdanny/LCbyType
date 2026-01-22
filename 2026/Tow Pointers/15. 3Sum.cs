//Leetcode 15. 3Sum med
//题意：给一个nums让 [nums[i], nums[j], nums[k]] 保证 i != j, i != k, and j != k, 
//nums[i] + nums[j] + nums[k] == 0.
//思路：双针+排序，i,left(i+1),right(length-1)然后找出sum，如果<sum,
//剪枝优化 (Pruning)        
//正数起始：nums[i] > 0，由于升序的，后面任何三个数之和都必然大于 0，break。
//当前最小和过大：nums[i] + nums[i + 1] + nums[i + 2] > 0，则后续不可能再找到更小的和， break。
//当前最大和过小：nums[i] + nums[last] + nums[last - 1] < 0，当前的 nums[i] 太小了，continue
//时间复杂度: O(nlogn) + O(n^2) = O(n^2)
//空间复杂度：O(logn)（主要用于排序）。
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            var res = new List<IList<int>>();
            int len = nums.Length;
            if (len < 3) return res;

            Array.Sort(nums);

            for (int i = 0; i < len - 2; i++)
            {
                // 优化 1: 如果最小的数大于 0，后面不可能相加等于 0
                if (nums[i] > 0) 
                    break;

                // 优化 2: 跳过重复值
                if (i > 0 && nums[i] == nums[i - 1]) 
                    continue;

                // 优化 3: 最小和剪枝
                if (nums[i] + nums[i + 1] + nums[i + 2] > 0) 
                    break;

                // 优化 4: 最大和剪枝
                if (nums[i] + nums[len - 1] + nums[len - 2] < 0) 
                    continue;

                int left = i + 1;
                int right = len - 1;

                while (left < right)
                {
                    int sum = nums[i] + nums[left] + nums[right];
                    if (sum == 0)
                    {
                        res.Add(new List<int> { nums[i], nums[left], nums[right] });

                        // 跳过重复的 left 和 right
                        while (left < right && nums[left] == nums[++left]) ;
                        while (left < right && nums[right] == nums[--right]) ;
                    }
                    else if (sum < 0)
                    {
                        // 也可以在这里跳过重复值
                        while (left < right && nums[left] == nums[++left]) ;
                    }
                    else
                    {
                        while (left < right && nums[right] == nums[--right]) ;
                    }
                }
            }
            return res;
        }
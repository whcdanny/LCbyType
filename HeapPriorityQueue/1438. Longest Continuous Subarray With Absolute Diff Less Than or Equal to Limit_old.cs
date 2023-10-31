//1438. Longest Continuous Subarray With Absolute Diff Less Than or Equal to Limit med
//是一个求解满足条件的最长连续子数组长度的
//思路：双指针和双端队列（Deque）来解决这个问题。双指针维护了子数组的左右边界，双端队列用来维护当前子数组的最大值和最小值；
        public int LongestSubarray(int[] nums, int limit)
        {
            int n = nums.Length;
            int left = 0, right = 0;
            int maxLength = 0;
            var maxQueue = new LinkedList<int>();
            var minQueue = new LinkedList<int>();

            while (right < n)
            {
                // 维护最大值队列（从大到小）
                while (maxQueue.Count > 0 && nums[right] > maxQueue.Last.Value)
                    maxQueue.RemoveLast();
                maxQueue.AddLast(nums[right]);

                // 维护最小值队列（从小到大）
                while (minQueue.Count > 0 && nums[right] < minQueue.Last.Value)
                    minQueue.RemoveLast();
                minQueue.AddLast(nums[right]);

                // 判断当前子数组的最大值和最小值的差是否满足条件
                while (maxQueue.First.Value - minQueue.First.Value > limit)
                {
                    if (maxQueue.First.Value == nums[left])
                        maxQueue.RemoveFirst();
                    if (minQueue.First.Value == nums[left])
                        minQueue.RemoveFirst();
                    left++;
                }

                // 更新最长子数组的长度
                maxLength = Math.Max(maxLength, right - left + 1);

                right++;
            }

            return maxLength;
        }
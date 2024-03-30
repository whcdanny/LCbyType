//Leetcode 2869. Minimum Operations to Collect Elements ez
//题意：计算收集元素 1 到 k 所需的最小操作次数，每次操作可以移除数组的最后一个元素并将其添加到集合中。
//思路：hashtable，用hashset来存总共的出现的1..k
//如果当前数<= k，放入，然后如果当前hashSet.Count == k，就有nums.Count - i的operation        
//时间复杂度：O(n)
//空间复杂度：O(n)
        public int MinOperations(IList<int> nums, int k)
        {
            var hashSet = new HashSet<int>();

            for (var i = nums.Count - 1; i >= 0; i--)
            {
                if (nums[i] <= k)
                {
                    hashSet.Add(nums[i]);

                    if (hashSet.Count == k)
                    {
                        return nums.Count - i;
                    }
                }
            }

            return nums.Count;
        }

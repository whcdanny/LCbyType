//Leetcode 2537. Count the Number of Good Subarrays med
//题意：给定一个整数数组 nums 和一个整数 k，返回 nums 的好子数组的数量。
//一个子数组 arr 被认为是好的，如果存在至少 k 对下标(i, j) 满足 i<j 且 arr[i] == arr[j]。
//思路：hashtable, sliding window,用Dictionary来做window
//不断更新有边界，直到满足k，然后[left，right]当前满足，所以到ms.Length-1都可以所以是res += n - right + 1;        
//时间复杂度：O(n) 
//空间复杂度：O(n)
        public long CountGood(int[] nums, int k)
        {
            long res = 0, pairs = 0, n = nums.Length;
            Dictionary<int, int> window = new Dictionary<int, int>();
            for (int left = 0, right = 0; right < n;)
            {
                while (right < n && pairs < k)
                {
                    if (!window.ContainsKey(nums[right]))
                        window.Add(nums[right], 0);
                    pairs += window[nums[right]];
                    window[nums[right]]++;
                    right++;
                }
                while (pairs >= k)
                {
                    res += n - right + 1;
                    window[nums[left]]--;
                    pairs -= window[nums[left]];
                    left++;
                }
            }
            return res;
        }
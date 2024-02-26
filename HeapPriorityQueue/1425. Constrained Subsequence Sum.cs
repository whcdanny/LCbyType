//Leetcode 1425. Constrained Subsequence Sum hard
//题意：给定一个整数数组 nums 和一个整数 k，返回一个非空子序列的最大和，使得子序列中任意两个连续的整数 nums[i] 和 nums[j]，其中 i < j，满足条件 j - i <= k。
//思路：PriorityQueue 用pq存（位置，和当前最大sum）从大到小，然后每一次找到最大的值并且当前位置满足 j - i <= k；       
//时间复杂度: O(nk)，其中 n 为数组 nums 的长度
//空间复杂度：O(n)
        public int ConstrainedSubsetSum(int[] nums, int k)
        {
            var pq = new PriorityQueue<int, int>(Comparer<int>.Create((a, b) => b.CompareTo(a)));
            var ans = int.MinValue;

            pq.Enqueue(int.MaxValue, 0);

            for (var j = 0; j < nums.Length; ++j)
            {
                int sum;
                for (; pq.TryPeek(out var i, out sum) && i < j - k; pq.Dequeue()) ;
                ans = Math.Max(ans, nums[j] + sum);
                pq.Enqueue(j, nums[j] + sum);
            }

            return ans;
        }
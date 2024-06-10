//Leetcode 2856. Minimum Array Length After Pair Removals med
//题意：给定一个升序排序的整数数组 nums。可以进行以下操作任意次数：
//选择两个索引 i 和 j，其中 i<j 且 nums[i] < nums[j]。
//然后，从 nums 中移除索引为 i 和 j 的元素。剩余元素保持原始顺序，数组重新索引。
//要求返回在进行任意次操作后（包括零次）nums 的最小长度。
//注意：nums 是升序排列的。
//思路: 是Boyer-Moore Majority Voting Algorithm的实现。
//当存在一个超过半数的majority时，显然其他所有元素“联合”起来不能使它“消除”。
//反过来的结论也是成立的。
//当存在一个超过半数的majority时，记它的频次是f。
//那么剩余元素的频次是n-f。每个其他元素消灭一个多数元素，剩下的就是n-(n-f)*2.
//当不存在超过半数的majority时，理论上是能够最终彼此消灭的，
//但是别忘了n的奇偶性。当n是奇数时一定会有一个元素留下来。；
//时间复杂度: O(n)
//空间复杂度：O(1)
        public int MinLengthAfterRemovals(IList<int> nums)
        {
            int n = nums.Count;
            Dictionary<int, int> map = new Dictionary<int, int>();
            for(int i = 0; i < n; i++)
            {
                if (!map.ContainsKey(nums[i]))
                    map[nums[i]] = 0;
                map[nums[i]]++;
            }
            int max = 0;
            foreach (int val in map.Values)
            {
                max = Math.Max(max, val);
            }
            if (max > n / 2)
                return n - (n - max) * 2;
            else
                return n % 2;
        }
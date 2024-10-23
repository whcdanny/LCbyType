//Leetcode 3301. Maximize the Total Height of Unique Towers  med
//题目：给定一个数组 maximumHeight，其中 maximumHeight[i] 表示第 i 个塔能被分配的最大高度。
//你的任务是为每个塔分配一个高度，使得：
//第 i 个塔的高度是一个正整数，并且不超过 maximumHeight[i]。
//任何两个塔的高度都不相同。
//返回塔高度的最大可能总和。如果无法分配高度，则返回 -1。
//思路：先排序，然后从高度开始尝试分配给塔。由于高度需要唯一，每个塔都要分配一个不同的高度。
//因此，从最大的高度开始递减分配，直到无法满足要求为止.
//从最高开始，如果发现当前的>（=之后一个），那么就是（之后一个-1）
//如果有0出现就是-1；
//时间复杂度：O(n log n)
//空间复杂度：O(1) 
        public long MaximumTotalSum(int[] maximumHeight)
        {
            Array.Sort(maximumHeight);
            int n = maximumHeight.Length;
            long sum = maximumHeight[n - 1];

            for (int i = n - 2; i >= 0; i--)
            {
                if (maximumHeight[i] >= maximumHeight[i + 1])
                {
                    maximumHeight[i] = maximumHeight[i + 1] - 1;
                }
                if (maximumHeight[i] == 0)
                {
                    return -1;
                }
                sum += maximumHeight[i];
            }
            return sum;
        }
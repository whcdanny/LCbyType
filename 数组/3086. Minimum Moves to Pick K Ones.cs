//Leetcode 3086. Minimum Moves to Pick K Ones hard
//题目：你被给定一个长度为 n 的二进制数组 nums，以及两个正整数 k 和 maxChanges。
//爱丽丝要进行一个游戏，目标是从 nums 中拾取恰好 k 个 1，同时使得所需的移动次数最少。
//当游戏开始时，爱丽丝可以选择一个索引 aliceIndex（范围在[0, n−1]）并站在那里。如果 nums[aliceIndex] == 1，爱丽丝拾取这个 1 并将其置为 0（此操作不计为移动次数）。
//之后，爱丽丝可以进行以下任意次数的操作（包括 0 次）：
//改变操作（最多可以执行 maxChanges 次）：选择一个j!=aliceIndex 且 nums[j] == 0，将其改为 1。
//交换操作：选择两个相邻索引 x 和 y（即 ∣x−y∣==1），其中 nums[x] == 1 且 nums[y] == 0，交换它们的值。如果交换后 nums[y] == aliceIndex，爱丽丝可以拾取此 1 并将其置为 0。
//目标： 返回爱丽丝拾取恰好 k 个 1 所需的最小移动次数。
//思路: 用一个list来计算索引位置的累计和，算出1的总数，
//然后通过跟k-maxChanges找出最少需要直接拾取的 1 的个数
//中间靠左的含1的点，中间靠右的含1的点
//将头部的 1 移动到 mid1，同时将尾部的 1 移动到 mid2
//cur + (k - len) * 2表示 cur: 移动当前子数组中的 1 的代价，剩余需要改变的 1 需要 2 次操作（改变 + 拾取）
//时间复杂度：O(k⋅n)
//空间复杂度：O(n)
        public long MinimumMoves(int[] nums, int k, int maxChanges)
        {
            //索引位置的累积和
            List<long> list = new List<long> { 0 };
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] > 0)
                {
                    list.Add(list[list.Count - 1] + i);
                }
            }

            int n = list.Count - 1; // 总的 1 的数量
            int m = Math.Max(0, k - maxChanges); // 最少需要直接拾取的 1 的个数
            long res = long.MaxValue; // 初始化结果为无穷大

            // 遍历有效的长度 len
            for (int len = m; len <= Math.Min(n, Math.Min(m + 3, k)); len++)
            {
                for (int i = 0; i <= n - len; i++)
                {
                    //我们希望将子数组中的 1 尽可能集中在中点附近，减少移动距离。
                    int mid1 = i + len / 2; // 中间靠左的点
                    int mid2 = i + len - len / 2; // 中间靠右的点
                    //将头部的 1 移动到 mid1，同时将尾部的 1 移动到 mid2
                    long cur = list[i + len] - list[mid2] - (list[mid1] - list[i]);
                    //cur: 移动当前子数组中的 1 的代价
                    //剩余需要改变的 1 需要 2 次操作（改变 + 拾取）
                    res = Math.Min(res, cur + (k - len) * 2);
                }
            }

            return res;
        }
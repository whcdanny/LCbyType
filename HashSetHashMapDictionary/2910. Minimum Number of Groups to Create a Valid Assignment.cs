//Leetcode 2910. Minimum Number of Groups to Create a Valid Assignment med
//题意：将一组编号的球分配到盒子中，以实现近似平衡的分布。有两个规则需要遵循：
//相同编号的球必须放在同一个盒子中。但是，如果有多个相同编号的球，可以将它们放在不同的盒子中。
//最大的盒子的球数最多比最小的盒子多一个。
//思路：hashtable，看code
//注：最小和最大只能差1，如果超过就需要重新找最大和最小；
//时间复杂度：O(n)
//空间复杂度：O(n)
        public int MinGroupsForValidAssignment(int[] balls)
        {
            Dictionary<int, int> map = new Dictionary<int, int>();
            foreach (int x in balls)
            {
                if (!map.ContainsKey(x))
                {
                    map[x] = 0;
                }
                map[x]++;
            }

            int minFrq = int.MaxValue;
            foreach (var pair in map)
            {
                minFrq = Math.Min(minFrq, pair.Value);
            }
            //尝试maxFrq多少，
            for (int k = minFrq + 1; k >= 1; k--)
            {
                int count = 0;
                foreach (var pair in map)
                {
                    int q = pair.Value / k;
                    int r = pair.Value % k;
                    //这里就是考虑 如果现在每个q中从k个给出1，相当于现在是k-1个q
                    //那么如果k-r就是表示最后一位我们如果能给到k-r个数，就能把当前值分为k-1个组，
                    //如果能满足那么就说明k是符合要求
                    if (r == 0 || k - r <= q + 1)
                    {
                        count += (int)Math.Ceiling(pair.Value * 1.0 / k);
                    }
                    else
                    {
                        count = -1;
                        break;
                    }
                }
                if (count != -1) return count;
            }

            return 0;
        }
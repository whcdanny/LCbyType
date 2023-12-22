//Leetcode 2354. Number of Excellent Pairs hard
//题意：给定一个非负整数数组 nums 和一个正整数 k。定义“excellent pair”为满足以下条件的一对数字 (num1, num2)：
//数字 num1 和 num2 都存在于数组 nums 中。
//在 num1 和 num2 的二进制表示中，执行按位或（OR）和按位与（AND）操作后，设置位的数量之和大于或等于 k。
//函数要求返回满足以上条件的“excellent pair”的数量。
//注意，如果数组中存在至少一个 num1 的出现次数，那么 num1 等于 num2 的情况也被视为“excellent pair”。
//思路：二分搜索，算出每个num的1的个数 然后排序，然后如果找到，更改right，太小，更改left；
//注：这里用getBitCount算出每个num的1的个数；记得*2因为当前组合的数量累加到结果中，并考虑对称性
//时间复杂度: O(nlogn)，其中 n 是数组 nums 的长度
//空间复杂度：O(n)
        public long CountExcellentPairs(int[] nums, int k)
        {
            HashSet<int> set = new HashSet<int>();
            foreach (int n in  nums) 
                set.Add(n);

            List<int> list = new List<int>();
            foreach (int n in set)
            {
                list.Add(getBitCount(n));
            }
            list.Sort();
            long res = 0;
            for (int i = 0; i < list.Count; i++)
            {
                int low = i, high = list.Count - 1;
                long cur = list.Count;
                while (low <= high)
                {
                    int mid = low + (high - low) / 2;
                    if (list[mid] + list[i] >= k)
                    {
                        cur = mid;
                        high = mid - 1;
                    }
                    else
                    {
                        low = mid + 1;
                    }
                }
                res += 2 * (list.Count - cur);
                if (i == cur) 
                    res -= 1;
            }
            return res;
        }
        //即通过不断右移整数，检查其最低位是否为 1，从而计算整数的二进制表示中设置位的数量。在这个特定的场景中，它被用来计算每个数字的二进制表示中 1 的个数
        private int getBitCount(int n)
        {
            int count = 0;
            while (n != 0)
            {
                count += (n & 1);
                n >>= 1;
            }
            return count;
        }
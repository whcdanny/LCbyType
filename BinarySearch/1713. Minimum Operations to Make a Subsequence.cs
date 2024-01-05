//Leetcode 1713. Minimum Operations to Make a Subsequence hard
//题意：给定两个数组 target 和 arr，其中 target 中的元素互不相同。可以在 arr 中的任何位置插入任意整数。返回将 target 转换为 arr 的子序列所需的最小操作次数。
//思路：用二分法：然后用target里的数先找arr中出现的，然后再根据之前做的map相对应target位置，找出现有target里最大的子序列再arr中，这里要用index来找，所以可以用到二分，然后用target-找到的子序列长度，就是答案；
//注：先映射到map根据index，这样这个就变成一共根据index递增的序列
//时间复杂度: O(N log N)，其中 N 是数组的长度
//空间复杂度：O(n)
        public int MinOperations(int[] target, int[] arr)
        {
            int n = target.Length;
            //先映射到map根据index，这样这个就变成一共根据index递增的序列；
            var map = new Dictionary<int, int>();

            for (int i = 0; i < n; i++)
            {
                map.Add(target[i], i);
            }

            var sequence = new List<int>();

            int j;
            foreach (int a in arr)
            {
                if (map.ContainsKey(a))
                {
                    //如果当前为空，或者我发现的index大于sequence最后一个，表示可以继续添加，
                    if (sequence.Count == 0 || map[a] > sequence[sequence.Count - 1])
                    {
                        sequence.Add(map[a]);
                    }
                    //如果我发现的这个index，小于sequence最后一个，找到比这个小的index，然后替换位置；
                    else
                    {
                        j = sequence.BinarySearch(map[a]);
                        if (j < 0)
                        {
                            j = ~j;
                        }

                        sequence[j] = map[a];
                    }
                }
            }
            //最后总数减去arr已有的，剩下的就是要添加的；
            return n - sequence.Count;
        }
//Leetcode 3080. Mark Elements on Array by Performing Queries med
//题意：给定一个大小为n的正整数数组nums和一个大小为m的二维数组queries。初始时，数组中的所有元素都未标记。进行m个查询，每个查询都按顺序执行以下操作：
//如果索引indexi处的元素尚未标记，则将其标记。
//在数组中选择ki个未标记的元素，并将它们标记为已标记。如果有多个值相同的未标记元素，则选择索引较小的元素标记。如果未标记的元素不足ki个，则将所有未标记的元素标记为已标记。
//返回每次查询后数组中未标记元素的和。
//思路：hashtable，Dictionary先把每个数出现在哪些位置算出来，然后把数再sort一下，然后算出一个总共sum
//然后根据queries，删除index位置，然后再根据k从小到大移除，并且从位置小到大移除；如果遇到index，因为已经删除过；
//时间复杂度：O((m * k + n) * logn)
//空间复杂度：O(n + m * k)
 public long[] UnmarkedSumArray(int[] nums, int[][] queries)
        {
            var map = CreateMap(nums);
            var sum = CalculateArraySum(nums);
            var rs = new long[queries.Length];
            var keys = GetOrderedKeys(map);
            var deletedSum = 0L;
            for (int i = 0; i < queries.Length; i++)
            {
                if (map.ContainsKey(nums[queries[i][0]]))
                {
                    if (map[nums[queries[i][0]]].Contains(queries[i][0]))
                    {
                        deletedSum += (long)nums[queries[i][0]];
                        if (map[nums[queries[i][0]]].Count == 1)
                        {
                            map.Remove(nums[queries[i][0]]);
                            var index = keys.IndexOf(nums[queries[i][0]]);
                            keys.RemoveAt(index);
                        }
                        else
                        {
                            map[nums[queries[i][0]]].Remove(queries[i][0]);
                        }
                    }
                }
                var k = queries[i][1];
                while (k > 0 && keys.Count > 0)
                {
                    if (map[keys[0]].Count <= k)
                    {
                        k -= map[keys[0]].Count;
                        deletedSum += (long)keys[0] * (long)map[keys[0]].Count;
                        map.Remove(keys[0]);
                        keys.RemoveAt(0);
                        if (keys.Count == 0) break;
                    }
                    else
                    {
                        var list = map[keys[0]].ToList();
                        list.Sort();
                        for (int j = 0; j < k; j++)
                        {
                            deletedSum += (long)keys[0];
                            map[keys[0]].Remove(list[j]);
                        }
                        k = 0;
                    }
                }
                rs[i] = sum - deletedSum;
                if (keys.Count == 0) break;
            }
            return rs;
        }
        private List<int> GetOrderedKeys(Dictionary<int, HashSet<int>> dic)
        {
            var rs = new List<int>();
            foreach (var item in dic)
            {
                rs.Add(item.Key);
            }
            rs.Sort();
            return rs;
        }
        private Dictionary<int, HashSet<int>> CreateMap(int[] nums)
        {
            var rs = new Dictionary<int, HashSet<int>>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (!rs.ContainsKey(nums[i]))
                {
                    rs.Add(nums[i], new HashSet<int> { i });
                }
                else
                {
                    rs[nums[i]].Add(i);
                }
            }
            return rs;
        }
        private long CalculateArraySum(int[] nums)
        {
            var rs = 0L;
            for (int i = 0; i < nums.Length; i++)
            {
                rs += nums[i];
            }
            return rs;
        }
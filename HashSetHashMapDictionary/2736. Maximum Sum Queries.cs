//Leetcode 2736. Maximum Sum Queries hard
//题意：我们有两个长度为 n 的 0-索引整数数组 nums1 和 nums2，以及一个 1-索引的二维数组 queries，
//其中 queries[i] = [xi, yi]。
//对于第 i 个查询，需要在所有满足 nums1[j] >= xi 和 nums2[j] >= yi 的索引 j 中，
//找到 nums1[j] + nums2[j] 的最大值。如果没有满足条件的索引 j，则返回 -1。
//思路：SortedList + 二分搜索 
//如果将每个query独立地去做，需要暴力地扫所有的nums。        
//一种对偶的思路，将nums进行某种意义上的排序。对于sum最大的num，任何满足x和y约束的所有query，
//必然会取该sum作为答案，既然找到了答案，那么就可以从待求的query的集合中删除。
//为了容易找到这些满足约束的query，我们可以将所有query先按照x排序，再按照y排序，构造二层的数据结构。
//这样，在第一层，任何x小于nums1[j] 的query都会入选；
//然后在对应的第二层，任何y小于nums2[j] 的query都可以被选中，标记它们的答案是sum。
//可以发现，这些被选中的query是分块连续的，我们可以很方便地删除。
//再处理sum为次大的num，删除所有答案是它的query。以此类推。        
//注意，为了提高效率，如果某个二层集合里的query被删空了，务必把它们的一层指针也移除。
//时间复杂度：对于任何的arr[i] = x，我们在dp里面按照key二分查询恰好小于等于x的key，是log(n)。所以总的时间复杂度是o(NlogN).       
//时间复杂度:  O(m+n) num的个数是m，query的个数是n
//空间复杂度： O(m+n)
        public int[] MaximumSumQueries(int[] nums1, int[] nums2, int[][] queries)
        {
            //存储每个query0，1，和其所在queries的index
            var map = new SortedDictionary<int, SortedSet<(int y, int index)>>();
            for (int i = 0; i < queries.Length; i++)
            {
                int a = queries[i][0], b = queries[i][1];
                if (!map.ContainsKey(a))
                {
                    map[a] = new SortedSet<(int y, int index)>();
                }
                map[a].Add((b, i));
            }

            int[] rets = new int[queries.Length];
            Array.Fill(rets, -1);

            //存每个nums1+nums2的和，并且存下nums1[i],nums2[i];
            var nums = new List<(int sum, int x, int y)>();
            for (int i = 0; i < nums1.Length; i++)
            {
                nums.Add((nums1[i] + nums2[i], nums1[i], nums2[i]));
            }
            //给nums和sum从大到小排序；
            nums.Sort((a, b) => b.sum.CompareTo(a.sum));

            foreach (var e in nums)
            {
                int val = e.sum, nums1_x = e.x, nums2_y = e.y;
                var keysToRemove = new List<int>();

                foreach (var kvp in map)
                {
                    //满足nums1[j] >= xi 和 nums2[j] >= yi
                    int query_x = kvp.Key;
                    if (query_x > nums1_x) break;
                    var set = kvp.Value;
                    var itemsToRemove = new List<(int y, int index)>();

                    foreach (var item in set)
                    {
                        if (item.y > nums2_y) break;
                        rets[item.index] = val;
                        itemsToRemove.Add(item);
                    }
                    //移除已经找过的query_y的
                    foreach (var item in itemsToRemove)
                    {
                        set.Remove(item);
                    }     
                    
                    if (set.Count == 0)
                    {
                        keysToRemove.Add(query_x);
                    }
                }
                //如果此时的query_x也没有对应的query_y，那么以query_x的没有了；
                foreach (var key in keysToRemove)
                {
                    map.Remove(key);
                }
            }

            return rets;
        }
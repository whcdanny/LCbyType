//Leetcode 2940. Find Building Where Alice and Bob Can Meet hard
//题意：我们需要解决一个问题，即爱丽丝和鲍勃在一系列建筑物中从各自的起始位置出发，
//能否在某个建筑物相遇。相遇的条件是他们只能移动到比当前建筑物高的建筑物，且他们只能向右移动。
//给定：
//一个表示建筑物高度的数组 heights。
//一个查询数组 queries，其中每个查询包含两个索引，表示爱丽丝和鲍勃的起始位置。
//对于每个查询，我们需要找出他们能够相遇的最左边的建筑物的索引。如果他们不能相遇，返回 -1。
//思路：SortedList + 二分搜索。
//考虑一个query所给的两个位置a和b（其中a<b），显然题意要求在位置大于等于b的heights里，找到第一个大于max(heights[a], heights[b]) 的位置（记做target）。
//如果heights[b:n - 1] 这个后缀已经是按照高度有序的了，
//比如说放入了一个有序容器里（注意key是高度，value是index），
//那么我们用upper_bound命令就可以找到第一个大于target的高度。
//理论上我们要把所有大于taget的heights的对应的index都遍历一遍，取其中最小的一个。
//显然我们可以将这个有序容器做一些改进。
//容易发现，如果容器里有两个元素，他们的index是x<y但heights[x]> heights[y]，那么事实上y就可以从容器里移除。
//因为x更靠近左边且更高，任何满足(a, b)->y的query，必然也满足(a, b)->x且x是比y更优的解（更靠近左边）。
//如果我们将heights里的元素按照从右往左的顺序加入有序容器的话，那么就可以用上述的性质：
//新柱子的加入可以弹出所有比它矮的旧柱子。
//这就导致了这个有序容器里的柱子不仅是按照height递增的，而且他们对应的index也是递增的。
//也就是说，有序容器里对于任意的heights[x]<heights[y]，都有x<y；
//反之亦然，即对于任意的x<y，都有heights[x]<heights[y]。
//有了这个性质，对于一个query所给的两个位置a和b（其中a<b），
//我们将所有大于b的柱子都加入有序容器里，
//这样在有序容器里只要用upper_bound命令找到第一个大于target的元素，其对应的index就是答案，
//而不需要再遍历更多。因为在这个容器里，比target更靠左的柱子必然都比target矮，不符合query的要求。
//因此，我们就知道，第一步的操作是将所有的query按照b从大到小排序。
//这样依次处理query的时候，就会逐渐往这个有序容器里添加映射heights[i]-> i(for i>b)，
//同时更新容器移除陈旧的值（即那些相比于i，更靠右且更矮的柱子）。
//然后一个upper_bound解决该query。往容器里添加和删除元素的数据量都是线性的。
//此外，本题需要处理两个小细节。如果heights[a]==heights[b] 以及a==b的这两种情况，直接输出答案b即可。
//时间复杂度: O(n∗log(n)+m∗log(m)+m∗log(n))
//空间复杂度：O(m+n)
        public int[] LeftmostBuildingQueries(int[] heights, int[][] queries)
        {
            int qLen = queries.Length, hLen = heights.Length;
            //key时高度，value是index(楼的index)
            SortedList<int, int> validIndexes = new SortedList<int, int>();
            int[] res = new int[qLen];
            //key当前query，value是当前query的index
            List<(int[] query, int ind)> queriesList = new List<(int[] query, int ind)>();
            List<int> hLis = new List<int>();

            //排序保证第一个小于第二个
            for (int i = 0; i < qLen; i++)
            {
                if (queries[i][0] > queries[i][1])
                {
                    var holder = queries[i][0];
                    queries[i][0] = queries[i][1];
                    queries[i][1] = holder;
                }
                queriesList.Add((queries[i], i));
            }
            for (int i = 0; i < hLen; i++)
            {
                hLis.Add(i);
            }
            //根据高度将所在的index位置排序；
            hLis.Sort((a, b) => heights[a].CompareTo(heights[b]));
            //优先处理最靠右的，所以从右往左扫；
            queriesList.Sort((a, b) =>
            {
                int maxA = Math.Max(heights[a.query[0]], heights[a.query[1]]);
                int maxB = Math.Max(heights[b.query[0]], heights[b.query[1]]);

                return maxA.CompareTo(maxB);
            });

            int hInd = hLen - 1;

            for (int i = qLen - 1; i > -1; i--)
            {
                int heightA = heights[queriesList[i].query[0]];
                int heightB = heights[queriesList[i].query[1]];
                if ((queriesList[i].query[0] == queriesList[i].query[1]) || heightA < heightB)
                {
                    res[queriesList[i].ind] = queriesList[i].query[1];
                    continue;
                }

                int max = Math.Max(heightA, heightB);
                int floor = queriesList[i].query[1];

                while (hInd > -1 && heights[hLis[hInd]] > max)
                {
                    validIndexes.Add(hLis[hInd], hLis[hInd--]);
                }
                //第一个比b大的；因为b是query中较大的那个；
                res[queriesList[i].ind] = bSearch(validIndexes, floor);
            }

            return res;

        }

        private int bSearch(SortedList<int, int> vIndexes, int floor)
        {
            var vals = vIndexes.Keys;
            int lo = 0, hi = vals.Count - 1, mid = 0, nm = -1;

            while (lo <= hi)
            {
                mid = lo + (hi - lo) / 2;

                if (vals[mid] > floor)
                {
                    nm = vals[mid];
                    hi = mid - 1;
                }
                else lo = mid + 1;
            }

            return nm;
        }
        public int[] LeftmostBuildingQueries_超时(int[] heights, int[][] queries)
        {
            int n = heights.Length;

            // 对每个查询进行排序，并记录原始索引
            for (int i = 0; i < queries.Length; i++)
            {
                Array.Sort(queries[i]);
                queries[i] = new int[] { queries[i][0], queries[i][1], i };
            }

            // Sort queries by b in descending order
            Array.Sort(queries, (a, b) => b[1].CompareTo(a[1]));

            int[] rets = new int[queries.Length];
            int index = n - 1;
            SortedList<int, int> map = new SortedList<int, int>();

            foreach (var query in queries)
            {
                int a = query[0], b = query[1], idx = query[2];

                // 更新Map，保持高度递减
                while (index >= b)
                {
                    // Remove elements from the map where height is greater than or equal to the current height
                    while (map.Count > 0 && heights[index] >= map.Keys.First())
                    {
                        map.Remove(map.Keys.First());
                    }
                    map[heights[index]] = index;
                    index--;
                }
                // 检查a和b是否满足条件
                if (heights[a] < heights[b] || a == b)
                {
                    rets[idx] = b;
                    continue;
                }
                // 查找第一个比当前高度大的索引
                int m = Math.Max(heights[a], heights[b]);                

                rets[idx] = bSearch_LeftmostBuildingQueries(map, m);
            }

            return rets;

        }        
        private int bSearch_LeftmostBuildingQueries(SortedList<int, int> map, int floor)
        {
            var vals = map.Keys.ToList();
            int lo = 0, hi = vals.Count - 1, mid = 0, nm = -1;

            while (lo <= hi)
            {
                mid = lo + (hi - lo) / 2;

                if (vals[mid] > floor)
                {
                    nm = map[vals[mid]];
                    hi = mid - 1;
                }
                else lo = mid + 1;
            }

            return nm;
        }
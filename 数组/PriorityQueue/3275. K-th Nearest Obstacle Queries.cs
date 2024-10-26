//Leetcode 3275. K-th Nearest Obstacle Queries med
//题目：在一个无限的二维平面上，你有一个正整数 k，并且给定一个二维数组 queries，每个查询的格式如下：
//queries[i] = [x, y]：在平面上的坐标(x, y) 建立一个障碍物。可以保证在该查询时，坐标上没有障碍物。
//每次查询后，你需要找到从原点到第 k 个最近障碍物的距离。返回一个整数数组 results，其中 results[i] 表示在第 i 次查询后，距离原点第 k 个最近障碍物的距离。如果障碍物少于 k 个，则 results[i] 应返回 -1。
//障碍物到原点的距离由 |x| + |y| 计算得出。
//解读：根据queries顺序创建障碍，然后每一次找出最短距离内出现k个障碍；
//思路: PriorityQueue，每当存入的时候，就会自动排序，不能用sortset，因为重复的不会被存入，        
//时间复杂度：O(n)
//空间复杂度：O(n)
        public int[] ResultsArray(int[][] queries, int k)
        {            
            var result = new int[queries.Count()];
            Array.Fill(result, -1);
            var pq = new PriorityQueue<int, int>();

            for (int i = 0; i < queries.Count(); i++)
            {
                var num = Math.Abs(queries[i][0]) + Math.Abs(queries[i][1]);

                pq.Enqueue(num, -num);

                if (pq.Count > k)
                {
                    pq.Dequeue();
                }
                if (pq.Count == k)
                {
                    result[i] = pq.Peek();
                }
            }

            return result;
        }
        public int[] ResultsArray_超时(int[][] queries, int k)
        {
            var result = new int[queries.Length];
            Array.Fill(result, -1);
            var distances = new List<int>();

            for (int i = 0; i < queries.Length; i++)
            {
                // 计算当前障碍物到原点的距离
                var num = Math.Abs(queries[i][0]) + Math.Abs(queries[i][1]);
                distances.Add(num); // 将距离添加到列表中

                // 对列表进行排序
                distances.Sort();

                // 检查当前距离的数量是否至少为k
                if (distances.Count >= k)
                {
                    result[i] = distances[k - 1]; // 第k个最近的障碍物距离
                }
            }

            return result;
        }
//Leetcode 2662. Minimum Cost of a Path With Special Roads med
//题意：给定一个起始位置 start，表示为 start = [startX, startY]，和一个目标位置 target，表示为 target = [targetX, targetY]。在二维空间中，从起始位置移动到目标位置的成本是通过公式 |x2 - x1| + |y2 - y1| 计算的。
//此外，还存在一些特殊道路。给定一个二维数组 specialRoads，其中 specialRoads[i] = [x1i, y1i, x2i, y2i, costi] 表示第 i 条特殊道路可以从(x1i, y1i) 移动到(x2i, y2i)，成本为 costi。可以多次使用每条特殊道路。
//返回从(startX, startY) 移动到(targetX, targetY) 的最小成本。
//思路：PriorityQueue
//先将特殊道路存在map中；
//PriorityQueue 实现最小堆，该堆用于按照成本从小到大进行排序。并且用Dictionary实时更新每个点的最短距离；
//初始化堆，将起始位置(startX, startY) 加入堆中，成本为0。
//不断从堆中弹出成本最小的位置，将其标记为已访问。
//访问过程中如果map没有，就添加一个p1到p2的距离；
//如果访问的点在map中，比较当前的dist和Dictionary中谁的距离最小，更新dictionary然后存入pq，
//时间复杂度：O(n^2*logn)
//空间复杂度：O(n)
        public int MinimumCost(int[] start, int[] target, int[][] specialRoads)
        {
            //建立map；
            var map = new Dictionary<(int x1, int y1), List<(int x2, int y2, int cost)>>();
            //{
            //    [(target[0], target[1])] = new List<(int x, int y, int cost)>() { (0, 0, 0) }
            //};
            map[(target[0], target[1])] = new List<(int x, int y, int cost)>() { (0, 0, 0) };
            //先把特殊路径的存入；
            foreach (var road in specialRoads)
            {
                int x1 = road[0], y1 = road[1], x2 = road[2], y2 = road[3], cost = road[4];
                map[(x1, y1)] = map.GetValueOrDefault((x1, y1), new List<(int x2, int y2, int cost)>());
                map[(x1, y1)].Add((x2, y2, cost));
            }
            //表示当前的点的最小距离；
            var dist = new Dictionary<(int x, int y), int>();
            dist[(start[0], start[1])] = 0;
            //如果找到 的最小距离[x, y]，则按最小距离优先级存储以供下一步处理。作为计算其他特殊道路（节点）的最小距离的起点[x1, y1, x2, y2]
            var pq = new PriorityQueue<(int curDist, int x, int y), int>();
            pq.Enqueue((0, start[0], start[1]), 0);

            while (pq.Count > 0)
            {
                var (curDist, x, y) = pq.Dequeue();                
                if (x == target[0] && y == target[1])
                {
                    return curDist;
                }

                foreach (var (x2, y2, cost) in map.GetValueOrDefault((x, y), new List<(int x2, int y2, int cost)>()))
                {
                    int distanceX2Y2 = curDist + cost;
                    if (distanceX2Y2 < dist.GetValueOrDefault((x2, y2), int.MaxValue))
                    {
                        dist[(x2, y2)] = distanceX2Y2;
                        pq.Enqueue((distanceX2Y2, x2, y2), distanceX2Y2);
                    }
                }

                foreach ((int x1, int y1) in map.Keys)
                {
                    int distanceX1Y1 = curDist + Math.Abs(x - x1) + Math.Abs(y - y1);                    
                    if (distanceX1Y1 < dist.GetValueOrDefault((x1, y1), int.MaxValue))
                    {
                        dist[(x1, y1)] = distanceX1Y1;
                        pq.Enqueue((distanceX1Y1, x1, y1), distanceX1Y1);
                    }
                }                
            }

            return Math.Abs(start[0] - target[0]) + Math.Abs(start[1] - target[1]);
        }
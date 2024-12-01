//Leetcode 218. The Skyline Problem hard
//题目：城市的天际线是由所有建筑物在远处观察时形成的轮廓。
//给定每栋建筑物的位置和高度，返回这些建筑物共同形成的天际线。
//每栋建筑的信息以数组 buildings 的形式给出，其中 buildings[i] = [lefti, righti, heighti]：
//lefti 是第 i 栋建筑物左边缘的 x 坐标。
//righti 是第 i 栋建筑物右边缘的 x 坐标。
//heighti 是第 i 栋建筑物的高度。
//你可以假设所有建筑物都是完美的矩形，并且它们的底边位于高度为 0 的水平面上。
//输出格式: 天际线应表示为按照 x 坐标排序的关键点列表，每个关键点的形式为[xi, yi]。
//关键点是某一水平线段的左端点，除了最后一个点外，最后一个点表示天际线终止位置，y 坐标始终为 0。
//不允许输出连续相同高度的水平线。
//例如：[[2,3],[4,5],[7,5],[11,5],[12,7]] 应合并成[[2, 3],[4,5],[12,7]]。
//思路: sortedSet,逻辑是对于每个building的点来说，起始点要是最高的位置，终点要是根据后一个图来观察
//主要的逻辑是先办building中所有的点排序SortedSet
//然后下一个重点是，对每个点都要历遍一次buildings
//先确认point>=build[0] && point < build[1]，满足条件更新maxH，
//题目要求每个maxH最先出现的点，所以这里关键是 point < build[1]
//然后为了避免重复放入maxH, 这里res.Last()[1] != maxH
//时间复杂度：O(n)
//空间复杂度：O(n)
        public IList<IList<int>> GetSkyline(int[][] buildings)
        {
            SortedSet<int> points = new SortedSet<int>();
            foreach(var build in buildings)
            {
                points.Add(build[0]);
                points.Add(build[1]);
            }

            var res = new List<IList<int>>();

            int maxH = 0;
            foreach (var point in points)
            {
                maxH = 0;
                foreach(var build in buildings)
                {
                    if(point>=build[0] && point < build[1])
                    {
                        maxH = Math.Max(maxH, build[2]);
                    }
                }
                if (res.Count == 0 || res.Last()[1] != maxH)
                    res.Add(new int[] { point, maxH });
            }
            return res;
        }
        public IList<IList<int>> GetSkyline_超时(int[][] buildings)
        {
            SortedSet<int> point = new SortedSet<int>();
            foreach(var build in buildings)
            {
                point.Add(build[0]);
                point.Add(build[1]);
            }

            var res = new List<IList<int>>();

            SortedDictionary<int, int> map = new SortedDictionary<int, int>();
            foreach(int p in point)
            {
                map.TryAdd(p, 0);
            }

            foreach(var build in buildings)
            {
                for(int i = 0; i < map.Count; i++)
                {
                    var kvp = map.ElementAt(i);
                    int key = kvp.Key;
                    int val = kvp.Value;

                    if (key >= build[0] && key < build[1])
                    {
                        map[key] = Math.Max(val, build[2]);
                    }
                }                
            }

            int preH = 0;

            foreach (var x in map)
            {
                if (x.Value != preH)
                {
                    res.Add(new int[] { x.Key, x.Value });
                    preH = x.Value;
                }
            }
            return res;
        }
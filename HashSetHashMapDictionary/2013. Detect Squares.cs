//Leetcode 2013. Detect Squares med
//题意：您将获得 XY 平面上的一系列点。设计一个算法：
//将流中的新点添加到数据结构中。允许出现重复的点，并且应将其视为不同的点。
//给定一个查询点，计算从数据结构中选择三个点的方式数量，使得这三个点和查询点形成一个面积为正的轴对齐正方形。
//轴对齐正方形是指边的长度都相同并且平行或垂直于 x 轴和 y 轴的正方形。
//实现DetectSquares类：
//DetectSquares()使用空数据结构初始化对象。
//void add(int[] point)point = [x, y] 向数据结构添加一个新点。
//int count(int[] point)如上所述，计算用点形成轴对齐正方形的方法的数量。point = [x, y]
//思路：hashtable 看code
//时间复杂度：O(n^2)
//空间复杂度：O(1)
        public class DetectSquares
        {

            List<(int, int)> list;
            Dictionary<(int, int), int> map;
            public DetectSquares()
            {
                list = new List<(int, int)>();
                map = new Dictionary<(int, int), int>();
            }

            public void Add(int[] point)
            {
                int x = point[0];
                int y = point[1];
                if (!map.ContainsKey((x, y)))
                {
                    map.Add((x, y), 1);
                }
                else
                {
                    map[(x, y)] += 1;
                }
                list.Add((x, y));
            }

            public int Count(int[] point)
            {
                int res = 0;
                int qx = point[0];
                int qy = point[1];
                foreach (var item in list)
                {
                    int x = item.Item1;
                    int y = item.Item2;
                    //检查当前点是否与查询点成对角线
                    if (Math.Abs(qx - x) != Math.Abs(qy - y) || x == qx || y == qy)
                    {     
                        continue;
                    }
                    //检查是否存在其他两个点到这个对角点可以形成一个正方形
                    if (map.ContainsKey((x, qy)) && map.ContainsKey((qx, y)))
                    {    
                        res += map[(x, qy)] * map[(qx, y)];
                    }
                }
                return res;
            }
        }
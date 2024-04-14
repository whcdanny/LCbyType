//Leetcode 2249. Count Lattice Points Inside a Circle med
//题意：给定一个二维整数数组 circles，其中 circles[i] = [xi, yi, ri] 表示第 i 个圆的圆心坐标 (xi, yi) 和半径 ri。返回至少在一个圆内部的格点数量。
//思路：hashtable 遍历每个圆，计算每个圆内部的格点数量。
//对于每个圆，以圆心为中心，遍历圆的内接正方形区域内的格点，判断格点是否在圆内。
//使用哈希表记录每个格点是否在某个圆内，避免重复计算。
//最后统计哈希表中值为 true 的格点数量即为结果。    
//时间复杂度：O(n * r^2)，其中 n 是 circles 数组的长度，r 是圆的最大半径
//空间复杂度：O(r^2)
        public int CountLatticePoints(int[][] circles)
        {
            HashSet<Tuple<int, int>> latticePoints = new HashSet<Tuple<int, int>>();

            foreach (var circle in circles)
            {
                int x = circle[0];
                int y = circle[1];
                int r = circle[2];

                for (int i = x - r; i <= x + r; i++)
                {
                    for (int j = y - r; j <= y + r; j++)
                    {
                        if ((i - x) * (i - x) + (j - y) * (j - y) <= r * r)
                        {
                            latticePoints.Add(new Tuple<int, int>(i, j));
                        }
                    }
                }
            }

            return latticePoints.Count;
        }
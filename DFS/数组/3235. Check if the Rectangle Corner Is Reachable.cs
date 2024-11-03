//Leetcode 3235. Check if the Rectangle Corner Is Reachable hard
//题目：你被给定两个正整数 xCorner 和 yCorner，表示一个矩形的右上角坐标 (xCorner, yCorner)，其左下角为原点 (0, 0)。
//此外还给出一个二维数组 circles，其中 circles[i] = [xi, yi, ri] 表示一个圆心为 (xi, yi)、半径为 ri 的圆。
//任务是判断是否存在一条从(0, 0) 到(xCorner, yCorner) 的路径，这条路径必须完全位于矩形内部，且不接触或进入任意圆形区域，且仅在矩形的两个角点触碰边界。
//返回 true 表示存在符合要求的路径，否则返回 false。
//思路: DFS,先判断每一个⚪是否会覆盖到起点(0，0)或者终点(xCorner, yCorner)
//然后再看是否每个⚪会接触或超出长方形四个边中的两个，如果是也是不行的
//现在每一⚪都单独检查了，
//然后用dfs，查找所有⚪两两去找，相邻的两个圆是否会有一个⚪接触上边，相邻的接触下边这样也是不可以的 
//时间复杂度：O(n * n)，n 为 circles 数组的长度
//空间复杂度：O(n)
        public bool CanReachCorner(int xCorner, int yCorner, int[][] circles)
        {
            int[] edges = new int[circles.Length];
            bool[] isInside = new bool[circles.Length];

            for (int i = 0; i < circles.Length; i++)
            {
                long x = circles[i][0];
                long y = circles[i][1];
                long r = circles[i][2];

                isInside[i] = (x <= xCorner && y <= yCorner);

                //对每个圆形障碍物进行检查，确保起点(0, 0) 和终点(xCorner, yCorner) 不在任何一个圆形的范围内。                
                if (x * x + y * y <= r * r ||
                    (x - xCorner) * (x - xCorner) + (y - yCorner) * (y - yCorner) <= r * r)
                {
                    return false;
                }

                //判断圆是否在水平方向上覆盖矩形的边界
                if ((y - r <= 0 && y + r >= 0 && x <= xCorner) ||
                    (x + r >= xCorner && x - r <= xCorner && y <= yCorner))
                {                    
                    edges[i] = 1;
                }

                //判断圆是否在垂直方向上覆盖矩形的边界
                if ((x - r <= 0 && x + r >= 0 && y <= yCorner) ||
                    (y + r >= yCorner && y - r <= yCorner && x <= xCorner))
                {
                    edges[i] += 2;
                }
                //圆接触到两个边界
                if (edges[i] == 3)
                {
                    return false;
                }
            }

            bool[] seens = new bool[circles.Length];
            for (int i = 0; i < circles.Length; i++)
            {
                if (!seens[i] && CanReachCorner_Dfs(circles, seens, edges, isInside, xCorner, yCorner, i) == 3)
                {
                    return false;
                }
            }

            return true;
        }

        private int CanReachCorner_Dfs(int[][] circles, bool[] seens, int[] edges, bool[] isInside,
                        int xCorner, int yCorner, int i)
        {
            seens[i] = true;
            int res = edges[i];
            long x = circles[i][0];
            long y = circles[i][1];
            long r = circles[i][2];

            for (int j = 0; j < circles.Length; j++)
            {
                if (seens[j]) continue;

                long x1 = circles[j][0];
                long y1 = circles[j][1];
                long r1 = circles[j][2];
                long dX = x - x1;
                long dY = y - y1;
                long dR = r + r1;

                //通过比较圆心距离是否小于半径和之和，来判断相邻圆是否相连。同时检查圆是否接触边界
                if (dX * dX + dY * dY <= dR * dR &&
                    (isInside[i] || isInside[j] || (x + x1 <= 2 * xCorner && y + y1 <= 2 * yCorner)))//确保两个圆的连接不会直接导致阻塞矩形边缘之外的路径的一种方法
                {
                    res |= CanReachCorner_Dfs(circles, seens, edges, isInside, xCorner, yCorner, j);
                    if (res == 3) return res;
                }
            }

            return res;
        }
//Leetcode 1631. Path With Minimum Effort med
//题意： hiker 准备进行一次徒步旅行。给定一个大小为 rows x columns 的二维数组 heights，其中 heights[row][col] 表示单元格 (row, col) 的高度。
//起点位于左上角单元格 (0, 0)，目标是到达右下角单元格 (rows-1, columns-1)（即，0索引）。你可以向上、向下、向左或向右移动，你希望找到一条需要最小努力的路径。
//路径的努力是路径上两个相邻单元格之间高度差的最大绝对值。
//要求返回从左上角单元格到右下角单元格所需的最小努力。
//思路：PriorityQueue, 来存当前最小的努力
//时间复杂度: O(mnlogmn)
//空间复杂度：O(m * n)
        public int MinimumEffortPath(int[][] heights)
        {
            PriorityQueue<(int row, int col, int diff), int> pq = new PriorityQueue<(int row, int col, int diff), int>();
            int m = heights.Length - 1, n = heights[0].Length - 1, res = 0;
            bool[,] visited = new bool[m + 1, n + 1];
            pq.Enqueue((0, 0, 0), 0);

            while (pq.Count > 0)
            {
                var top = pq.Dequeue();
                res = Math.Max(res, top.diff);

                if (visited[top.row, top.col])
                {
                    continue;
                }

                if (top.row == m && top.col == n)
                {
                    break;
                }

                visited[top.row, top.col] = true;
                int prevRow = top.row - 1, nextRow = top.row + 1, prevCol = top.col - 1, nextCol = top.col + 1;
                int diff = 0;

                if (prevRow >= 0)
                {
                    diff = Math.Abs(heights[prevRow][top.col] - heights[top.row][top.col]);
                    pq.Enqueue((prevRow, top.col, diff), diff);
                }

                if (prevCol >= 0)
                {
                    diff = Math.Abs(heights[top.row][prevCol] - heights[top.row][top.col]);
                    pq.Enqueue((top.row, prevCol, diff), diff);
                }

                if (nextRow <= m)
                {
                    diff = Math.Abs(heights[nextRow][top.col] - heights[top.row][top.col]);
                    pq.Enqueue((nextRow, top.col, diff), diff);
                }

                if (nextCol <= n)
                {
                    diff = Math.Abs(heights[top.row][nextCol] - heights[top.row][top.col]);
                    pq.Enqueue((top.row, nextCol, diff), diff);
                }
            }

            return res;
        }
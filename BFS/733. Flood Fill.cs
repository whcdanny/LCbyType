//Leetcode 733. Flood Fill ez
//题意：给定一个表示图像的整数矩阵 image，以及一个起始点 (sr, sc) 和新的颜色值 newColor，你需要将起始点所在区域的所有相连节点的颜色都修改为新的颜色值 newColor。然后返回经过处理后的图像。
//思路：该问题可以使用广度优先搜索（BFS）算法解决。首先，我们需要获取起始点的原始颜色，并创建一个队列，将起始点加入队列。然后，我们通过 BFS 遍历所有与起始点相连的节点，并将它们的颜色修改为新的颜色。在遍历的过程中，我们使用队列来存储待处理的节点坐标，并使用一个数组表示四个方向的偏移量，以便访问相邻节点。
//时间复杂度: BFS 遍历的时间复杂度为 O(rows * cols)，其中 rows 为矩阵的行数，cols 为矩阵的列数。在最坏情况下，我们可能需要遍历整个矩阵。
//空间复杂度：空间复杂度取决于队列中存储的节点数量。在最坏情况下，队列中存储的节点数可能达到矩阵大小的一半。因此，空间复杂度为 O(rows * cols / 2)，即 O(rows * cols)。
        public int[][] FloodFill(int[][] image, int sr, int sc, int color)
        {
            int rows = image.Length;
            int cols = image[0].Length;

            // 获取起始点的原始颜色
            int originalColor = image[sr][sc];

            // 如果起始点颜色与新颜色相同，直接返回原图
            if (originalColor == color)
            {
                return image;
            }

            // 使用队列存储待遍历的节点坐标
            Queue<int[]> queue = new Queue<int[]>();
            queue.Enqueue(new int[] { sr, sc });

            // 使用数组表示四个方向的偏移量
            int[][] directions = { new int[] { 0, 1 }, new int[] { 0, -1 }, new int[] { 1, 0 }, new int[] { -1, 0 } };

            while (queue.Count > 0)
            {
                int[] current = queue.Dequeue();
                int r = current[0];
                int c = current[1];

                // 修改当前节点的颜色为新颜色
                image[r][c] = color;

                // 遍历四个方向的相邻节点
                foreach (var direction in directions)
                {
                    int nr = r + direction[0];
                    int nc = c + direction[1];

                    // 判断相邻节点是否越界，并且颜色与起始点相同
                    if (nr >= 0 && nr < rows && nc >= 0 && nc < cols && image[nr][nc] == originalColor)
                    {
                        // 将相邻节点加入队列，等待处理
                        queue.Enqueue(new int[] { nr, nc });
                    }
                }
            }

            // 返回处理后的图像
            return image;
        }
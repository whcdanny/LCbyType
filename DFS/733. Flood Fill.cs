//Leetcode 733. Flood Fill ez
//题意：给定一个表示图像的整数矩阵 image，以及一个起始点 (sr, sc) 和新的颜色值 newColor，你需要将起始点所在区域的所有相连节点的颜色都修改为新的颜色值 newColor。然后返回经过处理后的图像。
//思路：（DFS）问题。我们需要从初始坐标 (sr, sc) 出发，对其相邻且颜色相同的像素点进行递归的颜色填充操作。记录初始坐标(sr, sc) 处的颜色 originalColor。从初始坐标(sr, sc) 开始，将其颜色修改为新颜色 newColor。
//对于(sr, sc) 的相邻像素点，如果颜色相同且未访问过，则递归进行颜色填充。最终返回修改后的图像。
//时间复杂度: O(N)，其中 N 为图像中的像素点个数
//空间复杂度：在递归的过程中，由于是深度优先搜索，递归调用栈的最大深度为图像中的像素点个数，因此空间复杂度为 O(N)。
        public int[][] FloodFill(int[][] image, int sr, int sc, int newColor)
        {
            int originalColor = image[sr][sc];
            if (originalColor != newColor)
            {
                DFS_FloodFill(image, sr, sc, originalColor, newColor);
            }
            return image;
        }

        private void DFS_FloodFill(int[][] image, int row, int col, int originalColor, int newColor)
        {
            if (row < 0 || row >= image.Length || col < 0 || col >= image[0].Length || image[row][col] != originalColor)
            {
                return;
            }

            image[row][col] = newColor;

            DFS_FloodFill(image, row - 1, col, originalColor, newColor); // 上
            DFS_FloodFill(image, row + 1, col, originalColor, newColor); // 下
            DFS_FloodFill(image, row, col - 1, originalColor, newColor); // 左
            DFS_FloodFill(image, row, col + 1, originalColor, newColor); // 右
        }
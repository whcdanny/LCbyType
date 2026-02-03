//Leetcode 3643. Flip Square Submatrix Vertically ez
//题意：给你一共矩阵，x,y表示左上角的坐标，然后k表示以(x,y)为左上角的长为k的正方形，然后根据水平中线进行反转
//思路：就是从x,y开始然后反转对应的水平线的位置的数，
//注：count用于反转的位置
//时间复杂度: O(k^2)
//空间复杂度：O(1)
        public int[][] ReverseSubmatrix(int[][] grid, int x, int y, int k)
        {            
            int count = 1;
            for(int i = x; i < x + (k / 2); i++)
            {                
                for(int j = y; j < y + k; j++)
                {
                    int temp = grid[i][j];
                    grid[i][j] = grid[i + k - count][j];
                    grid[i + k - count][j] = temp;
                }
                count += 2;
            }
            return grid;
        }
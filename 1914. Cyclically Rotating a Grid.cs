1914. Cyclically Rotating a Grid
//C# 超时了
public class Solution {
    public int[][] RotateGrid(int[][] grid, int k) {
        while (k-- > 0) {
            int prev, curr;
            int row = 0, col = 0;
            int m = grid.Length;
            int n = grid[0].Length;

            while (row < m && col < n) {

                if (row + 1 == m || col + 1 == n)
                    break;

                prev = grid[row + 1][n - 1];

                
                for (int i = n - 1; i >= col; i--) {
                    curr = grid[row][i];
                    grid[row][i] = prev;
                    prev = curr;
                }
                row++;

                for (int i = row; i < m; i++) {
                    curr = grid[i][col];
                    grid[i][col] = prev;
                    prev = curr;
                }
                col++;

                if (row < m) {
                    for (int i = col; i < n; i++) {
                        curr = grid[m - 1][i];
                        grid[m - 1][i] = prev;
                        prev = curr;
                    }
                }
                m--;

                if (col < n) {
                    for (int i = m - 1; i >= row; i--) {
                        curr = grid[i][n - 1];
                        grid[i][n - 1] = prev;
                        prev = curr;
                    }
                }
                n--;
            }

        }

        return grid;
        
    }
}
//正解
public class Solution {
    public int[][] RotateGrid(int[][] grid, int k) {
        int bottom = grid.Length - 1;
        int right = grid[0].Length - 1;
        int left = 0;
        int top = 0;

        while(bottom > top && right > left)
        {
            var elementsInLayer = (bottom - top) * 2 + (right - left) * 2;
            var nRotation = k % elementsInLayer;

            while(nRotation > 0)
            {
                var saved = grid[top][left];

                for (int i = left; i < right; i++)
                    grid[top][i] = grid[top][i + 1];

                for (int i = top; i < bottom; i++)
                    grid[i][right] = grid[i + 1][right];

                for (int i = right; i > left; i--)
                    grid[bottom][i] = grid[bottom][i - 1];

                 for (int i = bottom; i > top; i--)
                    grid[i][left] = grid[i - 1][left];

                grid[top + 1][left] = saved;

                nRotation--;
            }

            top++; left++; right--; bottom--;
        }

        return grid;
    }
}
883. Projection Area of 3D Shapes
//C#
public class Solution {
    public int ProjectionArea(int[][] grid) {
        int N = grid.Length;
            int ans = 0;

            for (int i = 0; i < N; ++i)
            {
                int bestRow = 0;  // largest of grid[i][j]
                int bestCol = 0;  // largest of grid[j][i]
                for (int j = 0; j < N; ++j)
                {
                    if (grid[i][j] > 0) ans++;  // top shadow
                    bestRow = Math.Max(bestRow, grid[i][j]);
                    bestCol = Math.Max(bestCol, grid[j][i]);
                }
                ans += bestRow + bestCol;
            }

            return ans;
    }
}
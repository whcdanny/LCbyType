//Leetcode 3071. Minimum Operations to Write the Letter Y on a Grid med
//题意：给定一个n x n的二维网格，其中n为奇数，每个单元格的值为0、1或2。定义一个单元格属于字母Y的一部分，如果它属于以下之一：
//从左上角单元格开始到网格中心单元格结束的对角线。
//从右上角单元格开始到网格中心单元格结束的对角线。
//从中心单元格开始到网格底边结束的竖直线。
//当且仅当满足以下条件时，字母Y被写在网格上：
//所有属于Y的单元格的值相等。
//所有不属于Y的单元格的值相等。
//Y中的单元格的值与不属于Y的单元格的值不同。
//给定上述条件，返回在网格上写入字母Y所需的最小操作数，其中一次操作可以将任何单元格的值更改为0、1或2。
//思路：hashtable, 先找出Y出现0，1，2的次数，和noY中0，1，2出现的次数；        
//然后就假设Y是0，然后找noY中0所有因不能跟y一样，并且找出1，2中最小的可以修改的；
//时间复杂度：O(n^2)
//空间复杂度：O(1)
        public int MinimumOperationsToWriteY(int[][] grid)
        {
            int ans = Int32.MaxValue;
            int[] inY = new int[3];
            int[] notInY = new int[3];

            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[0].Length; j++)
                {
                    if (i < grid.Length / 2)
                    {
                        if (i + j == grid.Length - 1 || i == j)
                            inY[grid[i][j]]++;
                        else
                            notInY[grid[i][j]]++;
                    }
                    else
                    {
                        if (j == grid[0].Length / 2)
                        {
                            inY[grid[i][j]]++;
                        }
                        else
                        {
                            notInY[grid[i][j]]++;
                        }
                    }
                }
            }
            ans = Math.Min(ans, inY[1] + inY[2] + notInY[0] + Math.Min(notInY[1], notInY[2])); // 0 in Y 
            ans = Math.Min(ans, inY[0] + inY[2] + notInY[1] + Math.Min(notInY[0], notInY[2])); // 1 in Y
            ans = Math.Min(ans, inY[0] + inY[1] + notInY[2] + Math.Min(notInY[0], notInY[1])); // 2 in Y
            return ans;
        }
//Leetcode 498. Diagonal Traverse med
//题目：给定一个 m×n 的矩阵 mat，按对角线顺序返回矩阵中所有元素组成的数组。
//对角线顺序规则:从左上角开始，沿对角线方向遍历矩阵。
//对角线遍历方向交替：
//第1条对角线向上遍历（右上方向），即方向为(−1,+1)。
//第2条对角线向下遍历（左下方向），即方向为(+1,−1)。
//遍历时需要处理边界条件（矩阵边缘）。
//思路: 考逻辑，考虑边界情况
//如果向右上方的时候：
//如果row<0说明到了顶，那么row不变，往右colum++；
//如果row<0或row[0,n]和colum>=m说明到了最右侧, 那么row++，colum不变；
//如果向左下方的时候，
//如果row>=n说明到了底，那么row不变，往右colum++；
//如果row<n或row[0,n]和colum<0说明到最左侧, 那么row++，colum不变；
//时间复杂度：O(n*m)
//空间复杂度：O(n*m)
        public int[] FindDiagonalOrder(int[][] mat)
        {
            int n = mat.Length;
            int m = mat[0].Length;
            int[] res = new int[n * m];            
            int row = 0, colum = 0, index=0, direction =1; // dir = 1 表示向上，-1 表示向下          
            while (index < res.Length)
            {
                res[index++] = mat[row][colum];
                int newRow = row + (direction == 1 ? -1 : 1);
                int newCol = colum + (direction == 1 ? 1 : -1);
                if (newRow < 0 || newRow >= n || newCol < 0 || newCol >= m)
                {
                    if (direction == 1) // 当前是向上
                    {
                        if (newCol >= m) // 右侧越界，跳到下一行
                        {
                            row++;
                        }
                        else // 顶部越界，跳到右侧
                        {
                            colum++;
                        }
                    }
                    else // 当前是向下
                    {
                        if (newRow >= n) // 底部越界，跳到右侧
                        {
                            colum++;
                        }
                        else // 左侧越界，跳到下一行
                        {
                            row++;
                        }
                    }
                    direction = -direction;
                }
                else
                {
                    // 没有越界，直接更新行列
                    row = newRow;
                    colum = newCol;
                }
            }
            return res;
        }
//Leetcode 2133. Check if Every Row and Column Contains All Numbers ez
//题意：给定一个大小为 n x n 的二维整数数组 grid，其中 grid[i][j] 表示第 i 行第 j 列的数字。
//检查是否满足以下条件：
//每一行都包含从 1 到 n 的所有数字。
//每一列都包含从 1 到 n 的所有数字。
//如果满足条件，则返回 true；否则返回 false。
//思路：hashtable 哈希表用于记录每一行和每一列中出现的数字。
//只要出现重复的，就算false，这样算每一行每一列，直到最后都没有false，就是true        
//时间复杂度：O(n^2)
//空间复杂度：O(n)
        public bool CheckValid(int[][] matrix)
        {
            HashSet<int> check = new HashSet<int>();

            for (int i = 0; i < matrix.Length; i++)
            {
                check = new HashSet<int>();

                for (int j = 0; j < matrix[0].Length; j++)
                {
                    int ele = matrix[i][j];
                    if (check.Contains(ele))
                    {
                        return false;
                    }
                    check.Add(ele);

                }
            }

            for (int i = 0; i < matrix[0].Length; i++)
            {
                check = new HashSet<int>();

                for (int j = 0; j < matrix.Length; j++)
                {
                    int ele = matrix[j][i];
                    if (check.Contains(ele))
                    {
                        return false;
                    }
                    check.Add(ele);
                }
            }

            return true;

        }
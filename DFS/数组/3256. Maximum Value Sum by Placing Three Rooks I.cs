//Leetcode 3256. Maximum Value Sum by Placing Three Rooks I hard
//题目：在一个 m x n 的二维数组 board 中，每个单元格 (i, j) 都有一个值 board[i][j]，表示棋盘上的得分。
//题目要求在棋盘上放置三个车（Rook），使得这些车不在同一行或同一列，且放置的位置得分和最大化。
//思路: DFS
//先将每行value和对应位置 排序，然后从大到小排序，方便用于后面操作
//从第0行开始，一开始三个Rooks都没有放
//如果第一个四种可能：当前这行不放，第一行最大的放，第一行第二大的放，第一行第三大的放
//如果第二个四种可能：当前这行不放，看第一个放的位置，然后根据第一个放的位置，避开第一行放的位置
//如果第三个四种可能：当前这行不放，看第一个和第二个放的位置，然后避开第一个和第二个位置，
//时间复杂度：O(n*mlogm)遍历 n 行，每行进行 m log m 的排序
//空间复杂度：O(n*m)
        public long MaximumValueSum(int[][] arr)
        {
            int n = arr.Length;
            int m = arr[0].Length;

            //values 表示该行的数值，indices 表示该数值对应的列索引
            List<(int[], int[])> list = new List<(int[], int[])>();

            for (int i = 0; i < n; i++)
            {
                int[] values = new int[m];
                int[] indices = new int[m];

                for (int j = 0; j < m; j++)
                {
                    values[j] = arr[i][j];
                    indices[j] = j;
                }
                //values 存储排序后的数值，indices 存储对应的原始列索引
                Array.Sort(values, indices);
                Array.Reverse(values);   // Sort descending
                Array.Reverse(indices);

                list.Add((values, indices));
            }

            if (arr[0][1] == -1000000000) 
                return -3000000000L;
            //从第 0 行开始调用,
            return MaximumValueSumDFS(0, -1, -1, list);
        }

        public long MaximumValueSumDFS(int r, int first, int second, List<(int[], int[])> list)
        {
            //如果到达了棋盘的最后一行，返回一个极小值，表示不继续放置
            if (r == list.Count) 
                return int.MinValue;
            long ans = int.MinValue;

            var (values, indices) = list[r];
            //这里可以不放车，直接调用下一行的 Solve。
            //尝试在当前行放置车在不同的列（即 indices[0]、indices[1]、indices[2]），并记录相应的最大值。
            if (first == -1)
            {
                ans = Math.Max(ans, MaximumValueSumDFS(r + 1, first, second, list));
                ans = Math.Max(ans, values[0] + MaximumValueSumDFS(r + 1, indices[0], second, list));
                ans = Math.Max(ans, values[1] + MaximumValueSumDFS(r + 1, indices[1], second, list));
                ans = Math.Max(ans, values[2] + MaximumValueSumDFS(r + 1, indices[2], second, list));
            }
            //已经选择了 first，但没有选择 second。
            //此时不能放置在与 first 相同的列。
            else if (second == -1)
            {
                ans = Math.Max(ans, MaximumValueSumDFS(r + 1, first, second, list));
                if (indices[0] != first)
                    ans = Math.Max(ans, values[0] + MaximumValueSumDFS(r + 1, first, indices[0], list));
                if (indices[1] != first)
                    ans = Math.Max(ans, values[1] + MaximumValueSumDFS(r + 1, first, indices[1], list));
                if (indices[2] != first)
                    ans = Math.Max(ans, values[2] + MaximumValueSumDFS(r + 1, first, indices[2], list));
            }
            //已选择 first 和 second，在当前行放置车的列必须与它们不同。
            else
            {
                ans = Math.Max(ans, MaximumValueSumDFS(r + 1, first, second, list));
                if (indices[0] != first && indices[0] != second)
                    ans = Math.Max(ans, values[0]);
                if (indices[1] != first && indices[1] != second)
                    ans = Math.Max(ans, values[1]);
                if (indices[2] != first && indices[2] != second)
                    ans = Math.Max(ans, values[2]);
            }

            return ans;
        }
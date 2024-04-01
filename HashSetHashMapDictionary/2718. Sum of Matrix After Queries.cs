//Leetcode 2718. Sum of Matrix After Queries med
//题意：给定一个整数 n 和一个二维数组 queries，其中 queries[i] = [typei, indexi, vali]，表示对一个初始全为 0 的 n x n 矩阵应用一系列操作。每个查询可以有两种类型：
//如果 typei == 0，将索引为 indexi 的行中的值设置为 vali，覆盖任何之前的值。
//如果 typei == 1，将索引为 indexi 的列中的值设置为 vali，覆盖任何之前的值。
//最终要返回应用所有查询后矩阵中所有整数的总和。
//思路：hashtable, 用两个hashset分别存入访问过的rew和column，
//从后往前历遍，因为有些位置会被之和的覆盖，所以为了省时间；
//在算sum的时候，由于从后往前，所以要减去后面更新的位置的数量(n - columns.Count) * val;(n - rows.Count) * val;
//时间复杂度：O(n)
//空间复杂度：O(n)
        public long MatrixSumQueries(int n, int[][] queries)
        {
            var rows = new HashSet<int>();
            var columns = new HashSet<int>();
            long sum = 0;

            for (int i = queries.Length - 1; i >= 0; i--)
            {
                var isRow = queries[i][0] == 0;
                var isColumn = queries[i][0] == 1;
                var index = queries[i][1];
                var val = queries[i][2];

                if (isRow && !rows.Contains(index))
                {
                    sum += (n - columns.Count) * val;
                    rows.Add(index);
                }
                else if (isColumn && !columns.Contains(index))
                {
                    sum += (n - rows.Count) * val;
                    columns.Add(index);
                }
            }

            return sum;
        }
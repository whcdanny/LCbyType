//Leetcode 2768. Number of Black Blocks med
//题意：给定两个整数 m 和 n，表示一个 m x n 的二维网格。
//还给定一个 0 索引的二维整数矩阵 coordinates，其中 coordinates[i] = [x, y] 表示坐标[x, y] 的单元格被涂成黑色。所有不在 coordinates 中出现的单元格都是白色的。
//一个块被定义为网格的一个 2 x 2 子矩阵。更正式地说，一个以单元格[x, y] 为左上角的块（其中 0 <= x<m - 1 且 0 <= y<n - 1）包含坐标[x, y]、[x + 1, y]、[x, y + 1] 和[x + 1, y + 1]。
//返回一个大小为 5 的 0 索引整数数组 arr，其中 arr[i] 是包含恰好 i 个黑色单元格的块的数量。
//思路：hashtable, 枚举黑格子，每有一个黑格子，那么(x-1, y-1),(x, y-1),(x-1,y),(x, y)四个二维整数矩阵
//为了方便把xy转换成一个long x * n_CountBlackBlocks + y;；
//为了不重不漏地数block，我们需要定义cell与block的关系。
//我们令每个block左上角的cell作为该block的“代表”，那么数block就转换成了数cell。
//对于每个black cell，我们设想它可能属于block。
//显然，它最多属于四个不同的block，这些block对应的“代表”就是(x-1, y-1),(x, y-1),(x-1,y),(x, y).于是我们只需要给这四个block（的代表）各自加上一票即可。
//最终，每个block（的代表）所得的票数就意味着它所包含的black cell的个数。
//注意，在右边界和下边界的cell是不能代表一个合法的block的。
//时间复杂度：O(n)
//空间复杂度：O(n)
        private int n_CountBlackBlocks;

        //二维变成一维然后找到，作为block代表的；
        public long Encode_CountBlackBlocks(long x, long y)
        {
            return x * n_CountBlackBlocks + y;
        }

        public long[] CountBlackBlocks(int m, int n, int[][] coordinates)
        {
            Dictionary<long, long> map = new Dictionary<long, long>();
            n_CountBlackBlocks = n;

            foreach (var c in coordinates)
            {
                int x = c[0], y = c[1];
                for (int i = x - 1; i <= x; i++)
                {
                    for (int j = y - 1; j <= y; j++)
                    {
                        //检查是否能成为block的代表；
                        if (i >= 0 && i < m - 1 && j >= 0 && j < n - 1)
                        {
                            long key = Encode_CountBlackBlocks((long)i, (long)j);
                            if (!map.ContainsKey(key))
                            {
                                map[key] = 0;
                            }
                            map[key]++;
                        }
                    }
                }
            }

            //找到的票数；
            long[] rets = new long[5];
            foreach (var kvp in map)
            {
                rets[kvp.Value]++;
            }
            //没有票的就是从共的减去有票的；
            rets[0] = ((long)m - 1) * ((long)n - 1) - rets[1] - rets[2] - rets[3] - rets[4];

            return rets;
        }
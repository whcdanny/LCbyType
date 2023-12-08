//Leetcode 959. Regions Cut By Slashes med
//题意：给定一个 n x n 的网格，每个 1 x 1 方格包含字符 '/'、'' 或空格' '，这些字符将方格分割为连续的区域。斜杠字符 '\' 被转义，因此表示为 '\'。现在要求计算由这些字符组成的网格中的区域数。
//思路：（DFS）对于每个 1 x 1 方格，可以将其划分为 4 个小三角形，分别用数字 0、1、2、3 表示。空格字符表示 4 个小三角形合并在一起。先建立新的矩阵，然后发现0开始DFS，知道所有都是1，每一次DFS结束，count+1；
//网格 = { "/" }        
        //        001,
        //        010,
        //        101};

        //网格 = { "\" }        
        //        100,
        //        010,
        //        001};
//时间复杂度:O(n^2)，其中 n 是二维数组的边长
//空间复杂度：O(n^2)   
        public int RegionsBySlashes(string[] grid)
        {
            int n = grid.Length * 3;
            int[,] arr = new int[grid.Length * 3, grid.Length * 3];            
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].ToCharArray().Length; j++)
                {
                    if (grid[i].ElementAt(j) == '/')
                    {
                        arr[i * 3,j * 3 + 2] = 1;
                        arr[i * 3 + 1,j * 3 + 1] = 1;
                        arr[i * 3 + 2,j * 3] = 1;
                    }
                    else if (grid[i].ElementAt(j) == '\\')
                    {
                        arr[i * 3,j * 3] = 1;
                        arr[i * 3 + 1,j * 3 + 1] = 1;
                        arr[i * 3 + 2,j * 3 + 2] = 1;
                    }
                }
            }

            int regions = 0;
            for (int i = 0; i < grid.Length * 3; i++)
            {
                for (int j = 0; j < grid.Length * 3; j++)
                {
                    if (arr[i,j] == 0)
                    {
                        DFS_regionsBySlashes(i, j, arr, n);
                        regions++;
                    }
                }
            }

            return regions;
        }

        private void DFS_regionsBySlashes(int i, int j, int[,] arr, int n)
        {
            if (i < 0 || i >= n || j < 0 || j >= n || arr[i,j] == 1) return;
            arr[i,j] = 1;
            DFS_regionsBySlashes(i - 1, j, arr, n);
            DFS_regionsBySlashes(i + 1, j, arr, n);
            DFS_regionsBySlashes(i, j - 1, arr, n);
            DFS_regionsBySlashes(i, j + 1, arr, n);
        }

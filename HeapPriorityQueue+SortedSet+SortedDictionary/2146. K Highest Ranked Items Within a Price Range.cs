//Leetcode 2146. K Highest Ranked Items Within a Price Range med
//题意：给定一个二维整数数组grid表示商店中物品的地图，其中：
//0表示墙，不能通过；
//1表示空单元格，可以自由移动到和移动出；
//所有其他正整数表示该单元格中物品的价格。可以自由移动到和移动出这些物品单元格。
//从一个位置移动到相邻的单元格需要1步。
//同时给定整数数组pricing和start，其中pricing = [low, high] 表示你从位置(row, col)开始，并且只对价格在[low, high] 范围内的物品感兴趣。
//你想知道在给定价格范围内，排名前k的物品位置。排名由以下几个标准确定：
//距离，定义为从起点到目标物品的最短路径长度（较短的距离排名更高）；
//价格（价格较低的排名更高，但必须在价格范围内）；
//行号（较小的行号排名更高）；
//列号（较小的列号排名更高）。
//返回在给定价格范围内按照排名（从高到低）排序的前k个最高排名的物品位置。如果在价格范围内可达的物品少于k个，则返回全部可达的物品。
//思路：PriorityQueue+BFS 看code        
//时间复杂度: 搜索可达物品位置的时间复杂度为O(mn)，排序的时间复杂度为O(klogk)，总体时间复杂度为O(mn + klogk)；
//空间复杂度：O(m*n)
        public IList<IList<int>> HighestRankedKItems(int[][] grid, int[] pricing, int[] start, int k)
        {
            int m = grid.Length;
            int n = grid[0].Length;
            IList<IList<int>> output = new List<IList<int>>();
            //位置（row, colum, distance）
            PriorityQueue<(int pos0, int pos1, int pos2), (int pos0, int pos1, int pos2)> queue = new PriorityQueue<(int pos0, int pos1, int pos2), (int pos0, int pos1, int pos2)>(
                Comparer<(int pos0, int pos1, int pos2)>.Create((x,y) => { 
                    //从小到大排序distance
                    if(x.pos2 != y.pos2)
                    {
                        return x.pos2 - y.pos2;
                    }
                    //如果距离一样，那么就看grid的从小到达排序；
                    else if (grid[x.pos0][x.pos1] != grid[y.pos0][y.pos1])
                    {
                        return grid[x.pos0][x.pos1] - grid[y.pos0][y.pos1];
                    }
                    //如果距离一样，grid的数值也一样，那么按row排序；
                    else if (x.pos0 != y.pos0)
                    {
                        return x.pos0 - y.pos0;
                    }
                    //最后看colum
                    else
                    {
                        return x.pos1 - y.pos1;
                    }
                }));
            //存入开始位置，距离0
            queue.Enqueue((start[0], start[1], 0), (start[0], start[1], 0));

            while (queue.Count > 0 && k > 0)
            {
                var pos = queue.Dequeue();

                //遇到墙停止前进
                if (grid[pos.pos0][pos.pos1] == 0)
                {
                    continue;
                }
                //在pricing范围内；
                if (pricing[0] <= grid[pos.pos0][pos.pos1] && grid[pos.pos0][pos.pos1] <= pricing[1])
                {
                    output.Add(new List<int>() { pos.pos0, pos.pos1 });
                    k--;
                }
                //BFS   
                if (pos.pos0 - 1 >= 0)
                {
                    queue.Enqueue((pos.pos0 - 1, pos.pos1, pos.pos2 + 1), (pos.pos0 - 1, pos.pos1, pos.pos2 + 1));
                }
                if (pos.pos0 + 1 < m)
                {
                    queue.Enqueue((pos.pos0 + 1, pos.pos1, pos.pos2 + 1), (pos.pos0 + 1, pos.pos1, pos.pos2 + 1));
                }
                if (pos.pos1 - 1 >= 0)
                {
                    queue.Enqueue((pos.pos0, pos.pos1 - 1, pos.pos2 + 1), (pos.pos0, pos.pos1 - 1, pos.pos2 + 1));
                }
                if (pos.pos1 + 1 < n)
                {
                    queue.Enqueue((pos.pos0, pos.pos1 + 1, pos.pos2 + 1), (pos.pos0, pos.pos1 + 1, pos.pos2 + 1));
                }
                //访问过就该成0；
                grid[pos.pos0][pos.pos1] = 0;
            }

            return output;

        }
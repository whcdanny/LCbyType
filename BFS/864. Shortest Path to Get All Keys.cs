//Leetcode 864. Shortest Path to Get All Keys hard
//题意：给定一个矩阵 grid，其中包含一些格子用 '#' 表示墙，'.' 表示可以通行的空地，'@' 表示起始位置，以及小写字母表示门和钥匙。所有钥匙都是按字母顺序排列在一起。每一个钥匙都对应一个大写字母的锁。所有大写字母锁也是按字母顺序排列。返回获取所有钥匙所需要的移动的最少次数。如果无法打开所有锁，则返回 -1。
//思路：用BFS，找到起始位置并计算网格中键的总数。使用队列对网格进行 BFS 遍历。队列中的每个元素代表一个具有当前位置（x，y）和获取的键（状态）的状态。迭代直到队列为空。对于队列中的每个元素，探索所有四个可能的方向（上、下、左、右）。检查新位置是否有效（在网格边界内）而不是墙。如果新位置是小写字母（密钥），则通过使用位掩码获取密钥来更新状态。如果新的位置是大写字母（锁），则检查当前状态下是否已经获取到对应的key。如果不是，则跳过当前方向。如果新位置以前没有以相同的状态被访问过，则将其标记为已访问并将其入队。跟踪 BFS 遍历期间所采取的步数。如果已获取所有键（状态等于(1 <<totalKeys) - 1），则返回步骤数。如果在探索所有可能的路径后没有找到有效的路径，则返回-1。
//时间复杂度: 该解决方案的时间复杂度为 O(m * n * 2^k)，其中 m 和 n 是网格的维度，k 是键的数量。这种复杂性源于 BFS 过程中网格的遍历。每个单元格最多可以被访问一次，并且最多可以有 2^k 种不同的状态（获得的组合键）。
//空间复杂度： O(m * n * 2^k)
        public int ShortestPathAllKeys(string[] grid)
        {
            int m = grid.Length;
            int n = grid[0].Length;
            int totalKeys = 0;
            int startX = -1;
            int startY = -1;

            // Find the starting position and count the total number of keys
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (grid[i][j] == '@')
                    {
                        startX = i;
                        startY = j;
                    }
                    else if (char.IsLower(grid[i][j]))
                    {
                        totalKeys++;
                    }
                }
            }

            int[][] directions = new int[][] {
                new int[] { -1, 0 }, // up
                new int[] { 1, 0 },  // down
                new int[] { 0, -1 }, // left
                new int[] { 0, 1 }   // right
            };

            var queue = new Queue<(int, int, int)>();  // (x, y, state)
            var visited = new HashSet<(int, int, int)>();

            queue.Enqueue((startX, startY, 0));
            visited.Add((startX, startY, 0));

            int steps = 0;

            while (queue.Count > 0)
            {
                int size = queue.Count;

                for (int i = 0; i < size; i++)
                {
                    var (x, y, state) = queue.Dequeue();

                    if (state == (1 << totalKeys) - 1)
                    {
                        return steps;
                    }

                    for (int j = 0; j < 4; j++)
                    {
                        int newX = x + directions[j][0];
                        int newY = y + directions[j][1];
                        int newState = state;

                        if (newX >= 0 && newX < m && newY >= 0 && newY < n && grid[newX][newY] != '#')
                        {
                            char c = grid[newX][newY];

                            if (char.IsLower(c))
                            {
                                //allKeys 是一个二进制数，表示已经获得的钥匙集合。每个小写字母 'a' 到 'f' 对应了一个比特位，通过 (c - 'a') 计算出这个字母对应的比特位的位置。左移运算符 << 将 1 移动到对应的比特位位置，然后使用 | 操作符将这个值与 allKeys 进行按位或运算，将对应的比特位置设为 1。这样就表示获得了这个钥匙。
                                //举例说明：假设当前的钥匙集合是 allKeys = 001010（二进制表示），现在获得了 'c' 钥匙（对应 'c' - 'a' = 2），那么将执行 allKeys |= 1 << 2 操作，结果是 001110，即在第 2 位上设置了 1。
                                newState |= (1 << (c - 'a'));
                            }
                            //c - 'A' 的部分是为了将大写字母转换为相应的数字，以便确定在状态中的哪一位。(state >> (c - 'A')) 将 state 向右移动(c - 'A') 位。这实际上是将状态右移到与字母对应的位，使得该位成为最右边的比特位。最后，&1 是一个位掩码，它确保我们只保留最右边的比特位的值。这是为了检查该位是否被设置为 1。
                            //检查在给定的状态 state 中，字母 c 对应的比特位是否为 1
                            if (char.IsUpper(c) && ((state >> (c - 'A')) & 1) == 0)
                            {
                                continue;
                            }

                            if (!visited.Contains((newX, newY, newState)))
                            {
                                visited.Add((newX, newY, newState));
                                queue.Enqueue((newX, newY, newState));
                            }
                        }
                    }
                }

                steps++;
            }

            return -1;  // No valid path found
        }
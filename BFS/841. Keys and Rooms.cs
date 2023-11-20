//Leetcode 841. Keys and Rooms med
//题意：有 N 个房间，每个房间有一个不同的编号从 0 到 N-1，并且每个房间可能有一些钥匙能够打开其他房间。形式上，每个房间 i 都有一个钥匙列表 rooms[i]，每个钥匙 rooms[i][j] 由[0, 1, 2,…, N - 1] 中的一个整数表示，其中 N = rooms.length。 钥匙 rooms[i][j] = v 可以打开编号为 v 的房间。最初，除 0 号房间外的其余所有房间都被锁住。你可以自由地在房间之间来回走动。如果能进入每个房间返回 true，否则返回 false。
//思路：可以使用 BFS 进行解决。初始时将 0 号房间加入队列，然后进行 BFS 遍历，将访问过的房间标记为已访问，并将这些房间的钥匙加入队列，直到队列为空。
//时间复杂度: O(N + E)，其中 N 为房间数，E 为房间之间的钥匙数。
//空间复杂度：O(N)，用于存储已访问的房间
        public bool CanVisitAllRooms(IList<IList<int>> rooms)
        {
            int n = rooms.Count;
            HashSet<int> visited = new HashSet<int>();
            Queue<int> queue = new Queue<int>();

            // 初始时从 0 号房间开始
            queue.Enqueue(0);
            visited.Add(0);

            while (queue.Count > 0)
            {
                int currentRoom = queue.Dequeue();
                foreach (int key in rooms[currentRoom])
                {
                    if (!visited.Contains(key))
                    {
                        queue.Enqueue(key);
                        visited.Add(key);
                    }
                }
            }

            // 判断是否所有房间都被访问到
            return visited.Count == n;
        }
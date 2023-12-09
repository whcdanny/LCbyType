//Leetcode 841. Keys and Rooms med
//题意：有 N 个房间，每个房间有一个不同的编号从 0 到 N-1，并且每个房间可能有一些钥匙能够打开其他房间。形式上，每个房间 i 都有一个钥匙列表 rooms[i]，每个钥匙 rooms[i][j] 由[0, 1, 2,…, N - 1] 中的一个整数表示，其中 N = rooms.length。 钥匙 rooms[i][j] = v 可以打开编号为 v 的房间。最初，除 0 号房间外的其余所有房间都被锁住。你可以自由地在房间之间来回走动。如果能进入每个房间返回 true，否则返回 false。
//思路：来遍历房间。首先，将 0 号房间加入已访问集合，然后递归地访问其他房间，如果某个房间有钥匙且还没访问过，则继续递归。
//时间复杂度: O(N + E)，其中 N 为房间数，E 为房间之间的钥匙数。
//空间复杂度：O(N)，用于存储已访问的房间
        public bool CanVisitAllRooms(IList<IList<int>> rooms)
        {
            int n = rooms.Count;
            HashSet<int> visited = new HashSet<int>();
            DFS_CanVisitAllRooms(0, rooms, visited);

            return visited.Count == n;
        }

        private void DFS_CanVisitAllRooms(int room, IList<IList<int>> rooms, HashSet<int> visited)
        {
            if (visited.Contains(room))
            {
                return;
            }

            visited.Add(room);

            foreach (var key in rooms[room])
            {
                DFS_CanVisitAllRooms(key, rooms, visited);
            }
        }
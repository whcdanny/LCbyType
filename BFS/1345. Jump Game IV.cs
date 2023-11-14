//Leetcode 1345. Jump Game IV hard
//题意：给定一个整数数组 arr ，你一开始在数组的第一个元素处（下标为 0）。每一步，你可以从下标 i 跳到下标：i + 1 满足：i + 1 < arr.lengthi - 1 满足：i - 1 >= 0j 满足：arr[i] == arr[j] 且 i != j如果你跳到了下标 i ，你需要花费 arr[i] 的代价。请你从数组的最后一个元素处（下标为 arr.length - 1 ）跳到下标 0 处（下标为 0 ），请你返回花费的最小代价。如果无法到达下标 0 ，请返回 -1 。
//思路：BFS 进行状态搜索。对于每个位置 i，可以从 i + 1、i - 1 和相同元素的位置 j 向前走，计算到达 i 的最小代价。使用一个队列进行 BFS，每次从队列中取出当前位置 cur，计算其相邻位置的代价，如果有更小的代价，将新位置加入队列。
//时间复杂度: O(N + E)，其中 N 为数组长度，E 为相邻元素的边数
//空间复杂度：O(N + E)
        public int MinJumps(int[] arr)
        {
            var map = new Dictionary<int, List<int>>();  //val, list of indexs
            var visited = new bool[arr.Length];
            var queue = new Queue<int>();
            queue.Enqueue(0);
            visited[0] = true;
            var steps = 0;

            for (var i = 0; i < arr.Length; i++)
            {
                if (!map.ContainsKey(arr[i]))
                    map.Add(arr[i], new List<int>());
                map[arr[i]].Add(i);
            }

            while (queue.Count > 0)
            {
                var count = queue.Count;
                for (var j = 0; j < count; j++)
                {
                    var cur = queue.Dequeue();
                    if (cur == arr.Length - 1)
                        return steps;

                    if (cur - 1 >= 0 && !visited[cur - 1])
                    {
                        queue.Enqueue(cur - 1);
                        visited[cur - 1] = true;
                    }

                    if (cur + 1 < arr.Length && !visited[cur + 1])
                    {
                        queue.Enqueue(cur + 1);
                        visited[cur + 1] = true;
                    }

                    if (map.ContainsKey(arr[cur]))
                    {
                        foreach (var index in map[arr[cur]])
                        {
                            if (visited[index]) continue;
                            queue.Enqueue(index);
                            visited[index] = true;
                        }
                        map.Remove(arr[cur]);
                    }
                }
                steps++;
            }
            return -1;
        }
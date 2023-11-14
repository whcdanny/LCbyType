//Leetcode 1306. Jump Game III med
//题意：给定一个数组 arr，表示一些非负整数。起始索引为 start，可以从起始索引开始出发，最后可以跳到数组中的任意位置。在移动过程中，你可以按照下列条件跳跃：向左跳转到索引 i - arr[i]，如果 i - arr[i] >= 0。向右跳转到索引 i + arr[i]，如果 i + arr[i] < arr.length。如果你可以从起始索引跳到任意位置，返回 true；否则，返回 false。
//思路：BFS 将起始位置放入队列，然后使用BFS，不断地从队列中取出位置，然后计算其左右可以到达的位置，并将其加入队列中。在搜索的过程中，需要标记已经访问过的位置，避免重复访问。
//时间复杂度: O(N)，其中 N 是数组的长度。
//空间复杂度：O(N)
        public bool CanReach(int[] arr, int start)
        {
            int n = arr.Length;
            bool[] visited = new bool[n];
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(start);

            while (queue.Count > 0)
            {
                int curr = queue.Dequeue();
                visited[curr] = true;

                if (arr[curr] == 0)
                {
                    return true;
                }

                int left = curr - arr[curr];
                int right = curr + arr[curr];

                if (left >= 0 && !visited[left])
                {
                    queue.Enqueue(left);
                }

                if (right < n && !visited[right])
                {
                    queue.Enqueue(right);
                }
            }

            return false;
        }
//Leetcode 1306. Jump Game III med
//题意：给定一个数组 arr，表示一些非负整数。起始索引为 start，可以从起始索引开始出发，最后可以跳到数组中的任意位置。在移动过程中，你可以按照下列条件跳跃：向左跳转到索引 i - arr[i]，如果 i - arr[i] >= 0。向右跳转到索引 i + arr[i]，如果 i + arr[i] < arr.length。如果你可以从起始索引跳到任意位置，返回 true；否则，返回 false。
//思路：DFS, 当前索引越界或已经访问过，返回 false。如果当前位置的值为 0，返回 true。将当前位置标记为已访问。分别递归检查从当前位置跳到 currentIndex + arr[currentIndex] 和 currentIndex - arr[currentIndex] 是否能够到达值为 0 的索引。
//时间复杂度: O(N)，其中 N 是数组的长度。
//空间复杂度：O(N)
        public bool CanReach(int[] arr, int start)
        {
            int n = arr.Length;
            bool[] visited = new bool[n];
            return DFS_CanReach(arr, start, visited);
        }

        private bool DFS_CanReach(int[] arr, int currentIndex, bool[] visited)
        {
            if (currentIndex < 0 || currentIndex >= arr.Length || visited[currentIndex])
            {
                return false;
            }

            if (arr[currentIndex] == 0)
            {
                return true;
            }

            visited[currentIndex] = true;

            return DFS_CanReach(arr, currentIndex + arr[currentIndex], visited) ||
                   DFS_CanReach(arr, currentIndex - arr[currentIndex], visited);
        }
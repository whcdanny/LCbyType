//Leetcode 565. Array Nesting med
//题意：给定一个长度为 n 的整数数组 nums，数组中的元素表示索引，从中选择一个索引作为起始索引开始，不断访问数组中的元素，每次访问下一个元素的索引是当前元素的值。直到出现循环，则停止访问。
//思路：（DFS）进行递归遍历，对每个索引进行访问，查找当前循环的长度。标记已访问的索引，避免重复访问。
//时间复杂度: O(n)，其中 n 为节点总数
//空间复杂度：visited，空间复杂度为 O(n)
        public int ArrayNesting(int[] nums)
        {
            int maxLen = 0;
            int n = nums.Length;
            bool[] visited = new bool[n];

            for (int i = 0; i < n; i++)
            {
                if (!visited[i])
                {
                    maxLen = Math.Max(maxLen, DFS_ArrayNesting(nums, i, visited));
                }
            }

            return maxLen;
        }

        private int DFS_ArrayNesting(int[] nums, int start, bool[] visited)
        {
            int len = 0;
            int current = start;

            while (!visited[current])
            {
                visited[current] = true;
                current = nums[current];
                len++;
            }

            return len;
        }

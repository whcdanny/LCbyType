//Leetcode 526 Beautiful Arrangement    med
//题意：给定一个整数 n，要求找出由 1 到 n 组成的排列，使得对于位置 i，满足 i % nums[i] == 0 或 nums[i] % i == 0。
//思路：深度优先搜索（DFS）: 从 1 开始，逐个将数字放到排列的不同位置上，然后递归调用寻找下一个位置。当排列的长度达到 n 时，将当前排列加入结果集中。
//时间复杂度: 整数为 n，O(n * n!)
//空间复杂度： 深度可能达到 n, O(n)
        public int CountArrangement(int n)
        {
            int[] nums = new int[n];
            for (int i = 0; i < n; i++)
            {
                nums[i] = i + 1;
            }
            int[] count = new int[1];
            CountArrangement_DFS(nums, 0, count);
            return count[0];
        }

        private void CountArrangement_DFS(int[] nums, int start, int[] count)
        {
            if (start == nums.Length)
            {
                count[0]++;
                return;
            }

            for (int i = start; i < nums.Length; i++)
            {
                Swap(nums, start, i);
                if (nums[start] % (start + 1) == 0 || (start + 1) % nums[start] == 0)
                {
                    CountArrangement_DFS(nums, start + 1, count);
                }
                Swap(nums, start, i);
            }
        }

        private void Swap(int[] nums, int i, int j)
        {
            int temp = nums[i];
            nums[i] = nums[j];
            nums[j] = temp;
        }
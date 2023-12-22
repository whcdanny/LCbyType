//Leetcode  2389. Longest Subsequence With Limited Sum ez
//题意：给定一个整数数组 nums 和一个整数数组 queries，要求对于每个 queries[i]，找到数组 nums 的一个子序列，使得该子序列的元素和不超过 queries[i]，并返回子序列的最大长度。
//思路：二分搜索，nums排序，然后更新nums算前缀和；然后用这个继续二分；如果刚好找到，返回当前位置，如果大于目标值，更改right，如果小更改left；         
//时间复杂度: O(n * log(n) + m * log(n))
//空间复杂度：O(n)
        public int[] AnswerQueries(int[] nums, int[] queries)
        {
            int n = nums.Length;
            int m = queries.Length;

            if (n > 0) 
                Array.Sort(nums);

            int[] answer = new int[m];

            for (int i = 1; i < n; i++)
            {
                nums[i] += nums[i - 1];
            }

            for (int i = 0; i < m; i++)
            {
                int query = queries[i];
                int result = BinarySearch_AnswerQueries(nums, query);

                answer[i] = result + 1;

            }

            return answer;
        }

        public int BinarySearch_AnswerQueries(int[] arr, int target)
        {
            int left = 0;
            int right = arr.Length - 1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;

                if (arr[mid] == target) 
                    return mid;
                else if (arr[mid] < target)
                {
                    left = mid + 1;
                }
                else
                    right = mid - 1;
            }

            return left - 1;
        }
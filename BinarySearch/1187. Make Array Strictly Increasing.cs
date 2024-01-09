//Leetcode 1187. Make Array Strictly Increasing hard
//题意：给定两个整数数组 arr1 和 arr2，两个数组均为严格递增（strictly increasing）。希望通过多次交换 arr1 中的元素来使其变成一个严格递增的数组。返回能够完成这样的交换的最小交换次数。如果无法完成，则返回 -1。
//思路：使用二分搜索+DFS+DP dfs 方法：**递归地计算最小交换次数。对于当前位置 i 和前一个元素的值 prev，如果 arr1[i] 已经大于 prev，说明可以不做交换，递归调用 dfs(i + 1, arr1[i], arr1, arr2)。
//否则，通过二分查找找到 arr2 中大于 prev 的最小值，替换 arr1[i]，递归调用 dfs(i + 1, arr2[idx], arr1, arr2)。
//bisectRight 方法：是一个二分查找的辅助函数，用于找到数组 arr 中大于 value 的最小值的位置。
//时间复杂度: O(n*m*log(n))
//空间复杂度：O(n*m)。
        private readonly Dictionary<(int, int), int> dp_MakeArrayIncreasing = new Dictionary<(int, int), int>();        

        public int MakeArrayIncreasing(int[] arr1, int[] arr2)
        {
            Array.Sort(arr2);

            var answer = dfs(0, -1, arr1, arr2);

            return answer < int.MaxValue ? answer : -1;
        }

        private int dfs(int i, int prev, int[] arr1, int[] arr2)
        {
            if (i == arr1.Length)
            {
                return 0;
            }

            var key = (i, prev);

            if (dp_MakeArrayIncreasing.TryGetValue(key, out var cached))
            {
                return cached;
            }

            var cost = int.MaxValue;

            // If arr1[i] is already greater than prev, we can leave it be.
            if (arr1[i] > prev)
            {
                cost = dfs(i + 1, arr1[i], arr1, arr2);
            }

            // Find a replacement with the smallest value in arr2.
            var idx = bisectRight(arr2, prev);

            // Replace arr1[i], with a cost of 1 operation.
            if (idx < arr2.Length)
            {
                cost = Math.Min(cost, 1 + dfs(i + 1, arr2[idx], arr1, arr2));
            }

            return dp_MakeArrayIncreasing[key] = cost;
        }

        // Returns an insertion point which comes after (to the right of) any existing entries of `value` in `arr`
        private static int bisectRight(int[] arr, int value)
        {
            var left = 0;
            var right = arr.Length;

            while (left < right)
            {
                var mid = left + (right - left) / 2;

                if (arr[mid] <= value)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid;
                }
            }

            return left;
        }
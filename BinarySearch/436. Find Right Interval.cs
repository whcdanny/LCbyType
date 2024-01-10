//Leetcode 436. Find Right Interval med
//题意：给定一组区间 intervals，每个区间 [start, end] 都包含起始位置 start 和结束位置 end。对于每个区间 i，请找出具有最小起始位置且与 i 区间不重叠的区间 j。
//如果不存在这样的区间，则对应位置输出 -1。如果有多个区间符合要求，输出起始位置最小的那个区间。
//思路：二分搜索我们可以按照每个区间的起始位置对它们进行排序。然后，对于每个区间 i，我们可以使用二分搜索来找到第一个起始位置大于或等于 i 的结束位置。如果找到了这样的区间 j，那么 j 就是符合要求的区间；否则，j 的位置就是 -1。
//时间复杂度: O(n log n)，其中 n 是区间的数量。
//空间复杂度：O(n)
        public int[] FindRightInterval(int[][] intervals)
        {
            int n = intervals.Length;
            int[] result = new int[n];
            Dictionary<int, int> startIndices = new Dictionary<int, int>();

            for (int i = 0; i < n; i++)
            {
                startIndices[intervals[i][0]] = i;
            }

            List<int> sortedStarts = new List<int>(startIndices.Keys);
            sortedStarts.Sort();

            for (int i = 0; i < n; i++)
            {
                int end = intervals[i][1];
                int index = BinarySearch_FindRightInterval(sortedStarts, end);

                if (index == sortedStarts.Count)
                {
                    result[i] = -1;
                }
                else
                {
                    result[i] = startIndices[sortedStarts[index]];
                }
            }

            return result;
        }

        private int BinarySearch_FindRightInterval(List<int> sortedStarts, int target)
        {
            int left = 0, right = sortedStarts.Count;

            while (left < right)
            {
                int mid = left + (right - left) / 2;

                if (sortedStarts[mid] < target)
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
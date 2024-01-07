//Leetcode 1539. Kth Missing Positive Number ez
//题意： 给定一个严格递增排序的正整数数组 arr 和一个整数 k。返回缺失的第 k 个正整数。
//思路：使用二分搜索，我们可以观察到，如果没有缺失的话，arr[i] 应该等于 i + 1，因为数组是从 1 开始递增的正整数数组。那么缺失的第 k 个正整数，实际上就是数组 arr 中第 k 个元素的值减去 k，即 arr[i] - i - 1。为了找到缺失的第 k 个正整数，我们可以使用二分查找。
//注： arr[mid]表示当前数，  (mid + 1)表示这个位置应该有的数，如果差值小于 k 说明需要找更大的；
//时间复杂度: O(log n)
//空间复杂度：O(1)
        public int FindKthPositive(int[] arr, int k)
        {
            int left = 0, right = arr.Length;

            while (left < right)
            {
                int mid = left + (right - left) / 2;
                //
                if (arr[mid] - (mid + 1) < k)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid;
                }
            }

            return left + k;
        }
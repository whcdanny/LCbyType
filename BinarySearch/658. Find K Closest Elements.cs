//Leetcode 658. Find K Closest Elements med
//题意：给定一个已排序的数组 arr，两个整数 k 和 x，找出数组中最接近 x 且有 k 个元素的子数组。返回这个子数组的起始位置。
//思路：二分搜索：首先，找到数组中最接近 x 的元素的索引，然后从该索引开始向两端扩展，选择最接近 x 的 k 个元素。
//使用二分查找找到最接近 x 的元素的索引 left。
//从 left 开始，向两端扩展，选择最接近 x 的 k 个元素
//时间复杂度: O(log n + k)，其中 n 为数组的长度。
//空间复杂度：O(k)
        public IList<int> FindClosestElements(int[] arr, int k, int x)
        {
            List<int> result = new List<int>();

            int left = 0;
            int right = arr.Length - 1;

            // 二分查找找到最接近 x 的元素的索引
            while (left < right)
            {
                int mid = left + (right - left) / 2;

                if (arr[mid] < x)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid;
                }
            }

            // 从最接近 x 的元素的位置向两端扩展，选择 k 个元素
            int start = left - 1;
            int end = left;

            while (k > 0)
            {
                if (start >= 0 && end < arr.Length)
                {
                    if (Math.Abs(arr[start] - x) <= Math.Abs(arr[end] - x))
                    {
                        result.Insert(0, arr[start]);
                        start--;
                    }
                    else
                    {
                        result.Add(arr[end]);
                        end++;
                    }
                }
                else if (start >= 0)
                {
                    result.Insert(0, arr[start]);
                    start--;
                }
                else
                {
                    result.Add(arr[end]);
                    end++;
                }

                k--;
            }

            return result;
        }
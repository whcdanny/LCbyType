//Leetcode 1385. Find the Distance Value Between Two Arrays ez
//题意：题目要求计算两个数组之间的「距离值」。距离值的定义为，对于数组 arr1 中的每个元素 x，如果不存在 arr2 中的元素 y 满足 |x - y| <= d，则将 x 看作有效的元素，否则将其视为无效元素。要求计算有效元素的数量。
//思路：使用二分搜索对 arr2 进行排序。
//对于 arr1 中的每个元素 x，在 arr2 中使用二分搜索找到最接近 x 的元素，计算其绝对差 absDiff。
//如果 absDiff <= d，则 x 为有效元素，计数器加一。
//返回计数器的值。
//时间复杂度:  O(n log m)，其中 n 为 arr1 的长度，m 为 arr2 的长度
//空间复杂度： O(1)
        public int FindTheDistanceValue(int[] arr1, int[] arr2, int d)
        {
            Array.Sort(arr2);

            int count = 0;
            foreach (var x in arr1)
            {
                if (!IsValid_FindTheDistanceValue(x, arr2, d))
                {
                    count++;
                }
            }

            return count;
        }

        private bool IsValid_FindTheDistanceValue(int x, int[] arr2, int d)
        {
            int left = 0, right = arr2.Length - 1;
            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                int absDiff = Math.Abs(x - arr2[mid]);
                if (absDiff <= d)
                {
                    return true;
                }
                else if (x < arr2[mid])
                {
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }
            return false;
        }
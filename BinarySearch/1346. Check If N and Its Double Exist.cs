//Leetcode 1346. Check If N and Its Double Exist ez
//题意：给定一个整数数组 arr，判断是否存在两个不同的索引 i 和 j，使得 arr[i] == 2 * arr[j] 或 arr[j] == 2 * arr[i]。
//思路：使用二分搜索二分搜索查找每个元素的两倍是否存在于数组中
//时间复杂度: O(n log n)，其中 n 是数组的长度
//空间复杂度： O(1)
        public bool CheckIfExist(int[] arr)
        {
            Array.Sort(arr);
            for(int i = 0; i < arr.Length; i++)
            {
                int index = binarySearch_CheckIfExist(arr, arr[i]*2);
                if (index != i && index != -1) return true;
            }            

            return false;
        }

        private int binarySearch_CheckIfExist(int[] arr, int target)
        {
            int left = 0;
            int right = arr.Length - 1;
            while (left <= right)
            {
                int mid = left + (right - left) / 2;

                if (arr[mid] == target)
                {
                    return mid;
                }
                else if (arr[mid] < target)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }
            return -1;
        }

        public bool CheckIfExist1(int[] arr)
        {
            HashSet<int> set = new HashSet<int>();
            foreach (int num in arr)
            {
                if (set.Contains(num * 2) || (num % 2 == 0 && set.Contains(num / 2)))
                {
                    return true;
                }
                set.Add(num);
            }
            return false;
        }
//Leetcode 1471. The k Strongest Values in an Array med
//题意：给定一个整数数组 arr 和整数 k。定义：如果对于数组中的两个元素 arr[i] 和 arr[j]（i 不等于 j），满足：
//如果 |arr[i] - m| > |arr[j] - m|，其中 m 是数组的中位数。
//如果 |arr[i] - m| == |arr[j] - m|，那么 arr[i] > arr[j]。
//则称 arr[i] 比 arr[j] 更强。现在要求返回数组中最强的 k 个元素。
//思路：双指针，数组进行排序，以便找到中位数。
//然后使用双指针，一个从数组的开头移动到中间，另一个从数组的结尾移动到中间。两个指针移动的方式是判断当前元素与中位数的强度大小关系，然后选择移动更强的一侧。
//将最终找到的最强的 k 个元素返回。
//时间复杂度：O(n log n)（由于排序）
//空间复杂度：O(1)
        public int[] GetStrongest(int[] arr, int k)
        {
            Array.Sort(arr);
            int median = arr[(arr.Length - 1) / 2];
            int[] result = new int[k];
            int left = 0, right = arr.Length - 1;
            int index = 0;

            while (index < k)
            {
                if (Math.Abs(arr[left] - median) > Math.Abs(arr[right] - median))
                {
                    result[index++] = arr[left++];
                }
                else
                {
                    result[index++] = arr[right--];
                }
            }

            return result;
        }
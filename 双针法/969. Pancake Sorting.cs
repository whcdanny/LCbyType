//Leetcode 969. Pancake Sorting med
//题意：给定一个整数数组 arr，通过执行一系列煎饼翻转操作来对数组进行排序。
//在一次煎饼翻转操作中，执行以下步骤：
//选择一个整数 k，其中 1 <= k <= arr.length。
//反转子数组 arr[0...k - 1]（以 0 为索引）。
//例如，如果 arr = [3, 2, 1, 4]，并且我们执行一个选择 k = 3 的煎饼翻转，我们将反转子数组[3, 2, 1]，因此在 k = 3 的煎饼翻转后，arr = [1,2,3,4]。
//返回一个数组，其中包含按照一系列煎饼翻转操作对 arr 进行排序的 k 值。对数组进行排序的任何有效答案，其翻转次数不超过 10 * arr.length，都将被判定为正确。
//思路：双指针，数组的最后一个元素开始，找到当前未排序部分的最大元素的位置 maxIndex。
//进行两次翻转操作，将最大元素移动到未排序部分的最前面。
//将最大元素移到数组的最前面后，再进行一次翻转操作，将其移动到正确的位置
//时间复杂度：O(n^2)，其中 n 是数组的长度
//空间复杂度：O(1)
        public IList<int> PancakeSort(int[] arr)
        {
            List<int> result = new List<int>();
            int n = arr.Length;

            for (int i = n; i > 0; i--)
            {
                int maxIndex = FindMaxIndex_PancakeSort(arr, i);

                if (maxIndex != i - 1)
                {
                    Flip_PancakeSort(arr, maxIndex + 1);
                    result.Add(maxIndex + 1);

                    Flip_PancakeSort(arr, i);
                    result.Add(i);
                }
            }

            return result;
        }

        private int FindMaxIndex_PancakeSort(int[] arr, int n)
        {
            int maxIndex = 0;
            for (int i = 0; i < n; i++)
            {
                if (arr[i] > arr[maxIndex])
                {
                    maxIndex = i;
                }
            }
            return maxIndex;
        }

        private void Flip_PancakeSort(int[] arr, int k)
        {
            int left = 0, right = k - 1;
            while (left < right)
            {
                int temp = arr[left];
                arr[left] = arr[right];
                arr[right] = temp;
                left++;
                right--;
            }
        }
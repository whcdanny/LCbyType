//Leetcode 1850. Minimum Adjacent Swaps to Reach the Kth Smallest Number med
//题意：给定一个数字字符串 num 和一个整数 k，我们需要进行最少的相邻数字交换，使得得到的新数字字符串是原数字字符串的一个排列，并且新的数字字符串比原字符串大。
//思路：双指针 先找出第k次的结果，这里用的是双针，从数字的最右侧找到第一个非递增的数字 arr[i]，交换 arr[i] 和 arr[j]。arr[i] 右边的部分进行逆序，保持升序。
//然后跟原来的数做比较，如果不相等，就找到 arr[i] 在 original 中的位置，然后通过多次相邻交换将 arr[i] 移动到正确的位置。swaps 变量记录了总的相邻交换次数
//时间复杂度：O(n log n)，其中 n 是字符串的长度
//空间复杂度：O(1)
        public int GetMinSwaps(string num, int k)
        {
            char[] arr = num.ToCharArray();
            string original = new string(arr);

            for (int i = 0; i < k; i++)
            {
                NextPermutation_GetMinSwaps(arr);
            }

            int swaps = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                //如果不相等，就找到 arr[i] 在 original 中的位置，然后通过多次相邻交换将 arr[i] 移动到正确的位置。swaps 变量记录了总的相邻交换次数。
                if (arr[i] != original[i])
                {
                    int j = i + 1;
                    while (j < arr.Length && arr[j] != original[i])
                    {
                        j++;
                    }

                    while (j > i)
                    {
                        Swap_GetMinSwaps(arr, j, j - 1);
                        swaps++;
                        j--;
                    }
                }
            }

            return swaps;
        }
        //函数的目标是找到当前排列的下一个排列。为了找到下一个排列，
        private void NextPermutation_GetMinSwaps(char[] arr)
        {
            int i = arr.Length - 2;
            //右到左遍历数组，找到第一个非递增的数字 arr[i]，即找到第一个 arr[i] < arr[i+1] 的位置。如果找不到这样的位置，说明当前排列已经是最大排列，无法再找到下一个排列，直接返回数组的逆序。
            while (i >= 0 && arr[i] >= arr[i + 1])
            {
                i--;
            }

            if (i >= 0)
            {
                int j = arr.Length - 1;
                while (j >= 0 && arr[j] <= arr[i])
                {
                    j--;
                }

                Swap_GetMinSwaps(arr, i, j);
            }

            Reverse_GetMinSwaps(arr, i + 1, arr.Length - 1);
        }

        private void Swap_GetMinSwaps(char[] arr, int i, int j)
        {
            char temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }

        private void Reverse_GetMinSwaps(char[] arr, int start, int end)
        {
            while (start < end)
            {
                Swap_GetMinSwaps(arr, start, end);
                start++;
                end--;
            }
        }
//Leetcode 1089. Duplicate Zeros ez
//题意：给定一个固定长度的整数数组 arr，要求将数组中的每个 0 复制一次，并将剩余的元素向右移动。需要在原地进行修改，不返回任何内容。
//思路：双指针，一个指向原始数组的末尾，另一个指向需要修改的数组的末尾。
//从原始数组的末尾开始遍历，如果当前元素不为 0，直接将其复制到修改数组的末尾，然后两个指针都左移一位。
//如果当前元素为 0，则复制两次 0 到修改数组的末尾，然后两个指针都左移一位。
//重复这个过程，直到原始数组的指针移动到数组的开头。
//时间复杂度： O(n)，其中n 是数组的长度
//空间复杂度：O(1)
        public void DuplicateZeros(int[] arr)
        {
            int n = arr.Length;
            int i = n - 1;

            // Count the number of zeros to determine the new length of the modified array
            int zeroCount = 0;
            foreach (var num in arr)
            {
                if (num == 0) zeroCount++;
            }

            // Calculate the new length after duplication
            int newLength = n + zeroCount;

            // Use two pointers: one for the original array, one for the modified array
            int j = newLength - 1;

            // Continue until the original array pointer reaches the beginning
            while (i >= 0)
            {
                // If the current element is not zero, copy it to the modified array
                if (arr[i] != 0)
                {
                    if (j < n)
                    {
                        arr[j] = arr[i];
                    }
                }
                else
                {
                    // If the current element is zero, copy two zeros to the modified array
                    if (j < n)
                    {
                        arr[j] = 0;
                    }
                    j--;
                    if (j < n)
                    {
                        arr[j] = 0;
                    }
                }

                // Move both pointers to the left
                i--;
                j--;
            }
        }
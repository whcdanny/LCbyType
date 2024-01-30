//Leetcode 556. Next Greater Element III med
//题意：给定一个正整数 n，要求找到比 n 大且由相同数字组成的最小整数。如果不存在这样的整数，则返回 -1。
//思路：双指针，整数 n 转换为字符数组 digits。
//从右到左找到第一个递减的位置 i。
//如果不存在递减的位置，说明整数已经是最大的，返回 -1。
//从右到左找到第一个大于 digits[i] 的位置 j。
//交换 digits[i] 和 digits[j]。
//反转 i 后面的部分。
//将字符数组转换为整数，如果结果不超过 32 位整数范围，返回结果；否则返回 -1。
//时间复杂度：O(logn)，其中 n 是整数的位数。
//空间复杂度：O(1)
        public int NextGreaterElement(int n)
        {
            char[] digits = n.ToString().ToCharArray();

            // 从右到左找到第一个递减的位置 i
            int i = digits.Length - 2;
            while (i >= 0 && digits[i] >= digits[i + 1])
            {
                i--;
            }

            // 如果不存在递减的位置，说明整数已经是最大的，返回 -1
            if (i == -1)
            {
                return -1;
            }

            // 从右到左找到第一个大于 digits[i] 的位置 j
            int j = digits.Length - 1;
            while (j >= 0 && digits[j] <= digits[i])
            {
                j--;
            }

            // 交换 digits[i] 和 digits[j]
            Swap_NextGreaterElement(digits, i, j);

            // 反转 i 后面的部分
            Reverse_NextGreaterElement(digits, i + 1, digits.Length - 1);

            // 将字符数组转换为整数
            int result;
            if (Int32.TryParse(new string(digits), out result))
            {
                return result;
            }
            else
            {
                return -1;
            }
        }

        // 交换数组中两个位置的元素
        private void Swap_NextGreaterElement(char[] arr, int i, int j)
        {
            char temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }

        // 反转数组中指定范围的元素
        private void Reverse_NextGreaterElement(char[] arr, int start, int end)
        {
            while (start < end)
            {
                Swap_NextGreaterElement(arr, start, end);
                start++;
                end--;
            }
        }
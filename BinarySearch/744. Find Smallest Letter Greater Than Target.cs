//Leetcode 744. Find Smallest Letter Greater Than Target ez
//题意：给定一个已排序的字符数组 letters 和一个目标字母 target，请找到数组中比目标字母大的最小字母。如果找不到，则返回数组中的第一个字母。
//思路：初始化左右指针： 使用左右指针 left 和 right，初始分别指向数组的起始和结束位置。
//开始二分搜索： 在循环中，计算中间位置 mid，并比较 letters[mid] 与目标字母 target 的大小。
//如果 letters[mid] <= target，说明目标字母在 mid 右侧，将 left 移动到 mid + 1。
//如果 letters[mid] > target，说明目标字母可能在 mid 左侧或就是 mid，将 right 移动到 mid。
//返回结果： 循环结束后，left 就是最终的答案。
//处理边界情况： 如果 left 超出数组范围，说明目标字母大于数组中的所有字母，因此返回数组的第一个字母。
//时间复杂度: O(log N)，其中 N 是数组的长度。
//空间复杂度：O(1)
        public char NextGreatestLetter(char[] letters, char target)
        {
            int left = 0, right = letters.Length;

            while (left < right)
            {
                int mid = left + (right - left) / 2;

                if (letters[mid] <= target)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid;
                }
            }

            // 处理边界情况
            return left == letters.Length ? letters[0] : letters[left];
        }

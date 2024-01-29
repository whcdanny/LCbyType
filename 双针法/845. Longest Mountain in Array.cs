//Leetcode 845. Longest Mountain in Array med
//题意：一个数组 arr 被称为山脉数组，当且仅当：
//arr.length >= 3，数组长度至少为3。
//存在一个索引 i（0索引），满足 0 < i<arr.length - 1，使得：
//arr[0] < arr[1] < ... < arr[i - 1] < arr[i]
//arr[i]> arr[i + 1] > ... > arr[arr.length - 1]
//给定一个整数数组 arr，要求返回最长的山脉子数组的长度。如果不存在山脉子数组，则返回0。
//思路：双指针，每个可能的山顶位置为中心，向左右两边扩展。
//使用两个指针 left 和 right 分别表示山脉的左边和右边。并且bool表示是否有左右山；
//在循环中，分别向左和向右扩展，直到不满足山脉的条件。
//如果 left 不等于山顶位置且 right 不等于山顶位置，说明找到了一个山脉，更新最长山脉的长度。
//时间复杂度：O(n)
//空间复杂度：O(1)
        public int LongestMountain(int[] arr)
        {
            int n = arr.Length;
            int maxLength = 0;

            for (int peak = 1; peak < n - 1; peak++)
            {
                int left = peak;
                int right = peak;
                bool foundLeft = false;
                bool foundRight = false;

                while (left > 0 && arr[left - 1] < arr[left])
                {
                    left--;
                    foundLeft = true;
                }

                while (right < n - 1 && arr[right] > arr[right + 1])
                {
                    right++;
                    foundRight = true;
                }

                if (foundLeft && foundRight)
                {
                    maxLength = Math.Max(maxLength, right - left + 1);
                }
            }

            return maxLength;
        }
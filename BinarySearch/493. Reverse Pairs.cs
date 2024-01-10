//Leetcode 493. Reverse Pairs hard
//题意：给定一个整数数组 nums，如果 i < j 且 nums[i] > 2 * nums[j]，则称 (i, j) 是一个重要翻转对。
//你需要返回给定数组中的重要翻转对的数量。
//思路：二分搜索+分支法+归并排序：定义一个辅助数组 temp 用于存储归并排序的结果。
//对于每一对(i, j)，其中 i 表示左侧数组的索引，j 表示右侧数组的索引：
//如果 nums[i] > 2 * nums[j]，则表明存在翻转对，累加计数。
//将左右两侧已排序的子数组合并到 temp 数组中。
//将 temp 数组中的排序结果复制回原数组 nums。
//注：分支法：一个大数组拆分成两个小数组；小数组的和+小数组在大数组中没算的；返回的时候排序 用归并排序，有助于算小数组在大数组中没算的；
//时间复杂度: O(n log n)，其中 n 是数组的长度。归并排序的时间复杂度为 O(n log n)。
//空间复杂度：O(n)用于存储归并排序时的辅助数组
        public int ReversePairs(int[] nums)
        {
            return MergeSort(nums, 0, nums.Length - 1);
        }

        private int MergeSort(int[] nums, int left, int right)
        {
            if (left >= right)
            {
                return 0;
            }

            int mid = left + (right - left) / 2;
            int count = MergeSort(nums, left, mid) + MergeSort(nums, mid + 1, right);

            // 统计重要翻转对
            int j = mid + 1;
            for (int i = left; i <= mid; i++)
            {
                while (j <= right && (long)nums[i] > 2 * (long)nums[j])
                {
                    j++;
                }
                count += j - (mid + 1);
            }

            // 归并排序
            int[] temp = new int[right - left + 1];
            int p = 0, p1 = left, p2 = mid + 1;
            while (p1 <= mid || p2 <= right)
            {
                if (p1 > mid)
                {
                    temp[p++] = nums[p2++];
                }
                else if (p2 > right)
                {
                    temp[p++] = nums[p1++];
                }
                else
                {
                    temp[p++] = nums[p1] <= nums[p2] ? nums[p1++] : nums[p2++];
                }
            }

            Array.Copy(temp, 0, nums, left, temp.Length);

            return count;
        }
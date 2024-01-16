//Leetcode 2161. Partition Array According to Given Pivot med
//题意：给定一个整数数组 nums 和一个整数 pivot，要求重新排列数组，使得满足以下条件：
//所有小于 pivot 的元素出现在所有大于 pivot 的元素之前。
//所有等于 pivot 的元素出现在所有小于和大于 pivot 的元素之间。
//元素之间的相对顺序保持不变。
//思路：左右针，按题目要求先小于，等于，大于；
//时间复杂度: O(n)
//空间复杂度：O(n)
        public int[] pivotArray(int[] nums, int pivot)
        {
            int[] ans = new int[nums.Length];
            int j = 0;

            foreach (int num in nums)
                if (num < pivot)
                    ans[j++] = num;

            foreach (int num in nums)
                if (num == pivot)
                    ans[j++] = num;

            foreach (int num in nums)
                if (num > pivot)
                    ans[j++] = num;

            return ans;
        }
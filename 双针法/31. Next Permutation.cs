//Leetcode 31. Next Permutation med
//题意：给定一个整数数组 nums，找到其下一个排列。
//排列是一种将元素重新排列的方式。例如，数组[1, 2, 3] 有以下排列：[1,2,3]、[1,3,2]、[2,1,3]、[2,3,1]、[3,1,2]、[3,2,1]。
//如果没有下一个更大的排列，则将数字重新排列成最小的排列（即按升序排列）。
//注意：
//必须在原地修改，只使用 O(1) 额外空间。
//必须使用常数时间复杂度。
//简而言之，题目要求在原地修改给定数组，找到其下一个字典序排列。
//思路：双指针，数组的最后一个元素开始，找到第一个不满足降序排列的元素，记为 i。即，nums[i] < nums[i+1]。
//如果不存在这样的元素，说明整个数组是降序排列的，直接翻转整个数组得到最小的排列。
//如果存在 i，再从数组的最后一个元素开始，找到第一个比 nums[i] 大的元素，记为 j。
//交换 nums[i] 和 nums[j]。
//最后，将从 i+1 开始到数组末尾的元素逆序，即翻转这部分数组，得到字典序上的下一个排列。
//时间复杂度：O(n)
//空间复杂度：O(1)
        public void NextPermutation(int[] nums)
        {
            int i = nums.Length - 2;

            // Find the first element that breaks the descending order
            while (i >= 0 && nums[i] >= nums[i + 1])
            {
                i--;
            }

            // If no such element exists, reverse the array
            if (i == -1)
            {
                Array.Reverse(nums);
                return;
            }

            // Find the first element greater than nums[i]
            int j = nums.Length - 1;
            while (j > i && nums[j] <= nums[i])
            {
                j--;
            }

            // Swap nums[i] and nums[j]
            Swap_NextPermutation(nums, i, j);

            // Reverse the subarray from i+1 to the end
            Array.Reverse(nums, i + 1, nums.Length - i - 1);
        }
        private void Swap_NextPermutation(int[] nums, int i, int j)
        {
            int temp = nums[i];
            nums[i] = nums[j];
            nums[j] = temp;
        }
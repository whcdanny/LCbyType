//324. Wiggle Sort II med
//题目：给定一个整数数组 nums，重新排列数组使其满足如下摆动排序要求：
//nums[0] < nums[1] > nums[2] < nums[3]...
//题目假设输入数组总是有一个有效的答案。
//思路：数组排序： 首先对数组进行排序，便于区分较小和较大部分。
//划分两部分：
//较小部分：取排序后前一半。
//较大部分：取排序后后一半。
//重新排列： 使用索引映射，将较大的部分从后往前填入奇数位置，较小的部分从后往前填入偶数位置。
//奇数位置（1, 3, ...）：放置较大的部分。
//偶数位置（0, 2, ...）：放置较小的部分。
//i % 2 == 0来安排数字
//时间复杂度:  O(n log n)
//空间复杂度： O(n)
        public void WiggleSort(int[] nums)
        {
            int n = nums.Length;
            //不能直接==nums，因为我们不能修改原数组
            int[] list = (int[])nums.Clone();
            Array.Sort(list);
            
            int left = (n - 1) / 2;
            int right = n - 1;
            for(int i = 0; i < n; i++)
            {
                if (i % 2 == 0)
                {
                    nums[i] = list[left--];
                }
                else
                {
                    nums[i] = list[right--];
                }
            }
        }
//Leetcode 2779. Maximum Beauty of an Array After Applying Operation med
//题意：给定一个数组 nums 和一个非负整数 k。每次操作可以选择一个尚未选择过的索引 i（范围为 [0, nums.length - 1]），并用范围 [nums[i] - k, nums[i] + k] 中的任意整数替换 nums[i]。数组的美丽度定义为由相等元素组成的最长子序列的长度。
//要求在任意次数的操作后，返回数组 nums 的最大可能美丽度。
//需要注意的是，每个索引 i 只能被选择一次。子序列是由原始数组中删除一些元素（可能为空）而生成的新数组，而不改变剩余元素的顺序。
//思路：二分查找来解决, 将数组 nums 进行排序，确保相同的元素相邻;
//需要找到这个子数组的最后一个元素。显然，最大可能值将是最后一个元素的最小可能值：nums[last] - k = nums[first] + k。我们得到 nums[last] = nums[first] + 2k 的关系
//说白了这个数组被sort之和，当前i为最小的，那么如果想满足改变之和的值与后面都相同那么就是，最小的最大范围nums[first] + k，与最大值的最小值nums[last] - k 一样；
//注：这里的逻辑是假设我们算出一个group修改之和都满足相同value，那么第一位的就算nums[first] + k，最后一位nums[last] - k ，那么也就是说，对于last的边界就算nums[first] + 2k，所以用二分法只要找到，右边界，那么就能算出一个length；            
//时间复杂度:  O(n∗log(n))
//空间复杂度： O(1)
        public int MaximumBeauty(int[] nums, int k)
        {
            Array.Sort(nums);
            int res = 1;
            int n = nums.Length;
            int last = -1;
            //右边界记录
            int lastRight = 0;
            for (int i = 0; i < n; i++)
            {
                //skip repeated elements
                if (nums[i] == last)
                    continue;
                //需要找到这个子数组的最后一个元素。显然，最大可能值将是最后一个元素的最小可能值：nums[last] - k = nums[first] + k。我们得到 nums[last] = nums[first] + 2k 的关系
                //说白了这个数组被sort之和，当前i为最小的，那么如果想满足改变之和的值与后面都相同那么就是，最小的最大范围nums[first] + k，与最大值的最小值nums[last] - k 一样；
                int maxValue = nums[i] + k + k;
                res = Math.Max(res, MaximumBeauty(nums, i, maxValue, ref lastRight));
                last = nums[i];

            }
            return res;
        }

        private int MaximumBeauty(int[] nums, int start, int maxV, ref int lastRight)
        {
            int left = lastRight;
            int n = nums.Length;
            int right = n - 1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                if (nums[mid] > maxV)
                    right = mid - 1;
                else if (nums[mid] <= maxV)
                {
                    left = mid + 1;
                }

            }
            //记录当时right边界，然后用于下一次算的left；
            lastRight = right;
            return right - start + 1;
        }
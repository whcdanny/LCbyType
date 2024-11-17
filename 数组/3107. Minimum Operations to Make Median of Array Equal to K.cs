//Leetcode 3107. Minimum Operations to Make Median of Array Equal to K med
//题目：给定一个整数数组 nums 和一个非负整数 k。在一次操作中，你可以将数组中的任意元素增加或减少 1。
//你的任务是计算 最少需要多少次操作，才能使数组的中位数等于 k。
//中位数定义：
//中位数是数组排序后位于中间的元素。如果数组长度为奇数，中位数是中间的元素；如果数组长度为偶数，中位数是两个中间元素中的较大值。
//思路: 这个逻辑是，如果25568 k=4 那么应该是再2(4)5(中间数5)68 25568 k=7 25(中间数5)6(7)8
//这样就看k的插入初始nums的位置在中间数的左侧还是右侧
//如果k < nums[mid] 就找mid-1到0有多少个nums[i]>k，然后算差值nums[i] - k；
//如果k >= nums[mid] 就找mid+1到length有多少个nums[i]<k，然后算差值k - nums[i]；
//最后看一下nums[mid] - k 然后输出res
//时间复杂度：O(n log n)
//空间复杂度：O(1)
        public long MinOperationsToMakeMedianK(int[] nums, int k)
        {
            Array.Sort(nums);
            long res = 0;
            var mid = nums.Length / 2;

            if (k < nums[mid])
                for (int i = mid - 1; i >= 0; i--)
                    if (nums[i] <= k) 
                        break;
                    else 
                        res += nums[i] - k;
            else
                for (int i = mid + 1; i < nums.Length; i++)
                    if (nums[i] >= k) 
                        break;
                    else 
                        res += k - nums[i];
            return res + Math.Abs(nums[mid] - k);
        }
//Leetcode 2970. Count the Number of Incremovable Subarrays I ez;
//题意：给定一个由正整数组成的数组 nums，一个子数组被称为“incremovable”（不可移除的），如果在移除该子数组后，数组 nums 变得严格递增。
//例如，对于数组 [5, 3, 4, 6, 7]，子数组 [3, 4] 是一个“incremovable”子数组，因为移除这个子数组后，数组变成了 [5, 6, 7]，严格递增。
//要求返回 nums 中“incremovable”子数组的总数。需要注意，空数组被认为是严格递增的。
//子数组是数组中连续的非空元素序列。
//思路：左右针，在两端查找严格递增/严格升序子数组”您现在不是计算要删除的子数组的数量以使剩余数组严格增加，而是查看通过从给定数组的两个严格增加的分区中选择前缀和后缀可以形成的有效数组的数量。
//有效的子数组将仅由严格增加的部分组成。
//找到leftIdx从开始到严格递增的idx, 如果leftIdx = n，则意味着整个数组是严格递增的，那么我们将返回子数组的总数，就好像我们从严格递增的数组中删除任何内容一样，它将始终严格递增。
//找到rightIdx从末尾到严格递增的idx。
//[1,2,5,2,9,2,4,7,8,9] ，这里leftIdx = 2& rightIdx = 5 移除之和的效果是[2,4,7,8,9], [4,7,8,9], [7,8,9], [8,9], [9],[]， 
//右侧严格递增部分组成的可增量子数组是右侧部分中的元素数量，并且加一用于删除整个数组，因为空数组也被视为严格递增
//我们检查左部分元素是否小于右部分元素，如果是，则通过指向右部分元素的指针来统计所形成的子数组，如果否，则增加右部分的指针subArray 对所有左侧部分元素一次又一次地重复此过程。
//时间复杂度:  O(n)
//空间复杂度：  O(1)
        public long IncremovableSubarrayCount(int[] nums)
        {
            var n = nums.Length;

            var leftidx = 0;
            while (leftidx + 1 < n && nums[leftidx] < nums[leftidx + 1])
                leftidx++;

            if (leftidx == n - 1)
                //整个都是递增，所以可以是等差数列的求和公式
                return (long)n * (n + 1) / 2;

            var rightidx = n - 1;
            while (nums[rightidx - 1] < nums[rightidx])
                rightidx--;

            long totalIncremovableSubarrays = 0;
            totalIncremovableSubarrays += (n - (int)rightidx) + 1;

            int left = 0, right = (int)rightidx;

            while (left <= leftidx)
            {
                while (right < n && nums[left] >= nums[right])
                {
                    right++;
                }
                totalIncremovableSubarrays += (n - right + 1);
                left++;
            }

            return totalIncremovableSubarrays;
        }
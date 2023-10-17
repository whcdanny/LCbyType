//Leetcode 1060. Missing Element in Sorted Array med
//题意：在一个升序排列的整数数组中找到缺失的元素
//思路：二分法: 由于数组是升序排列的，我们可以通过计算数组中每个位置上的数值与预期值的差，来找到缺失的元素。
//时间复杂度: n 是数组的长度, O(logn)
//空间复杂度： O(1)    
        public int MissingElement(int[] nums, int k)
        {
            int left = 0, right = nums.Length - 1;

            while (left < right)
            {
                int mid = left + (right - left) / 2;
                int expectedValue = nums[0] + mid;
                int diff = nums[mid] - expectedValue;

                if (diff < k)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid;
                }
            }

            return nums[left - 1] + k - (nums[left - 1] + left - 1);
        }
		
		//1060. Missing Element in Sorted Array 
        //给定一个按升序排序的整数数组 nums，其中数组中的数字是连续的（但可能有一些缺失），请找出缺失的那个数
        //思路：由于数组按升序排序且连续，缺失的元素可以通过使用二分搜索找到缺失的元素;如果缺失的元素在当前区间内，则缺失的元素在右侧,如果缺失的元素不在当前区间内，则缺失的元素在左侧;
        public int MissingElement(int[] nums)
        {
            int n = nums.Length;
            int left = 0, right = n - 1;

            // 如果最后一个元素已经缺失，则直接返回缺失的值
            if (nums[right] - nums[left] == n - 1)
                return nums[right] + 1;

            // 使用二分搜索找到缺失的元素
            while (left < right)
            {
                int mid = left + (right - left) / 2;
                int missing = nums[mid] - nums[left] - (mid - left);

                // 如果缺失的元素在当前区间内，则缺失的元素在右侧
                if (missing > 0)
                    right = mid;
                // 如果缺失的元素不在当前区间内，则缺失的元素在左侧
                else
                    left = mid + 1;
            }

            // 缺失的元素为当前left元素的值加上缺失的个数
            return nums[left] + left - nums[0];
        }
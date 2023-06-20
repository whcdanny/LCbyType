//1060. Missing Element in Sorted Array med
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

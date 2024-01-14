//Leetcode 2824. Count Pairs Whose Sum is Less than Target ez
//题意：给定一个长度为 n 的整数数组 nums 和一个整数 target。要求返回满足条件 nums[i] + nums[j] < target 的不同索引对 (i, j) 的数量，其中 0 <= i < j < n。        
//思路：左右针， 按升序对数组进行排序。排序有助于有效地探索总和小于目标值的对。
//当左指针小于右指针时：如果左右元素之和小于目标值，则表示与当前左元素的所有对也满足条件。因此，将计数从右到左递增，并将左指针向右移动。
//如果总和大于或等于目标，则将右指针向左移动。        
//时间复杂度: O(nlogn)
//空间复杂度：O(1)
        public int CountPairs(IList<int> nums, int target)
        {
            nums = nums.OrderBy(x => x).ToList();
            int count = 0; 
            int left = 0; 
            int right = nums.Count - 1; 
            while (left < right)
            {
                if (nums[left] + nums[right] < target)
                { 
                    count += right - left;
                    left++; 
                }
                else
                { 
                    right--; 
                }
            }
            return count; 
        }
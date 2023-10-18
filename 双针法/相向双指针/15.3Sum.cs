//Leetcode 15.3Sum med
//题意：给定一个整数数组 nums，要求找到所有不重复的三元组，使得三元组的和等于零。
//思路：双指针方法来解决这个问题。将数组排序。遍历数组，对于每个元素 nums[i]，将其作为目标值，并使用双指针在剩余的元素中查找两个数使它们的和等于 0 - nums[i]。使用两个指针 left 和 right 分别指向剩余元素的最左端和最右端。
//时间复杂度:  排序的时间复杂度是 O(nlogn)，双指针遍历的时间复杂度是 O(n^2)，所以总的时间复杂度是 O(n^2)。
//空间复杂度： O(1)           
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            IList<IList<int>> res = new List<IList<int>>();
            Array.Sort(nums);
            for(int i=0; i < nums.Length - 2; i++)
            {
                if (i > 0 && nums[i] == nums[i - 1]) continue;
                int left = i + 1;
                int right = nums.Length - 1;
                int target = -nums[i];

                while (left < right)
                {
                    int sum = nums[left] + nums[right];
                    if (sum == target)
                    {
                        res.Add(new List<int> { nums[i], nums[left], nums[right] });
                        left++;
                        right--;
                        while (left < right && nums[left] == nums[left - 1])
                            left++;
                        while (left < right && nums[right] == nums[right + 1])
                            right--;
                    }
                    else if (sum < target)
                    {
                        left++;
                    }
                    else
                    {
                        right--;
                    }
                }
            }
            return res;
        }
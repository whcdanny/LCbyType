//Leetcode 16. 3Sum Closest  med
//题意：给定一个整数数组 nums，要求找到所有不重复的三元组，使得三元组的和等于零。
//思路：双指针方法来解决这个问题。将数组排序。遍历数组，对于每个元素 nums[i]，将其作为目标值，并使用双指针在剩余的元素中查找两个数使它们的和等于 0 - nums[i]。使用两个指针 left 和 right 分别指向剩余元素的最左端和最右端。
//时间复杂度:  排序的时间复杂度是 O(nlogn)，双指针遍历的时间复杂度是 O(n^2)，所以总的时间复杂度是 O(n^2)。
//空间复杂度： O(1)           
        public int ThreeSumClosest(int[] nums, int target)
        {
            Array.Sort(nums);
            int res = nums[0] + nums[1] + nums[2];
            for(int i = 0; i < nums.Length - 2; i++)
            {
                int left = i + 1;
                int right = nums.Length - 1;
                while (left < right)
                {
                    int temp = nums[i] + nums[left] + nums[right];
                    if (Math.Abs(res - target) > Math.Abs(temp - target))
                    {
                        res = temp;
                    }

                    if (temp == target)
                    {
                        return temp;
                    }
                    else if (temp < target) {
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
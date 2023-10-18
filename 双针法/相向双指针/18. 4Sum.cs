//Leetcode 18. 4Sum  med
//题意：给定一个整数数组 nums 和一个目标值 target，要求找到所有不重复的四元组，使得四元组的和等于目标值。
//思路：可以使用双指针方法来解决这个问题。将数组排序。遍历数组，对于每个元素 nums[i]，将其作为第一个数，并使用双指针在剩余的元素中查找三个数使它们的和等于 target - nums[i]。使用三个指针 left1、left2 和 right 分别指向剩余元素的最左端、中间和最右端。计算当前四个数的和 sum = nums[i] + nums[left1] + nums[left2] + nums[right]。
//时间复杂度:  排序的时间复杂度是 O(nlogn)，双指针遍历的时间复杂度是 O(n^3)，所以总的时间复杂度是 O(n^3)。
//空间复杂度： O(1)         
        public IList<IList<int>> FourSum(int[] nums, int target)
        {
            List<IList<int>> result = new List<IList<int>>();
            Array.Sort(nums);

            for (int i = 0; i < nums.Length - 3; i++)
            {
                if (i > 0 && nums[i] == nums[i - 1]) continue; // 跳过重复的元素

                for (int j = i + 1; j < nums.Length - 2; j++)
                {
                    if (j > i + 1 && nums[j] == nums[j - 1]) continue; // 跳过重复的元素

                    int left1 = j + 1;
                    int left2 = nums.Length - 1;

                    while (left1 < left2)
                    {
						//给定的数字太大，可能会导致整数溢出问题
                        long sum = (long)nums[i] + (long)nums[j] + (long)nums[left1] + (long)nums[left2]; // 使用 long 类型

                        if (sum == target)
                        {
                            result.Add(new List<int> { nums[i], nums[j], nums[left1], nums[left2] });
                            left1++;
                            left2--;

                            while (left1 < left2 && nums[left1] == nums[left1 - 1]) left1++; // 跳过重复的元素
                            while (left1 < left2 && nums[left2] == nums[left2 + 1]) left2--; // 跳过重复的元素
                        }
                        else if (sum < target)
                        {
                            left1++;
                        }
                        else
                        {
                            left2--;
                        }
                    }
                }
            }

            return result;
        }
//Leetcode 611. Valid Triangle Number med
//题意：给定一个非负整数数组 nums，统计其中可以组成三角形三边长度的三元组的个数
//思路：二分搜索：在排序后的数组中，我们不能简单地通过二分查找来找到符合三角形条件的值。一般而言，对于三个数字 a、b、c，它们能够构成三角形的条件是 a + b > c。
//如果我们固定了其中两个数，那么我们只需要找到第三个数，使得它大于两者之差，即 c > b - a。由于数组是有序的，我们可以考虑固定最小的两个数 a 和 b，然后使用二分查找来找到符合条件的第三个数 c。  
//时间复杂度: O(n^2 * log n)，其中 n 是数组 nums 的长度。
//空间复杂度：O(1)
        public int TriangleNumber(int[] nums)
        {
            Array.Sort(nums);
            int count = 0;

            for (int i = 0; i < nums.Length - 2; i++)
            {
                for (int j = i + 1; j < nums.Length - 1; j++)
                {
                    int target = nums[i] + nums[j];
                    int left = j + 1, right = nums.Length - 1;

                    while (left <= right)
                    {
                        int mid = left + (right - left) / 2;

                        if (nums[mid] < target)
                        {
                            left = mid + 1;
                        }
                        else
                        {
                            right = mid - 1;
                        }
                    }

                    count += left - j - 1;
                }
            }

            return count;
        }
        //2points
        public int TriangleNumber1(int[] nums)
        {
            Array.Sort(nums);
            int count = 0;

            for (int i = 0; i < nums.Length - 2; i++)
            {
                int k = i + 2;

                for (int j = i + 1; j < nums.Length - 1 && nums[i] != 0; j++)
                {
                    while (k < nums.Length && nums[i] + nums[j] > nums[k])
                    {
                        k++;
                    }

                    count += k - j - 1;
                }
            }

            return count;
        }
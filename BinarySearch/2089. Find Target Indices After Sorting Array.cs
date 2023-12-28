//Leetcode 2089. Find Target Indices After Sorting Array ez
//题意：给定一个数组 nums 和目标元素 target，要求找出数组 nums 在非递减排序后，目标元素 target 所在的所有索引，并返回按升序排列的结果。
//思路：二分搜索,先sortnums， 然后用二分法 找到位置，然后由于数字可以重复，那么就根据找到位置 前后再找，直到没有，然后输出；
//时间复杂度: O(log n)
//空间复杂度：O(1)       
        public IList<int> TargetIndices(int[] nums, int target)
        {
            var result = new List<int>();
            if (nums.Length == 1)
            {
                if (nums[0] == target)
                {
                    result.Add(0);
                }
                return result.ToArray();
            }
            Array.Sort(nums);
            int low = 0;
            int high = nums.Length - 1;
            while (low <= high)
            {

                int mid = (low + high) / 2;

                if (nums[mid] == target)
                {
                    int k = mid;
                    while (k > -1 && nums[k] == target)
                    {
                        result.Add(k);
                        k -= 1;
                    }
                    mid += 1;

                    while (mid < nums.Length && nums[mid] == target)
                    {
                        result.Add(mid);
                        mid++;
                    }
                    result.Sort();
                    return result.ToArray();

                }

                else if (nums[mid] < target)
                {
                    low = mid + 1;
                }

                else
                {
                    high = mid - 1;
                }
            }
            return result.ToArray();
        }
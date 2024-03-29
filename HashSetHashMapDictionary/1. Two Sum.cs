//Leetcode 1. Two Sum ez
//题意：给定一个整数数组 nums 和一个目标值 target，请你在数组中找出和为目标值的那两个整数，并返回它们的数组下标。
//思路：创建一个HashMap，用于存储数组元素及其对应的索引。遍历数组，对于每个元素 nums[i]，计算出目标值减去该元素的差值 diff = target - nums[i]。检查差值 diff 是否在HashMap中，如果在则找到了符合条件的两个元素，返回它们的索引。
//时间复杂度：n 是数组的长度, O(n)
//空间复杂度：O(n) 
        public int[] TwoSum(int[] nums, int target)
        {
            Dictionary<int, int> numMap = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                int diff = target - nums[i];
                if (numMap.ContainsKey(diff))
                {
                    return new int[] { numMap[diff], i };
                }
                numMap[nums[i]] = i;
            }

            return null;
        }
        public int[] TwoSum_OLD(int[] nums, int target)
        {
            int[] res = new int[2];
            if (nums == null || nums.Length < 2)
            {
                return null;
            }
            Dictionary<int, int> map = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (map.ContainsKey(target - nums[i]))
                {
                    res[0] = map[target - nums[i]];
                    res[1] = i;
                    return res;
                }
                if (map.ContainsKey(nums[i]))
                {
                    map[nums[i]] += i;
                }
                else
                    map.Add(nums[i], i);
            }
            return null;
        }

        //这个不推荐因为顺序调换了，不过如果找的是值而不是位置 可以用		
        public int[] TwoSum1(int[] nums, int target)
        {
            Array.Sort(nums);
            int l = 0, r = nums.Length - 1;
            while (l < r)
            {
                int sum = nums[l] + nums[r];
                if (sum < target)
                {
                    l++;
                }
                else if (sum > target)
                {
                    r--;
                }
                else if (sum == target)
                {
                    return new int[] { nums[l], nums[r] };
                }
            }
            return new int[] { };
        }

        //题意同上，但是此时的数组是可重复的，我们为了避免输出重复的值，就需要检查下一个放入的和当前是否为一个值；
        public IList<IList<int>> TwoSum2(int[] nums, int start, int target)
        {
            List<IList<int>> res = new List<IList<int>>();
            Array.Sort(nums);
            int l = start, r = nums.Length - 1;
            while (l < r)
            {
                int sum = nums[l] + nums[r];
                int left = nums[l], right = nums[r];
                if (sum < target)
                {
                    l++;
                }
                else if (sum > target)
                {
                    r--;
                }
                else if (sum == target)
                {
                    res.Add(new List<int> { nums[l], nums[r] });
                    while (l < r && nums[l] == left)
                        l++;
                    while (l < r && nums[r] == right)
                        r--;
                }
            }
            return res;
        }
//1. Two Sum ez
//给一个可重复数组，找出2个数之和=target的位置；
//思路：左右指针向中间移动的方式进行查找
        public int[] TwoSum(int[] nums, int target)
        {
            // 创建一个存储原始数组索引的数组
            int[] indexes = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                indexes[i] = i;
            }

            // 对数组进行排序
            Array.Sort(nums, indexes);

            // 左指针和右指针
            int left = 0;
            int right = nums.Length - 1;

            while (left < right)
            {
                int sum = nums[left] + nums[right];
                if (sum == target)
                {
                    // 找到目标值，返回两个数的索引
                    return new int[] { indexes[left], indexes[right] };
                }
                else if (sum < target)
                {
                    // 和小于目标值，左指针右移
                    left++;
                }
                else
                {
                    // 和大于目标值，右指针左移
                    right--;
                }
            }

            return new int[0]; // 如果未找到符合条件的两个数，返回空数组或null
        }
//思路：找出满足的；利用dictionary来寻找；

		public int[] TwoSum(int[] nums, int target)
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
		public int[] TwoSum(int[] nums, int target)
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
		public IList<IList<int>> TwoSum1(int[] nums, int start, int target)
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
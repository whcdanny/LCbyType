//kSum
//4Sums的衍生
		public IList<IList<int>> fourSum(int[] nums, int target)
        {
            Array.Sort(nums);
            return kSum(nums, target, 0, 4);
        }
		public IList<IList<int>> kSum(int[] nums, int target, int start, int k)
        {
            List<IList<int>> res = new List<IList<int>>();

            // If we have run out of numbers to add, return res.
            if (start == nums.Length)
            {
                return res;
            }

            // There are k remaining values to add to the sum. The 
            // average of these values is at least target / k.
            int average_value = target / k;

            // We cannot obtain a sum of target if the smallest value
            // in nums is greater than target / k or if the largest 
            // value in nums is smaller than target / k.
            if (nums[start] > average_value || average_value > nums[nums.Length - 1])
            {
                return res;
            }

            if (k == 2)
            {
                return twoSum(nums, target, start);
            }

            for (int i = start; i < nums.Length; ++i)
            {
                if (i == start || nums[i - 1] != nums[i])
                {
                    foreach (List<int> subset in kSum(nums, target - nums[i], i + 1, k - 1))
                    {
                        subset.Add(nums[i]);
                        res.Add(subset);                       
                    }
                    while (i < nums.Length - 1 && nums[i] == nums[i + 1])
                        i++;
                }
            }

            return res;
        }

        public IList<IList<int>> twoSum(int[] nums, int target, int start)
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
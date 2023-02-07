//18. 4Sum med
//给一个可重复的数组，输出所有 其中四个相加=0，的组合；
//思路如同3sums，但是问题是target有界限-10^9 <= target <= 10^9, 所以暂时不能完全解决
	public IList<IList<int>> FourSum(int[] nums, int target)
        {
            List<IList<int>> res = new List<IList<int>>();
            Array.Sort(nums);
            int n = nums.Length;
            for (int i = 0; i < n; i++)
            {
                List<IList<int>> temps = (List<IList<int>>)ThreeSum1(nums, i + 1, target - nums[i]);
                foreach (List<int> temp in temps)
                {
                    temp.Add(nums[i]);
                    res.Add(temp);
                }
                while (i < n - 1 && nums[i] == nums[i + 1])
                    i++;
            }
            return res;
        }
        public IList<IList<int>> ThreeSum1(int[] nums, int start, int target)
        {
            List<IList<int>> res = new List<IList<int>>();
            Array.Sort(nums);
            int n = nums.Length;
            for (int i = start; i < n; i++)
            {
                List<IList<int>> temps = (List<IList<int>>)TwoSum1(nums, i + 1, target - nums[i]);
                foreach (List<int> temp in temps)
                {
                    temp.Add(nums[i]);
                    res.Add(temp);
                }
                while (i < n - 1 && nums[i] == nums[i + 1])
                    i++;
            }
            return res;
        }
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
//这个可以解决：不过判断稍多；		
		public IList<IList<int>> FourSum1(int[] nums, int target)
        {
            if (nums.Length < 4) return new List<List<int>>().ToArray();

            List<List<int>> fourSumList = new List<List<int>>();
            //sort input to save duplication check consumption
            List<int> sortList = new List<int>(nums);
            sortList.Sort();
            nums = sortList.ToArray();
            for (int h = 0; h < nums.Length - 3; h++)
            {
                //if same nums[h], skip
                if (h > 0 && nums[h] == nums[h - 1]) continue;
                for (int i = h + 1; i < nums.Length - 2; i++)
                {
                    //if same nums[i], skip
                    if (i > 0 && i - 1 != h && nums[i] == nums[i - 1]) continue;
                    int j = i + 1;
                    int k = nums.Length - 1;
                    while (j < k)
                    {
                        int sum = nums[h] + nums[i] + nums[j] + nums[k];
                        if (sum == target)
                        {
                            List<int> fourSum = new List<int>();
                            fourSum.Add(nums[h]);
                            fourSum.Add(nums[i]);
                            fourSum.Add(nums[j]);
                            fourSum.Add(nums[k]);
                            //check duplications
                            if (fourSumList.Count() > 0)
                            {
                                bool isDuplicate = false;
                                List<int> last = fourSumList.Last();
                                for (int index = 0; index < last.Count(); index++)
                                {
                                    if (last[index] != fourSum[index]) break;
                                    else if (last[index] == fourSum[index] && index == last.Count() - 1) isDuplicate = true;
                                }
                                if (!isDuplicate) fourSumList.Add(fourSum);
                            }
                            else
                            {
                                fourSumList.Add(fourSum);
                            }
                        }
                        //update j,k
                        if (sum <= target) j++;
                        if (sum >= target) k--;
                    }
                }
            }
            return fourSumList.ToArray();
        }
		
		
		
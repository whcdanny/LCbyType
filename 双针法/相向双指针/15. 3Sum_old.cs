//15. 3Sum med
//给一个可重复的数组，输出所有 其中三个相加=0，的组合；
//思路：相当于从数组里找target，只要保证第一位的数字不是重复的，然后用0-第一位数字，找剩下的两位之和；
		public IList<IList<int>> ThreeSum(int[] nums)
        {
            List<IList<int>> res = new List<IList<int>>();
            Array.Sort(nums);
            int n = nums.Length;
            for(int i=0; i < n; i++)
            {
                List<IList<int>> temps = (List<IList<int>>)TwoSum1(nums, i + 1, 0 - nums[i]);
                foreach(List<int> temp in temps)
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
//思路相同，不过验证的此时要多；		
		public IList<IList<int>> ThreeSum2(int[] nums)
        {
            if (nums.Length < 3) return new List<List<int>>().ToArray();

            List<List<int>> threeSumList = new List<List<int>>();
            //sort input to save duplication check consumption
            List<int> sortList = new List<int>(nums);
            sortList.Sort();
            nums = sortList.ToArray();
            for (int i = 0; i < nums.Length - 2; i++)
            {
                //if same nums[i], skip
                if (i > 0 && nums[i] == nums[i - 1]) continue;
                int j = i + 1;
                int k = nums.Length - 1;
                while (j < k)
                {
                    int sum = nums[i] + nums[j] + nums[k];
                    if (sum == 0)
                    {
                        List<int> threeSum = new List<int>();
                        threeSum.Add(nums[i]);
                        threeSum.Add(nums[j]);
                        threeSum.Add(nums[k]);
                        //check duplications
                        if (threeSumList.Count() > 0)
                        {
                            bool isDuplicate = false;
                            List<int> last = threeSumList.Last();
                            for (int index = 0; index < last.Count(); index++)
                            {
                                if (last[index] != threeSum[index]) break;
                                else if (last[index] == threeSum[index] && index == last.Count() - 1) isDuplicate = true;
                            }
                            if (!isDuplicate) threeSumList.Add(threeSum);
                        }
                        else
                        {
                            threeSumList.Add(threeSum);
                        }
                    }
                    //update j,k
                    if (sum <= 0) j++;
                    if (sum >= 0) k--;
                }
            }
            return threeSumList.ToArray();
        }
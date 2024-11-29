//Leetcode 347. Top k Largest Elements med
//题意：给定一个整数数组 nums，找出其中最大的 k 个元素。
//思路：用dictionary来存数字和对应的count
//dic.OrderByDescending(x => x.Value).Take(k).ToList();
//最后得到key
//时间复杂度：O(nlogk)
//空间复杂度：O(k) 
        public int[] TopKFrequent1(int[] nums, int k)
        {
            int[] result = new int[k];
            Dictionary<int, int> dic = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                if (!dic.ContainsKey(nums[i]))
                {
                    dic.Add(nums[i], 1);
                }
                else
                {
                    dic[nums[i]]++;
                }
            }

            var ordered = dic.OrderByDescending(x => x.Value).Take(k).ToList();

            for (int i = 0; i < ordered.Count(); i++)
            {
                result[i] = ordered[i].Key;
            }

            return result;
        }
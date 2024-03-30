//Leetcode 2845. Count of Interesting Subarrays med
//题意：给定一个整数数组 nums、一个整数模数 modulo 和一个整数 k，求满足以下条件的子数组个数：
//子数组 nums[l..r] 是有趣的，如果满足以下条件：
//令 cnt 为范围[l, r] 内的索引 i 的数量，使得 nums[i] % modulo == k。那么，cnt % modulo == k。
//返回一个整数，表示有趣子数组的数量。
//思路：hashtable + prefix，看到subarray就想到前缀数组之差。
//[X X X X X] [l X X r] 总长m, k2=k1-k
//   k2          k
//对于以r为结尾的前缀数组，假设其cnt对于M的取模是kk，那么想要得到以r为结尾、且cnt%M=k的subarray，
//我们只需要查看在r之前有多少前缀数组里的cnt%M=k-kk。每一个这样的前缀数组，都对应了一个l与r能够组成符合条件的subarray。    
//时间复杂度：O(n)
//空间复杂度：O(n)

        public long CountInterestingSubarrays(IList<int> nums, int modulo, int k)
        {
            int n = nums.Count;
            int count = 0;
            Dictionary<int, long> map = new Dictionary<int, long>();//key是余数，val有几个前缀数组
            //subarray包含了全部所以要给1；
            map[0] = 1;
            long res = 0;

            for (int i = 0; i < n; i++)
            {
                //i为右端点是否满足k
                count += (nums[i] % modulo == k) ? 1 : 0;     
                //此时的当前区间的k1是
                int k1 = count % modulo;
                //如果想满足k个，那么前面的数组就要满足k2
                int k2 = (k1 - k + modulo) % modulo;

                if (map.ContainsKey(k2))
                {
                    res += map[k2];
                }
                if (map.ContainsKey(k1))
                {
                    map[k1] += 1;
                }
                else
                {
                    map[k1] = 1;
                }
            }

            return res;
        }
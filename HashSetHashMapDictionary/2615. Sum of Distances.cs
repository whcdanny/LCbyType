//Leetcode 2615. Sum of Distances med
//题意：给定一个长度为 n 的整数数组 nums。存在一个长度为 n 的数组 arr，其中 arr[i] 表示对于所有 j，
//满足 nums[j] == nums[i] 且 j != i，|i - j| 的总和。如果不存在这样的 j，则将 arr[i] 设置为 0。
//返回数组 arr。
//思路：hashtable, 这里有一个逻辑 比如 j1 j2 i j3 j4 是相同数的位置
//那么|i - j| 前半部分是 i-j1+i-j2 => 2*i-(j1+j2)
//那么|i - j| 后半部分是 -i+j3-i+j4 => -2*i+(j3+j4)
//可以看出从前往后找到每个位置的前半部分，然后再从后往前历遍 找到后半部
//时间复杂度：O(n^2)
//空间复杂度：O(n)
        public long[] Distance(int[] nums)
        {
            int n = nums.Length;
            var totalCount = new Dictionary<int, long>();
            //当前位置，有几个相同数的位置之和
            var sameNumSum = new Dictionary<int, long>();
            var result = new long[n];

            for (int i = 0; i < n; ++i)
            {
                sameNumSum.TryAdd(nums[i], 0);
                totalCount.TryAdd(nums[i], 0);

                result[i] = totalCount[nums[i]] * i - sameNumSum[nums[i]];

                totalCount[nums[i]] += 1;
                sameNumSum[nums[i]] += i;
            }

            sameNumSum = new Dictionary<int, long>();
            totalCount = new Dictionary<int, long>();
            for (int i = n - 1; i >= 0; --i)
            {
                sameNumSum.TryAdd(nums[i], 0);
                totalCount.TryAdd(nums[i], 0);

                result[i] += (-totalCount[nums[i]] * i + sameNumSum[nums[i]]);

                totalCount[nums[i]] += 1;
                sameNumSum[nums[i]] += i;
            }

            return result;
        }
		
		 //思路：hashtable,基本逻辑是 对于sum[i] = sum{|num[j] - numx[i]|} j=0,1,...n-1;
        //那么sum[i+1] = sum + (i+1)*d - (m-i-1)*d, 这里d = |arr[i+1]-arr[i]|
        //由此可见，只要找到每个相同数字的1第一个位置sum[0]，那么后面的都可以根据这个来找出；
        //所以先用dictionary找出所有数字的位置，然后根据上面的规则，先找到当前相同数字的第一个位置sum[0]，然后找到剩下的，
        //这样结果的当前位置的答案就算这个res[list[0]] = sum;
        public long[] Distance1(int[] nums)
        {
            int n = nums.Length;
            Dictionary<int, List<int>> map = new Dictionary<int, List<int>>();
            for(int i = 0; i < n; i++)
            {
                if (!map.ContainsKey(nums[i]))
                    map[nums[i]] = new List<int>();
                map[nums[i]].Add(i); 
            }
            long[] res = new long[n];
            foreach (KeyValuePair<int, List<int>> kv in map)
            {
                List<int> list = kv.Value;
                int m = list.Count;
                long sum = 0;
                foreach(int x in list)
                {
                    sum += Math.Abs(x - list[0]);
                }
                res[list[0]] = sum;

                for(int i = 0; i+1 < m; i++)
                {
                    int d = list[i + 1] - list[i];
                    sum += (i + 1) * d - (m - i - 1) * d;
                    res[list[i + 1]] = sum;
                }
            }
            return res;
        }
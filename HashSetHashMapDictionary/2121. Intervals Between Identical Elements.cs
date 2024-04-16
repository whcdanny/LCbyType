//Leetcode 2121. Intervals Between Identical Elements med
//题意：给定一个长度为 n 的整数数组 arr，数组中可能存在相同的元素。数组中元素 arr[i] 和 arr[j] 之间的间隔定义为它们索引的绝对差值，即 |i - j|。
//要求：返回一个长度为 n 的数组 intervals，其中 intervals[i] 表示 arr[i] 与与其相等的元素之间的间隔之和。
//思路：hashtable 逻辑
//如果：[2,1,2,1,2,1,2,1,2], 位置4的
//ans[4] = (4-0)+(4-2) + (6-4) + (8-4)
//可以分为前后两个部分
//before = (4-0)+(4-2) ,可以被分解为= 4 * 2 - (0+2)，所以(0+2)为前几项之和element(here i is 4)；
//after = (6-4) + (8-4) 可以被分解为= (6+8) - 4 * 2. 所以(6+8)为后几项之和from(i+1)th to the last；        
//所以Dictionary存储每个数字出现的位置，然后对每个数，算preSums，然后再根据上面的公式来找出最后答案；
//时间复杂度：O(n^2)
//空间复杂度：O(n)
        public long[] GetDistances(int[] arr)
        {
            int n = arr.Length;
            Dictionary<int, List<int>> positionMap = new Dictionary<int, List<int>>();
            for (int i = 0; i < n; i++)
            {
                if (!positionMap.ContainsKey(arr[i]))
                {
                    positionMap[arr[i]] = new List<int>();
                }

                positionMap[arr[i]].Add(i);
            }

            long[] ans = new long[n];
            foreach (List<int> list in positionMap.Values)
            {
                long[] preSums = new long[list.Count + 1];
                for (int i = 0; i < list.Count; i++)
                {
                    preSums[i + 1] = preSums[i] + list[i];
                }

                for (int i = 0; i < list.Count; i++)
                {
                    long value = list[i];
                    // pre
                    ans[value] = value * (i + 1) - preSums[i + 1];
                    // post
                    ans[value] += preSums[list.Count] - preSums[i] - value * (list.Count - i);
                }
            }

            return ans;
        }
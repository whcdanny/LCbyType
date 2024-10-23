//Leetcode 3312. Sorted GCD Pair Queries hard
//题目：给定一个整数数组 nums，长度为 n，以及一个整数数组 queries。
//定义 gcdPairs 为数组，通过计算所有可能的(nums[i], nums[j]) 对的最大公约数(GCD)，其中 0 <= i<j<n，然后将这些值按升序排序。
//对于每个查询 queries[i]，需要找到在 gcdPairs 中索引为 queries[i] 的元素。
//返回一个整数数组 answer，其中 answer[i] 是对应于每个查询 queries[i] 的 gcdPairs 值。
//思路：超时方法就是算出所有的每一对儿的GCD,然后排序，然后根据queries却得出结论；
//简便方法是，由于会有很多重复的GCD出现，所以可以先找出所有会出现的因数和其出现的总个数；
//然后根据每一个GCD找出所有的对数，这里要考虑会出现重复，比如GCD 2 和 GCD 4,
//然后用前缀和和二分搜索去找出，
//因为 prefixSum 是累积的，也就是说，从小到大排列的 GCD 值的对数是依次增加的。这就相当于在一个已经排序的数组中，记录了每个 GCD 值所占的位置范围。
//时间复杂度：因数计算的复杂度约为 O(n * sqrt(maxValue))。计算 gcdPairCount 和 prefixSum 的复杂度为 O(maxValue* log(maxValue))。查询处理的复杂度为 O(q* log(maxValue))，其中 q 为查询数量。
//空间复杂度：O(maxValue) 大小的数组来存储 divisorCount、gcdPairCount 和 prefixSum。
        public int[] GcdValues(int[] nums, long[] queries)
        {
            int n = nums.Length;
            int maxValue = nums.Max();
            int[] divisorCount = new int[maxValue + 1];

            //计算每个数的因数个数
            foreach (int number in nums)
            {
                //只运行到 number 的平方根,
                for (int i = 1; i * i <= number; i++)
                {
                    //因为我们考虑的是最大公约数，所以只需要找出哪些数可以整除；
                    if (number % i == 0)
                    {
                        //可以整除那么i和number/i都要存入
                        divisorCount[i]++;
                        if (i != number / i)
                        {
                            divisorCount[number / i]++;
                        }
                    }
                }
            }

            long[] gcdPairCount = new long[maxValue + 1];

            // 计算每个 GCD 的对数
            for (int gcd = maxValue; gcd >= 1; gcd--)
            {
                long count = divisorCount[gcd];
                //计算出有多少个不同的 (i, j) 对，其最大公约数是 gcd
                //从 count 个元素中选择两个不重复的元素的组合数
                gcdPairCount[gcd] = count * (count - 1) / 2;
                //消除计数的重复部分,所有是 gcd 的倍数进行查找，
                for (int multiple = 2 * gcd; multiple <= maxValue; multiple += gcd)
                {
                    gcdPairCount[gcd] -= gcdPairCount[multiple];
                }
            }

            long[] prefixSum = new long[maxValue + 1];
            // 计算前缀和
            for (int gcd = 1; gcd <= maxValue; gcd++)
            {
                prefixSum[gcd] = prefixSum[gcd - 1] + gcdPairCount[gcd];
            }

            int[] result = new int[queries.Length];
            // 处理查询
            for (int i = 0; i < queries.Length; i++)
            {
                long query = queries[i];
                long left = 1, right = maxValue, answer = -1;
                // 二分查找找到满足条件的最小 GCD
                while (left <= right)
                {
                    long mid = (left + right) / 2;
                    if (prefixSum[mid] > query)
                    {
                        answer = mid;
                        right = mid - 1;
                    }
                    else
                    {
                        left = mid + 1;
                    }
                }
                result[i] = (int)answer;
            }

            return result;
        }

        public int[] GcdValues_超时(int[] nums, long[] queries)
        {
            int n = nums.Length;
            List<int> gcdPairs = new List<int>();

            // 计算所有 GCD 对
            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    int gcdValue = GCD_GcdValues(nums[i], nums[j]);
                    gcdPairs.Add(gcdValue);
                }
            }

            // 将 GCD 对排序
            gcdPairs.Sort();

            // 处理查询
            int[] answer = new int[queries.Length];
            for (int i = 0; i < queries.Length; i++)
            {
                answer[i] = gcdPairs[(int)queries[i]];
            }

            return answer;
        }
        // 辅助函数：计算两个数的 GCD
        private int GCD_GcdValues(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }
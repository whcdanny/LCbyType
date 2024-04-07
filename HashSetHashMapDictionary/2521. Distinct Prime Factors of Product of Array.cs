//Leetcode 2521. Distinct Prime Factors of Product of Array  med
//题意：给定一个正整数数组 nums，返回 nums 中所有元素的乘积的不同质因数的数量。
//思路：hashtable,首先，遍历数组 nums，对每个元素进行质因数分解，统计每个元素的质因数。
//使用一个集合（HashSet）来存储所有的质因数，因为集合中的元素不重复。
//遍历数组中的每个元素，对其进行质因数分解，将分解得到的质因数加入集合中。
//返回集合的大小，即为不同质因数的数量。
//时间复杂度：质因数分解O(sqrt(num))总的时间复杂度为 O(n* sqrt(max(nums)))，其中 n 是数组 nums 的长度，max(nums) 是数组中的最大元素。
//空间复杂度：O(sqrt(max(nums)))
        public int DistinctPrimeFactors(int[] nums)
        {
            HashSet<int> primeFactors = new HashSet<int>();

            foreach (int num in nums)
            {
                primeFactors.UnionWith(GetPrimeFactors(num));
            }

            return primeFactors.Count;
        }
        private HashSet<int> GetPrimeFactors(int num)
        {
            HashSet<int> factors = new HashSet<int>();

            for (int i = 2; i * i <= num; i++)
            {
                while (num % i == 0)
                {
                    factors.Add(i);
                    num /= i;
                }
            }

            if (num > 1)
            {
                factors.Add(num);
            }

            return factors;
        }
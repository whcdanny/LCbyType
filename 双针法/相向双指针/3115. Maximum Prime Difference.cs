//Leetcode 3115. Maximum Prime Difference med
//题目：给定一个整数数组 nums，要求返回两个（不一定是不同的）素数在数组中索引之间的最大距离。
//换句话说，你需要找出数组中素数元素的索引，计算它们之间的最大距离。
//思路: 双针，从左右两个point来找是否有prime
//当找到了，right-left
//判定素数质数：因为只能被1或自己整除，那么如果从i=2开始然后检查i^2<检查的数n
//那么只要有一个i能实现n % i == 0，那么就不是质数
//时间复杂度：O(nlogk)
//空间复杂度：O(1)
        public int MaximumPrimeDifference(int[] nums)
        {
            int left = 0;
            int right = nums.Length - 1;
            bool hasLeftPrime = false;
            bool hasRightPrime = false;
            while (!hasLeftPrime || !hasRightPrime)
            {
                if (!IsPrime_MaximumPrimeDifference(nums[left]) && !hasLeftPrime)
                {
                    left++;
                }
                else
                {
                    hasLeftPrime = true;
                }
                if (!IsPrime_MaximumPrimeDifference(nums[right]) && !hasRightPrime)
                {
                    right--;
                }
                else
                {
                    hasRightPrime = true;
                }
            }
            return right - left;
        }
        public bool IsPrime_MaximumPrimeDifference(int n)
        {
            if (n == 1) 
                return false;
            for (int i = 2; i * i <= n; i++)
            {
                if (n % i == 0) 
                    return false;
            }
            return true;
        }
        //思路: 筛选素数：
        //由于题目要求找出素数之间的最大距离，我们首先需要识别出数组中的素数。
        //可以利用埃拉托斯特尼筛法来提前判断每个数是否是素数。这样我们可以快速检查每个数是否是素数，避免重复计算。
        //记录素数的位置：
        //遍历数组 nums，对于每个素数，我们记录其索引。
        //计算最大距离：
        //找到所有素数的索引后，计算这些索引之间的最大距离。
        //时间复杂度：O(n log log n + m)
        //空间复杂度：O(n + m)
        public int MaximumPrimeDifference1(int[] nums)
        {
            int maxNum = nums.Max(); // 找到数组中的最大值
            bool[] isPrime = SieveOfEratosthenes(maxNum); // 使用埃拉托斯特尼筛法生成素数表

            List<int> primeIndices = new List<int>(); // 存储素数的索引

            // 遍历 nums，记录素数的索引
            for (int i = 0; i < nums.Length; i++)
            {
                if (isPrime[nums[i]]) // 如果是素数
                {
                    primeIndices.Add(i); // 记录素数的索引
                }
            }

            // 如果没有素数，返回 0
            if (primeIndices.Count == 0)
            {
                return 0;
            }

            // 计算最大距离
            int maxDist = primeIndices.Last() - primeIndices.First();
            return maxDist;
        }
        // 埃拉托斯特尼筛法生成素数表
        private bool[] SieveOfEratosthenes(int maxNum)
        {
            bool[] isPrime = new bool[maxNum + 1];
            for (int i = 2; i <= maxNum; i++)
            {
                isPrime[i] = true;
            }

            for (int i = 2; i * i <= maxNum; i++)
            {
                if (isPrime[i])
                {
                    for (int j = i * i; j <= maxNum; j += i)
                    {
                        isPrime[j] = false;
                    }
                }
            }

            return isPrime;
        }
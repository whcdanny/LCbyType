//Leetcode 3267. Count Almost Equal Pairs II hard
//题目：给定一个由正整数组成的数组 nums。
//我们称两个整数 x 和 y 是“几乎相等的”，如果在执行以下操作最多两次后，两个整数可以相等：
//从 x 或 y 中选择一个数，并交换其任意两个数字的位置。
//返回数组中满足 i<j 且 nums[i] 和 nums[j] 是“几乎相等”的数对 (i, j) 的数量。
//注意：在执行操作后，允许整数有前导零。
//思路: 使用 Dictionary<int, int> 来记录每个数字变体的频率。
//遍历 nums 数组中的每个元素，计算所有可能的两次交换后的变体，并更新频率字典。
//找出一个数字的所有一次交换后的变体，并存储到 HashSet<int> 中。
//通过嵌套循环尝试交换任意一对数字的位置。
//时间复杂度：O(N * D^4)其中 n 是nums的数量
//空间复杂度：O(1)
       
        public int CountPairs2(int[] nums)
        {
            // 频率字典，用于记录每个数字变体的出现次数
            Dictionary<int, int> frequences = new Dictionary<int, int>();
            int result = 0;

            foreach (int value in nums)
            {
                // 增加当前数字的频率到结果中
                result += frequences.GetValueOrDefault(value, 0);

                // 获取所有可能的两次交换后的变体
                HashSet<int> twoSwapVariations = new HashSet<int>();
                foreach (int oneSwapVariation in AllOneSwapVariations(value))
                {
                    foreach (int twoSwapVariation in AllOneSwapVariations(oneSwapVariation))
                    {
                        twoSwapVariations.Add(twoSwapVariation);
                    }
                }

                // 更新频率字典
                foreach (int twoSwapVariation in twoSwapVariations)
                {
                    if (frequences.ContainsKey(twoSwapVariation))
                    {
                        frequences[twoSwapVariation]++;
                    }
                    else
                    {
                        frequences[twoSwapVariation] = 1;
                    }
                }
            }

            return result;
        }

        private HashSet<int> AllOneSwapVariations(int number)
        {
            int[] pow10 = { 1, 10, 100, 1_000, 10_000, 100_000, 1_000_000 };
            HashSet<int> variations = new HashSet<int>();
            variations.Add(number);
            int maxDigits = 7;

            // 尝试交换任意一对数字
            for (int i = 0; i < maxDigits; i++)
            {
                for (int j = i + 1; j < maxDigits; j++)
                {
                    int di = (number / pow10[i]) % 10;
                    int dj = (number / pow10[j]) % 10;

                    if (di == dj)
                    {
                        continue;
                    }

                    // 交换第i位和第j位的数字
                    int diff1Variation = number
                        - di * pow10[i] + di * pow10[j]
                        - dj * pow10[j] + dj * pow10[i];

                    variations.Add(diff1Variation);
                }
            }

            return new HashSet<int>(variations);
        }
        public int CountPairs_超时(int[] nums)
        {
            int len = nums.Length;
            int res = 0;

            // 双重循环检查所有可能的数对
            for (int i = 0; i < len - 1; i++)
            {
                for (int j = i + 1; j < len; j++)
                {
                    if (IsEqual(nums[i], nums[j]))
                    {
                        res++;
                    }
                }
            }

            return res;
        }
        // 检查两个数字是否可以通过最多两次交换来使其相等
        private bool IsEqual(int x, int y)
        {
            int[] xAr = ConvertNumToArr(x);
            int[] yAr = ConvertNumToArr(y);

            int diffDigitCnt = 0;
            int[] diffDigitInd = new int[4];

            // 记录不同的数字位置
            for (int i = 0; i < 8; i++)
            {
                if (xAr[i] != yAr[i])
                {
                    if (diffDigitCnt == 4)
                    {
                        return false;
                    }
                    diffDigitInd[diffDigitCnt] = i;
                    diffDigitCnt++;
                }
            }

            // 如果没有差异，则返回true
            if (diffDigitCnt == 0)
            {
                return true;
            }

            // 如果有两个差异，检查是否可以通过一次交换使其相等
            if (diffDigitCnt == 2)
            {
                int a = diffDigitInd[0];
                int b = diffDigitInd[1];

                return (xAr[a] == yAr[b] && xAr[b] == yAr[a]);
            }

            // 如果有三个差异，检查是否可以通过两次交换使其相等
            if (diffDigitCnt == 3)
            {
                int a = diffDigitInd[0];
                int b = diffDigitInd[1];
                int c = diffDigitInd[2];

                return (xAr[a] == yAr[b] && xAr[b] == yAr[c] && xAr[c] == yAr[a])
                    || (xAr[a] == yAr[c] && xAr[c] == yAr[b] && xAr[b] == yAr[a]);
            }

            // 如果有四个差异，检查是否可以通过两次交换使其相等
            if (diffDigitCnt == 4)
            {
                int a = diffDigitInd[0];
                int b = diffDigitInd[1];
                int c = diffDigitInd[2];
                int d = diffDigitInd[3];

                return (xAr[a] == yAr[b] && xAr[b] == yAr[a] && xAr[c] == yAr[d] && xAr[d] == yAr[c]) ||
                       (xAr[a] == yAr[c] && xAr[c] == yAr[a] && xAr[b] == yAr[d] && xAr[d] == yAr[b]) ||
                       (xAr[a] == yAr[d] && xAr[d] == yAr[a] && xAr[c] == yAr[b] && xAr[b] == yAr[c]);
            }

            return false;
        }
        // 将数字转换为数组表示，最多支持8位
        private int[] ConvertNumToArr(int num)
        {
            int[] tmp = new int[8];
            int i = 0;
            while (num > 0)
            {
                tmp[i] = num % 10;
                num /= 10;
                i++;
            }

            return tmp;
        }
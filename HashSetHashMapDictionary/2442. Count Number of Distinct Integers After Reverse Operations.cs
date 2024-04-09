//Leetcode 2442. Count Number of Distinct Integers After Reverse Operations med
//题意：给定一个由正整数组成的数组 nums。
//对数组中的每个整数，你需要将其翻转后的数字添加到数组的末尾。你应该将此操作应用于 nums 中的原始整数。
//返回最终数组中不同整数的数量。
//思路：hashtable 将数组中的每个整数进行翻转，并将翻转后的数字添加到数组的末尾。然后，统计最终数组中不同整数的数量。
//时间复杂度：O(n)
//空间复杂度：O(n)
        public int CountDistinctIntegers(int[] nums)
        {

            HashSet<int> unique = new HashSet<int>();
            int reversedNumber = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (!unique.Contains(nums[i]))
                    unique.Add(nums[i]);
                reversedNumber = Reverse_CountDistinctIntegers(nums[i]);
                if (reversedNumber != nums[i] && !unique.Contains(reversedNumber))
                    unique.Add(reversedNumber);

            }
            return unique.Count;
        }
        public int Reverse_CountDistinctIntegers(int num)
        {
            int reversedNumber = 0;
            int cycle = 1;
            while (num > 0)
            {
                reversedNumber = (cycle * reversedNumber * 10) + (num % 10);
                num /= 10;
            }
            return reversedNumber;
        }
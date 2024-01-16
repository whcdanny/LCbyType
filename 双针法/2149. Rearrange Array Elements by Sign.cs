//Leetcode 2149. Rearrange Array Elements by Sign med
//题意：给定一个长度为偶数的整数数组 nums，数组中包含相同数量的正整数和负整数。要求重新排列数组，满足以下条件：
//相邻的两个整数具有相反的符号。
//具有相同符号的整数保持它们在数组中的相对顺序。
//重新排列后的数组以正整数开头。
//思路：左右针，用正数位和负数位，然后+2；
//注：无论是正数还是负数计算一次+2；
//时间复杂度: O(n)
//空间复杂度：O(1)
        public int[] rearrangeArray(int[] nums)
        {
            int[] res = new int[nums.Length];
            int positivePoint = 0;
            int negativePoint = 1;

            foreach (int num in nums)
            {
                if (num > 0)
                {
                    res[positivePoint] = num;
                    positivePoint += 2;
                }
                else
                {
                    res[negativePoint] = num;
                    negativePoint += 2;
                }
            }

            return res;
        }
//Leetcode 3153. Sum of Digit Differences of All Pairs med
//题目：给定一个由正整数组成的数组 nums，其中所有整数具有相同的位数。
//两个整数的位数差异定义为在相同位置上具有不同数字的位数总数。
//返回 nums 中所有整数对的位数差异之和。
//思路: 先找出nums总共有几位，然后根据这个建立一个存0-9，每个位置出现的个数
//然后每个找出0-9出现不同的次数，(long)list[j, i] * (long)list[k, i];
//差异和的一半累加到 ans，因为在双循环中，每个组合 list[j, i] * list[k, i] 被计算了两次。
//时间复杂度：O(n * d + 10 * d * 10)
//空间复杂度：O(10 * d)
        public long SumDigitDifferences(int[] nums)
        {
            int length = 0;
            int num = nums[0];
            //找出nums每个num的长度
            while (num != 0)
            {
                length++;
                num /= 10;
            }
            int[,] list = new int[10, length];
            //把每个位置0-9 出现的个数统计；
            for (int i = 0; i < nums.Length; i++)
            {
                int cur = nums[i];
                for (int j = length - 1; j >= 0; j--)
                {
                    int d = cur % 10;
                    cur /= 10;
                    list[d, j]++;
                }
            }

            long ans = 0;
            for (int i = 0; i < length; i++)
            {
                long sum = 0;
                for (int j = 0; j < 10; j++)
                {
                    for (int k = 0; k < 10; k++)
                    {
                        if (j != k) {                           
                            sum += (long)list[j, i] * (long)list[k, i]; 
                        }
                    }
                }
                //差异和的一半累加到 ans，因为在双循环中，每个组合 list[j, i] * list[k, i] 被计算了两次。
                ans += sum / 2;
            }
            return ans;
        }
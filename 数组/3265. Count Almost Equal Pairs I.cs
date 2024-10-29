//Leetcode 3265. Count Almost Equal Pairs I med
//题目：给定一个正整数数组 nums。我们称两个整数 x 和 y 在本问题中“几乎相等”如果满足以下条件：通过对其中一个数最多进行一次操作后，可以使两个整数相等。操作包括：
//从 x 或 y 中选择一个数，并交换该数中的任意两个数字。
//目标是找到满足条件的索引对(i, j)，其中 i<j，并且 nums[i] 和 nums[j] 是“几乎相等”的。
//思路: 暴力搜索，检查两个数字，
//如果数字不一样且长度不一样，那么就用0把短的前面补上
//然后找出现的两个不一样的数字出现在num1的位置，因为如果多于两个那就事false，
//还没结束，我们要把这两个位置在num1中进行交换，然后再跟num2比较
//时间复杂度：O(n*n*n)，其中 n 是nums的数量
//空间复杂度：O(1)
        public int CountPairs(int[] nums)
        {
            int count = 0;
            int n = nums.Length;

            // 遍历所有数对
            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    // 检查两个数是否相等或几乎相等
                    if (nums[i] == nums[j] || IsAlmostEqual(nums[i], nums[j]))
                    {
                        count++;
                    }
                }
            }

            return count;
        }

        private bool IsAlmostEqual(int num1, int num2)
        {
            string first = num1.ToString();
            string second = num2.ToString();

            // 补齐较短的字符串，使其长度相同
            while (first.Length < second.Length)
            {
                first = "0" + first;
            }
            while (second.Length < first.Length)
            {
                second = "0" + second;
            }

            int diffCount = 0;
            int firstMismatch = -1, secondMismatch = -1;

            // 计算两个字符串的不同位数
            for (int i = 0; i < first.Length; i++)
            {
                if (first[i] != second[i])
                {
                    diffCount++;
                    if (diffCount == 1)
                    {
                        firstMismatch = i;
                    }
                    else if (diffCount == 2)
                    {
                        secondMismatch = i;
                    }
                    else
                    {
                        return false; // 如果不同位数超过2，则返回false
                    }
                }
            }

            // 如果有且仅有两个不同位数，检查交换后是否相等
            if (diffCount == 2)
            {
                char[] firstArray = first.ToCharArray();
                char temp = firstArray[firstMismatch];
                firstArray[firstMismatch] = firstArray[secondMismatch];
                firstArray[secondMismatch] = temp;
                first = new string(firstArray);
            }

            return first == second;
        }
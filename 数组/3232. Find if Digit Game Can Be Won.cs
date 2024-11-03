//Leetcode 3232. Find if Digit Game Can Be Won ez
//题目：给定一个正整数数组 nums。Alice 和 Bob 在玩一个游戏：
//Alice 可以选择数组中所有的个位数（即一位数）或所有的两位数。
//剩余的数字分配给 Bob。
//如果 Alice 的数字之和严格大于 Bob 的数字之和，则 Alice 赢得比赛。
//要求判断 Alice 是否有可能赢得比赛，返回 true 表示可以赢，否则返回 false。
//思路: 分类统计：遍历数组，将所有一位数和两位数分别累加，得到 totalSum，singleDigitSum 和 doubleDigitSum。
//然后如果singleDigitSum 或者 doubleDigitSum 大于totalSum - 他们相反的，Alice胜
//时间复杂度：O(n)
//空间复杂度：O(1)
        public bool CanAliceWin(int[] nums)
        {
            int singleDigitSum = 0;
            int doubleDigitSum = 0;
            int totalSum = 0;

            foreach (int num in nums)
            {
                totalSum += num;
                if (num < 10)
                {
                    singleDigitSum += num;
                }
                else if (num < 100)
                {
                    doubleDigitSum += num;
                }
            }

            // Alice chooses all single-digit numbers
            if (singleDigitSum > totalSum - singleDigitSum)
            {
                return true;
            }

            // Alice chooses all double-digit numbers
            if (doubleDigitSum > totalSum - doubleDigitSum)
            {
                return true;
            }

            return false;
        }
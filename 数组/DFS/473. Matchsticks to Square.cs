//Leetcode 473. Matchsticks to Square med
//题意：给定一个整数数组 matchsticks，其中 matchsticks[i] 是第i根火柴的长度。
//你需要用这些火柴构成一个正方形。要求：
//每根火柴只能使用一次。火柴不能折断。所有火柴必须被使用。
//输出： DFS递归 + 回溯
//如果可以用这些火柴构成一个正方形，返回 true；否则返回 false。
//思路：如果火柴的总长度不能被 4 整除，则无法组成正方形，直接返回 false。
//目标边长正方形的四条边必须等长，设边长为 target = totalLength / 4。
//火柴排序优化将火柴按长度从大到小排序。这样可以优先尝试较长的火柴，从而减少回溯次数。
//递归 + 回溯定义一个数组 sides 表示当前每条边的长度，初始为[0, 0, 0, 0]。
//从第一根火柴开始，尝试将它放到某条边上，如果当前边长度加上火柴长度不超过 target，
//则继续尝试下一根火柴。如果无法放置，则回溯，移除当前火柴。
//剪枝如果当前火柴无法放置到任何边上，说明该方案不可行，提前终止搜索。
//时间复杂度:  O(4^n)
//空间复杂度： O(n)
        public bool Makesquare(int[] matchsticks)
        {
            int sum = matchsticks.Sum();
            int sideLength = sum / 4;
            if (sum % 4 != 0 || matchsticks.Max() > sideLength)
                return false;
            Array.Sort(matchsticks);
            Array.Reverse(matchsticks);

            int[] sides = new int[4];

            bool dfsMakesquare(int index)
            {
                if (index == matchsticks.Length)
                {
                    return sides[0] == sideLength && sides[1] == sideLength && sides[2] == sideLength && sides[3] == sideLength;
                }
                for(int i = 0; i < 4; i++)
                {
                    if (sides[i] + matchsticks[index] <= sideLength)
                    {
                        sides[i] += matchsticks[index];
                        if (dfsMakesquare(index + 1))
                            return true;
                        sides[i] -= matchsticks[index];
                    }
                    if (sides[i] == 0)
                        break;
                }
                return false;
            }

            return dfsMakesquare(0);
        }
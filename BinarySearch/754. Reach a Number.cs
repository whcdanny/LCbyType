//Leetcode 754. Reach a Number med
//题意：你站在无限数轴上的位置 0 处，有一个目标位置在 target 处。你可以通过一些移动次数 numMoves 来实现：
//在每一步中，你可以选择向左或向右移动。
//在第 i 步（从 i == 1 到 i == numMoves），你可以选择向左或向右移动 i 步。
//问题要求返回到达目标位置的最小移动次数。
//思路：通过二分查计算目标位置的绝对值：
//由于无论是向左还是向右移动，最终结果都是对称的，因此我们可以先计算目标位置的绝对值 target，不考虑具体方向。
//找到最小的 numMoves：
//对于任意 numMoves，总共的移动次数是 numMoves * (numMoves + 1) / 2。
//我们需要找到最小的 numMoves，使得 numMoves * (numMoves + 1) / 2 大于等于 target。
//使用二分搜索找到满足条件的最小 numMoves。
//计算实际的移动次数：如果 numMoves * (numMoves + 1) / 2 与 target 之间的差值是偶数，则返回 numMoves。如果差值是奇数，再考虑 numMoves + 1 是否是偶数，如果是则返回 numMoves + 1，否则返回 numMoves + 2。
//时间复杂度: O(log(target))
//空间复杂度：O(1)
        public int ReachNumber(int target)
        {
            target = Math.Abs(target);
            int start = 1, end = target, numOfMoves = 0;
            long finalPosition = 0;
            while (start <= end)
            {
                int mid = start + (end - start) / 2;
                long sum = (long)mid * (mid + 1) / 2;
                if (sum >= target)
                {
                    finalPosition = sum;
                    numOfMoves = mid;
                    end = mid - 1;
                }
                else
                {
                    start = mid + 1;
                }
            }
            return ((int)(finalPosition - target)) % 2 == 0 ? numOfMoves : numOfMoves % 2 == 0 ? numOfMoves + 1 : numOfMoves + 2;
        }
//Leetcode 967. Numbers With Same Consecutive Differences med
//题意：给定两个整数 N 和 K，找到所有长度为 N 且具有以下属性的整数：整数中的每个相邻数字之间的绝对差正好等于 K。整数的首位数字不会是 0。
//思路：BFS（广度优先搜索）这里我们使用 List而不是 Queue ，因为出队顺序与此问题无关。我们从左到右迭代，因此起始队列没有0。我们总是关心在右侧追加哪个数字，因此找出尾部数字是什么很重要。当 k 不为零时，下一个数字可以有两个候选者。当我们切换级别时，原来的队列被nextQueue取代。
//时间复杂度: 假设 N 为所需数字的位数，K 为相邻数字之间的差值。在最坏情况下，我们需要遍历所有可能的数字，即从 1 到 9，然后逐步构造符合条件的数字。对于每个数字，我们都需要检查它的最后一位，然后计算可能的下一位数字。因此，总体时间复杂度可以表示为 O(9 * 2^(N-1))，其中 9 是从 1 到 9 的可能的起始数字的数量。
//空间复杂度：空间复杂度取决于结果列表和队列的大小。在最坏情况下，我们可能需要存储所有符合条件的数字，因此空间复杂度为 O(9 * 2^(N-1))。其中 9 是从 1 到 9 的可能的起始数字的数量。
        public int[] NumsSameConsecDiff(int n, int k)
        {
            if (n == 1)
                return new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            List<int> queue = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            for (int level = 1; level < n; ++level)
            {
                List<int> nextQueue = new List<int>();
                // iterate through each number within the level
                foreach (int num in queue)
                {
                    int tailDigit = num % 10;

                    List<int> nextDigits = new List<int>();
                    nextDigits.Add(tailDigit + k);
                    if (k != 0)
                        nextDigits.Add(tailDigit - k);
                    foreach (int nextDigit in nextDigits)
                    {
                        if (0 <= nextDigit && nextDigit < 10)
                        {
                            int newNum = num * 10 + nextDigit;
                            nextQueue.Add(newNum);
                        }
                    }
                }
                // prepare for the next level
                queue = nextQueue;
            }

            return queue.ToArray();
        }
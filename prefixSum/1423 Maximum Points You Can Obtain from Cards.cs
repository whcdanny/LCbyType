//Leetcode 1423 Maximum Points You Can Obtain from Cards med
//题意：给定一个由 n 张卡牌组成的数组 points，其中 points[i] 是第 i 张卡牌的点数。玩家轮流从数组的两端拿取一张卡牌，每次拿取一张，分数累计。玩家需要取得最大的分数。
//思路：前缀和（Prefix Sum）, 这个问题可以转化为一个求连续子数组和的最小值的问题。首先，我们可以计算数组所有元素的总和，然后从数组两端开始移动一个固定大小的窗口，使得窗口内的元素和最小。通过总和减去窗口内元素的和，就可以得到窗口外的元素和，从而得到窗口内元素的和的最大值。
//时间复杂度：O(n)
//空间复杂度：O(1)
        public int MaxScore(int[] cardPoints, int k)
        {
            int n = cardPoints.Length;
            int totalSum = cardPoints.Sum();
            int windowSize = n - k;
            int currentSum = cardPoints.Take(windowSize).Sum();
            int minSum = currentSum;

            for (int i = windowSize; i < n; i++)
            {
                currentSum += cardPoints[i] - cardPoints[i - windowSize];
                minSum = Math.Min(minSum, currentSum);
            }

            return totalSum - minSum;
        }
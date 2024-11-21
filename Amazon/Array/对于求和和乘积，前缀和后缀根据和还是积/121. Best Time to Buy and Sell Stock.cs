//Leetcode 121. Best Time to Buy and Sell Stock ez
//题目：给定一个数组 prices，其中 prices[i] 表示某支股票在第 i 天的价格。
//你需要选择一天买入股票，随后选择未来的一天卖出股票，目的是尽可能地获取最大的利润。
//要求：
//返回可以获得的最大利润。如果无法获得利润，则返回 0。
//思路: 遍历数组时，记录到当前为止的最小价格。
//计算每一天卖出时的潜在利润，更新最大利润。
//整个过程只需一次遍历，
//时间复杂度：O(n)
//空间复杂度：O(1)
        public int MaxProfit(int[] prices)
        {
            int minPrice = int.MaxValue;
            int maxProfit = 0;

            foreach (int currentPrice in prices)
            {
                minPrice = Math.Min(currentPrice, minPrice);
                maxProfit = Math.Max(maxProfit, currentPrice - minPrice);
            }

            return maxProfit;
        }
//Leetcode 901. Online Stock Span med
//题意：收集某股票的每日价格报价，并返回该股票当天价格的价格跨度。
//股票在一天内的价格跨度是指从当天开始向前连续的最大天数（包括当天），在这些天内股票价格都小于或等于当天的价格。
//例如，如果过去四天的股票价格分别是[7, 2, 1, 2]，并且当天的股票价格是 2，那么当天的价格跨度为 4，因为从当天开始，股票价格在连续的 4 天内都小于或等于 2。
//再如，如果过去四天的股票价格分别是[7, 34, 1, 2]，并且当天的股票价格是 8，那么当天的价格跨度为 3，因为从当天开始，股票价格在连续的 3 天内都小于或等于 8。
//思路：stack 单调栈来解决该问题，其中栈中存储的是价格的索引，而不是具体的价格。
//遍历每日的价格列表，如果当前价格大于栈顶的价格，则弹出栈顶元素。
//计算当前价格的跨度，即当前价格索引减去栈顶元素索引。
//将当前价格的索引入栈。
//最后返回跨度。
//时间复杂度: 假设共有 n 个价格，遍历所有价格需要 O(n) 的时间
//空间复杂度：O(n)。
        public class StockSpanner
        {

            private Stack<int> prices;
            private Stack<int> spans;

            public StockSpanner()
            {
                prices = new Stack<int>();
                spans = new Stack<int>();
            }

            public int Next(int price)
            {
                int span = 1;
                while (prices.Count > 0 && prices.Peek() <= price)
                {
                    prices.Pop();
                    span += spans.Pop();
                }
                prices.Push(price);
                spans.Push(span);
                return span;
            }
        }

        /**
         * Your StockSpanner object will be instantiated and called as such:
         * StockSpanner obj = new StockSpanner();
         * int param_1 = obj.Next(price);
         */
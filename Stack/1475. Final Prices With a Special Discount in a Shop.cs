//Leetcode 1475. Final Prices With a Special Discount in a Shop ez
//题意：给定一个整数数组 prices，表示商店中每件商品的价格。
//商店提供特殊折扣：如果购买第 i 件商品，那么你将获得一个折扣，该折扣金额等于第一个价格小于等于当前商品价格的商品的价格。
//如果不存在这样的商品，则不会获得任何折扣。返回一个整数数组 answer，其中 answer[i] 表示购买第 i 件商品时最终需要支付的价格，考虑到了特殊折扣。
//思路：Stack,用单调栈来找到每件商品的特殊折扣。
//首先，遍历数组，维护一个递增栈，栈中存放的是数组元素的索引。
//当遇到一个价格小于栈顶价格时，将栈顶元素出栈，并将当前商品价格作为栈顶元素的特殊折扣。
//然后再遍历一次数组，根据找到的特殊折扣，计算每件商品的最终价格。
//时间复杂度：O(n)，其中 n 是数组 prices 的长度。需要两次遍历数组，并且每个元素最多入栈和出栈一次。
//空间复杂度：O(n)，额外使用了一个整型数组 discounts 和一个栈。
        public int[] FinalPrices(int[] prices)
        {
            int n = prices.Length;
            int[] discounts = new int[n];
            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < n; i++)
            {
                while (stack.Count > 0 && prices[stack.Peek()] >= prices[i])
                {
                    discounts[stack.Pop()] = prices[i];
                }
                stack.Push(i);
            }

            for (int i = 0; i < n; i++)
            {
                prices[i] -= discounts[i];
            }

            return prices;
        }
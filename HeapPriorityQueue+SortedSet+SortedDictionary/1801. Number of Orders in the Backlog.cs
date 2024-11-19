//Leetcode 1801. Number of Orders in the Backlog med
//题意：给定一个二维整数数组orders，其中每个orders[i] = [pricei, amounti, orderTypei]表示以pricei价格放置了amounti个orderTypei类型的订单。orderTypei为：
//如果是批量购买订单，则为0
//如果是批量销售订单，则为1
//有一个backlog，包含尚未执行的订单。当下订单时，发生以下情况：
//如果订单是购买订单，你会查看backlog中价格最低的销售订单。如果该销售订单的价格小于等于当前购买订单的价格，它们将匹配并执行，该销售订单将从backlog中删除。否则，购买订单将被添加到backlog中。
//如果订单是销售订单，你会查看backlog中价格最高的购买订单。如果该购买订单的价格大于等于当前销售订单的价格，它们将匹配并执行，该购买订单将从backlog中删除。否则，销售订单将被添加到backlog中。
//要求返回输入订单放置后backlog中订单总数。由于该数字可能很大，因此返回取模后的结果。
//思路：PriorityQueue 维护两个优先队列，一个用于存放购买订单（最大堆），一个用于存放销售订单（最小堆）。
//遍历订单数组，根据订单类型将订单放入相应的优先队列中。
//对于购买订单，首先查看销售订单的最小价格，如果小于等于当前购买订单的价格，则匹配并执行，否则将购买订单加入backlog中。
//对于销售订单，首先查看购买订单的最大价格，如果大于等于当前销售订单的价格，则匹配并执行，否则将销售订单加入backlog中。
//最后返回backlog中订单的总数，取模后的结果。
//时间复杂度: O(nlogn)
//空间复杂度：O(n)  
        public int GetNumberOfBacklogOrders(int[][] orders)
        {
            var buyOrders = new SortedDictionary<long, long>(Comparer<long>.Create((x, y) => y.CompareTo(x)));

            var sellOrders = new SortedDictionary<long, long>();

            foreach (var bid in orders)
            {
                long price = bid[0];
                long amount = bid[1];
                var type = bid[2];

                if (type == 0)
                {//购买
                    while (amount > 0 && sellOrders.Count > 0 && sellOrders.First().Key <= price)
                    {
                        var sell = sellOrders.First();

                        var sellAmount = Math.Min(amount, sell.Value);
                        amount -= sellAmount;
                        if (sell.Value == sellAmount)
                        {                           
                            sellOrders.Remove(sell.Key);
                        }
                        else
                        {
                            sellOrders[sell.Key] = sellOrders[sell.Key] - sellAmount;
                        }
                    }

                    if (amount > 0)
                    {
                        buyOrders[price] = buyOrders.GetValueOrDefault(price) + amount;
                    }
                }
                else
                {//销售
                    while (amount > 0 && buyOrders.Count > 0 && buyOrders.First().Key >= price)
                    {
                        var buy = buyOrders.First();

                        var buyAmount = Math.Min(amount, buy.Value);
                        amount -= buyAmount;
                        if (buy.Value == buyAmount)
                        {                            
                            buyOrders.Remove(buy.Key);
                        }
                        else
                        {
                            buyOrders[buy.Key] = buyOrders[buy.Key] - buyAmount;
                        }
                    }

                    if (amount > 0)
                    {
                        sellOrders[price] = sellOrders.GetValueOrDefault(price) + amount;
                    }
                }

            }
            return (int)((sellOrders.Values.Sum() + buyOrders.Values.Sum()) % (Math.Pow(10, 9) + 7));
        }

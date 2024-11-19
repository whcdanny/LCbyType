//Leetcode 2034. Stock Price Fluctuation med
//题意：要求设计一个算法，用于处理股票的价格记录流。每个记录包含一个时间戳和该时间戳对应的股票价格。
//算法需要实现以下功能：
//更新特定时间戳处的股票价格，从而纠正以前记录在该时间戳处的价格。
//找到基于当前记录的股票最新价格。最新价格是最近记录的时间戳对应的价格。
//找到基于当前记录的股票的最高价格。
//找到基于当前记录的股票的最低价格。
//下面是对应的 StockPrice 类的功能描述：
//StockPrice()：初始化对象，没有股票价格记录。
//void update(int timestamp, int price)：更新给定时间戳的股票价格。
//int current()：返回股票的最新价格。
//int maximum()：返回股票的最高价格。
//int minimum()：返回股票的最低价格。
//思路：PriorityQueue 看code
//时间复杂度: O(nlogn) Current - O(1) Update - O(logn) Min - O(logn) Max - O(logn)
//空间复杂度：O(n)            
        public class StockPrice
        {
            PriorityQueue<(int time, int price), int> minHeap;
            PriorityQueue<(int time, int price), int> maxHeap;
            Dictionary<int, int> dict = new Dictionary<int, int>();

            int latestTime = 0;
            public StockPrice()
            {
                minHeap = new PriorityQueue<(int time, int price), int>();

                maxHeap = new PriorityQueue<(int time, int price), int>(Comparer<int>.Create((a, b) => b - a));
            }

            public void Update(int timestamp, int price)
            {

                latestTime = Math.Max(timestamp, latestTime);

                dict.TryAdd(timestamp, price);
                dict[timestamp] = price;

                minHeap.Enqueue((timestamp, price), price);
                maxHeap.Enqueue((timestamp, price), price);
            }

            public int Current()
            {
                return dict[latestTime];
            }

            public int Maximum()
            {
                while (maxHeap.Count != 0)
                {
                    if (maxHeap.Peek().price == dict[maxHeap.Peek().time])
                        break;
                    maxHeap.Dequeue();
                }

                return maxHeap.Peek().price;
            }

            public int Minimum()
            {
                while (minHeap.Count != 0)
                {
                    if (minHeap.Peek().price == dict[minHeap.Peek().time])
                        break;
                    minHeap.Dequeue();
                }

                return minHeap.Peek().price;
            }
        }
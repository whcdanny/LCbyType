//933. Number of Recent Calls med
//题意：您有一个RecentCounter类，它计算一定时间范围内的最近请求的数量。
//实现RecentCounter类：
//RecentCounter()使用零个最近请求来初始化计数器。
//int ping(int t)在时间 处添加新请求t，其中t表示某个时间（以毫秒为单位），
//并返回过去几毫秒内发生的请求数3000（包括新请求）。
//具体而言，返回在 范围内发生的请求数[t - 3000, t]。
//保证每次调用都使用ping比前一次调用更大的值t。
//思路：用queue去存每一次放入的t，
//保证每次调用都使用ping比前一次调用更大的值t
//queue.Peek() < t - 3000 queue.Dequeue();
//时间复杂度：O(n)
//空间复杂度：O(n)
        public class RecentCounter
        {
            private Queue<int> queue;
            public RecentCounter()
            {
                queue = new Queue<int>();
            }
            public int Ping(int t)
            {
                queue.Enqueue(t);
                while (queue.Peek() < t - 3000)
                {
                    queue.Dequeue();
                }

                return queue.Count;
            }
        }
        /**
        * Your RecentCounter object will be instantiated and called as such:
        * RecentCounter obj = new RecentCounter();
        * int param_1 = obj.Ping(t);
        */
//Leetcode 1845. Seat Reservation Manager med
//题意：设计一个系统来管理从1到n编号的n个座位的预订状态。
//实现SeatManager类：
//SeatManager(int n) 初始化一个SeatManager对象，该对象将管理从1到n编号的n个座位。所有座位最初都是可用的。
//int reserve() 获取最小编号的未预订座位，预订它，并返回其编号。
//void unreserve(int seatNumber) 取消预订具有给定seatNumber的座位。
//思路：PriorityQueue 看code
//使用优先队列（Priority Queue）来管理可用的座位，以便在O(log n)时间内找到最小编号的未预订座位。
//初始化时，将所有座位编号添加到优先队列中。
//当调用Reserve方法时，从优先队列中取出队首元素（即最小编号的未预订座位），并将其返回。这一操作的时间复杂度是O(log n)。
//当调用Unreserve方法时，将取消预订的座位编号重新添加到优先队列中，以便其他顾客可以预订。这一操作的时间复杂度同样是O(log n)。
//时间复杂度: 初始化时，向优先队列中添加n个元素，时间复杂度为O(nlogn)。Reserve方法和Unreserve方法每次操作的时间复杂度都是O(log n)。
//空间复杂度：O(n)  
        public class SeatManager
        {
            private int last;
            private PriorityQueue<int, int> pq;

            public SeatManager(int n)
            {
                last = 0;
                pq = new PriorityQueue<int, int>();
            }

            public int Reserve()
            {
                if (pq.Count == 0)
                {
                    return ++last;
                }
                else
                {
                    return pq.Dequeue();
                }
            }

            public void Unreserve(int seatNumber)
            {
                if (seatNumber == last)
                {
                    last--;
                }
                else
                {
                    pq.Enqueue(seatNumber, seatNumber);
                }
            }
        }
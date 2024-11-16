//Leetcode 2402. Meeting Rooms III hard
//题意：给定一个整数 n。有 n 个编号从 0 到 n - 1 的房间。
//给定一个二维整数数组 meetings，其中 meetings[i] = [starti, endi] 表示一个会议将在半开时间区间[starti, endi) 内举行。所有 starti 的值都是唯一的。
//会议被分配到房间的方式如下：
//每个会议将在未使用的房间中编号最低的房间举行。
//如果没有可用的房间，会议将延迟，直到有房间可用。延迟的会议应该与原始会议具有相同的持续时间。
//当一个房间变为空闲时，应该给出比原始开始时间更早的会议使用该房间。
//返回举行了最多会议的房间编号。如果有多个房间，返回编号最低的房间。
//半开区间[a, b) 是指介于 a 和 b 之间的区间，包括 a，但不包括 b。
//思路：PriorityQueue 开始时间按升序对会议进行排序
//availableTime值相等，则会比较该roomNumber字段。这确保了优先级队列首先检索最早可用的房间。   
//检查优先队列中房间的可用性
//如果最早的可用房间在当前会议开始时间 ( ) 内仍然不可用meetings[i][0]，则会将该房间出队，更新其可用时间以匹配当前会议开始时间，并将其重新排入优先级队列。
//如果availableTime值大于meetings[i][0]，说明需要等带这个room空才可以加入到这里开会，所以availableTime += (meetings[i][1] - meetings[i][0])；
//如果不用等待直接用，那么availableTime = meetings[i][1];
//时间复杂度: O(nlogn)
//空间复杂度：O(n)       
        public int MostBooked(int n, int[][] meetings)
        {
            //开始时间按升序对会议进行排序
            Array.Sort(meetings, (x, y) => x[0] - y[0]);
            //availableTime值相等，则会比较该roomNumber字段。这确保了优先级队列首先检索最早可用的房间。
            var rooms = new PriorityQueue<(int roomNumber, long availableTime, int count), (int roomNumber, long availableTime, int count)>(
                Comparer<(int roomNumber, long availableTime, int count)>.Create(
                    (x, y) => x.availableTime == y.availableTime ? x.roomNumber - y.roomNumber : (int)(x.availableTime - y.availableTime)));

            for (int i = 0; i < n; i++)
            {
                rooms.Enqueue((i, 0, 0), (i, 0, 0));
            }
            //检查优先队列中房间的可用性
            for (int i = 0; i < meetings.Length; i++)
            {
                //如果最早的可用房间在当前会议开始时间 ( ) 内仍然不可用meetings[i][0]，则会将该房间出队，更新其可用时间以匹配当前会议开始时间，并将其重新排入优先级队列。
                while (rooms.Peek().availableTime < meetings[i][0])
                {
                    var temp = rooms.Dequeue();
                    temp.availableTime = meetings[i][0];
                    rooms.Enqueue(temp, temp);
                }
                //如果availableTime值大于meetings[i][0]，说明需要等带这个room空才可以加入到这里开会，所以availableTime += (meetings[i][1] - meetings[i][0])；
                var cur = rooms.Dequeue();
                if (cur.availableTime > meetings[i][0])
                    cur.availableTime += (meetings[i][1] - meetings[i][0]);
                //如果不用等待直接用，那么availableTime = meetings[i][1];
                else
                    cur.availableTime = meetings[i][1];
                cur.count++;
                rooms.Enqueue(cur, cur);
            }
            //开始循环查找预订数最多的房间
            (int roomNumber, long availableTime, int count) best = rooms.Dequeue();
            while (rooms.Count > 0)
            {
                var cur = rooms.Dequeue();
                if (cur.count == best.count && cur.roomNumber < best.roomNumber)
                    best = cur;
                else if (cur.count > best.count)
                    best = cur;
            }
            return best.roomNumber;
        }
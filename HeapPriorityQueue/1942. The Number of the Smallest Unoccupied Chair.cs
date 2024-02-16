//Leetcode 1942. The Number of the Smallest Unoccupied Chair med
//题意：有一个派对上有 n 个朋友，编号从 0 到 n - 1。派对上有无限多个椅子，编号从 0 到无穷大。当朋友到达派对时，他们会坐在编号最小的空椅子上。
//例如，如果椅子 0、1 和 5 在朋友到达时已被占用，那么他们将坐在椅子号为 2 的位置上。
//当一个朋友离开派对时，他们的椅子立即变为空闲。如果在同一时刻有另一个朋友到达，他们可以坐在那个椅子上。
//给定一个二维整数数组 times，其中 times[i] = [arrivali, leavingi] 表示第 i 个朋友的到达和离开时间，以及一个整数 targetFriend。所有到达时间都是不同的。
//返回编号为 targetFriend 的朋友将坐在哪个椅子上。
//思路：PriorityQueue 看code
//时间复杂度: O(nlogn)
//空间复杂度：O(1)        
        public int SmallestChair(int[][] times, int targetFriend)
        {
            List<(int arriveTime, int leaveTime, int index)> friends = new List<(int arriveTime, int leaveTime, int index)>();
            PriorityQueue<(int leaveTime, int chair), int> usedChairs = new PriorityQueue<(int leaveTime, int chair), int>();
            PriorityQueue<int, int> availableChairs = new PriorityQueue<int, int>();

            for (int i = 0; i < times.Length; i++)
            {
                friends.Add((times[i][0], times[i][1], i));
            }
            friends.Sort();

            int maxChair = -1;
            foreach (var friend in friends)
            {
                int arriveTime = friend.arriveTime;
                int chairToOccupy;

                //看谁离开之和 谁可以来坐， 把有空位的位值存下；
                while (usedChairs.Count != 0 && usedChairs.Peek().leaveTime <= arriveTime)
                {
                    var chair = usedChairs.Dequeue();
                    availableChairs.Enqueue(chair.chair, chair.chair);
                }
                //如果有空位，就选择最小的位置；
                if (availableChairs.Count != 0)
                {
                    chairToOccupy = availableChairs.Dequeue();
                }
                else
                {
                    maxChair++;
                    chairToOccupy = maxChair;
                }
                //如果刚好是targetFriend 输出结果；
                if (friend.index == targetFriend)
                    return chairToOccupy;

                usedChairs.Enqueue((friend.leaveTime, chairToOccupy), friend.leaveTime);
            }
            return 0;
        }
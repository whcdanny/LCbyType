//Leetcode 871. Minimum Number of Refueling Stops hard
//题意：一辆车从起始位置向东行驶到目的地，目的地距离起始位置 target 英里。
//途中有加油站。加油站表示为一个数组 stations，其中 stations[i] = [positioni, fueli] 表示第 i 个加油站位于起始位置东面 positioni 英里处，并有 fueli 升汽油。
//车辆初始时有无限量的汽油，初始时的油箱中有 startFuel 升汽油。车辆每行驶一英里就消耗一升汽油。当车辆到达加油站时，它可以停下来加油，将加油站的所有汽油都转移到车辆中。    
//返回车辆必须停多少次加油才能到达目的地。如果无法到达目的地，则返回 -1。
//注意，如果车辆到达一个油量为 0 的加油站，仍然可以在该加油站加油。如果车辆在到达目的地时剩余的油量为 0，则仍然视为已到达。
//思路：PriorityQueue + 贪心
//初始化当前位置为 0，当前油量为 startFuel，加油次数为 0。
//使用一个优先队列（Priority Queue）来存储可以到达的加油站的油量，按照油量的多少来排序，这样我们可以优先选择油量最多的加油站。
//遍历加油站数组 stations，对于每个加油站，我们判断当前位置与加油站的距离，如果当前油量无法到达该加油站，则从优先队列中取出油量最多的加油站进行加油，直到当前位置能够到达该加油站为止。
//时间复杂度: O(nlogn)，其中 n 为加油站的数量
//空间复杂度：O(n)
        public int MinRefuelStops(int target, int startFuel, int[][] stations)
        {
            int n = stations.Length;
            //添加最后一个到达加油站的
            Array.Resize(ref stations, n + 1);
            stations[n] = new int[] { target, 0 };

            int pos = 0, fuel = startFuel, refuels = 0;
            PriorityQueue<int, int> pq = new PriorityQueue<int, int>();

            for (int i = 0; i <= n; i++)
            {
                int toReach = stations[i][0];
                //如果我发现当前到不了，那么我就加油，这个加油是加访问过所有加油站中能加最多的油；
                while (pq.Count > 0 && (pos + fuel) < toReach)
                {
                    fuel += pq.Dequeue();
                    refuels++;
                }
                //检查是否能到这一站；
                if (pos + fuel < toReach) return -1;

                //
                fuel -= toReach - pos;
                pos = toReach;

                //输入当前的能加的油
                pq.Enqueue(stations[i][1], -stations[i][1]);
            }

            return refuels;
        }
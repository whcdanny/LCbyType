//Leetcode 1094. Car Pooling med
//题意：有一辆车，车辆有一定的座位容量，只能向东行驶（不能掉头向西行驶）。
//给定整数 capacity 和一个 trips 数组，其中 trips[i] = [numPassengersi, fromi, toi] 表示第 i 次行程有 numPassengersi 位乘客，从 fromi 地点上车，到达 toi 地点下车。
//地点的位置是相对于车辆初始位置向东的公里数。
//判断是否可能完成所有行程，即能够接送所有乘客。如果可以，返回 true，否则返回 false。
//思路：PriorityQueue, 我们需要根据每个行程的起点和终点对 trips 数组进行排序，按照起点的位置从小到大排序。
//然后，使用一个优先队列（最小堆）来存储当前正在车上的乘客，在行驶过程中根据乘客下车的位置来及时释放座位。
//将乘客从上车点添加到优先队列中。
//如果优先队列中的总乘客数量超过了车辆的座位容量，则返回 false。
//如果乘客从下车点下车，将其从优先队列中移除。
//时间复杂度: 排序 trips 数组的时间复杂度为 O(nlogn)，遍历 trips 数组的时间复杂度为 O(nlogn)，总的时间复杂度为 O(nlogn)。
//空间复杂度：O(n * m)，其中 n 是栈的数量，m 是每个栈的容量
        public bool CarPooling(int[][] trips, int capacity)
        {
            Array.Sort(trips, (trip1, trip2) => trip1[1] - trip2[1]);
            PriorityQueue<int[], int> pq = new PriorityQueue<int[], int>();
            int passengersCount = 0;

            for (int i = 0; i < trips.Length; i++)
            {
                while (pq.Count > 0 && pq.Peek()[2] <= trips[i][1])
                {
                    passengersCount -= pq.Dequeue()[0];
                }

                passengersCount += trips[i][0];
                pq.Enqueue(trips[i], trips[i][2]);

                if (passengersCount > capacity)
                {
                    return false;
                }
            }

            return true;
        }


        public bool CarPooling1(int[][] trips, int capacity)
        {
            // 最多有 1001 个车站
            int[] nums = new int[1001];
            // 构造差分解法
            Difference df = new Difference(nums);

            foreach (int[] trip in trips)
            {
                // 乘客数量
                int val = trip[0];
                // 第 trip[1] 站乘客上车
                int i = trip[1];
                // 第 trip[2] 站乘客已经下车，
                // 即乘客在车上的区间是 [trip[1], trip[2] - 1]
                int j = trip[2] - 1;
                // 进行区间操作
                df.increment(i, j, val);
            }

            int[] res = df.result();

            // 客车自始至终都不应该超载
            for (int i = 0; i < res.Length; i++)
            {
                if (capacity < res[i])
                {
                    return false;
                }
            }
            return true;
        }
        class Difference
        {
            // 差分数组
            private int[] diff;

            /* 输入一个初始数组，区间操作将在这个数组上进行 */
            public Difference(int[] nums)
            {
                //nums.Length > 0;
                diff = new int[nums.Length];
                // 根据初始数组构造差分数组
                diff[0] = nums[0];
                for (int i = 1; i < nums.Length; i++)
                {
                    diff[i] = nums[i] - nums[i - 1];
                }
            }

            /* 给闭区间 [i, j] 增加 val（可以是负数）*/
            public void increment(int i, int j, int val)
            {
                diff[i] += val;
                if (j + 1 < diff.Length)
                {
                    diff[j + 1] -= val;
                }
            }

            /* 返回结果数组 */
            public int[] result()
            {
                int[] res = new int[diff.Length];
                // 根据差分数组构造结果数组
                res[0] = diff[0];
                for (int i = 1; i < diff.Length; i++)
                {
                    res[i] = res[i - 1] + diff[i];
                }
                return res;
            }
        }
//Leetcode 1606. Find Servers That Handled Most Number of Requests hard
//题意： 你有 k 台服务器，编号从 0 到 k-1，用于同时处理多个请求。每台服务器具有无限的计算能力，但一次只能处理一个请求。请求根据特定的算法分配给服务器：
        //第 i 个（从 0 开始编号）请求到达。
        //如果所有服务器都忙，则丢弃该请求（完全不处理）。
        //如果第(i % k) 台服务器空闲，则将请求分配给该服务器。
        //否则，将请求分配给下一个可用服务器（从服务器列表中循环，如果需要从 0 开始）。例如，如果第 i 台服务器忙碌，则尝试将请求分配给第(i+1) 台服务器，然后是第(i+2) 台服务器，依此类推。
        //给定一个严格递增的正整数数组 arrival，其中 arrival[i] 表示第 i 个请求的到达时间，以及另一个数组 load，其中 load[i] 表示第 i 个请求的负载（完成所需的时间）。你的目标是找到最繁忙的服务器。服务器被认为是最繁忙的，如果它在所有服务器中成功处理了最多数量的请求。
        //返回一个包含最繁忙服务器的 ID（从 0 开始编号）的列表。你可以以任何顺序返回 ID。
        //思路：PriorityQueue, free表示空的服务器，busy是PQ 存入服务器id和结束时间，
        //当插入一个任务的时候，先看是否有busy的结束时间是否有小于当前任务到达的时间，然后找i%k的服务器
        //由于有可能要选择的服务器当前满，所以用二分法查找到下一个空的服务器通过free
        //然后更新free和busy；并且给当前服务器的数量++；
        //最后找到max，然后找到所有max的位置；
        //时间复杂度: O(nlogk)
        //空间复杂度：O(k)
        public IList<int> BusiestServers(int k, int[] arrival, int[] load)//超时
        {
            SortedSet<int> free = new SortedSet<int>();
            PriorityQueue<(int id, int time), int> busy = new PriorityQueue<(int, int), int>();
            int[] countList = new int[k];
           
            for (int i = 0; i < k; i++)
            {
                free.Add(i);
            }

            for (int i = 0; i < arrival.Length; i++)
            {
                while (busy.Count > 0 && busy.Peek().time <= arrival[i])
                {                   
                    free.Add(busy.Peek().id);
                    busy.Dequeue();
                }
                if (free.Count == 0)
                    continue;
                //int index = Array.BinarySearch(free.ToArray(), i % k);
                int index = BusiestServersBinarySearch(free, i % k);
                if (index < 0)
                    index = ~index;                
                if (index == free.Count)
                    index = 0;
                int id = free.ElementAt(index);
                countList[id]++;
                free.Remove(id);
                busy.Enqueue((id, arrival[i] + load[i]), arrival[i] + load[i]);
            }
            IList<int> res = new List<int>();
            int maxCount = countList.Max();
            for (int i = 0; i < k; i++)
            {
                if (countList[i] == maxCount)
                    res.Add(i);
            }
            return res;
            
        }
        private int BusiestServersBinarySearch(SortedSet<int> free, int value)
        {
            int left = 0;
            int right = free.Count;
            while (left < right)
            {
                int mid = left + (right - left) / 2;

                if (free.ElementAt(mid) < value)
                    left = mid + 1;
                else
                    right = mid;
            }
            return left;
        }
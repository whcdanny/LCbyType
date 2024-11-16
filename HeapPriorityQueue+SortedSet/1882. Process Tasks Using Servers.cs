//Leetcode 1882. Process Tasks Using Servers med
//题意：给定两个长度分别为 n 和 m 的数组 servers 和 tasks。servers[i] 表示第 i 个服务器的权重，tasks[j] 表示处理第 j 个任务所需的时间（以秒为单位）。
//任务使用一个任务队列分配给服务器。最初，所有服务器都是空闲的，队列为空。
//在第 j 秒，第 j 个任务被插入队列中（从第 0 个任务开始插入，第 0 秒插入第 0 个任务）。只要有空闲的服务器且队列不为空，队列前面的任务将被分配给具有最小权重的空闲服务器，如果权重相同，则分配给具有最小索引的空闲服务器。
//如果没有空闲的服务器且队列不为空，则等待直到有服务器空闲，并立即分配下一个任务。如果有多个服务器同时空闲，则按照权重和索引的优先级依次分配队列中的多个任务。
//在第 t 秒被分配任务 j 的服务器将在 t + tasks[j] 秒后再次空闲。
//构建一个长度为 m 的数组 ans，其中 ans[j] 表示第 j 个任务将被分配给的服务器的索引。
//返回数组 ans。
//思路：PriorityQueue 看code
//创建两个优先队列（最小堆）ready和running，分别用于存储空闲的服务器和正在运行的任务。
//将所有服务器按照权重插入ready队列中。
//用一个变量time来模拟时间流逝，index表示当前任务的下标，res用于存储任务分配结果。
//在循环中，不断模拟时间的流逝，直到所有任务都被分配完毕。
//在每个时间点，先检查running队列中是否有任务完成，如果有，则将其对应的服务器重新加入ready队列。
//接着，从ready队列中取出空闲服务器，将当前任务分配给其处理，并将该任务添加到running队列中。
//将当前任务的分配结果保存到res数组中。
//时间复杂度: 将所有服务器插入ready队列的时间复杂度为O(nlogn)，n为服务器数量。在每一秒的循环中，处理任务的时间复杂度为O(logn + logm)，m为任务数量。O((n + m) * logn)
//空间复杂度：O(n + m)  
        public int[] AssignTasks(int[] servers, int[] tasks)
        {
            int time = 0, len = tasks.Length;
            //可选的servers，排序最小的权重
            PriorityQueue<int, int> freeServers = new PriorityQueue<int, int>(Comparer<int>.Create((a, b) =>
                    servers[a] == servers[b] ? a - b : servers[a] - servers[b]));
            //serverID, 变为空的时间； 按照结束时间排序
            PriorityQueue<(int, int), (int, int)> running = new PriorityQueue<(int, int), (int, int)>(Comparer<(int index0, int index1)>.Create((a, b) => a.index1 - b.index1));
            //先加入server
            for (int i = 0; i < servers.Length; i++)
            {
                freeServers.Enqueue(i, i);
            }

            int index = 0;
            int[] res = new int[len];

            while (index < len)
            {
                //如果没有可用的server，找到下一个有空的server时间, 跟time来找到正确的时间；
                if (freeServers.Count == 0)
                {
                    time = Math.Max(time, running.Peek().Item2);
                }
                //如果running的里面有一个用空的时间跟当前time一样，那么freeserver更新；
                while (running.Count != 0 && running.Peek().Item2 == time)
                {
                    freeServers.Enqueue(running.Peek().Item1, running.Peek().Item1);
                    running.Dequeue();
                }                
                while (freeServers.Count != 0 && index < len && time >= index)
                {
                    //最小的权重server
                    int serverId = freeServers.Dequeue();
                    //serverID, 变为空的时间；
                    running.Enqueue((serverId, time + tasks[index]), (serverId, time + tasks[index]));
                    res[index++] = serverId;
                }
                time++;
            }

            return res;
        }
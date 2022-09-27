1882. Process Tasks Using Servers
//Java	
	public static int[] assignTasks(int[] servers, int[] tasks) {
        int time = 0, len = tasks.length;

        PriorityQueue<Integer> ready = new PriorityQueue<>((a, b) ->
                servers[a] == servers[b] ? a - b : servers[a] - servers[b]);
        PriorityQueue<int[]> running = new PriorityQueue<>((a, b) -> a[1] - b[1]);
        for (int i = 0; i < servers.length; i++) {
            ready.offer(i);
        }

        int index = 0;
        int[] res = new int[len];

        while (index < len) {
            if (ready.isEmpty())
                time = Math.max(time, running.peek()[1]);
            while (!running.isEmpty() && running.peek()[1] == time)
                ready.offer(running.poll()[0]);
            while (!ready.isEmpty() && index < len && time >= index) {
                int serverId = ready.poll();
                running.offer(new int[]{serverId, time + tasks[index]});
                res[index++] = serverId;
            }
            time++;
        }

        return res;
    }
	
	int[] servers = new int[] { 5, 1, 4, 3, 2 };
	int[] tasks = new int[] { 2, 1, 2, 4, 5, 2, 1 };
	
//C#
		class Server
        {
            public int server;
            public bool used;
            public Server(int server, bool used)
            {
                this.server = server;
                this.used = used;
            }
        }
        class TakeServer
        {
            public int position;
            public int time;
            public TakeServer(int position, int time)
            {
                this.position = position;
                this.time = time;
            }

        }
		public static int[] assignTasks(int[] servers, int[] tasks)
        {
            int time = 0, len = tasks.Length;
            HashSet<Server> ready = new HashSet<Server>();//当前有空闲的servers
            HashSet<TakeServer> running = new HashSet<TakeServer>();//servers位置和什么时候这个server会空闲            
            for (int i = 0; i < servers.Length; i++)
            {
                ready.Add(new Server(servers[i], false));
            }

            int index = 0;
            int[] res = new int[len];

            while (index < len)
            {
                if (!hasFreeInServers(ready))
                    time = Math.Max(time, runningMinTime(running));
                while (running.Count!=0 && runningMinTime(running) == time)
                {
                    List<TakeServer> removes = new List<TakeServer>();
                    foreach(TakeServer ts in running)
                    {
                        if(ts.time == time)
                        {
                            int position = ts.position;
                            ready.ElementAt(position).used = false;
                            removes.Add(ts);
                            break;
                        }
                    }
                    foreach (TakeServer ts in removes)
                        running.Remove(ts);
                }                    
                while (ready.Count != 0 && index < len && time >= index && hasFreeInServers(ready))
                {
                    int serverId = readyMinServer(ready);                    
                    running.Add( new TakeServer(serverId, time + tasks[index]));
                    res[index++] = serverId;
                }
                time++;
            }

            return res;
        }

        private static bool hasFreeInServers(HashSet<Server> ready)
        {
            foreach(Server s in ready)
            {
                if (!s.used)
                    return true;
            }
            return false;
        }

        private static int readyMinServer(HashSet<Server> ready)
        {
            int res = int.MaxValue;
            int min = int.MaxValue;
            foreach(Server ser in ready)
            {
                if (ser.server <= min && !ser.used)
                    min = ser.server;
            }
            int i = 0;
            foreach(Server ser in ready)
            {                
                if(ser.server == min && !ser.used)
                {
                    res = i;
                    ser.used = true;
                    break;
                }
                i++;
            }                        
            return res;    
        }


        private static int runningMinTime(HashSet<TakeServer> running)
        {
            int res = int.MaxValue;
            foreach(TakeServer ts in running)
            {
                if (ts.time < res)
                    res = ts.time;
            }
            return res;
        }
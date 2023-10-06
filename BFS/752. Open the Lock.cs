//Leetcode 752. Open the Lock med
//题意：题目要求通过旋转拨盘将锁打开。每个拨盘上都有10个数字（'0' 到 '9'）。开始时，锁的数字都是 '0'，你可以旋转拨盘将一个数字变成相邻的数字（例如 '0' 变成 '1'，'9' 变成 '0'），也可以将数字往回旋转。锁上有一个列表，其中包含四个代表目标数字的字符串，我们需要将锁从起始状态变为目标状态，每次只能旋转一个拨盘。。
//思路：广度优先搜索（BFS）序列化： 将起始状态加入队列，同时初始化一个集合来记录已经访问过的状态。开始BFS，每次从队列中取出一个状态，将其拨盘旋转得到相邻状态，如果该状态已经访问过，则跳过。
//时间复杂度: 字符串数组的长度为 n，拨盘上的数字个数为 m, 每个状态可以生成最多 8 个相邻状态O(8^n * m)
//空间复杂度：O(8^n)
        public int OpenLock(string[] deadends, string target)
        {
            HashSet<string> dead = new HashSet<string>(deadends);
            HashSet<string> visited = new HashSet<string>();
            Queue<string> queue = new Queue<string>();
            string start = "0000";
            if (dead.Contains(start)) return -1;
            queue.Enqueue(start);
            visited.Add(start);
            int steps = 0;

            while (queue.Count > 0)
            {
                int size = queue.Count;
                for (int i = 0; i < size; i++)
                {
                    string current = queue.Dequeue();
                    if (current == target) return steps;
                    for (int j = 0; j < 4; j++)
                    {
                        for (int d = -1; d <= 1; d += 2)
                        {
                            int nextDigit = (current[j] - '0' + d + 10) % 10;
                            string next = current.Substring(0, j) + nextDigit + current.Substring(j + 1);
                            if (!dead.Contains(next) && !visited.Contains(next))
                            {
                                queue.Enqueue(next);
                                visited.Add(next);
                            }
                        }
                    }
                }
                steps++;
            }

            return -1;
        }

//752. Open the Lock med
//有一个锁上面是0-9，每次旋转一次，给一个deadends 如果转到的数字包含在里面，就锁死无法转动，
//target如果没找到，return-1；
//思路：BFS: 记录需要跳过的死亡密码,记录已经穷举过的密码，防止走回头路,将当前队列中的所有节点向周围扩散
//判断是否到达终点,将一个节点的未遍历相邻节点加入队列
//注：超时
		public int OpenLock1(string[] deadends, string target)
        {
            // 记录需要跳过的死亡密码
            List<string> deads = new List<string>();
            foreach (string s in deadends)
                deads.Add(s);
            // 记录已经穷举过的密码，防止走回头路
            List<string> visited = new List<string>();
            Queue<string> q = new Queue<string>();
            // 从起点开始启动广度优先搜索
            int step = 0;
            q.Enqueue("0000");
            visited.Add("0000");
            while (q.Count > 0)
            {
                int sz = q.Count;
                /* 将当前队列中的所有节点向周围扩散 */
                for (int i = 0; i < sz; i++)
                {
                    string cur = q.Dequeue();
                    /* 判断是否到达终点 */
                    if (deads.Contains(cur))
                        continue;
                    if (cur.Equals(target))
                        return step;
                    /* 将一个节点的未遍历相邻节点加入队列 */
                    for (int j = 0; j < 4; j++)
                    {
                        string up = plusOne(cur, j);
                        if (!visited.Contains(up))
                        {
                            q.Enqueue(up);
                            visited.Add(up);
                        }
                        string down = minusOne(cur, j);
                        if (!visited.Contains(down))
                        {
                            q.Enqueue(down);
                            visited.Add(down);
                        }                        
                    }
                }
                /* 在这里增加步数 */
                step++;
            }
            return -1;
        }
        // 将 s[j] 向上拨动一次
        public string plusOne(string s, int j)
        {
            char[] ch = s.ToCharArray();
            if (ch[j] == '9')
                ch[j] = '0';
            else
                ch[j] += (char)1;
            return new string(ch);
        }
        // 将 s[j] 向下拨动一次
        public string minusOne(string s, int j)
        {
            char[] ch = s.ToCharArray();
            if (ch[j] == '0')
                ch[j] = '9';
            else
                ch[j] -= (char)1;
            return new string(ch);
        }
		
//双向BFS: 因为你必须知道终点在哪里
//注：超时
		public int OpenLock(string[] deadends, string target)
        {            
            List<string> deads = new List<string>();
            foreach (string s in deadends)
                deads.Add(s);
            List<string> q1 = new List<string>();
            List<string> q2 = new List<string>();
            List<string> visited = new List<string>();
            int step = 0;
            q1.Add("0000");
            q2.Add(target);
            while(q1.Count!=0 && q2.Count != 0)
            {
                List<string> temp = new List<string>();

                foreach(string cur in q1)
                {
                    if (deads.Contains(cur))
                        continue;
                    if (q2.Contains(cur))
                        return step;
                    visited.Add(cur);
                    for(int j = 0; j < 4; j++)
                    {
                        string up = plusOne(cur, j);
                        if (!visited.Contains(up))
                        {                           
                            temp.Add(up);
                        }
                        string down = minusOne(cur, j);
                        if (!visited.Contains(down))
                        {
                            temp.Add(down);
                        }
                    }
                }
                step++;
                if (q1.Count > q2.Count)
                {
                    temp = q1;
                    q1 = q2;
                    q2 = temp;
                }
                q1 = q2;
                q2 = temp;
            }
            return -1;
        }
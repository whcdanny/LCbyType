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
//Leetcode 2092. Find All People With Secret hard
//题意：给定整数 n 表示人数，二维数组 meetings 表示一系列会议，其中 meetings[i] = [a, b] 表示第 i 个会议的参与人数为 a，并且第 i 个会议的参与人编号为 b。给定整数 firstPerson 表示从第 firstPerson 个人开始找，要求找到所有与 firstPerson 直接或间接相识的人。
//思路：广度优先搜索（BFS）创建一个图表，其中键为人员，值为他们与其他人的会议列表, P1 与 P2 的会面发生在 P1 知道秘密之前或 P2 在与 P1 会面之前知道秘密
//时间复杂度:  O(n^2)
//空间复杂度： Space O(Max(m,n)), m = length of meetings
        public IList<int> FindAllPeople(int n, int[][] meetings, int firstPerson)
        {
            int[] SecretKnowTime = Enumerable.Repeat(int.MaxValue, n).ToArray();
            SecretKnowTime[0] = SecretKnowTime[firstPerson] = 0;    // set time when first 2 person know the secret
            Dictionary<int, List<int[]>> meetSchedule = new Dictionary<int, List<int[]>>();
            foreach (var meet in meetings)                           // O(m), m = no of meetings
            {
                var p1 = meet[0];
                var p2 = meet[1];
                var time = meet[2];
                // update Graph for P1
                if (!meetSchedule.ContainsKey(p1))
                    meetSchedule[p1] = new List<int[]>(){};                
                   
                // update Graph for P2
                if (!meetSchedule.ContainsKey(p2))
                    meetSchedule[p2] = new List<int[]>(){};               

                meetSchedule[p2].Add(new int[] { p1, time });
                meetSchedule[p1].Add(new int[] { p2, time });
            }

            Queue<int> q = new Queue<int>();
            q.Enqueue(0);
            q.Enqueue(firstPerson);
            while (q.Count > 0)
            {
                var currPerson = q.Dequeue();
                if (!meetSchedule.ContainsKey(currPerson)) continue; // no meetings present for a given person
                foreach (var meet in meetSchedule[currPerson])
                {
                    // P1 meeting with P2 happened before P1 knew Secret or P2 knew secret before his meeting with P1
                    if (SecretKnowTime[currPerson] > meet[1] || SecretKnowTime[meet[0]] <= meet[1])
                        continue;
                    else
                    {
                        q.Enqueue(meet[0]);
                        SecretKnowTime[meet[0]] = meet[1];  // update the secret known time for P2 to earlier duration
                    }
                }
            }

            List<int> knowSecret = new List<int>();
            for (int i = 0; i < n; i++)                        // O(n)
                if (SecretKnowTime[i] != int.MaxValue)
                    knowSecret.Add(i);
            return knowSecret.ToList();
        }
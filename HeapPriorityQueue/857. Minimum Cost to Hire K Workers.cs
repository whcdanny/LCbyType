//Leetcode 857. Minimum Cost to Hire K Workers hard
//题意有 n 名工人。给定两个整数数组 quality 和 wage，其中 quality[i] 表示第 i 名工人的素质，wage[i] 表示第 i 名工人的最低期望工资。
//我们想要雇佣恰好 k 名工人组成一个付费团队。为了雇佣一个 k 名工人的团队，我们必须根据以下规则支付工资：
//付费团队中的每个工人的工资应按其与付费团队中其他工人的素质比例来支付。
//付费团队中的每个工人必须至少获得其最低期望工资。
//给定整数 k，返回满足上述条件的形成付费团队所需的最少金额。结果与实际答案的误差在 10-5 范围内将被接受。
//思路：PriorityQueue 
//单位工资期望；较小的放在前面；这个值是wage/quality
//时间复杂度: O(nlogn)
//空间复杂度：O(n)
        public double MincostToHireWorkers(int[] quality, int[] wage, int k)
        {           
            //单位工资期望；较小的放在前面；
            List<Tuple<int, int>> workers = new List<Tuple<int, int>>();            
           
            for (int i = 0; i < quality.Length; i++)
            {
                workers.Add(new Tuple<int, int>(quality[i], wage[i]));
            }
            var comparer = Comparer<Tuple<int, int>>.Create((a, b) => {
                double ratioA = (double)a.Item2 / a.Item1;
                double ratioB = (double)b.Item2 / b.Item1;
                return ratioA.CompareTo(ratioB);
            });
            workers.Sort(comparer);

            //存的是效率，并且从大到小；
            PriorityQueue<int, int> pq = new PriorityQueue<int, int>();
            double res = int.MaxValue;
            int sumQuality = 0;
            for(int i = 0; i < workers.Count; i++)
            {
                //把当前的quality加入，然后算当前的效率；
                sumQuality += workers[i].Item1;
                pq.Enqueue(workers[i].Item1, -workers[i].Item1);
                //如果超过k个 移除效率最高的；
                if (pq.Count > k)
                {
                    sumQuality -= pq.Dequeue();
                }
                if (pq.Count == k) 
                {
                    double unitwage = (double)workers[i].Item2 / workers[i].Item1;
                    res = Math.Min(res, unitwage * sumQuality);
                }
            }

            return res;
        }
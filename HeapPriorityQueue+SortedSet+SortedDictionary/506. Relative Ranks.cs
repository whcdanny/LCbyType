//Leetcode 506. Relative Ranks ez
//题意：给定一个大小为 n 的整数数组 score，其中 score[i] 表示比赛中第 i 名运动员的分数。所有的分数都保证是唯一的。   
//根据分数，运动员的排名被确定，第 1 名运动员有最高的分数，第 2 名运动员有第 2 高的分数，以此类推。每个运动员的排名决定了他们的奖牌：
//第 1 名运动员的奖牌是 "Gold Medal"。
//第 2 名运动员的奖牌是 "Silver Medal"。
//第 3 名运动员的奖牌是 "Bronze Medal"。
//对于第 4 名到第 n 名的运动员，他们的奖牌是他们的排名数字（即，第 x 名运动员的奖牌是 "x"）。
//返回一个大小为 n 的数组 answer，其中 answer[i] 是第 i 名运动员的奖牌。
//思路：PriorityQueue, 存入score从大到小；
//时间复杂度: O(nlogn)，排序所需时间
//空间复杂度：O(n)   
        public string[] FindRelativeRanks(int[] score)
        {
            string[] res = new string[score.Length];
            PriorityQueue<int, int> pq = new PriorityQueue<int, int>();            

            for (int i = 0; i < score.Length; i++)
            {
                pq.Enqueue(i, -score[i]);
            }

            if (pq.Count > 0)
            {
                res[pq.Dequeue()] = "Gold Medal";
            }

            if (pq.Count > 0)
            {
                res[pq.Dequeue()] = "Silver Medal";
            }

            if (pq.Count > 0)
            {
                res[pq.Dequeue()] = "Bronze Medal";
            }

            for (int i = 4; pq.Count > 0; i++)
            {
                res[pq.Dequeue()] = $"{i}";
            }

            return res;
        }
        //思路：首先，我们需要对 score 进行降序排序，并记录下原始的下标位置。
        //然后，根据排序后的顺序，给出每个运动员对应的奖牌。最后，根据原始的下标位置恢复结果数组 answer。
        //时间复杂度：O(nlogn)，排序所需时间。
        //空间复杂度：O(n)，用于存储排序后的结果和原始下标位置。
        public string[] FindRelativeRanks1(int[] score)
        {
            int n = score.Length;
            string[] result = new string[n];

            // 统计分数和对应的下标
            var scoreAndIndex = new List<Tuple<int, int>>();
            for (int i = 0; i < n; i++)
            {
                scoreAndIndex.Add(new Tuple<int, int>(score[i], i));
            }

            // 按分数降序排序
            scoreAndIndex.Sort((a, b) => b.Item1.CompareTo(a.Item1));

            // 分配奖牌
            for (int i = 0; i < n; i++)
            {
                int index = scoreAndIndex[i].Item2;
                if (i == 0)
                {
                    result[index] = "Gold Medal";
                }
                else if (i == 1)
                {
                    result[index] = "Silver Medal";
                }
                else if (i == 2)
                {
                    result[index] = "Bronze Medal";
                }
                else
                {
                    result[index] = (i + 1).ToString();
                }
            }

            return result;
        }

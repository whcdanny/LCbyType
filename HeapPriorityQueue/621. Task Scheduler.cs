//Leetcode 621. Task Scheduler med
//题意：给定一个 CPU 任务数组，每个任务由字母 A 到 Z 表示，并且有一个冷却时间 n。每个周期或间隔允许完成一个任务。
//任务可以以任何顺序完成，但有一个约束条件：由于冷却时间，相同的任务必须至少间隔 n 个周期。
//返回完成所有任务所需的最小间隔数。
//思路：PriorityQueue, 先建立一个字母和出现次数，然后pq存入这些次数并从大到小的排列；
//queue存入出现频率和下一次该字母出现的个数；最后直到pq和queue都空的结束；
//注：由于每一次pq都会dequeue所以不会有重复字母出现；
//时间复杂度: O(k + (m log m))k为任务数组的长度，m为唯一任务的数量
//空间复杂度：O(m)       
        public int LeastInterval(char[] tasks, int n)
        {            
            IDictionary<char, int> hashMap = new Dictionary<char, int>();
            for (int i = 0; i < tasks.Length; i++)
            {
                hashMap.TryAdd(tasks[i], 0);
                hashMap[tasks[i]] += 1;
            }
            PriorityQueue<int, int> pq = new PriorityQueue<int, int>();
            foreach (var item in hashMap)
            {
                pq.Enqueue(item.Value, - item.Value);
            }
            int time = 0, freq = 0;
            Queue<(int, int)> queue = new Queue<(int, int)>();
            while (pq.Count > 0 || queue.Count > 0)
            {
                time++;
                if (pq.TryDequeue(out freq, out _) && --freq != 0)
                {
                    queue.Enqueue((freq, time + n));
                }
                if (queue.TryPeek(out var item) && item.Item2 == time)
                {
                    freq = queue.Dequeue().Item1;
                    pq.Enqueue(freq, freq);
                }
            }
            return time;
        }
        //思路：我们首先统计每个任务出现的次数，并将任务按照出现次数从高到低排序。然后，我们从出现次数最多的任务开始，依次安排任务。
        //为了满足冷却时间的要求，我们需要在相邻任务之间插入空闲间隔，使得相同任务之间的间隔至少为 n。
        //如果我们的任务种类较少，可以在空闲间隔中插入其他任务。因此，我们只需要统计任务种类数，并使用公式计算总的最小间隔数。
        //时间复杂度：统计任务种类数的时间复杂度为 O(n)，其中 n 是任务的总数。
        //空间复杂度：空间复杂度为 O(1)，因为我们只需要常数级别的空间来存储任务种类数和间隔数。
        public int LeastInterval1(char[] tasks, int n)
        {
            int[] count = new int[26];
            foreach (char task in tasks)
            {
                count[task - 'A']++;
            }

            Array.Sort(count);
            int maxCount = count[25];

            int idleSlots = (maxCount - 1) * n;
            for (int i = 24; i >= 0 && count[i] > 0; i--)
            {
                idleSlots -= Math.Min(maxCount - 1, count[i]);
            }

            return Math.Max(0, idleSlots) + tasks.Length;
        }
    
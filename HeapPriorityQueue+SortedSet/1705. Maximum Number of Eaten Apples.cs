//Leetcode 1705. Maximum Number of Eaten Apples med
//题意：有一种特殊的苹果树，它在连续的 n 天内每天都会长出一定数量的苹果，但是这些苹果只有在长出后的若干天内可以被吃掉，过了这个时间就会腐烂。具体来说，第 i 天长出的 apples[i] 个苹果会在 i + days[i] 天腐烂。有些天树上不会长出苹果，此时 apples[i] == 0 并且 days[i] == 0。
//玩家每天最多只能吃一个苹果，即使在连续 n 天内也是如此。现在需要计算在这 n 天内玩家最多能吃到多少苹果。
//思路：PriorityQueue, 看code
//时间复杂度: O(nlogn)
//空间复杂度：O(n)  
        public int EatenApples(int[] apples, int[] days)
        {
            //count, expiry
            PriorityQueue<(int, int), int> pq = new PriorityQueue<(int, int), int>();
            int day = 0;
            int count = 0;

            while (day < apples.Length)
            {
                //把每一天产生的苹果数量和到期时间存在pq
                int expiry = day + days[day] - 1;
                pq.Enqueue((apples[day], expiry), expiry);

                //如果当前苹果已经到期了，或者已经没有苹果了，那就移除；
                while (pq.Count > 0 && (pq.Peek().Item2 < day || pq.Peek().Item1 == 0))
                {
                    pq.Dequeue();
                }
                //如果用那么就从快过期的里面吃一个
                if (pq.Count > 0)
                {
                    count++;
                    int tempcount = pq.Peek().Item1-1;
                    int tempExpiry = pq.Peek().Item2;
                    pq.Dequeue();
                    pq.Enqueue((tempcount, tempExpiry), tempExpiry);
                }

                day++;
            }
            //如果苹果树已经不产新的苹果了，那么就看剩余的还能吃几天；
            while (pq.Count > 0)
            {
                while (pq.Count > 0 && (pq.Peek().Item2 < day || pq.Peek().Item1 == 0))
                {
                    pq.Dequeue();
                }

                if (pq.Count > 0)
                {
                    count++;
                    int tempcount = pq.Peek().Item1 - 1;
                    int tempExpiry = pq.Peek().Item2;
                    pq.Dequeue();
                    pq.Enqueue((tempcount, tempExpiry), tempExpiry);
                }

                day++;
            }

            return count;
        }
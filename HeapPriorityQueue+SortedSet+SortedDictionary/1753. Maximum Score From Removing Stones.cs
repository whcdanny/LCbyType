//Leetcode 1753. Maximum Score From Removing Stones med
//题意：你正在玩一个独立的游戏，游戏中有三堆石头，分别有大小a、b和c。每一轮，你可以选择两个不同的非空堆，从每个堆中取出一块石头，然后将你的得分加1。游戏在剩下不足两个非空堆时结束（即没有更多可用的移动）。
//思路：PriorityQueue, 每一次选最小的两个石头堆；直到为0
//时间复杂度: O(n)
//空间复杂度：O(n)  
        public int MaximumScore(int a, int b, int c)
        {
            var pQueue = new PriorityQueue<int, int>();
            pQueue.Enqueue(a, a);
            pQueue.Enqueue(b, b);
            pQueue.Enqueue(c, c);

            int score = 0;
            int tempA = 0;
            int tempB = 0;

            while (pQueue.Count >= 2)
            {
                tempA = pQueue.Dequeue() - 1;
                tempB = pQueue.Dequeue() - 1;

                score++;

                if (tempA != 0) pQueue.Enqueue(tempA, tempA);
                if (tempB != 0) pQueue.Enqueue(tempB, tempB);
            }

            return score;
        }
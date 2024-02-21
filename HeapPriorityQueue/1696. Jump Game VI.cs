//Leetcode 1696. Jump Game VI med
//题意：给定一个整数数组 nums 和一个整数 k，数组中的每个元素代表你在当前位置可以跳跃的最大步数。
//你初始时站在数组的第一个位置，每一步可以选择跳跃的步数在 1 到 k 之间，目标是达到数组的最后一个位置。在跳跃的过程中，你会累计经过的位置的值作为分数。求最大的分数。       
//思路：PriorityQueue + sliding window, 来存分数和位置，并且这个是从大到小排序；
//逆向思路，当你在i的位置的时候，你之前的分数肯是最大的，所以每走一步都是要找最大的分数并满足你选的i的位置跟这个最大分的位置小于k；
//找到满足走下一步的条件即为 当前位置-pq中最大的数的位置<=k，则可以添加到res中；
//如果大于k，那么就弹出，直到找到满足条件；一直走到结束；
//时间复杂度: O(nlogk)
//空间复杂度：O(n)
        public int maxResult(int[] nums, int k)
        {
            if (nums.Length == 0) return 0;
            //score,index
            PriorityQueue<(int, int),int> pq = new PriorityQueue<(int, int), int>();
            pq.Enqueue((nums[0], 0), -nums[0]);
            int res = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                while (!(i - pq.Peek().Item2 <= k))
                {
                    pq.Dequeue();
                }
                (int score, int index) = pq.Peek();
                res = nums[i] + score;
                pq.Enqueue((res, i), -res);                
            }
            return res;
        }

//950. Reveal Cards In Increasing Order med
//题意：给定一个整数数组deck。有一副牌，每张牌都有一个唯一的整数。牌上的整数是。ithdeck[i]
//你可以按任意顺序排列牌组。最初，一副牌中的所有牌面朝下（未翻开）摆放。
//您将重复执行以下步骤，直到所有卡片都亮出：
//拿起牌堆顶的牌，展示它，并将其从牌堆中取出。
//如果牌堆中还有牌，则将牌堆顶部的下一张牌放在牌堆底部。
//如果还有未揭开的牌，则返回步骤1。否则，停止。
//返回按升序显示牌的牌组顺序。
//请注意，答案中的第一个条目被视为牌堆的顶部。
//思路：找到规律，先对deck排序，然后从大到小放入数字，
//每一次当queuesize>2个时候，再插入一个数时,
//先把queue最前面得数弹出，然后重新放入queue, 然后再把要放入的数放入queue
//queue.Enqueue(queue.Dequeue());queue.Enqueue(deck[i]);
//最后再将queue反转；
//时间复杂度：O(nlogn*logn)
//空间复杂度：O(n)
        public int[] DeckRevealedIncreasing(int[] deck)
        {
            Array.Sort(deck);
            int n = deck.Length;
            if (n == 1)
                return new int[] { deck[0] };
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(deck[n - 1]);
            queue.Enqueue(deck[n - 2]);
            for(int i = n - 3; i >= 0; i--)
            {
                queue.Enqueue(queue.Dequeue());
                queue.Enqueue(deck[i]);
            }
            int[] res = queue.ToArray();
            Array.Reverse(res);
            return res;
        }
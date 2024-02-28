//Leetcode 1046. Last Stone Weight ez
//题意：给定一个整数数组 stones，其中 stones[i] 表示第 i 个石头的重量。
//我们正在玩一个游戏。在每一轮中，我们选择最重的两个石头并将它们粉碎在一起。
//假设最重的两个石头的重量为 x 和 y，其中 x <= y。这次粉碎的结果是：
//如果 x == y，则两个石头都被摧毁。
//如果 x != y，则重量为 x 的石头被摧毁，并且重量为 y 的石头的新重量为 y - x。
//在游戏结束时，最多只剩下一个石头。
//返回最后剩下的石头的重量。如果没有石头剩下，则返回 0。
//思路：PriorityQueue, 统计每个条形码的出现次数，并将其存储到字典中。
//使用优先队列（最大堆）来按照条形码的出现次数进行排序。
//从出现次数最多的条形码开始，依次将其放入结果数组的奇数索引位置，直到用完该条形码或者结果数组已经填满。
//然后再从次多的条形码开始，依次将其放入结果数组的偶数索引位置，直到用完该条形码或者结果数组已经填满。
//最后返回结果数组。
//时间复杂度: 每次取出两个石头的时间复杂度为 O(logn)，总共进行 n - 1 次操作，所以总的时间复杂度为 O(nlogn)。
//空间复杂度：O(n)
        public int LastStoneWeight(int[] stones)
        {
            var heap = new PriorityQueue<int, int>();

            foreach (var stone in stones)
                heap.Enqueue(stone, -stone);

            while (heap.Count > 1)
            {
                var newStone = heap.Dequeue() - heap.Dequeue();
                if (newStone > 0)
                    heap.Enqueue(newStone, -newStone);
            }

            return heap.Count > 0 ? heap.Dequeue() : 0;
        }
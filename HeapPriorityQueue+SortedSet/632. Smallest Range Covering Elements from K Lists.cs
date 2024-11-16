//Leetcode 632. Smallest Range Covering Elements from K Lists hard	
//题意：给定 k 个有序整数列表，找到包含每个列表中至少一个数字的最小范围。
//我们将范围[a, b] 定义为小于范围[c, d]，如果 b - a<d - c，或者当 b - a == d - c 时，a<c。
//思路：PriorityQueue, 确保了优先级队列首先检索范围最小的元组，也就是max-min最小，如果diff一样，那就找min最小的
//通过跟踪当前遇到的最小值和最大值，我们可以确定范围。优先级队列帮助我们高效地检索范围最小的元组。
//通过更新索引并重复这一过程，我们可以找到包含每个列表中至少一个数字的最小范围。
//说白了，因为是从小到大排序好的，所以每个数组最后一位开始，找到那一列的最后一位最大，然后往前移，找到当前min和max
//存入，然后继续找，直到都放入之和 找max-min最小，如果diff一样，那就找min最小的
//时间复杂度: O(k * m * log k)
//空间复杂度：O(k)       
        public int[] SmallestRange(IList<IList<int>> nums)
        {
            int[] indexes = new int[nums.Count];
            for (int i = 0; i < nums.Count; i++)
            {
                indexes[i] = nums[i].Count - 1;
            }

            PriorityQueue<(int min, int max), (int min, int max)> minHeap = new PriorityQueue<(int min, int max), (int min, int max)>(
                Comparer<(int min, int max)>
                .Create((x, y) => (x.max - x.min) == (y.max - y.min) ? x.min - y.min : (x.max - x.min) - (y.max - y.min)));


            while (true)
            {
                int max = int.MinValue, min = int.MaxValue, maxList = 0;
                for (int i = 0; i < nums.Count; i++)
                {
                    var index = indexes[i];
                    //如果索引小于0，则表示列表已穷尽，并找到最小的范围
                    if (index < 0)
                    {
                        var c = minHeap.Dequeue();
                        return new int[] { c.min, c.max };
                    }
                    min = Math.Min(min, nums[i][index]);
                    //如果当前索引处的值大于当前最大值 ( max)，则会max使用该值更新变量，并将 更新maxListIndex为当前列表索引 ( i)。
                    if (max < nums[i][index])
                    {
                        max = nums[i][index];
                        maxList = i;
                    }
                }
                minHeap.Enqueue((min, max), (min, max));
                indexes[maxList]--;
            }

            return null;
        }
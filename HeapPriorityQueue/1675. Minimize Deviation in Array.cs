//Leetcode 1675. Minimize Deviation in Array hard
//题意：给定一个由 n 个正整数组成的数组 nums。
//你可以对数组中的任意元素执行两种类型的操作任意次数：
//如果元素是偶数，则将其除以 2。
//如果元素是奇数，则将其乘以 2。
//数组的偏差是数组中任意两个元素之间的最大差值。
//返回在执行一些操作后数组可能具有的最小偏差。
//思路：PriorityQueue, 用两个PQ，分别从max和min
//由于偶数要/2,奇数*2，所以先找到最大的，所以先找奇数；
//然后在所有max中，如果偶数/2，直到找到最小值；
//时间复杂度: O(nlogn)
//空间复杂度：O(n)
        public int MinimumDeviation(int[] nums)
        {
            var maxQueue = new PriorityQueue<int, int>();
            var minQueue = new PriorityQueue<int, int>();

            foreach (var it in nums)
            {
                //先把奇数*2；
                var newValue = it % 2 != 0 ? it * 2 : it;
                maxQueue.Enqueue(newValue, - newValue);
                minQueue.Enqueue(newValue, newValue);
            }

            var max = maxQueue.Dequeue();
            var result = max - minQueue.Peek();
            while (max % 2 == 0)
            {
                //因为偶数要/2，所以如果max为偶数，需要/2；
                max /= 2;
                maxQueue.Enqueue(max, - max);
                minQueue.Enqueue(max, max);
                max = maxQueue.Dequeue();
                result = Math.Min(result, max - minQueue.Peek());
            }

            return result;
        }
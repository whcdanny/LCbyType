//Leetcode 2593. Find Score of an Array After Marking All Elements med
//题意：给定一个由正整数组成的数组 nums。从 score = 0 开始，依次应用以下算法：
//选择数组中未标记的最小整数。如果有多个整数值相同，选择索引最小的。
//将选择的整数值加到 score 中。
//标记选择的元素及其相邻的两个元素（如果存在）。
//重复步骤 1-3，直到所有数组元素都被标记。
//最终返回应用上述算法后得到的 score。
//思路：PriorityQueue    
//优先队列 SortedSet,将nums的数字和位置放入里面 按照值升序排序，如果值相同，按照索引升序排序
//将所有元素及其相邻的两个元素（如果存在）插入优先队列
//获取队列中值最小的元素,移除队列中的元素,将该元素及其相邻的两个元素标记为已访问
//时间复杂度：O(n log n)
//空间复杂度：O(n)
        public long FindScore(int[] nums)
        {
            //int n = nums.Length;
            //long result = 0;

            //PriorityQueue<(int, int), (int, int)> pq = new PriorityQueue<(int, int), (int, int)>()(Comparer<(int v, int i)>.Create((x, y)
            //    => x.v == y.v ? x.i.CompareTo(y.i) : x.v.CompareTo(y.v)));

            //for (int i = 0; i < n; i++)
            //{
            //    pq.Enqueue((nums[i], i), (nums[i], i));
            //}

            //HashSet<int> hashSet = new HashSet<int>();

            //while (pq.Count > 0)
            //{
            //    (int v, int i) current = pq.Dequeue();

            //    if (!hashSet.Contains(current.i))
            //    {
            //        result += current.v;

            //        hashSet.Add(current.i + 1);
            //        hashSet.Add(current.i - 1);
            //    }
            //}

            //return result;
            // 使用 SortedSet 来实现优先队列，元组 (值, 索引) 作为元素
            SortedSet<Tuple<int, int>> pq = new SortedSet<Tuple<int, int>>(Comparer<Tuple<int, int>>.Create((a, b) => {
                if (a.Item1 != b.Item1) return a.Item1.CompareTo(b.Item1); // 按照值升序排序
                return a.Item2.CompareTo(b.Item2); // 如果值相同，按照索引升序排序
            }));

            int score = 0;
            int n = nums.Length;

            // 将所有元素及其相邻的两个元素（如果存在）插入优先队列
            for (int i = 0; i < n; i++)
            {
                pq.Add(new Tuple<int, int>(nums[i], i));
            }

            // 标记数组元素
            bool[] marked = new bool[n];

            while (pq.Count > 0)
            {
                var tuple = pq.Min; // 获取队列中值最小的元素
                pq.Remove(tuple); // 移除队列中的元素

                int value = tuple.Item1;
                int index = tuple.Item2;

                // 如果该元素已被标记，则跳过
                if (marked[index]) continue;

                // 将该元素及其相邻的两个元素标记为已访问
                marked[index] = true;
                if (index > 0) marked[index - 1] = true;
                if (index < n - 1) marked[index + 1] = true;

                // 将该元素的值加到 score 中
                score += value;
            }

            return score;
        }
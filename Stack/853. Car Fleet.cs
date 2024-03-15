//Leetcode 853. Car Fleet med
//题意：有一条单车道的道路上有n辆汽车，它们都要去同一个目的地，目的地距离起点target英里远。
//给定两个整数数组position和speed，长度都为n，其中position[i] 表示第i辆车的位置，speed[i] 表示第i辆车的速度（以小时为单位）。
//汽车在行驶过程中不能超车，但可以追上前面的车并与其以相同的速度并排行驶。
//速度较快的车将减速以与速度较慢的车的速度相匹配。忽略这两辆车之间的距离（即假设它们的位置相同）。
//车队是一组以相同速度相同位置行驶的汽车，注意单个汽车也是车队的一部分。
//如果一辆汽车恰好在目的地点追上了一个车队，它仍然被视为一个车队。
//要求计算有多少个车队最终到达目的地。
//思路：Stack, 栈来存可以距离目标还剩多少步到达的车队；
//数组进行排序
//对于每个位置/速度对，获取距离目标还剩多少步
//如果步数大于现有步数，则说明我在你之前位置需要更少的步到达终点，所以我比你快，那么我就会在终点前追上你，变成一个组，所以要stackpop并存入较慢的步数；     
//返回堆栈的大小
//时间复杂度：O(n) 
//空间复杂度：O(n) 
        public int CarFleet(int target, int[] position, int[] speed)
        {
            var stack = new Stack<double>();
            Array.Sort(position, speed);
            for (int i = 0; i < position.Length; i++)
            {
                var current = (double)(target - position[i]) / speed[i];
                while (stack.Any() && current >= stack.Peek())
                {
                    stack.Pop();
                }
                stack.Push(current);
            }
            return stack.Count();
        }
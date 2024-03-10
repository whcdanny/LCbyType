//Leetcode 1776. Car Fleet II med
//题意：有 n 辆车沿着同一方向在一条单车道上行驶，每辆车的位置和速度已知。当两辆车在同一位置相遇时，它们会合并成一个车队。
//要求计算每辆车与下一辆车相撞的时间，如果不会与下一辆车相撞，则返回 -1。
//思路：Stack, 从后往前遍历，对于每辆车，我们需要找到下一辆车与它的碰撞时间。
//使用单调递减栈存储车辆的位置，栈顶为当前车辆的下一辆车。如果栈顶车辆速度大于等于当前车辆，则无法追上当前车辆，时间为 -1。
//如果栈顶车辆速度小于当前车辆，则根据相对速度计算碰撞时间，更新栈顶车辆位置，然后再次检查下一辆车是否能追上当前车辆。
//将每辆车的碰撞时间记录在数组中，返回结果。
//注：如果能追上下一辆，但是如果下一辆提前撞上了，那么也就以当前情况撞不上
//时间复杂度：O(n)，其中 n 是车辆数量，遍历一次数组并使用单调栈计算每辆车的碰撞时间。
//空间复杂度：O(n)，需要额外的空间存储前缀和数组和单调栈
        public double[] GetCollisionTimes(int[][] cars)
        {
            int n = cars.Length;
            double[] result = new double[n];
            Stack<int> stack = new Stack<int>();

            for (int i = n - 1; i >= 0; i--)
            {
                result[i] = -1.0;
                int position = cars[i][0], speed = cars[i][1];
                while (stack.Count > 0)
                {
                    int next = stack.Peek(), nextPosition = cars[next][0], nextSpeed = cars[next][1];
                    double time = (double)(nextPosition - position) / (speed - nextSpeed);
                    //如果下一辆车速度快，就不会追上，
                    //如果能追上下一辆，但是如果下一辆提前撞上了，那么也就以当前情况撞不上
                    if (nextSpeed >= speed || (result[next] >= 0 && time >= result[next]))
                    {
                        stack.Pop();
                    }
                    else
                    {
                        result[i] = time;
                        break;
                    }
                }
                stack.Push(i);
            }

            return result;
        }
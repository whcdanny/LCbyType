//Leetcode 2751. Robot Collisions hard
//题意：有n个1索引的机器人，每个机器人都有一个在一条线上的位置、健康值和移动方向。
//给定0索引的整数数组positions、healths和一个字符串directions（directions[i] 为'L'表示向左，'R'表示向右）。positions数组中的所有整数都是唯一的。
//所有机器人同时以相同的速度和给定方向在线上移动。如果两个机器人在移动过程中相遇，它们就会发生碰撞。
//如果两个机器人碰撞，健康值较低的机器人将从线上移除，另一个机器人的健康值减少1。幸存的机器人将继续以原来的方向移动。如果两个机器人的健康值相同，它们都将从线上移除。
//你的任务是确定幸存碰撞的机器人的健康值，按照给定的顺序返回它们的健康值，即机器人1（如果幸存）、机器人2（如果幸存）等。如果没有幸存的机器人，则返回一个空数组。
//返回一个数组，其中包含剩余机器人的健康值（按照输入中给定的顺序），在不再发生碰撞的情况下。
//注意：位置可能是未排序的。
//思路：Stack; 先将position排序，然后根据位置从头开始，然后因为我们从index最小的开始，如果是R，则存入stack
//如果遇到L，说明会跟之前一位的R撞到，那么根据要求看是否健康度一样或者大小；然后对heath的值进行修改；
//时间复杂度：O(NLogN)
//空间复杂度：O(n)，最坏情况下，栈的大小为heights数组的长度 
        public IList<int> SurvivedRobotsHealths(int[] positions, int[] healths, string directions)
        {
            int n = positions.Length;
            int[] indexLookup = new int[n];
            for (int i = 0; i < n; i++)
                indexLookup[i] = i;

            Array.Sort(indexLookup, (x, y) => positions[x] - positions[y]);
            Stack<int> roboStack = new Stack<int>();

            foreach (int robo in indexLookup)
            {
                if (directions[robo] == 'R')
                {
                    roboStack.Push(robo);
                    continue;
                }

                while (roboStack.Count != 0)
                {
                    int topRobo = roboStack.Peek();
                    if (healths[topRobo] == healths[robo])
                    {
                        healths[topRobo] = 0;
                        healths[robo] = 0;
                        roboStack.Pop();
                        break;
                    }

                    if (healths[topRobo] < healths[robo])
                    {
                        healths[topRobo] = 0;
                        healths[robo] -= 1;
                        roboStack.Pop();
                    }
                    else
                    {
                        healths[robo] = 0;
                        healths[topRobo] -= 1;
                        break;
                    }
                }
            }

            List<int> result = new List<int>();
            foreach (int health in healths)
                if (health != 0)
                    result.Add(health);

            return result;
        }
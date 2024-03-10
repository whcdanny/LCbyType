//Leetcode 2211. Count Collisions on a Road med
//题意：题目描述了一条无限长的道路上有多辆汽车，汽车从左到右依次编号为 0 到 n - 1，并且每辆汽车都位于不同的位置上。
//给定一个长度为 n 的字符串 directions，其中 directions[i] 可以是 'L'、'R' 或 'S'，分别表示第 i 辆汽车向左、向右移动或者停留在当前位置。每辆移动的汽车速度相同。
//碰撞的计算规则如下：
//当两辆相向而行的汽车相撞时，碰撞次数增加 2。
//当一辆移动的汽车与一辆静止的汽车相撞时，碰撞次数增加 1。
//发生碰撞后，参与碰撞的汽车将停留在碰撞点处，不再移动。
//思路：Stack, 用于存入每一位的状态，
//一开始stack为空，如果不是L那么就加入到stack，因第一位是L，反正前面没有车就无所谓了；
//如果不为空，如果是L，那么就看stack最上面的是什么
//如果是R，那么就是+2，然后再看之前的只要不是S，那么就会发生碰撞所以+1，并弹出，然后把此时位置的状态从L改成S存入stack，因为碰撞完就不动了，
//如果是S，那么就是+1
//如果是R，就直接加入stack
//如果是S，那么只要stack最上面不是S，就+1，并弹出，因为stack只能右S和R
//注：stack只有可能右S和R
//时间复杂度：O(n)
//空间复杂度：O(1)
        public int CountCollisions(string directions)
        {
            int count = 0;
            Stack<char> stack = new Stack<char>();
            for (int i = 0; i < directions.Length; i++)
            {
                char c = directions[i];
                if (stack.Count == 0)
                {
                    if (c != 'L')
                        stack.Push(c);
                    continue;
                }
                if (c == 'L')
                {
                    char p = stack.Peek();
                    if (p == 'R')
                    {
                        count += 2;
                        stack.Pop();
                        while (stack.Count > 0 && stack.Peek() != 'S')
                        {
                            count += 1;
                            stack.Pop();
                        }
                        stack.Push('S');
                        continue;
                    }
                    if (p == 'S')
                    {
                        count += 1;
                        continue;
                    }
                }
                else if (c == 'R')
                {
                    stack.Push(c);
                }
                else
                {
                    while (stack.Count > 0 && stack.Peek() != 'S')
                    {
                        count += 1;
                        stack.Pop();
                    }
                    stack.Push(c);
                }

            }

            return count;
        }

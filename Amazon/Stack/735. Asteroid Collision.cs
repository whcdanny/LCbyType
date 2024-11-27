//Leetcode 735. Asteroid Collision med
//题意：给定一个数组表示不同大小的行星，正数表示向右移动，负数表示向左移动。当两颗行星相遇时，大小较小的行星会爆炸并消失。
//如果两颗行星相同大小，两颗行星都会爆炸。返回最终剩下的行星数组。
//思路：可以使用栈来解决这个问题。
//遍历行星数组，当遇到向右移动的行星时，将其压入栈中；
//当遇到向左移动的行星时，与栈顶的行星进行比较：
//如果栈顶的行星也是向左移动，直接将当前行星入栈；
//如果栈顶的行星是向右移动，需要比较它们的大小：
//如果当前行星的绝对值大于栈顶行星的大小，就需要持续比较，直到当前行星的大小小于等于栈顶行星的大小，或者栈为空；
//如果栈为空或者栈顶行星的大小小于当前行星的大小，将当前行星入栈
//时间复杂度：O(n)
//空间复杂度：O(n) 
        public int[] AsteroidCollision(int[] asteroids)
        {
            Stack<int> stack = new Stack<int>();

            foreach (int asteroid in asteroids)
            {
                if (asteroid > 0 || stack.Count == 0)
                {
                    stack.Push(asteroid);
                }
                else
                {
                    while (stack.Count > 0 && stack.Peek() > 0 && stack.Peek() < Math.Abs(asteroid))
                    {
                        stack.Pop();
                    }
                    if (stack.Count == 0 || stack.Peek() < 0)
                    {
                        stack.Push(asteroid);
                    }
                    else if (stack.Peek() == Math.Abs(asteroid))
                    {
                        stack.Pop();
                    }
                }
            }

            int[] result = new int[stack.Count];
            for (int i = stack.Count - 1; i >= 0; i--)
            {
                result[i] = stack.Pop();
            }

            return result;
        }
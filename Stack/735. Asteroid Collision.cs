//735. Asteroid Collision med
//是一个关于行星碰撞的问题,正数表示向右行进，负数表示向左行进,较小的行星会被较大的行星消灭
//思路：如果读取到+数，存入stack，如果-数证明要相撞，如果stack里大于相撞的，读取下一个数，如果小于stack里这个pop，然后继续跟stack里比较，如果等于stack里和当前的都消失；
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
//Leetcode 2682. Find the Losers of the Circular Game ez
//题意：描述了一个游戏的规则：有 n 个朋友围成一个圆圈，依次编号为 1 到 n。游戏的规则如下：
//第一个朋友收到球。
//接下来，第一个朋友将球传给顺时针方向上距离他 k 步的朋友。
//然后，接到球的朋友应将球传给距离他 2k 步的朋友。
//接下来，接到球的朋友应将球传给距离他 3k 步的朋友，依此类推。
//游戏结束的条件是某个朋友第二次接到球。
//我们需要找出游戏中输掉的朋友，即整个游戏中没有接到球的朋友。
//思路：hashtable, 用hashset存访问过的人
//然后找到没有访问的，添加到list；
//时间复杂度：O(n)
//空间复杂度：O(n)
        public int[] CircularGameLosers(int n, int k)
        {
            int current = 0;
            HashSet<int> visited = new HashSet<int>() { current };
            int turn = 1;
            while (true)
            {
                current = (current + k * turn) % n;
                if (visited.Contains(current))
                    break;
                visited.Add(current);
                turn++;
            }
            int[] losers = new int[n - visited.Count];
            int index = 0;
            for (int i = 0; i < n; i++)
                if (!visited.Contains(i))
                {
                    losers[index] = i + 1;
                    index++;
                }
            return losers;
        }
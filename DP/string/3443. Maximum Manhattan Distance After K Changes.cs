//Leetcode 3443. Maximum Manhattan Distance After K Changes med
//题意：题目要求我们在给定的字符串 s 中，最多可以将其中的 k 个字符更改为任意方向，
//以使在执行这些移动后，从原点（0,0）出发所能达到的最大曼哈顿距离最大化。
//曼哈顿距离定义为两个点 (xi, yi) 和 (xj, yj) 之间的距离为 |xi - xj| + |yi - yj|。
//思路：方向组合定义：定义了四个方向组合 {'N','E'}, {'N','W'}, {'S','E'}, {'S','W'}，每组包含两个正交方向（例如 N 和 E 可以同时增加 y 和 x）。
//遍历每组方向：对每组方向，初始化当前累计值 curr 和剩余修改次数 t。
//字符处理逻辑：
//如果当前字符属于当前方向组合（如 N 或 E），可以尝试改变方向，也就是说我们将现在的方向转到相反的方向
//也就是如果是如果是北，东，那么我们就可以转换成南，西
//如果当前字符不属于当前方向组合，直接增加 curr，表示我们希望在当前方向一直延申
//时间复杂度：O(n)
//空间复杂度：O(1)
        public int MaxDistance(string s, int k)
        {
            int ans = 0;
            // 定义四个方向组合
            char[][] dir = new char[][]
            {
                new char[] {'N', 'E'},
                new char[] {'N', 'W'},
                new char[] {'S', 'E'},
                new char[] {'S', 'W'}
            };

            // 遍历每组方向组合
            foreach (char[] d in dir)
            {
                // 初始化当前距离 curr，修改剩余次数 t（初始为 k）
                int curr = 0, t = k;
                for (int i = 0; i < s.Length; i++)
                {
                    char c = s[i];
                    // 如果当前字符等于 d[0] 或 d[1]
                    if (c == d[0] || c == d[1])
                    {
                        if (t > 0)
                        {
                            t--;
                            curr++;
                        }
                        else
                        {
                            curr--;
                        }
                    }
                    else
                    {
                        curr++;
                    }
                    ans = Math.Max(ans, curr);
                }
            }

            return ans;
        }
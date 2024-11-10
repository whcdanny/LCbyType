//Leetcode 3160. Find the Number of Distinct Colors Among the Balls med
//题目：你有一个整数 limit 和一个大小为 n x 2 的二维数组 queries。一共有 limit + 1 个球，每个球的标签在 [0, limit] 范围内，
//最初这些球没有颜色。对于 queries 中的每一个查询 [x, y]：
//将标签为 x 的球标记为颜色 y。
//每次标记后，找出所有球的不同颜色数量。
//返回一个数组 result，其中 result[i] 表示在第 i 次查询后不同颜色的数量。
//注意：不考虑没有颜色的情况，即只有被标记的颜色才算在内。
//思路: Dictionary 两个 colorMap存颜色和其相对的个数，ballMap对于当前球位置和颜色
//如果当前添加的球没在ballMap，添加到ballMap，
//如果添加的球在ballMap，那就看颜色，
//如果添加颜色等于当前球位置颜色，输出colorMap总共个数
//如果添加颜色不等于当前球位置颜色，那么更新颜色，colorMap是否有这个颜色，有的话这个颜色总个数-1，如果count=0，那么就移除
//最后无论怎样要检查颜色是否在colorMap；更新colorMap 然后输出colorMap总共个数
//时间复杂度：O(n)
//空间复杂度：O(n)
        public int[] QueryResults(int limit, int[][] queries)
        {
            Dictionary<int, int> colorMap = new Dictionary<int, int>();
            Dictionary<int, int> ballMap = new Dictionary<int, int>();
            int[] result = new int[queries.Length];

            for (int i = 0; i < queries.Length; i++)
            {
                int ball = queries[i][0];
                int color = queries[i][1];

                if (ballMap.TryGetValue(ball, out var previousColor))
                {
                    if (previousColor != color)
                    {
                        colorMap[previousColor] -= 1;

                        if (colorMap[previousColor] == 0)
                        {
                            colorMap.Remove(previousColor);
                        }
                    }
                    else
                    {
                        result[i] = colorMap.Count;
                        continue;
                    }
                }

                ballMap[ball] = color;

                if (!colorMap.TryAdd(color, 1))
                {
                    colorMap[color] += 1;
                }

                result[i] = colorMap.Count;
            }

            return result;
        }
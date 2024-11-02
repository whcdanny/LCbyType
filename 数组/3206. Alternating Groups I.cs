//Leetcode 3206. Alternating Groups I ez
//题目：我们有一个由红色和蓝色瓷砖组成的圆形序列，其中：
//colors[i] == 0 表示第 i 个瓷砖是红色。
//colors[i] == 1 表示第 i 个瓷砖是蓝色。
//题目要求找出**“交替组”**的数量，定义如下：
//在连续的三个瓷砖中，满足左中右颜色交替，即中间颜色不同于两边颜色的组称为“交替组”。
//由于 colors 是一个圆形序列，序列的第一个和最后一个元素视为相邻。
//思路: 找到i，前一项和后一项，由于是循环，那么i-1要被改成(i - 1 + n) % n，i+1不用改
//时间复杂度：O(n)
//空间复杂度：O(1)
        public int NumberOfAlternatingGroups(int[] colors)
        {
            int n = colors.Length;
            int count = 0;

            for (int i = 0; i < n; i++)
            {
                int prev = colors[(i - 1 + n) % n]; // 前一个瓷砖的颜色
                int curr = colors[i];               // 当前瓷砖的颜色
                int next = colors[(i + 1) % n];     // 下一个瓷砖的颜色

                // 判断是否形成交替组
                if (prev != curr && curr != next && prev == next)
                {
                    count++;
                }
            }

            return count;
        }
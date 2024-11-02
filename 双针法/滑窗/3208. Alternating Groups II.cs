//Leetcode 3208. Alternating Groups II med
//题目：我们有一个红色和蓝色瓷砖的圆形序列，由数组 colors 表示，其中：
//colors[i] == 0 表示第 i 个瓷砖是红色。
//colors[i] == 1 表示第 i 个瓷砖是蓝色。
//题目要求找出**“交替组”**的数量。一个交替组定义为在圆形序列中每 k 个连续的瓷砖必须交替排列，即每个瓷砖（除首尾）和其相邻瓷砖颜色不同。
//思路: 滑框 left和right，用count来统计相邻是相同数字的个数，
//然后先把滑框确定 找出0 到 k-1里 的count个数
//然后left和right同时移动，保持窗口大小，
//然后如果left遇到相邻相同数字-1，right遇到相邻相同数字+1；
//时间复杂度：O(n * k)，其中 n 是数组长度，k 是交替组长度
//空间复杂度：O(1)
        public int NumberOfAlternatingGroups(int[] colors, int k)
        {

            int n = colors.Length;
            int left = 0;
            int right = 0;
            int count = 0; // count of adjacent match tile.
            for (; right < k - 1; right++)
            {
                if (colors[right] == colors[right + 1]) 
                    count++;
            }

            int result = 0;
            while (left < n)
            {
                if (count == 0) 
                    result++;

                if (colors[left] == colors[(left + 1) % n]) 
                    count--;
                left++;

                if (colors[right % n] == colors[(right + 1) % n]) 
                    count++;
                right++;
            }

            return result;
        }
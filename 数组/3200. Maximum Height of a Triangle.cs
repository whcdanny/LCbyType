//Leetcode 3200. Maximum Height of a Triangle ez
//题目：在这个问题中，我们有两种颜色的球：红色和蓝色，分别有 red 和 blue 个。
//我们需要将这些球按照三角形的结构进行排列，三角形的第 1 行放 1 个球，第 2 行放 2 个球，第 3 行放 3 个球，以此类推。
//并且，三角形的每一行必须由同一种颜色的球组成，同时相邻的行必须是不同颜色。
//目标是找到三角形的 最大高度，即最多能构建多少行。
//思路: 贪心策略：
//分别以red开始和blue开始，
//然后找出最大值，
//时间复杂度：O(Sqrt(N))
//空间复杂度：O(1)
        public int MaxHeightOfTriangle(int red, int blue)
        {
            return Math.Max(MaxHeight(red, blue), MaxHeight(blue, red));
        }
        public int MaxHeight(int color1, int color2)
        {
            int count = 1;
            while (true)
            {
                if (color1 - count >= 0)
                {
                    color1 -= count;
                    count += 1;
                }
                else 
                    break;
                if (color2 - count >= 0)
                {
                    color2 -= count;
                    count += 1;
                }
                else 
                    break;
            }
            return count - 1;
        }
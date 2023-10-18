//Leetcode 11. Container With Most Water med
//题意：要求是在一个非负整数数组中找到两个线段，它们与 x 轴共同构成一个容器，使容器能容纳的水最多。给定一个非负整数数组 height，每个元素表示一个竖直线的高度，求在这些线段中选择两条线，使得它们与 x 轴构成的容器能容纳的水最多。
//思路：双指针方法来解决这个问题。使用两个指针 left 和 right 分别指向数组的首尾。计算当前两条线段之间的容器容积，即 min(height[left], height[right]) * (right - left)。
//时间复杂度:   n 是数组的长度, O(n)
//空间复杂度： O(1)
        public int MaxArea(int[] height)
        {
            int left = 0;
            int right = height.Length-1;
            int res = 0;
            while (left < right)
            {
                int area = Math.Min(height[left], height[right]) * (right - left);
                res = Math.Max(area, res);

                if (height[left] < height[right])
                {
                    left++;
                }
                else
                {
                    right--;
                }
            }
            return res;
        }
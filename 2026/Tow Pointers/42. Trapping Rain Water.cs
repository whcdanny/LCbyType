//Leetcode 42. Trapping Rain Water hard
//题意：给一个非负的int[],每一个数相当于一共柱子，然后算如果小于这些柱子之间能储水量，
//思路：双针法 从前往后找出height[right] >= height[left]的然后找到left和right，然后找出这个区间的值；
//然后如何还有没完成的部分，再从right往左扫；
//时间复杂度: O(n)
//空间复杂度：O(1)
        public int Trap(int[] height)
        {
            int res = 0;
            int left = 0;
            int right = left + 1;
            while (left < height.Length && right < height.Length)
            {
                if (height[right] >= height[left])
                {
                    int minValue = Math.Min(height[left], height[right]);
                    int dis = right - left - 1;
                    res += minValue * dis;
                    for (int i = left + 1; i < right; i++)
                    {
                        res -= height[i];
                    }
                    left = right;
                }
                right++;
            }
            int temp = left;
            right = height.Length - 1;
            left = right - 1;
            while (left >= temp && right >= temp)
            {
                if (height[right] <= height[left])
                {
                    int minValue = Math.Min(height[left], height[right]);
                    int dis = right - left - 1;
                    res += minValue * dis;
                    for (int i = left + 1; i < right; i++)
                    {
                        res -= height[i];
                    }
                    right = left;
                }
                left--;
            }
            return res;
        }
        //思路：双指针优化
        //维护left和right分别指向两端，以及两个变量 leftMax 和 rightMax。
        //如果height[left]<height[right]，left处的存水量只取决于leftMax(因为右边已经有一个更高的柱子顶着了,短板一定在左边)
        //反之，则处理 right 端。
        //时间复杂度: O(n)
        //空间复杂度：O(1)
        public int Trap1(int[] height)
        {
            if (height == null || height.Length == 0) return 0;

            int left = 0, right = height.Length - 1;
            int leftMax = 0, rightMax = 0;
            int res = 0;

            while (left < right)
            {
                if (height[left] < height[right])
                {
                    // 左侧较矮，水的高度取决于左侧最大值
                    if (height[left] >= leftMax)
                    {
                        leftMax = height[left];
                    }
                    else
                    {
                        res += leftMax - height[left];
                    }
                    left++;
                }
                else
                {
                    // 右侧较矮或相等，水的高度取决于右侧最大值
                    if (height[right] >= rightMax)
                    {
                        rightMax = height[right];
                    }
                    else
                    {
                        res += rightMax - height[right];
                    }
                    right--;
                }
            }
            return res;
        }
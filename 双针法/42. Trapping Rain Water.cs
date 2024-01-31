//Leetcode 42. Trapping Rain Water hard 
//题意：给定一个非负整数数组 height，表示每个位置的高度，宽度为1。问在雨水下雨后，这个地形能够存储多少雨水
//思路：双指针，左右指针往中间移动，计算每个位置能够存储的雨水量。
//初始化左右指针 left 和 right 分别指向数组的两端。
//初始化左侧最大高度 leftMax 和右侧最大高度 rightMax 分别为 0。
//在每一步中，比较 height[left] 和 height[right]，选择较小的高度进行处理。
//如果 height[left] 小于 height[right]，则判断当前高度是否大于 leftMax，如果是，更新 leftMax；否则，计算当前位置的雨水量并累加到结果中。
//反之，如果 height[right] 小于等于 height[left]，同样处理。
//时间复杂度：O(n)
//空间复杂度：O(1)
        public int Trap(int[] height)
        {
            int left = 0, right = height.Length - 1;
            int leftMax = 0, rightMax = 0;
            int result = 0;

            while (left < right)
            {
                if (height[left] < height[right])
                {
                    // Process left side
                    if (height[left] >= leftMax)
                    {
                        leftMax = height[left];
                    }
                    else
                    {
                        result += leftMax - height[left];
                    }
                    left++;
                }
                else
                {
                    // Process right side
                    if (height[right] >= rightMax)
                    {
                        rightMax = height[right];
                    }
                    else
                    {
                        result += rightMax - height[right];
                    }
                    right--;
                }
            }

            return result;
        }
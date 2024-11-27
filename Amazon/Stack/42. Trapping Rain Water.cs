//Leetcode 42. Trapping Rain Water hard 
//题意：给定一个非负整数数组 height，表示每个位置的高度，宽度为1。问在雨水下雨后，这个地形能够存储多少雨水
//思路：先用stack找出从右往左比前一个大或等于，maxRightHeight.Peek() <= height[i]作为标杆
//然后从头开始，maxLeftHeight找出左侧最高，然后根据每个位置，跟
//totWater += Math.Max(0, Math.Min(maxLeftHeight, maxRightHeight.Peek()) - height[i]);
//maxLeftHeight = Math.Max(maxLeftHeight, height[i]);
//时间复杂度：O(n)
//空间复杂度：O(1)
        public int Trap(int[] height)
        {
            var maxRightHeight = new Stack<int>(); ;
            for (int i = height.Length - 1; i >= 0; i--)
                if (!maxRightHeight.Any() || maxRightHeight.Peek() <= height[i])
                    maxRightHeight.Push(height[i]);
            var totWater = 0;
            var maxLeftHeight = 0;
            for (int i = 0; i < height.Length - 1; i++)
            {
                if (height[i] == maxRightHeight.Peek())
                    maxRightHeight.Pop();
                totWater += Math.Max(0, Math.Min(maxLeftHeight, maxRightHeight.Peek()) - height[i]);
                maxLeftHeight = Math.Max(maxLeftHeight, height[i]);
            }
            return totWater;
        }
//Leetcode 11. Container With Most Water med
//题意：给一个高度的int[],然后找出找出能储水的最大面积
//思路：双针法，从两头开始算面积，然后Math.Min(height[left], height[right])*对应len
//然后保留height[left]和height[right]中大的值，移动最小值left++ or right--;
//时间复杂度:  O(n)
//空间复杂度： O(1)
        public int MaxArea(int[] height)
        {
            int len = height.Length-1;
            int res = 0;
            int left = 0;
            int right = len;
            while (left < right)
            {
                int min = Math.Min(height[left], height[right]);
                res = Math.Max(res, min * len);
                if (height[left] <= height[right])
                    left++;
                else
                    right--;
                len--;
            }
            return res;
        }
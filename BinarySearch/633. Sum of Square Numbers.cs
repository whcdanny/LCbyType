//Leetcode 633. Sum of Square Numbers med
//题意：给定一个非负整数 c，判断是否存在两个整数 a 和 b，使得 a^2 + b^2 = c。
//思路：二分搜索：在区间 [0, sqrt(c)] 上使用二分查找，寻找一个数 a，使得 a^2 + b^2 = c。在二分查找的过程中，不断调整区间的边界，以找到解或确定解不存在。        
//时间复杂度:  O(sqrt(c) * log c)，其中 sqrt(c) 是二分查找的区间范围，log c 是二分查找的时间复杂度。
//空间复杂度：O(1)
        public bool JudgeSquareSum(int c)
        {
            for (long a = 0; a * a <= c; a++)
            {
                long bSquared = c - a * a;

                if (BinarySearch(0, bSquared, bSquared))
                {
                    return true;
                }
            }

            return false;
        }

        private bool BinarySearch(long left, long right, long target)
        {
            while (left <= right)
            {
                long mid = left + (right - left) / 2;

                if (mid * mid == target)
                {
                    return true;
                }
                else if (mid * mid < target)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }

            return false;
        }
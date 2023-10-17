//Leetcode 69. Sqrt(x) ez
//题意：计算一个非负整数的平方根
//思路：二分法: 我们可以将问题转化为在有序整数范围 [0, x] 中查找满足 num * num <= x 的最大整数。
//时间复杂度:  x 是给定的非负整数, O(logx)
//空间复杂度： O(1)
        public int MySqrt(int x)
        {
            if (x == 0)
                return 0;

            int left = 1;
            int right = x;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;

                if (mid == x / mid)
                    return mid;
                else if (mid > x / mid)
                    right = mid - 1;
                else
                    left = mid + 1;
            }

            return right;
        }
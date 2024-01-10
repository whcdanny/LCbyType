//Leetcode 367. Valid Perfect Square ez
//题意：判断给定的正整数是否是完全平方数。完全平方数是指一个整数是另一个整数的平方，例如 1、4、9、16 等。
//思路：初始化搜索范围为 [1, num]。
//在每一步中，通过计算中间值 mid 的平方来判断是否与目标值 num 相等。
//根据比较结果，缩小搜索范围为左半部分或右半部分。
//重复步骤 2 和步骤 3，直到找到目标数字。
//时间复杂度：O(log num)
//空间复杂度：O(1)
        public bool IsPerfectSquare(int num)
        {
            if (num < 2)
            {
                return true; // 0和1都是完全平方数
            }

            long left = 1;
            long right = num;

            while (left <= right)
            {
                long mid = left + (right - left) / 2;
                long square = mid * mid;

                if (square == num)
                {
                    return true;
                }
                else if (square < num)
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
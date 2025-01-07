//Leetcode 3370. Smallest Number With All Set Bits ez
//题意：给定一个正整数 n，需要找到一个大于或等于 n 的最小数字 x，
//使得 x 的二进制表示只包含 1 （即全为设定位，形如 111...111）。
//思路：满足条件的数字形式：
//满足条件的数字 x 的二进制形式是 111...111，即全为 1 的数字。
//这些数字的形式可以表示为 2^k −1（例如：1=2^1-1，3=2^2-1，7=2^3-1，15=2^4-1）。
//确定最小的 x：x 是大于或等于 n 的最小满足条件的数字。
//找到一个 k，使得 2^k −1≥n。
//时间复杂度:  O(logn)
//空间复杂度： O(1)
        public int SmallestNumber(int n)
        {
            //暴力搜索
            int k = 1;
            while (true)
            {
                int candidate = (1 << k) - 1; // 计算 2^k - 1
                if (candidate >= n)
                    return candidate;
                k++;
            }
            //位操作
            int x = n;
            while ((x & (x + 1)) != 0) // 检查是否全为 1
            {
                x |= (x >> 1); // 右移并或操作，扩展 1
            }
            return x;
        }
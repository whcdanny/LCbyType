//Leetcode 326. Power of Three ez
//题目：给定一个整数n，true如果它是三的幂，则返回 。否则，返回false。
//n如果存在一个整数使得 ，则整数是三的x幂。n == 3x
//思路: 递归：看说白了首先n <= 0 || n % 3 != 0全错
//然后在可以被3整除的情况下，继续检查
//时间复杂度：O(n)
//空间复杂度：O(1)
        public bool IsPowerOfThree(int n)
        {
            if (n == 1)
                return true;
            if (n <= 0 || n % 3 != 0)
                return false;
            return IsPowerOfThree(n / 3);
        }
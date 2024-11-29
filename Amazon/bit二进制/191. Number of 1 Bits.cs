//Leetcode 191. Number of 1 Bits ez
//题意：给定一个正整数 n，编写一个函数返回其二进制表示中 1 的个数，也称为其 汉明重量。
//思路：观察性质：n & (n - 1) 会将 n 的二进制表示中最右侧的 1 置为 0。
//例如：n = 6（110），n & (n - 1) = 4（100）。
//每次执行 n & (n - 1) 操作，n 中的 1 会减少一个。
//重复操作直到 n == 0，记录操作次数。
//时间复杂度:  O(n)
//空间复杂度： O(26) = O(1)
        public int HammingWeight(uint n)
        {
            int count = 0;
            while (n > 0)
            {
                n &= (n - 1); // 消去最右侧的 1
                count++;
            }
            return count;
            //int num = 0;
            //for (int i = 0; i < 32; i++)
            //{
            //    if ((n & 1) == 1)
            //        num++;
            //    n = n >> 1;
            //}
            //return num;
        }
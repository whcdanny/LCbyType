//Leetcode 2549. Count Distinct Numbers on Board ez
//题意：给定一个初始放置在棋盘上的正整数 n。在接下来的 10^9 天里，每天都要执行以下过程：
//对于棋盘上的每个数字 x，找到所有满足 1 <= i <= n 且 x % i == 1 的数字 i。
//然后，将这些数字放置在棋盘上。
//返回在经过 10^9 天后棋盘上存在的不同整数的数量。
//思路：hashtable, 无需过多考虑，我注意到可以接受此条件的最后一个数字x % i = 1将适合结果
//有两个主要例外，即数字 1 和 2，所以我确实使用 if 语句来实现；如果允许的话，我不知道，但从我的角度来看，它只需较少的计算就可以正常工作
//时间复杂度：O(n) 
//空间复杂度：O(1)
        public int DistinctIntegers(int n)
        {
            if (n == 1)
                return n;
            else if (n == 2)
                return 1;

            int i = n - 1;
            while (i > 0)
            {
                if (n % i == 1)
                    break;
                i--;
            }

            return i;
        }
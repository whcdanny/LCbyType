//Leetcode 3233. Find the Count of Numbers Which Are Not Special med
//题目：给定两个正整数 l 和 r，对于任何整数 x，x 的所有正因数（不包括 x 本身）被称为 x 的“适当因数”。
//如果一个数的适当因数恰好有两个，那么这个数被称为“特殊数”。例如：
//数字 4 是特殊的，因为它的适当因数是 1 和 2。
//数字 6 不是特殊的，因为它的适当因数是 1、2 和 3。
//要求我们返回[l, r] 范围内不特殊的数的个数。
//思路: 数学角度，当只有1和另一个数能整除的，那就是质数的平方，
//1，2，3，5，7，11.。。 这些数的平方 1，4，9，25，49，121。。。
//所以先将l,r开方，然后找出这个范围内的质数，然后再平方确认是否在区间内
//如何确认质数，从3开始，只要添加来的数，可以被2，3，。。。直到开发i，有一个能整除，那肯定不是
//时间复杂度：O(sqrt(r))
//空间复杂度：O(1)
        public int NonSpecialCount(int l, int r)
        {
            var res = r - l + 1;
            var limit0 = (int)Math.Sqrt(l);
            var limit1 = (int)Math.Sqrt(r);
            for (int i = limit0; i <= limit1; i++)
            {
                //质数平方才可能生成特殊数
                if (IsPrime(i))
                {
                    var square = i * i;
                    if (l <= square && square <= r)
                    {
                        res--;
                    }
                }
            }
            return res;
        }
        //用于判断给定的数 n 是否是质数。
        private bool IsPrime(int n)
        {
            if (n == 1) return false;
            if (n == 2) return true;
            if (n % 2 == 0) return false;
            for (int i = 3; i <= Math.Sqrt(n); i += 2)
            {
                if (n % i == 0) return false;
            }
            return true;
        }
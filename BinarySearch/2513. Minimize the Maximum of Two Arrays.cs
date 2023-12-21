//Leetcode 2513. Minimize the Maximum of Two Arrays med
//题意：有两个初始为空的数组 arr1 和 arr2。需要向它们中添加正整数，使得它们满足以下所有条件：
//arr1 包含 uniqueCnt1 个不可被 divisor1 整除的不同正整数。
//arr2 包含 uniqueCnt2 个不可被 divisor2 整除的不同正整数。
//两个数组中没有相同的整数。
//给定 divisor1、divisor2、uniqueCnt1 和 uniqueCnt2，返回两个数组中可能存在的最小可能最大整数。
//思路：二分搜索, 去假设个n值来猜测，满足arr1的是 n - n/divisor1, arr2=n - n/divisor2;
//注：由于有的数可以被divisor1 和 divisor2 整除，所以找出divisor1 和 divisor2 最小公倍数 lcm得出，然后找出重复部分，num - (num / d1 + num / d2 - num / lcm(d1, d2))；
//然后判断n - n/divisor1； n - n/divisor2； n - n/divisor1 + n - n/divisor2 - n - (n / divisor1 + n / divisor2 - n / lcm(divisor1, divisor2)) 是否都应该满足当前需却；
//时间复杂度:  O(uniqueCnt1 + uniqueCnt2 + log(lcm))
//空间复杂度： O(uniqueCnt1 + uniqueCnt2)
//最大公因数和最小公倍数之间的关系:https://zhidao.baidu.com/question/310011656478050484.html
        public int MinimizeSet(int divisor1, int divisor2, int uniqueCnt1, int uniqueCnt2)
        {
            int low = 1;
            int high = int.MaxValue;
            while (low < high)
            {
                int mid = low + (high - low) / 2;
                if (canDo(mid, divisor1, divisor2, uniqueCnt1, uniqueCnt2))
                    low = mid + 1;
                else
                    high = mid;
            }
            return low;
        }
        public bool canDo(long num, long d1, long d2, long c1, long c2)
        {           
            long canbestoredinarr1 = num - (num / d1);
            long canbestoredinarr2 = num - (num / d2);         
            long bothdivisiblebyd1andd2 = num - (num / d1 + num / d2 - num / lcm(d1, d2));
            if (canbestoredinarr1< c1) return true;
            if (canbestoredinarr2 < c2) return true;
            if (canbestoredinarr1+ canbestoredinarr2 - bothdivisiblebyd1andd2 < c1 + c2) return true;            
            return false;
        }
        public long lcm(long d1, long d2)
        {
            return (d1 * d2) / gcd(d1, d2);
        }
        public long gcd(long a, long b)
        {
            if (b == 0)
                return a;
            return gcd(b, a % b);
        }
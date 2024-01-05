//Leetcode 1739. Building Boxes  hard
//题意：这道题的目标是在一个长宽高均为 n 的立方体房间中摆放 n 个立方体盒子，要求满足一定规则：
//盒子可以放在房间的任何位置。
//如果盒子 x 放在盒子 y 的上方，那么盒子 y 的四个垂直侧面的每一侧都必须要么靠近另一个盒子，要么靠近墙壁。
//问题要求返回放在地板上的盒子的最小数量。
//思路：用二分法：猜测等边三角形，然后看code
//注：这里用到底层根据等边三角形；
//时间复杂度: O(log n)
//空间复杂度：O(1)
        public int MinimumBoxes(int n)
        {
            long left = 1;
            long right = 1000000000;
            while (left < right)
            {
                long mid = left + (right - left) / 2;
                if (cal_MinimumBoxes(mid) >= n)
                {
                    right = mid;
                }
                else
                {
                    left = mid + 1;
                }
            }
            return (int)left;
        }

        private long cal_MinimumBoxes(long area)
        {
            //d^2 < d*(d+1)/2<=area;     
            //d相当于变成，能构成的等腰三角形；
            long d = (long)Math.Sqrt(2 * area);
            //找到d的上限 d*(d+1)/2<=area;
            while ((1 + d) * d / 2 > area)
                d--;
            //找总共的零头，也就是最底层确定；
            long diff = area - (1 + d) * d / 2;
            long[] a = new long[d];
            //i相当于行；
            for (int i = 0; i < d; i++)
                a[i] = d - i;
            //
            for (int i = 0; i < diff; i++)
                a[i] += 1;
            long total = 0;
            long sufSum = 0;
            for(int i = (int)(d - 1); i >= 0; i--)
            {
                sufSum += a[i];
                total += sufSum;
            }
            return total;
        }
//Leetcode 1954. Minimum Garden Perimeter to Collect Enough Apples med
//题意：在一个表示为无限二维网格的花园中，每个整数坐标上都种有一个苹果树。在坐标 (i, j) 处的苹果树上有 |i| + |j| 个苹果。
//你将购买一个以(0, 0) 为中心的轴对齐正方形土地。给定一个整数 neededApples，返回一个正方形土地的最小周长，以便至少有 neededApples 个苹果在该土地的内部或周围。
//这里 |x| 的值定义为：
//x，如果 x >= 0
//-x，如果 x< 0
//思路：用二分法计算以某个边长为 side 的正方形土地的周长，并且在该土地内或周围有多少个苹果。
//注：这里估算苹果总数的时候，二分法用到了，正数和公式，和奇数和公式，并且考虑到(0，0)的问题；最后*4是因为我们这里mid是根据（0,0）的边长，而整个周长是*2（把(0,0)->(0,mid (0,-mid))），再*4(一共四个边)；
//时间复杂度: O(log n)，其中 n 是问题的规模。这是因为我们使用二分查找来寻找合适的土地边长。
//空间复杂度：O(1)，因为我们只使用了常量级别的额外空间。
        public long MinimumPerimeter(long neededApples)
        {
            long left = 0, right = 100000;                      
            // 二分查找
            while (left < right)
            {
                long mid = left + (right - left) / 2;
                long apples = CountApples(mid);

                if (apples >= neededApples)
                {
                    right = mid;
                }
                else
                {
                    left = mid + 1;
                }
            }

            // 返回最小周长
            return left * 4 * 2;

        }
        // 定义计算苹果数量的函数
        //要看做坐标(i,j);
        long CountApples(long side)
        {
            //数列总和为n*(n+1)/2，
            //对于j来说：(i,j) 上部分(i,j+1) 下部分(i,j-1);所以 按行算是side * (side + 1)/2 然后 上下各一半所以*2 所以side * (side + 1)；
            //对于i来说：(i,j) 相当于每一列上苹果数量的累积和，考虑到第一列，所以加上 1，side * (2*side + 1)/2同时乘以 2 考虑上半部分和下半部分, 所以side * (2*side + 1)。
            return 2 * side * (side + 1) * (2 * side + 1);
        }

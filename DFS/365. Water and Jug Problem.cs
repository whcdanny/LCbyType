//Leetcode 365. Water and Jug Problem med
//题意：判断是否能够通过两个水壶，其中一个容量为 x 升，另一个容量为 y 升，得到 z 升的水。可以进行以下操作：
//装满任意一个水壶。清空任意一个水壶。从一个水壶向另一个水壶倒水，直到装满或倒空。
//思路：DFS, 这是一个经典的数学问题，可以通过数学的方法来解决。具体思路如下：判断 z 是否小于等于 x 和 y 的最大公约数的倍数。
//如果满足条件，那么存在整数 a 和 b，使得 ax + by = z。
//注：GCD，Greatest Common Divisor,两个数的最大公约数就是能够同时整除它们的最大正整数
//时间复杂度: 欧几里得算法（辗转相除法）的时间复杂度为 O(log(min(x, y)))
//空间复杂度：O(log(min(x,y)))
        public bool CanMeasureWater(int jug1Capacity, int jug2Capacity, int targetCapacity)
        {
            if (jug1Capacity + jug2Capacity < targetCapacity)// 总容量小于目标值，无法得到目标值的水
                return false;
            return targetCapacity % gcd(jug1Capacity, jug2Capacity) == 0;// 检查 targetCapacity 是否为 jug1Capacity 和 jug1Capacity 的最大公约数的倍数
        }

        public int gcd(int x, int y)
        {
            if (y == 0)
                return x;
            return gcd(y, x % y);
        }
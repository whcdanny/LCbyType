//Leetcode 888. Fair Candy Swap ez
//题意：题目描述了两个人 Alice 和 Bob，各自拥有一些糖果。他们想要交换一些糖果，使得两人拥有的糖果总量相等。两人可以同时交换一个糖果，交换的规则是 Alice 给出一个糖果 x，Bob 给出一个糖果 y，交换后 Alice 和 Bob 的糖果总量应该相等。
//问题要求找到一种交换方式，使得两人的糖果总量相等。若有多种解决方案，返回其中任意一种即可。若不存在这样的交换方案，返回空数组。
//思路：二分搜索 计算差值：计算数组 A 和 B 的差值 diff，即 sum(A) - sum(B)。此时，我们的目标是找到一个糖果 x，使得 sum(A) - x + y = sum(B) - y + x，即 2 * (x - y) = diff。
//遍历 A 和 B：遍历数组 A，对于 A 中的每个糖果 x，我们需要在数组 B 中找到一个糖果 y，使得 2 * (x - y) = diff。可以通过二分查找在 B 中找到满足条件的糖果 y。
//时间复杂度: 遍历数组 A 和 B 的时间复杂度为 O(A + B)。二分查找的时间复杂度为 O(B* log(B))。
//空间复杂度：O(1)
        public int[] FairCandySwap(int[] A, int[] B)
        {
            int sumA = 0, sumB = 0;
            foreach (int a in A) sumA += a;
            foreach (int b in B) sumB += b;

            int diff = (sumA - sumB) / 2;

            Array.Sort(B);

            foreach (int a in A)
            {
                int targetB = a - diff;
                int index = Array.BinarySearch(B, targetB);
                if (index >= 0)
                {
                    return new int[] { a, B[index] };
                }
            }

            return new int[2];
        }
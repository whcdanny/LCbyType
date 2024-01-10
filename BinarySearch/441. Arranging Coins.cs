//Leetcode 441. Arranging Coins ez
//题意：给定一个整数 n，代表 n 枚硬币，排列成 k 行，其中第 i 行必须正好有 i 枚硬币。形成的总行数是多少？
//思路：二分搜索二分法的左右边界，左边界为 0，右边界为 n。
//在每次循环中，计算总行数的猜测值 mid，即(left + right) / 2。
//计算当前猜测值 mid 行所需的硬币数，即 coins = (1 + mid) * mid / 2。
//根据硬币数与目标硬币数 n 的大小关系，缩小二分法的搜索范围：
//如果 coins == n，说明猜测的总行数正好符合要求，返回 mid。
//如果 coins<n，说明当前猜测值太小，将左边界更新为 mid + 1。
//如果 coins > n，说明当前猜测值太大，将右边界更新为 mid - 1。
//时间复杂度: O(log n)，其中 n 是给定的硬币数。
//空间复杂度：O(1)
        public int ArrangeCoins(int n)
        {
            long left = 0, right = n;

            while (left <= right)
            {
                long mid = left + (right - left) / 2;
                long coins = (1 + mid) * mid / 2;

                if (coins == n)
                {
                    return (int)mid;
                }
                else if (coins < n)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }

            return (int)right;
        }

//Leetcode 887. Super Egg Drop hard
//题意：题目描述了一种超级蛋掉落的游戏。有 K 个鸡蛋，N 层楼。你可以选择一个楼层 F，然后将所有鸡蛋扔在那个楼层。如果蛋没摔碎，它会回到你手中，如果蛋摔碎了，那么就不能再使用这个蛋。
//现在要求找到最小的测试次数，即最小的 F 值，使得在最坏情况下，你能确定 F 的值，而且测试次数不会超过指定的次数 K。
//思路：二分搜索+动态规划 dp_SuperEggDrop[k][m] 表示有 k 个鸡蛋，进行了 m 次测试 在递归的过程中，使用 dp_SuperEggDrop 数组保存已经计算过的中间结果，避免重复计算，提高效率。
//在每一层楼进行二分搜索，通过调整 mid 的值来寻找最优的测试次数。通过比较左右两侧的情况，选择使得测试次数最小的一侧。
//注：对于当前状态 dp[k][m]，可以选择在某个楼层 x 进行测试。
//如果鸡蛋摔碎了，剩余的鸡蛋数变为 k-1，测试次数变为 m-1，继续在 x 以下的楼层进行测试。
//如果鸡蛋没摔碎，剩余的鸡蛋数仍为 k，测试次数变为 m-1，继续在 x 以上的楼层进行测试。
//时间复杂度: O(k⋅n⋅logn)
//空间复杂度：dp_SuperEggDrop 决定，为 O(k * n)。
        private int[,] dp_SuperEggDrop;

        public int SuperEggDrop(int k, int n)
        {
            dp_SuperEggDrop = new int[k + 1, n + 1];
            for (int i = 0; i <= k; i++)
            {
                for (int j = 0; j <= n; j++)
                {
                    dp_SuperEggDrop[i, j] = -1;
                }
            }

            return Solve(k, n);
        }

        private int Solve(int egg, int floor)
        {
            if (floor == 0 || floor == 1 || egg == 1)
            {
                return floor;
            }

            if (dp_SuperEggDrop[egg, floor] != -1)
            {
                return dp_SuperEggDrop[egg, floor];
            }

            int min = int.MaxValue;
            int start = 0, end = floor;

            while (start <= end)
            {
                int mid = start + (end - start) / 2;

                int left = Solve(egg - 1, mid - 1);
                int right = Solve(egg, floor - mid);

                int temp = 1 + Math.Max(left, right);

                min = Math.Min(min, temp);

                if (left < right)
                {
                    start = mid + 1;
                }
                else
                {
                    end = mid - 1;
                }
            }

            return dp_SuperEggDrop[egg, floor] = min;
        }
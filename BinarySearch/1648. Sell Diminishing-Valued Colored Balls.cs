//Leetcode 1648. Sell Diminishing-Valued Colored Balls med
//题意：题目描述了一个库存管理的情景，有不同颜色的球，每个颜色球的价值是该颜色球的库存数量。
//例如，如果你拥有 6 个黄色球，那么第一个黄色球的价值为 6。交易完成后，库存中只剩下 5 个黄色球，因此下一个黄色球的价值为 5（即随着向客户卖出更多球，球的价值逐渐减少）。
//给定一个整数数组 inventory，表示初始拥有的各种颜色球的数量，以及一个整数 orders，表示客户想要购买的总球数。你可以以任意顺序出售这些球。
//要求返回在卖出 orders 个颜色球后可以获得的最大总价值。由于答案可能太大，返回它对 $10^9 + 7$ 取模的结果。
//思路：用二分法：首先对库存数组 inventory 进行降序排序，以便先卖出价值较高的颜色球,
//用二分法 猜出一个可能的数值，满足最接近orders，然后数学算（首项+末项）*（个数）/2;然后再加上剩余的零头用k-1因为k是满足整数的取，剩下的就是k-1；
//注：这里二分法猜出的是最接近orders，因为有可能有零头，所以在之后要算出这个数和order的差值，然后加入到最后res；
//时间复杂度: n 是指库存中颜色球的数量，而 O(n log n) 表示对库存进行排序的时间复杂度。在二分搜索中，时间复杂度为 O(log M)，其中 M 是库存中最大的数量。整体的时间复杂度为 O(n log n + log M)。
//空间复杂度：O(1)
        public int MaxProfit(int[] inventory, int orders)
        {
            long M = 1000000007;
            Array.Sort(inventory);
            Array.Reverse(inventory);

            int left = 1, right = inventory[0];
            while (left < right)
            {
                int mid = left + (right - left) / 2;
                if (Count(inventory, mid) <= orders)
                    right = mid;
                else
                    left = mid + 1;
            }

            long x = left;
            long ret = 0;

            for (int i = 0; i < inventory.Length; i++)
            {
                if (inventory[i] < x)
                    break;
                //（首项+末项）*（个数）/2;
                ret += (inventory[i] + x) * (inventory[i] - x + 1) / 2 % M;
                ret %= M;
            }
            //算零头，
            ret += (x - 1) * (orders - Count(inventory, (int)x)) % M;
            ret %= M;

            return (int)ret;
        }

        private long Count(int[] inventory, int k)
        {
            long total = 0;

            for (int i = 0; i < inventory.Length; i++)
            {
                if (inventory[i] < k)
                    break;

                total += inventory[i] - k + 1;
            }

            return total;
        }
        public int MaxProfit1(int[] inventory, int orders)
        {
            long tot = 0;
            int cnt = 0;
            int n = inventory.Length;
            System.Array.Sort(inventory, (e1, e2) => e2 - e1);
            int mod = (int)Math.Pow(10, 9) + 7;
            int idx = 0;

            while (idx < n)
            {
                int currVal = inventory[idx];
                while (idx < n - 1 && inventory[idx + 1] == inventory[idx])
                {
                    idx++;
                }

                int totRows = idx + 1;
                int nextVal = idx == n - 1 ? 0 : inventory[idx + 1];

                long tryAdd = (long)totRows * (currVal - nextVal);

                if (cnt + tryAdd <= orders)
                {
                    tot += (long)(currVal + nextVal + 1) * (currVal - nextVal) / 2 * totRows;
                    tot %= mod;

                    idx++;
                    cnt += (int)tryAdd;
                }
                else
                {
                    int prevCols = (orders - cnt) / totRows;
                    int remn = (orders - cnt) % totRows;

                    nextVal = currVal - prevCols;
                    tot += (long)(currVal + nextVal + 1) * (currVal - nextVal) / 2 * totRows;
                    tot %= mod;

                    tot += (long)nextVal * remn;
                    tot %= mod;
                    break;
                }
            }

            return (int)tot;
        }
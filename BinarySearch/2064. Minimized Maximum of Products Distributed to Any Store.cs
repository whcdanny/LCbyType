//Leetcode 2064. Minimized Maximum of Products Distributed to Any Store med
//题意：给定一个整数 n，表示有 n 个专卖店。有 m 种不同数量的产品，数量分别用一个从 0 开始的整数数组 quantities 表示，其中 quantities[i] 表示第 i 种产品的数量。
//需要按照以下规则将所有产品分配给这些专卖店：
//每个店只能获得一种产品，但可以获得任意数量。
//分配后，每个店将被分配一定数量的产品（可能为 0）。设 x 表示分配给任何店的产品的最大数量，希望最小化 x，即最小化分配给任何店的产品的最大数量。
//返回最小可能的 x。
//思路：二分搜索, 找到可能的每个商店的最大值mid，然后因为quantity不一定能被(quantity / mid)整除，这样我们需要向上取整到 mid 的倍数，然后算出可能的个数，如果比n大，那么left动；
//注：quantity + mid - 1) 的目的是将 quantity 进行向上取整到 mid 的倍数。这是因为商店的容量是 mid，所以我们需要确保将产品数量 quantity 合理地分配到商店中
//如果 quantity 是 7，而商店容量 mid 是 3，如果我们直接使用 (quantity / mid) 来计算商店的数量，结果是 7 / 3 = 2。这意味着在商店容量为 3 的情况下，无法容纳 7 个产品。为了解决这个问题，我们使用 (quantity + mid - 1) 来确保 7 除以 3 向上取整到最接近的 3 的倍数
//时间复杂度: O(log(max(quantities)) * log n)，其中 max(quantities) 表示 quantities 数组中的最大值。
//空间复杂度：O(1)       
        public int MinimizedMaximum(int n, int[] quantities)
        {
            int left = 1, right = int.MinValue;
            foreach (int q in quantities)
            {
                right = Math.Max(right, q);
            }

            while (left < right)
            {
                int mid = (left + right) / 2, sum = 0;
                //(quantity + mid - 1) 的目的是将 quantity 进行向上取整到 mid 的倍数。这是因为商店的容量是 mid，所以我们需要确保将产品数量 quantity 合理地分配到商店中。
                //如果 quantity 是 7，而商店容量 mid 是 3，如果我们直接使用 (quantity / mid) 来计算商店的数量，结果是 7 / 3 = 2。这意味着在商店容量为 3 的情况下，无法容纳 7 个产品。为了解决这个问题，我们使用 (quantity + mid - 1) 来确保 7 除以 3 向上取整到最接近的 3 的倍数
                foreach (int quantity in quantities)
                    sum += (quantity + mid - 1) / mid;
                if (sum > n)
                    left = mid + 1;
                else
                    right = mid;
            }
            return left;
        }

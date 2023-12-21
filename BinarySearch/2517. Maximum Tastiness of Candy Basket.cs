//Leetcode 2517. Maximum Tastiness of Candy Basket med
//题意：给定一个正整数数组 price，其中 price[i] 表示第 i 个糖果的价格，以及一个正整数 k。
//商店出售包含 k 种不同糖果的礼篮。糖果篮的美味程度是篮子中任意两种糖果价格的最小绝对差。
//返回糖果篮的最大美味程度。
//思路：二分搜索, 我们可以对美味程度进行二分搜索。上界是最大价格与最小价格的差.对于每个二分搜索的中间值，我们尝试在价格数组中选择 k 种糖果，使得这 k 种糖果的差小于等于中间值。如果可以，则说明我们需要增加美味程度，因此更新left；否则，更新right        
//时间复杂度:  二分搜索的时间复杂度为 O(log(maxPrice - minPrice))，在每个二分搜索步骤中，我们计算糖果篮的美味程度的时间复杂度为 O(n)。因此，总时间复杂度为 O(n log(maxPrice - minPrice))。
//空间复杂度： O(1)
        public int MaximumTastiness(int[] price, int k)
        {
            Array.Sort(price);
            int left = 0, right = price[price.Length - 1] - price[0];
            while (left <= right)
            {
                int mid = left + (right - left) / 2;

                if (CanAchieveTastiness(price, k, mid))
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }

            return right;
        }
        private bool CanAchieveTastiness(int[] price, int k, int minDiff)
        {
            int i = 0, j = 1, count = 1;
            while (j < price.Length && count < k)
            {
                if (price[j] - price[i] >= minDiff)
                {
                    count++;
                    i = j;
                }
                j++;
            }
            return count >= k;
        }
//Leetcode 1802. Maximum Value at a Given Index in a Bounded Arraye med
//题意：题目要求构造一个数组 nums 满足以下条件：
//数组的长度为 n。
//数组中的元素都是正整数。
//相邻元素之差的绝对值不超过 1。
//数组元素之和不超过 maxSum。
//数组中的第 index 个元素要最大化。
//要求返回构造数组中的第 index 个元素的值。
//思路：用二分法：逻辑是找出最大的h，因为h的位置在index，而这是一个先以1递增到index位置然后再以-1递减的，那么我们可以用index为分界线分为左右两个；
//然后分完之后 每部分有两种可能一种就是h>index，也就是第一项不是1，而是h-index，另一种就是以1开始可能有一连串1然后再增长到h，这样有两种算sum的方法；
//注：当我们算完左右部分要减去一共h，是因为我们算了两遍；等差数列公式进行计算：Sum = (A1 + An) * n / 2
//时间复杂度: O(log(maxSum))，因为二分搜索的次数取决于 maxSum 的大小
//空间复杂度：O(1)
        public int MaxValue(int n, int index, int maxSum)
        {
            int left = 1, right = maxSum;

            while (left < right)
            {
                int mid = right - (right - left) / 2;

                if (IsValid(mid, n, index, maxSum))
                {
                    left = mid;
                }
                else
                {
                    right = mid - 1;
                }
            }

            return left;
        }

        private bool IsValid(int h, int n, int index, int maxSum)
        {
            //因为index为数组中最大的数位置，所以以index为基准，分为左右两个部分；
            //等差数列公式进行计算：Sum = (A1 + An) * n / 2
            long sum = 0;
            //左半部分；
            //还没有降到1的时候就已经到了0的位置，所以第一项不是1，而是h-index
            if (h > index)
            {
                sum += (long)(h - index + h) * (index + 1) / 2;
            }
            else
            {
                sum += (long)h * (h + 1) / 2;
                sum += index + 1 - h;
            }
            //右半部分；
            //还没有降到n的时候就已经到了最后的位置，所以第后一项不是n，而是n-index
            if (h > n - index)
            {
                sum += (long)(h + h - (n - index) + 1) * (n - index) / 2;
            }
            else{
                sum += (long)h * (h + 1) / 2;
                sum += (n - (index + h));
            }
            return sum-h <= maxSum;
        }

//1891. Cutting Ribbons med:给定一个由正整数表示的带子数组 ribbons 和一个整数 k，每个带子的长度表示带子的初始长度。需要从这些带子中切割出 k 段相同长度的带子。希望找到最大可能的切割长度
//思路:二分查找,下界为 1，上界为带子长度的最大值。然后在每次迭代中计算切割长度的中间值 mid，并调用辅助函数 CountRibbons(ribbons, mid) 来计算在长度为 mid 时，带子可以切割成多少段。如果切割段数大于等于 k，说明当前切割长度可能满足要求，将下界更新为 mid+1；否则，将上界更新为 mid-1。最终的下界值即为最大可能的切割长度。
        public int MaxLength(int[] ribbons, int k)
        {
            int left = 1;
            int right = ribbons.Max();

            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                int count = CountRibbons(ribbons, mid);

                if (count >= k)
                    left = mid + 1;
                else
                    right = mid - 1;
            }

            return left - 1;
        }

        private int CountRibbons(int[] ribbons, int length)
        {
            int count = 0;
            foreach (int ribbon in ribbons)
            {
                count += ribbon / length;
            }
            return count;
        }
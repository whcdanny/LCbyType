//Leetcode 1552. Magnetic Force Between Two Balls med
//题意： 在地球 C-137 宇宙中，Rick 发现了一种特殊的磁力形式，当两个球放在他新发明的篮子中时，它们之间会有磁力。Rick 有 n 个空篮子，第 i 个篮子的位置为 position[i]。Morty 有 m 个球，需要将这些球分配到篮子中，使得任意两个球之间的最小磁力值最大。
//Rick 定义两个不同位置的球之间的磁力为 |x - y|。
//给定整数数组 position 和整数 m，返回所需的最大磁力值。
//注：说白了找间隔最大的值满足m；
//思路：使用二分搜索，对篮子的位置进行排序。
//使用二分查找来确定磁力值的可能范围，然后在该范围内进行查找。
//在二分查找的过程中，判断是否可以将 m 个球放入篮子中，使得任意两个球之间的最小磁力值不小于当前猜测的值。
//时间复杂度: O(n log n)
//空间复杂度：O(1)
        public int MaxDistance(int[] position, int m)
        {
            Array.Sort(position);
            int left = 1, right = position[position.Length - 1] - position[0];

            while (left < right)
            {
				////0-1这条路 因为left是1开始
                int mid = right - (right - left) / 2;

                if (CanPlaceBalls(position, m, mid))
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

        private bool CanPlaceBalls(int[] position, int m, int minDistance)
        {
            int count = 1;
            int lastPosition = position[0];

            for (int i = 1; i < position.Length; i++)
            {
                if (position[i] - lastPosition >= minDistance)
                {
                    count++;
                    lastPosition = position[i];
                }
            }

            return count >= m;
        }
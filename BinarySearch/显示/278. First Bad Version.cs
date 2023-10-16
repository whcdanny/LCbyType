//Leetcode 278. First Bad Version ez
//题意：在一系列版本中找到第一个出错的版本。给定一个函数 bool isBadVersion(int version)，它会返回 true 如果版本出错，否则返回 false。
//思路：二分法: 在版本范围内缩小搜索范围，直到找到第一个出错的版本
//时间复杂度:  二分查找的时间复杂度是 O(logn)
//空间复杂度： O(1)
        public bool IsBadVersion(int version)
        {
            return true;
        }
        public int FirstBadVersion(int n)
        {
            int left = 1;
            int right = n;

            while (left < right)
            {
                int mid = left + (right - left) / 2;

                if (IsBadVersion(mid))
                {
                    right = mid;
                }
                else
                {
                    left = mid + 1;
                }
            }

            return left;
        }
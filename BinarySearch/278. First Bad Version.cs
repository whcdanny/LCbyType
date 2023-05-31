//278. First Bad Version ez
//是一个查找第一个错误版本
//思路：使用二分查找的思想来寻找第一个错误版本。由于错误版本是连续的，因此我们可以利用二分查找来缩小查找范围
        public bool IsBadVersion(int version)
        {
            
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
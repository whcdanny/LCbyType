//1095. Find in Mountain Array hard
//是一个在山脉数组中搜索目标值的问题
//思路：找到山脉数组的峰顶，使用二分查找的思想来找到峰顶的位置。 找到峰顶后，可以将山脉数组分为两个有序的子数组，一个是递增的左侧子数组，一个是递减的右侧子数组。然后再进行二分查找
        public class MountainArray
        {
            public int Get(int index) {  }
            public int Length() { }
        }
        public int FindInMountainArray(int target, MountainArray mountainArr)
        {
            int peak = FindPeakIndex(mountainArr);

            int left = BinarySearch(mountainArr, target, 0, peak, true);
            if (left != -1)
            {
                return left;
            }

            int right = BinarySearch(mountainArr, target, peak + 1, mountainArr.Length() - 1, false);
            return right;
        }

        private int FindPeakIndex(MountainArray mountainArr)
        {
            int left = 0;
            int right = mountainArr.Length() - 1;

            while (left < right)
            {
                int mid = left + (right - left) / 2;

                if (mountainArr.Get(mid) < mountainArr.Get(mid + 1))
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid;
                }
            }

            return left;
        }

        private int BinarySearch(MountainArray mountainArr, int target, int left, int right, bool isAscending)
        {
            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                int midValue = mountainArr.Get(mid);

                if (midValue == target)
                {
                    return mid;
                }

                if ((isAscending && midValue < target) || (!isAscending && midValue > target))
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }

            return -1;
        }
 //Leetcode 1095. Find in Mountain Array hard
//题意：要求在一个山脉数组中查找目标元素，山脉数组是一个先递增后递减的数组。数组中的一个元素 x 是一个山峰当且仅当：x > x-1 且 x > x+1。数组 mountainArr 是一个类，它实现了以下接口：int get(int index)：返回数组中索引为 index 的元素值。int length()：返回数组的长度。
//思路：二分法: 我们需要找到山脉数组的峰顶。我们可以使用一个二分查找来找到峰顶的索引。接着，我们可以在两个子数组中分别进行二分查找来找到目标元素。
//时间复杂度:  找到山脉峰顶的过程使用了一次二分查找，时间复杂度是 O(logn)。在两个子数组中进行二分查找的过程，时间复杂度也是 O(logn)。因此，总的时间复杂度是 O(logn)。
//空间复杂度： O(1)
        public class MountainArray
        {
            public int Get(int index) { return 0; }
            public int Length() { return 0; }
        }
        public int FindInMountainArray(int target, MountainArray mountainArr)
        {
            int length = mountainArr.Length();

            // Step 1: Find the peak index
            int left = 0, right = length - 1;
            int peakIndex = -1;

            while (left < right)
            {
                int mid = left + (right - left) / 2;
                int midValue = mountainArr.Get(mid);
                int nextValue = mountainArr.Get(mid + 1);

                if (midValue < nextValue)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid;
                }
            }
            peakIndex = left;

            // Step 2: Binary search in the left part
            left = 0;
            right = peakIndex;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                int midValue = mountainArr.Get(mid);

                if (midValue == target)
                {
                    return mid;
                }
                else if (midValue < target)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }

            // Step 3: Binary search in the right part
            left = peakIndex + 1;
            right = length - 1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                int midValue = mountainArr.Get(mid);

                if (midValue == target)
                {
                    return mid;
                }
                else if (midValue < target)
                {
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }

            return -1;
        }
        public int FindInMountainArray_1(int target, MountainArray mountainArr)
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
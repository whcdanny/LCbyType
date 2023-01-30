//34. Find First and Last Position of Element in Sorted Array med
//给一个数组，然后找出target的数重复的起点和终点
//思路：用二分法再用上左右针，
//先找起始点，这样右针可以一直选比target>=的边界
//然后找终点，因为left已经是起始点位置，那么只要把右边的位置重新放回最后，然后这次比较左针target<=的边界；
		public int[] SearchRange(int[] nums, int target)
        {
            int[] res = { -1, -1 };
            if (nums == null || nums.Length == 0)
                return res;
            int left = 0, right = nums.Length - 1;
            int mid = 0;
            while (left + 1 < right)
            {
                mid = (left + right) / 2;
                if (nums[mid] < target)
                {
                    left = mid;
                }
                else
                    right = mid;
            }
            if (nums[left] == target)
                res[0] = left;
            else if (nums[right] == target)
                res[0] = right;
            else
                return res;
            right = nums.Length - 1;
            while (left + 1 < right)
            {
                mid = (left + right) / 2;
                if (nums[mid] > target)
                {
                    right = mid;
                }
                else
                    left = mid;
            }
            if (nums[right] == target)
                res[1] = right;
            else if (nums[left] == target)
                res[1] = left;
            else
                return res;
            return res;
        }
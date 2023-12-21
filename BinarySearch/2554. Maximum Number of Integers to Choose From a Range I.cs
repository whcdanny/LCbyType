//Leetcode 2554. Maximum Number of Integers to Choose From a Range I med
//题意：给定整数数组 banned，整数 n，和整数 maxSum。规则是在区间 [1, n] 中选择一些整数，满足以下条件：
//选定的整数必须在范围[1, n] 内。
//每个整数最多只能选择一次。
//选定的整数不能在数组 banned 中。
//选定的整数的和不能超过 maxSum。
//返回满足上述规则的最大整数数量。
//思路：二分搜索, 用二分法去搜索所选的num是否在banned里，然后如果加上之后是否下雨maxSum；        
//时间复杂度:  O(nlogn)
//空间复杂度： O(1)
        public int MaxCount(int[] banned, int n, int maxSum)
        {
            Array.Sort(banned);
            int count = 0;
            int i = 1;
            int sum = 0;
            while (i <= n)
            {
                if (binarySearch_MaxCount(i, banned))
                {
                    i++;
                }
                else
                {
                    if (sum + i <= maxSum)
                    {
                        count++;
                        sum = sum + i;
                    }
                    i++;
                }
            }
            return count;

        }

        private bool binarySearch_MaxCount(int i, int[] banned)
        {
            int low = 0;
            int high = banned.Length - 1;
            while (low <= high)
            {
                int mid = (high - low) / 2 + low;
                if (banned[mid] == i)
                {
                    return true;
                }
                else if (banned[mid] < i)
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            }
            return false;
        }
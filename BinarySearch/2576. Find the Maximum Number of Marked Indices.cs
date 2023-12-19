//Leetcode 2576. Find the Maximum Number of Marked Indices med
//题意：题目要求找出一个整数数组中，通过以下操作最多能标记多少个索引对：
//可以任意多次选择两个不同的未标记索引 i 和 j（i ≠ j），其中 2 * nums[i] <= nums[j]。
//一旦选择了索引对(i, j)，则要标记这两个索引。
//思路：二分搜索, 我们对数组进行排序，以便我们可以检查潜在的答案“max”是否为“max”。在线性时间内是可能的。我们贪婪greedyly地检查mid前一组中最小数字与max后一组中的最小数字是否匹配。
//注：因为是索引对，所以right = n/2; 也正因为如此，res也是right*2；
//时间复杂度:  Sorting cost O(nLog(n))Binary Search cost O(Log(n)；最终 O(nLog(n))
//空间复杂度： O(n)
        public int MaxNumOfMarkedIndices(int[] nums)
        {

            int n = nums.Length;
            int[] ascendArray = (int[])nums.Clone();

            Array.Sort(ascendArray);


            int left = 0;
            int right = n / 2; //因为是索引对

            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                if (Check_MaxNumOfMarkedIndices(mid, n, ascendArray))
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }

            return right * 2;

        }

        bool Check_MaxNumOfMarkedIndices(int max, int n, int[] ascendArray)
        {
            if (max > n)
            {
                return false;
            }

            for (int i = 0; i < max; i++)
            {
                int small = ascendArray[i];
                int large = ascendArray[n - max + i];
                if (small * 2 > large)
                {
                    return false;
                }
            }

            return true;
        }
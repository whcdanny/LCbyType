//Leetcode 1760. Minimum Limit of Balls in a Bag med
//题意：题目要求在最多进行 maxOperations 次操作的情况下，将每个袋子的球进行分割，使得分割后每个袋子中的球数的最大值最小。要求返回最小可能的最大值。
//思路：用二分法：在定义的范围内进行二分搜索，对于每一个猜测值 mid，判断是否能够通过分割操作得到每个袋子中球的最大值不超过 mid。判断的条件包括进行分割操作的次数不超过 maxOperations。
//注：这里利用了一共公式 nums=[n1,n2] maxOperations =2, 如果1分，op=(n1-1)/1+(n2-1)/1， 如果k分， op=(n1-1)/k+(n2-1)/k;
//时间复杂度: O(N log M)，其中 N 是数组 nums 的长度，M 是数组中最大的元素值
//空间复杂度：O(1)
        public int MinimumSize(int[] nums, int maxOperations)
        {
            int left = 1, right = nums.Max();

            while (left < right)
            {
                int mid = left + (right - left) / 2;

                if (IsValid(mid, nums, maxOperations))
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

        private bool IsValid(int mid, int[] nums, int maxOperations)
        {
            int operations = 0;

            foreach (int num in nums)
            {
                //减去 1 (num - 1) 是为了确保如果 num 恰好可以被 mid 整除，我们不会多计算一次操作。例如，如果 num 是 4，mid 是 2，我们只需要一次操作将其分割成尺寸为 2 的袋子。如果不减去 1，结果将是 (4 / 2) = 2，这样就错误地计算了两次操作。
                operations += (num - 1) / mid;
            }

            return operations <= maxOperations;
        }

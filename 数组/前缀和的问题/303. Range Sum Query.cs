//303. Range Sum Query - Immutable ez
//让你计算数组区间内元素的和；
//思路：因为算某两个位置之间的和，换个思路就是right位置和-left位置的和，相当于减去left位置之前的数，
//所以我们建立一个preSum，把到每一位的和都存下来
		class NumArray2
        {
            // 前缀和数组
            private int[] preSum;

            /* 输入一个数组，构造前缀和 */
            public NumArray2(int[] nums)
            {
                // preSum[0] = 0，便于计算累加和
                preSum = new int[nums.Length + 1];
                // 计算 nums 的累加和
                for (int i = 1; i < preSum.Length; i++)
                {
                    preSum[i] = preSum[i - 1] + nums[i - 1];
                }
            }

            /* 查询闭区间 [left, right] 的累加和 */
            public int sumRange(int left, int right)
            {
                return preSum[right + 1] - preSum[left];
            }
        }
		public class NumArray
        {

            int[] temp;
            public NumArray(int[] nums)
            {
                temp = new int[nums.Length];
                for (int i = 0; i < nums.Length; i++)
                {
                    temp[i] = i == 0 ? nums[0] : temp[i - 1] + nums[i];
                }
            }

            public int SumRange(int left, int right)
            {
                if (left < 0 || right > temp.Length)
                {
                    return 0;
                }
                if (left == 0)
                {
                    return temp[right];
                }
                else
                {
                    return temp[right] - temp[left - 1];
                }
            }
        }

        /**
         * Your NumArray object will be instantiated and called as such:
         * NumArray obj = new NumArray(nums);
         * int param_1 = obj.SumRange(left,right);
         */
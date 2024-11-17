//Leetcode 3095. Shortest Subarray With OR at Least K I ez
//题目：题目描述
//给定一个由非负整数组成的数组 nums 和一个整数 k。
//定义一个子数组为 特殊子数组，如果该子数组中所有元素的按位或(bitwise OR) 值大于等于 k。
//返回 最短特殊子数组的长度，如果不存在这样的子数组，返回 -1
//思路: 滑窗，从头开始，然后如果bitwise OR的结果>=k，那么更新minLength Math.Min(minLength, j - i + 1);
//时间复杂度：O(nlogn)
//空间复杂度：O(1)
        public int MinimumSubarrayLength(int[] nums, int k)
        {
            var minLength = int.MaxValue;
            var found = false;

            for (int i = 0; i < nums.Length; i++)
            {
                int orResult = 0;

                for (int j = i; j < nums.Length; j++)
                {
                    orResult |= nums[j];

                    if (orResult >= k)
                    {
                        minLength = Math.Min(minLength, j - i + 1);
                        found = true;
                        break;
                    }

                }
            }

            return found ? minLength : -1;
        }
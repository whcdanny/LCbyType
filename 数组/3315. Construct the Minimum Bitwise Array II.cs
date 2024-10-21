//Leetcode 3315. Construct the Minimum Bitwise Array II med
//题目：给定一个由 𝑛 n 个质数组成的数组 nums，需要构造一个长度为 𝑛 n 的数组 ans。
//对于每个索引 i，需要满足以下条件： ans[i]OR(ans[i]+1)=nums[i] 也就是说，
//ans[i] 与 ans[i] + 1 的按位或操作结果必须等于 nums[i]。 
//此外，还需要尽量最小化 ans[i] 的值。如果无法找到满足条件的值，则将 ans[i] 设置为 -1。
//思路：看code，通过位运算检查 num 的最低位是否为 0。如果是，则无法构造满足条件的 ans[i]，直接将 res[i] 设置为 -1。
//时间复杂度：O(n) n 是 nums 的长度
//空间复杂度：O(n) n 是 nums 的长度
        public int[] MinBitwiseArray_1(IList<int> nums)
        {
            int[] res = new int[nums.Count];

            for (int i = 0; i < nums.Count; i++)
            {
                int num = nums[i];
                //通过位运算检查 num 的最低位是否为 0。如果是，则无法构造满足条件的 ans[i]，直接将 res[i] 设置为 -1。
                if ((num & 1) == 0)
                {
                    res[i] = -1;
                    continue;
                }
                //从 31 到 0 的循环是因为代码处理的是 32 位整数
                for (int j = 31; j >= 0; j--)
                {
                    /*1. 位移操作：int shift = 1 << j;
                    这行代码计算 2^j，即二进制中 1 向左移动 j 位。例如：
                    当 j = 0 时，shift = 1 << 0，结果是 1（即 0001）。
                    当 j = 1 时，shift = 1 << 1，结果是 2（即 0010）。
                    当 j = 2 时，shift = 1 << 2，结果是 4（即 0100）。*/
                    int shift = 1 << j;
                    //如果 shift 的值大于 num，则表示当前位数对于构造 temp 来说是无效的
                    //例如，如果 num 是 10（即 1010），而 shift 是 16（即 10000），则跳过这个循环。
                    if (shift > num) continue;

                    //temp 代表了我们想要的 ans[i] 的值。
                    int temp = num - shift;
                    //按位或的特性：如果在 temp 的某一位上为 0，则在 temp + 1 的这一位上一定会为 1，这样就能确保这一位在最终结果中被设置为 1。
                    int or = temp | (temp + 1);

                    if (or != num) continue;

                    res[i] = temp;
                    break;
                }
            }

            return res;
        }
//Leetcode 3314. Construct the Minimum Bitwise Array I ez
//题目：给定一个由 𝑛 n 个质数组成的数组 nums，需要构造一个长度为 𝑛 n 的数组 ans。
//对于每个索引 i，需要满足以下条件： ans[i]OR(ans[i]+1)=nums[i] 也就是说，
//ans[i] 与 ans[i] + 1 的按位或操作结果必须等于 nums[i]。 
//此外，还需要尽量最小化 ans[i] 的值。如果无法找到满足条件的值，则将 ans[i] 设置为 -1。
//思路：初始化：将 ans 数组初始化为 -1，表示默认情况下没有找到满足条件的解。
//嵌套循环：外层循环遍历每个 nums[i]，内层循环从 0 开始尝试找到符合条件的 ans[i] 值。如果找到满足(a | (a + 1)) == nums[i] 的最小值 a，就将其赋值给 ans[i]，并跳出内层循环。
//返回结果：遍历结束后，返回构造好的 ans 数组。
//时间复杂度：最坏情况下，对于每个元素，我们需要从 0 尝试到 nums[i]，因此时间复杂度为O(n⋅m)，其中 n 是 nums 的长度，m 是每个 nums[i] 的值的上限。
//空间复杂度：O(n) n 是 nums 的长度
        public int[] MinBitwiseArray(IList<int> nums)
        {
            int n = nums.Count;
            int[] ans = new int[n];

            for (int i = 0; i < n; i++)
            {
                ans[i] = -1; // 初始化为 -1，表示没有找到符合条件的值

                // 尝试找到最小的 ans[i]
                for (int a = 0; a <= nums[i]; a++)
                {
                    if ((a | (a + 1)) == nums[i])
                    {
                        ans[i] = a;
                        break;
                    }
                }
            }

            return ans;
        }
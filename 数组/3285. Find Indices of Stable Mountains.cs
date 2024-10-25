//Leetcode 3285. Find Indices of Stable Mountains ez
//题目：给定一个整数数组 height，其中 height[i] 表示第 i 座山的高度，以及一个整数 threshold。
//我们称一座山为“稳定山”（stable mountain），当且仅当其前一座山的高度严格大于 threshold。需要注意的是，第 0 座山不被视为稳定山。
//要求返回一个数组，包含所有稳定山的索引，顺序不限。
//思路：遍历山的高度数组：从第二座山（索引为1）开始遍历到最后一座山。
//判断稳定性：对于每一座山，检查其前一座山的高度是否严格大于给定的 threshold。
//收集稳定山的索引：如果条件满足，将当前山的索引（即当前循环的索引 i）添加到结果列表中。
//时间复杂度：O(n)，其中 n 是数组 height 的长度
//空间复杂度：O(k)，其中 k 是稳定山的数量
        public IList<int> StableMountains(int[] height, int threshold)
        {
            List<int> stableIndices = new List<int>();

            for (int i = 1; i < height.Length; i++)
            {
                // 检查前一座山的高度是否大于阈值
                if (height[i - 1] > threshold)
                {
                    stableIndices.Add(i);
                }
            }

            return stableIndices.ToArray();
        }
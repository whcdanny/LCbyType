//Leetcode 3069. Distribute Elements Into Two Arrays I ez
//题目：给定一个 1-索引 的数组 nums，其长度为 n，数组中的整数互不相同。
//需要将 nums 中的所有元素分配到两个数组 arr1 和 arr2 中，并通过 n 次操作完成分配。
//规则如下：
//第一次操作，将 nums[1] 添加到 arr1 中。
//第二次操作，将 nums[2] 添加到 arr2 中。
//从第 i 次操作起，根据以下规则进行分配：
//如果 arr1 的最后一个元素大于 arr2 的最后一个元素，则将 nums[i] 添加到 arr1 中；
//否则，将 nums[i] 添加到 arr2 中。
//最后，将 arr1 和 arr2 连接在一起形成 result 数组，返回 result。
//思路: 首先将 nums[1] 添加到 arr1，nums[2] 添加到 arr2，如果 n == 1 则直接返回 arr1。
//从第 3 个元素开始的分配规则：
//比较 arr1 和 arr2 的最后一个元素大小：
//如果 arr1 的最后一个元素大，则将当前元素追加到 arr1。
//否则，追加到 arr2。
//构造结果：
//最后，将 arr1 和 arr2 拼接起来形成 result 并返回。
//时间复杂度：O(n)
//空间复杂度：O(n)
        public int[] ResultArray(int[] nums)
        {
            // 初始化 arr1 和 arr2
            List<int> arr1 = new List<int>();
            List<int> arr2 = new List<int>();

            // 处理前两次分配
            arr1.Add(nums[0]); // nums[1] 对应 nums[0] (1-indexed)
            if (nums.Length > 1)
                arr2.Add(nums[1]);

            // 从第 3 个元素开始分配
            for (int i = 2; i < nums.Length; i++)
            {
                if (arr1[arr1.Count-1] > arr2[arr2.Count-1]) // arr1[^1] 是 arr1 的最后一个元素
                    arr1.Add(nums[i]);
                else
                    arr2.Add(nums[i]);
            }

            // 拼接结果
            List<int> result = new List<int>(arr1);
            result.AddRange(arr2);

            return result.ToArray();
        }
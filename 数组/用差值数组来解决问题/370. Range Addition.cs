//370. Range Addition med
//给一个数组，给k个操作，[起始点，终点，增加的数]
//思路：逻辑是用差值，建立一个class存入每个位置的差值，0位置为输入的值，
//这个差值的数组，相当于每个位置为前一位[i-1]+差值数组[i],
//如何添加差值，只需要将起始位置+输入的val，然后终点位置+1减去输入的val；
//中间都不用算，因为是每一个位置的算法为前一位[i-1]+差值数组[i]
		public int[] getModifiedArray(int length, int[][] updates)
        {
            // nums 初始化为全 0
            int[] nums = new int[length];
            // 构造差分解法
            Difference df = new Difference(nums);

            foreach (int[] update in updates)
            {
                int i = update[0];
                int j = update[1];
                int val = update[2];
                df.increment(i, j, val);
            }

            return df.result();
        }
        // 差分数组工具类
        class Difference
        {
            // 差分数组
            private int[] diff;

            /* 输入一个初始数组，区间操作将在这个数组上进行 */
            public Difference(int[] nums)
            {
                //nums.Length > 0;
                diff = new int[nums.Length];
                // 根据初始数组构造差分数组
                diff[0] = nums[0];
                for (int i = 1; i < nums.Length; i++)
                {
                    diff[i] = nums[i] - nums[i - 1];
                }
            }

            /* 给闭区间 [i, j] 增加 val（可以是负数）*/
            public void increment(int i, int j, int val)
            {
                diff[i] += val;
                if (j + 1 < diff.Length)
                {
                    diff[j + 1] -= val;
                }
            }

            /* 返回结果数组 */
            public int[] result()
            {
                int[] res = new int[diff.Length];
                // 根据差分数组构造结果数组
                res[0] = diff[0];
                for (int i = 1; i < diff.Length; i++)
                {
                    res[i] = res[i - 1] + diff[i];
                }
                return res;
            }
        }
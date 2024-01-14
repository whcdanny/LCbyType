//Leetcode 2562. Find the Array Concatenation Value ez
//题意：给定一个整数数组 nums。
//两个数字的连接是由它们的数字拼接而成的数。
//例如，15 和 49 的连接是 1549。
//nums 的连接值最初等于 0。执行以下操作，直到 nums 变为空：
//如果 nums 中存在多个数字，分别选择 nums 的第一个元素和最后一个元素，将它们的连接值加到 nums 的连接值上，然后从 nums 中删除第一个和最后一个元素。
//如果只有一个元素存在，将其值添加到 nums 的连接值上，然后删除它。
//返回 nums 的连接值。
//思路：左右针，两个指针i和j分别设置为数组的第一个和最后一个索引。        
//将变量初始化inc为 10 来表示串联的增量因子。
//inc通过重复乘以 10 直到大于或等于 来找到适当的增量因子num2。说白了根据num2的位数，如果是个位那么num1*10+num2，如果是十位，num1*10*10+num2；依此类推；
//num1通过乘以并inc加上来计算串联值num2。将此值添加到res.
//递增i和递减j以向内移动指针。
//如果数组的长度为奇数且i等于j，则剩余一个元素。
//将剩余的元素添加到res.
//时间复杂度: O(n)
//空间复杂度：O(1)
        public long findTheArrayConcVal(int[] nums)
        {
            long res = 0;
            int i = 0;
            int j = nums.Length - 1;

            while (i < j)
            {
                int num1 = nums[i];
                int num2 = nums[j];
                int inc = 10;
                while (num2 >= inc) inc *= 10;
                res += num1 * inc + num2;
                i++;
                j--;
            }

            if (i == j) res += nums[i];
            return res;
        }
        //暴力算
        public long FindTheArrayConcVal1(int[] nums)
        {
            long result = 0;

            while (nums.Length > 0)
            {
                if (nums.Length > 1)
                {
                    result += ConcatenateAndRemove(ref nums, 0, nums.Length - 1);
                }
                else
                {
                    result += nums[0];
                    nums = Array.Empty<int>();
                }
            }

            return result;
        }
        private long ConcatenateAndRemove(ref int[] nums, int left, int right)
        {
            long concatenatedValue = long.Parse(nums[left].ToString() + nums[right].ToString());
            nums = nums.Skip(1).Take(nums.Length - 2).ToArray();
            return concatenatedValue;
        }
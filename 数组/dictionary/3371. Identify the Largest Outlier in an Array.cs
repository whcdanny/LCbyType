//Leetcode 3371. Identify the Largest Outlier in an Array med
//题意：给定一个整数数组 nums，该数组包含 n 个元素，其中有 n−2 个元素是特殊数字。
//剩余两个元素中，一个是这些特殊数字的和，另一个是离群值（Outlier）。
//离群值定义为既不是特殊数字，也不是表示这些数字和的元素。
//注意，特殊数字、和元素以及离群值的索引必须是不同的，但它们的值可以相同。
//要求：返回数组 nums 中最大的可能离群值。
//思路：因为找一个outlier所以，用总和 - 每一个数字来猜测哪一个数字可以是最大outlier
//然后subSum % 2 == 0 && dict.ContainsKey(subSum / 2)
//这里要算一个每个数字出现的个数
//因为如果subSum / 2 != key 那么很容易知道当前的值可能是outlier
//如果subSum / 2 == key 那么就要看是否出现个数2个如果不是，那么说明不可以
//最后找出max
//时间复杂度:  O(n)
//空间复杂度： O(n)
        public int GetLargestOutlier(int[] nums)
        {
            int sum = 0;
            int res = -1001;
            int n = nums.Length;
            Dictionary<int, int> dict = new Dictionary<int, int>();
            for (int i = 0; i < n; i++)
            {
                if (dict.ContainsKey(nums[i])) 
                    dict[nums[i]]++;
                else 
                    dict.Add(nums[i], 1);
                sum += nums[i];
            }
            foreach (int key in dict.Keys)
            {
                int subSum = sum - key;
                if (subSum % 2 == 0 && dict.ContainsKey(subSum / 2))
                {
                    if (subSum / 2 != key || (dict[subSum / 2] > 1)) 
                        res = Math.Max(key, res);
                }
            }
            return res;
        }
        public int GetLargestOutlier_超时(int[] nums)
        {
            int n = nums.Length;
            int sum = nums.Sum();
            int res = int.MinValue;
            for(int i = 0; i < n; i++)
            {
                for(int j = i + 1; j < n; j++)
                {
                    int val1 = nums[i];
                    int val2 = nums[j];
                    int sub = sum - val1 - val2;
                    if (sub == val1)
                        res = Math.Max(res, val2);
                    if (sub == val2)
                        res = Math.Max(res, val1);
                }
            }
            return res;
        }
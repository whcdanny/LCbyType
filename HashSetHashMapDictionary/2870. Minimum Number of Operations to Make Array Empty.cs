//Leetcode 2870. Minimum Number of Operations to Make Array Empty med
//题意：计算将数组清空所需的最小操作次数，数组中有两种操作：
//选择两个相等的元素并删除它们。
//选择三个相等的元素并删除它们。
//思路：hashtable，Dictionary算出每个数字出现的个数；
//如果有1个就-1不存在，如果大于1个，那么就直接用(int)Math.Ceiling((double)count / 3);找到上边界就好，
//注：上边界用3
//时间复杂度：O(n)
//空间复杂度：O(n)
        public int MinOperations(int[] nums)
        {
            Dictionary<int, int> map = new Dictionary<int, int>();

            foreach (int num in nums)
            {
                if (!map.ContainsKey(num))
                {
                    map[num] = 0;
                }
                map[num]++;
            }

            int res = 0;

            foreach (var count in map.Values)
            {
                if (count == 1)
                {
                    return -1;
                }
                else
                {
                    res += (int)Math.Ceiling((double)count / 3);
                }
            }

            return res;
        }
//Leetcode 3020. Find the Maximum Number of Elements in Subset med
//题意：给定一个正整数数组nums。
//需要选择一个子集nums，满足以下条件：
//可以将所选元素放入一个0索引的数组中，使其遵循模式：[x, x^2, x^4, ..., x^(k/2), x^k, x^(k/2), ..., x^4, x^2, x]
//（注意，k可以是任意非负2的幂）。例如，[2, 4, 16, 4, 2] 和[3, 9, 3] 符合模式，而[2, 4, 8, 4, 2] 不符合。
//要求返回满足这些条件的子集中最大元素数目。
//思路：hashtable, Dictionary找出所有的数字对应的个数；
//然后算出当前数字的个数是1个还是多个，如果多个，就+2然后下一个数字寻找num*num；如果一个就说存在mid最后总数+1，没有中间-1；
//注：1是个特别的因为1^n都是1，所以分出来，
//时间复杂度：O(n^2)
//空间复杂度：O(n)
        public int MaximumLength(int[] nums)
        {
            var map = CreateMaximumLength(nums);
            var res = 1;
            foreach (var item in map)
            {
                var tempRes = 0;
                long key = item.Key;
                var hasMid = false;
                while (map.ContainsKey(key))
                {
                    if (key == 1)
                    {
                        tempRes = (map[key] / 2) * 2;
                        if (map[key] % 2 == 1) hasMid = true;
                        break;
                    }
                    if (map[key] > 1)
                    {
                        tempRes += 2;
                        key *= key;
                    }
                    else
                    {
                        hasMid = true;
                        break;
                    }
                }
                tempRes += hasMid ? 1 : -1;
                res = Math.Max(res, tempRes);
            }
            return res;
        }
        private Dictionary<long, int> CreateMaximumLength(int[] nums)
        {
            var res = new Dictionary<long, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (!res.ContainsKey(nums[i]))
                {
                    res.Add(nums[i], 1);
                }
                else
                {
                    res[nums[i]]++;
                }
            }
            return res;
        }
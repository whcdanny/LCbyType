//Leetcode 3085. Minimum Deletions to Make String K-Special med
//题意：给定一个字符串word和一个整数k，定义字符串word为k-special的条件是对于字符串中的任意两个字符，它们的频率差的绝对值都不超过k。
//要求计算使得字符串word成为k-special所需删除的最小字符数。
//思路：hashtable，用dictionary来存出现字母和对应数目；
//然后从小到大排序，然后从第一个开始，来算多余k个的可能性，然后找出最小的更改次数；
//注：从第二个开始，要算上前面几没有加入的个数，sumOfLess += vals[i - 1];
//时间复杂度：O(n^2)
//空间复杂度：O(1)
        public int MinimumDeletions(string word, int k)
        {
            Dictionary<char, int> map = new Dictionary<char, int>();
            foreach (char ch in word)
            {
                if (!map.ContainsKey(ch))
                    map[ch] = 0;
                map[ch]++;
            }

            List<int> vals = new List<int>();
            foreach (var item in map)
                vals.Add(item.Value);
            vals.Sort();

            int sumOfLess = 0;
            int ans = int.MaxValue;
          
            for (int i = 0; i < vals.Count; i++)
            {
                if (i > 0)
                    sumOfLess += vals[i - 1];
                int sum = sumOfLess;
                for (int j = i + 1; j < vals.Count; j++)
                {
                    if (vals[j] - vals[i] > k)
                        sum += vals[j] - vals[i] - k;
                }
                ans = Math.Min(ans, sum);
            }
            return ans;
        }
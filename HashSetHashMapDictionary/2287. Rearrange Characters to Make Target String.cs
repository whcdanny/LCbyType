//Leetcode 2287. Rearrange Characters to Make Target String ez
//题意：给定两个字符串 s 和 target，要求从字符串 s 中取出一些字母并重新排列，以形成新的字符串。问最多可以形成多少个字符串 target。
//思路：hashtable 这里用两个Dictionary来收集target中每个字母出现的次数，和 结果；
//收集完target中每个字母出现的次数，然后历遍s，让result先收集s每个char出现的个数
//最后对于买个char，result[c] /= targetDict[c]; 这样能找到每个char对于target中能找到对少，然后取最小的
//时间复杂度：O(n)
//空间复杂度：O(n)
        public int RearrangeCharacters(string s, string target)
        {
            Dictionary<char, int> targetDict = new Dictionary<char, int>();
            Dictionary<char, int> result = new Dictionary<char, int>();

            foreach (char c in target)
            {
                if (targetDict.ContainsKey(c)) 
                    targetDict[c]++;
                else
                {
                    targetDict[c] = 1;
                    result[c] = 0;
                }
            }

            foreach (char c in s)
            {
                if (result.ContainsKey(c)) 
                    result[c]++;
            }

            foreach (char c in targetDict.Keys)
            {
                result[c] /= targetDict[c];
            }

            return result.Min(x => x.Value);
        }
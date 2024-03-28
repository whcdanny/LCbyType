//Leetcode 3043. Find the Length of the Longest Common Prefix med
//题意：给定两个正整数数组arr1和arr2。
//一个正整数的前缀是由其一位或多位数字组成的整数，从最左边的数字开始。例如，123是整数12345的前缀，而234不是。
//两个整数a和b的公共前缀是一个整数c，使得c是a和b的前缀。例如，5655359和56554具有公共前缀565，而1223和43456没有公共前缀。
//你需要找到所有整数对(x, y)的最长公共前缀的长度，其中x属于arr1，y属于arr2。
//返回所有整数对的最长公共前缀的长度。如果它们之间不存在公共前缀，则返回0。
//思路：hashtable, 两个数组中的每一对数字，比较它们的前缀直到找到最长的公共前缀。
//可以利用哈希表来存储数字的前缀。
//遍历数组arr1，对每个数字求出所有可能的前缀，并存储在哈希表中。
//遍历数组arr2，对每个数字求出所有可能的前缀，并检查是否存在于哈希表中，同时更新最长公共前缀的长度。
//时间复杂度：假设arr1的长度为m，arr2的长度为n，对于每个数字，生成所有可能的前缀O(max(m, n))，总的时间复杂度为O(m + n)。
//空间复杂度：O(m + n)
        public int LongestCommonPrefix(int[] arr1, int[] arr2)
        {
            HashSet<string> prefixSet = new HashSet<string>();
            int maxPrefixLength = 0;

            // Generate prefixes for arr1
            foreach (int num in arr1)
            {
                string numStr = num.ToString();
                string prefix = "";
                foreach (char c in numStr)
                {
                    prefix += c;
                    prefixSet.Add(prefix);
                }
            }

            // Check prefixes for arr2
            foreach (int num in arr2)
            {
                string numStr = num.ToString();
                string prefix = "";
                foreach (char c in numStr)
                {
                    prefix += c;
                    if (prefixSet.Contains(prefix))
                    {
                        maxPrefixLength = Math.Max(maxPrefixLength, prefix.Length);
                    }
                    else
                    {
                        break; // If the prefix is not found, break the loop
                    }
                }
            }

            return maxPrefixLength;
        }
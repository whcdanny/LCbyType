//Leetcode 2729. Check if The Number is Fascinating ez
//题意：给定一个三位数 n，判断它是否是“迷人”的数字。一个数字是迷人的，如果将 n 与 2 * n 和 3 * n 连接起来后，得到的结果包含数字 1 到 9，并且不包含 0。
//思路：hashtable, 找到n2 n3，然后组成string，
//然后用hashset存这个string里所以不重复的数字
//最后比较是否hashset的个数和string是相同，同时string里不能出现0；
//时间复杂度：O(n)
//空间复杂度：O(1)
        public bool IsFascinating(int n)
        {
            int n2 = n * 2;
            int n3 = n * 3;
            string concatenatedNumber = n.ToString() + n2.ToString() + n3.ToString();
            HashSet<char> hash = new HashSet<char>();
            foreach (char c in concatenatedNumber)
            {
                hash.Add(c);
            }

            return (!hash.Contains('0') && hash.Count == concatenatedNumber.Length);
        }
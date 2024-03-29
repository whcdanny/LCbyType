//Leetcode 2983. Palindrome Rearrangement Queries hard
//题意：给定一个长度为偶数的字符串s。
//同时给定一个二维整数数组queries，其中queries[i] = [ai, bi, ci, di]。
//对于每个查询i，可以执行以下操作：
//重新排列子串s[ai:bi] 中的字符，其中0 <= ai <= bi<n / 2。
//重新排列子串s[ci:di]中的字符，其中n / 2 <= ci <= di<n。
//对于每个查询，需要确定是否可以通过执行操作使s成为回文串。
//返回一个布尔类型的数组answer，其中answer[i] == true表示可以通过第i个查询的操作使s成为回文串，否则为false。
//每个查询都是独立回答的。
//思路：hashtable, 看code       
//时间复杂度：O(n + qm)假设字符串的长度为 n，并且有 q 个查询，m 为绑定列表的长度
//空间复杂度：O(m)
        public bool[] CanMakePalindromeQueries(string s, int[][] queries)
        {
            bool[] result = new bool[queries.Length];

            //找出前一半和后一半，并把后一半反转这样就可以于前一半一一对应；
            string s1 = s[..(s.Length / 2)];
            string s2 = s[(s.Length / 2)..];
            s2 = new string(s2.Reverse().ToArray());

            //找到前后半部分，相同字母相对于的字母位置；
            List<(int, int)> binds = new List<(int, int)>();
            int[] indexes = new int[26];
            for (int i = 0; i < s1.Length; i++)
            {
                bool found = false;
                for (int j = indexes[s1[i] - 'a']; j < s2.Length; j++)
                {
                    if (s1[i] == s2[j])
                    {
                        indexes[s1[i] - 'a'] = j + 1;
                        if (i != j)
                        {
                            binds.Add((i, j));
                        }
                        found = true;
                        break;
                    }
                }
                //因为s是偶数，所以必须前后半区都有相同的字母；
                if (!found)
                {
                    return result;
                }
            }

            // Process
            foreach (var (index, query) in queries.Select((value, index) => (index, value)))
            {
                int left1 = query[0];
                int right1 = query[1];
                int left2 = s.Length - query[3] - 1;
                int right2 = s.Length - query[2] - 1;

                result[index] = true;
                foreach (var bind in binds)
                {
                    (int left, int right) range1 = (bind.Item1, bind.Item1);
                    (int left, int right) range2 = (bind.Item2, bind.Item2);
                    //如果找到的绑定的第一个点再第一个区间；
                    if (bind.Item1 >= left1 && bind.Item1 <= right1)
                    {
                        range1 = (left1, right1);
                    }
                    //如果找到的绑定的第二个点再第二个区间；
                    if (bind.Item2 >= left2 && bind.Item2 <= right2)
                    {
                        range2 = (left2, right2);
                    }
                    //双方都没有相重叠的位置，不符合
                    if (range1.left > range2.right || range2.left > range1.right)
                    {
                        result[index] = false;
                        break;
                    }
                }
            }

            return result;
        }
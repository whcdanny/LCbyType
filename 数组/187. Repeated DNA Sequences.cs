//187. Repeated DNA Sequences med
//DNA 序列由四种碱基 A, G, C, T 组成，现在给你输入一个只包含 A, G, C, T 四种字符的字符串 s 代表一个 DNA 序列，请你在 s 中找出所有重复出现的长度为 10 的子字符串。
//思路：暴力算法 每一个位置往后算10位，然后查找是否有重复
//O(NL)
        public IList<string> FindRepeatedDnaSequences(string s)
        {
            Dictionary<string, int> dic = new Dictionary<string, int>();
            for (int i = 0; i < s.Length - 9; i++)
            {
                string sequence = s.Substring(i, 10);
                dic.Add(sequence, dic.GetValueOrDefault(sequence) + 1);
            }
            List<string> res = new List<string>();
            foreach (string seq in dic.Keys)
            {
                if (dic[seq] > 1)
                    res.Add(seq);
            }
            return res;
        }
//思路：因为只有A, G, C, T，所以把他们变成0123，然后把十位变成数字，然后查找是否存在相同数字；
//正常O(N) 最坏情况O(NL)
//这个会超时现在
        public IList<string> FindRepeatedDnaSequences1(string s)
        {
            // 先把字符串转化成四进制的数字数组
            int[] nums = new int[s.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                switch (s.ElementAt(i))
                {
                    case 'A':
                        nums[i] = 0;
                        break;
                    case 'G':
                        nums[i] = 1;
                        break;
                    case 'C':
                        nums[i] = 2;
                        break;
                    case 'T':
                        nums[i] = 3;
                        break;
                }
            }
            // 记录重复出现的哈希值
            List<int> seen = new List<int>();
            //HashSet<Integer> seen = new HashSet<>();
            // 记录重复出现的字符串结果
            List<string> res = new List<string>();
            //HashSet<String> res = new HashSet<>();

            // 数字位数
            int L = 10;
            // 进制
            int R = 4;
            // 存储 R^(L - 1) 的结果
            int RL = (int)Math.Pow(R, L - 1);
            // 维护滑动窗口中字符串的哈希值
            int windowHash = 0;

            // 滑动窗口代码框架，时间 O(N)
            int left = 0, right = 0;
            while (right < nums.Length)
            {
                // 扩大窗口，移入字符，并维护窗口哈希值（在最低位添加数字）
                windowHash = R * windowHash + nums[right];
                right++;

                // 当子串的长度达到要求
                if (right - left == L)
                {
                    // 根据哈希值判断是否曾经出现过相同的子串
                    if (seen.Contains(windowHash))
                    {
                        // 当前窗口中的子串是重复出现的
                        if(!res.Contains(s.Substring(left, L)))
                            res.Add(s.Substring(left, L));
                    }
                    else
                    {
                        // 当前窗口中的子串之前没有出现过，记下来
                        seen.Add(windowHash);
                    }
                    // 缩小窗口，移出字符，并维护窗口哈希值（删除最高位数字）
                    windowHash = windowHash - nums[left] * RL;
                    left++;
                }
            }
            // 转化成题目要求的 List 类型
            return res;
        }
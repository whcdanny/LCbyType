//Leetcode 423. Reconstruct Original Digits from English ez
//题目：给定一个字符串 s，它包含了乱序的英文数字拼写（例如 zero 表示数字 0，one 表示数字 1，以此类推）。任务是从字符串中还原这些数字，并按照升序返回数字的字符串形式。
//约束条件
//字符串长度 1 <= s.length <= 10^5。
//字符串中的字符只包括以下字母："e", "g", "f", "i", "h", "o", "n", "s", "r", "u", "t", "w", "v", "x", "z"。
//字符串保证是有效的，即必然可以还原成某些数字的拼写。
//思路: 通过数字拼写中独特的字母特征来还原数字。例如：
//数字 0 的拼写是 zero，其中字母 z 是独一无二的。
//数字 2 的拼写是 two，其中字母 w 是独一无二的。
//数字 4 的拼写是 four，其中字母 u 是独一无二的。
//通过这些独特字母特征，我们可以依次确定数字并移除已处理的字母。
//提取顺序
//按照独特字母的特性，提取数字的顺序如下：
//提取包含唯一字母的数字：
//0(z)、2(w)、4(u)、6(x)、8(g)
//提取依赖其他数字的非唯一字母：
//3(h，需要减去 8 的贡献)
//5(f，需要减去 4 的贡献)
//7(s，需要减去 6 的贡献)
//1(o，需要减去 0、2、4 的贡献)
//9(i，需要减去 5、6、8 的贡献)
//时间复杂度：O(n + k)
//空间复杂度：O(k)
        public string OriginalDigits(string s)
        {
            // 统计每个字母的出现次数
            int[] count = new int[26];
            foreach (char c in s)
            {
                count[c - 'a']++;
            }

            // 数组 nums 用于记录每个数字的出现次数
            int[] nums = new int[10];

            // 提取独特字母的数字
            nums[0] = count['z' - 'a']; // "zero"
            nums[2] = count['w' - 'a']; // "two"
            nums[4] = count['u' - 'a']; // "four"
            nums[6] = count['x' - 'a']; // "six"
            nums[8] = count['g' - 'a']; // "eight"

            // 提取非独特字母的数字
            nums[3] = count['h' - 'a'] - nums[8]; // "three"
            nums[5] = count['f' - 'a'] - nums[4]; // "five"
            nums[7] = count['s' - 'a'] - nums[6]; // "seven"
            nums[1] = count['o' - 'a'] - nums[0] - nums[2] - nums[4]; // "one"
            nums[9] = count['i' - 'a'] - nums[5] - nums[6] - nums[8]; // "nine"

            // 根据 nums 数组生成结果字符串
            string res = "";
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < nums[i]; j++)
                {
                    res+=i.ToString();
                }
            }

            return res;
        }
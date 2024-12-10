//791. Custom Sort String med
//题目：给定两个字符串 order 和 s：
//字符串 order 的所有字符都是唯一的，并且已经按照自定义顺序进行了排序。
//将字符串 s 的字符重新排列，使其符合 order 中字符的排列顺序。
//具体来说，如果字符 x 在 order 中出现在字符 y 之前，那么在重新排列后的字符串中，x 也应该出现在 y 之前。
//返回一个符合条件的任意排列。
//思路：统计字符串 s 中字符的频率
//使用一个哈希表 frequency 统计 s 中每个字符的出现次数。
//按照 order 的顺序重建字符串
//遍历 order 中的每个字符，如果该字符存在于 frequency 中，将其按频率添加到结果字符串中。
//追加 order 中未出现的字符
//遍历 frequency 中剩余的字符（即 order 中没有指定顺序的字符），将它们按频率追加到结果字符串中。
//时间复杂度:  O(order+s)
//空间复杂度： O(s)
        public string CustomSortString(string order, string s)
        {
            // 统计 s 中每个字符的频率
            var frequency = new Dictionary<char, int>();
            foreach (var c in s)
            {
                if (!frequency.ContainsKey(c))
                {
                    frequency[c] = 0;
                }
                frequency[c]++;
            }

            // 按照 order 的顺序构造结果字符串
            var result = new StringBuilder();
            foreach (var c in order)
            {
                if (frequency.ContainsKey(c))
                {
                    for (int i = 0; i < frequency[c]; i++)
                    {
                        result.Append(c);
                    }
                    frequency.Remove(c); // 删除已处理的字符
                }
            }

            // 追加 order 中未出现的字符
            foreach (var kvp in frequency)
            {
                for (int i = 0; i < kvp.Value; i++)
                {
                    result.Append(kvp.Key);
                }
            }

            return result.ToString();
        }
//Leetcode 880. Decoded String at Index med
//题意：给定一个编码字符串 s，你需要按照以下规则解码字符串，并返回解码后字符串的第 k 个字符（1 索引）：
//如果读取到的字符是字母，则将该字母直接写入磁带。
//如果读取到的字符是数字 d，则将当前磁带上的所有内容重复写入 d-1 次。
//注意：解码字符串的长度可能非常大，而 k 是给定的，因此无法真正构建完整的解码字符串，需要通过逻辑推导实现结果。
//思路：由于解码字符串可能非常长，直接构造整个字符串会导致性能和空间超限。
//因此，需要采用 反向推导 来定位结果：
//先计算解码字符串的长度：
//遍历字符串 s，模拟解码过程，计算解码字符串的总长度。
//遇到字母时，长度加一；遇到数字 d 时，将长度乘以 d。
//反向定位字符：
//从后向前遍历字符串，通过反推 k 的位置找到结果：
//如果当前字符是数字，则将长度缩小为原来的 length /= c - '0'; 
//注：k = (int)((k - 1) % length + 1); // 更新 k 的位置;
//如果当前字符是字母，则检如果 k 为 0 或与长度相等，则找到目标字符。如果不是移动到前一个字符length--；        
//时间复杂度：O(n)
//空间复杂度：O(1)
        public string DecodeAtIndex(string s, int k)
        {
            long length = 0;

            // 1. 计算解码字符串的总长度
            foreach (char c in s)
            {
                if (char.IsDigit(c))
                {
                    length *= c - '0'; // 字符对应的数字
                }
                else
                {
                    length++; // 字母直接增加长度
                }
            }

            // 2. 反向推导
            for (int i = s.Length - 1; i >= 0; i--)
            {
                char c = s[i];
                if (char.IsDigit(c))
                {
                    // 缩小长度范围
                    length /= c - '0';
                    k = (int)((k - 1) % length + 1); // 更新 k 的位置
                }
                else
                {
                    // 如果 k 为 0 或与长度相等，则找到目标字符
                    if (k == 0 || k == length)
                    {
                        return c.ToString();
                    }

                    length--; // 移动到前一个字符
                }
            }

            return "";
        }
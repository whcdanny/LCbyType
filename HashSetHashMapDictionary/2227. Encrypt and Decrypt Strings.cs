//Leetcode 2227. Encrypt and Decrypt Strings hard
//题意：给定一个字符数组 keys 包含唯一字符和一个字符串数组 values 包含长度为2的字符串。
//还给出一个字符串数组 dictionary，其中包含解密后允许的所有原始字符串。你需要实现一个数据结构，可以加密或解密一个从0开始的字符串。
//加密一个字符串的过程如下：
//对于字符串中的每个字符 c，我们在 keys 中找到满足 keys[i] == c 的索引 i。
//用 values[i] 替换字符串中的 c。
//注意，在字符串的字符不在 keys 中时，无法进行加密过程，返回空字符串 ""。
//解密一个字符串的过程如下：
//对于字符串中的每个长度为2的子串 s，出现在偶数索引处，我们找到一个 i，满足 values[i] == s。
//如果有多个有效的 i，我们选择其中任意一个。这意味着一个字符串可以有多个可能的解密字符串。
//用 keys[i] 替换字符串中的 s。
//要求实现 Encrypter 类：
//Encrypter(char[] keys, String[] values, String[] dictionary)：使用 keys、values 和 dictionary 初始化 Encrypter 类。
//String encrypt(String word1)：对 word1 使用上述加密过程加密，并返回加密后的字符串。
//int decrypt(String word2)：返回 word2 可能解密到的在 dictionary 中也出现的字符串数量。
//思路：hashtable 对于加密 - 因为对于 key[i] 中存在的字符串“c”中的每个字符，
//我们需要获取 value[i]，我们将构建一个字典，将每个 key[i] 映射到 valeus[i]，
//以便我们可以获得关联的值每个关键字符的复杂度为 O(1)。
//对于解密 - 由于我们需要在有效的“字典”数组中找到可能的字符串，我们可以对其进行加密以获得当前正在尝试解密的字符串，
//因此我们可以简单地加密“字典”数组中已提供的所有可能/有效的字符串，并查看其中有多少字符串可以映射到相同的加密结果（我们当前正在尝试解密）
//对于这两个步骤，由于我们需要构建字典，因此我们执行构造函数中所需的预计算步骤。
//时间复杂度：Constructor/Pre-processing O(D*N) D是字典中的单词数，N是单词中的最大字符数. Encrypt - O(N) Decrypt - O(1)
//空间复杂度：Constructor/Pre-processing O(D) Encrypt O(N) Decrypt - O(1)
        public class Encrypter
        {
            char[] keys;
            string[] values;
            string[] dictionary;

            //for encrypt
            Dictionary<char, string> keyMap;

            //for decrypt
            Dictionary<string, int> valueMap;

            public Encrypter(char[] keys, string[] values, string[] dictionary)
            {
                this.keys = keys;
                this.values = values;
                this.dictionary = dictionary;

                keyMap = new Dictionary<char, string>();
                for (int i = 0; i < keys.Length; i++)
                    keyMap[keys[i]] = values[i];

                valueMap = new Dictionary<string, int>();
                for (int i = 0; i < dictionary.Length; i++)
                {
                    string str = Encrypt(dictionary[i]);
                    if (!valueMap.ContainsKey(str))
                    {
                        valueMap.Add(str, 1);
                    }
                    else
                    {
                        valueMap[str]++;
                    }
                }
            }

            public string Encrypt(string word1)
            {
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < word1.Length; i++)
                {
                    if (keyMap.TryGetValue(word1[i], out string str))
                    {
                        sb.Append(str);
                    }
                    else
                    {
                        return "";
                    }
                }

                return sb.ToString();
            }

            public int Decrypt(string word2)
            {
                if (valueMap.TryGetValue(word2, out int result))
                    return result;
                else
                    return 0;
            }
        }
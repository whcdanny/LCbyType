//Leetcode 2697. Lexicographically Smallest Palindrome ez
//题意：给定一个由小写英文字母组成的字符串 s，允许对其进行操作。每次操作，可以将 s 中的一个字符替换为另一个小写英文字母。
//任务是通过尽可能少的操作，使 s 成为回文串。如果有多个回文串可以通过最小操作数得到，要求返回字典序最小的一个。
//字符串 a 在字典序上小于字符串 b（长度相同），如果在它们第一次不相等的位置上，a 的字母在字母表中出现的顺序较早。       
//思路：左右针， 字符串的两端向中间遍历。
//当 chars[i] != chars[j] 时，将较大的字符替换为较小的字符，使字符串尽可能小。这样可以保证得到的回文串是字典序最小的。
//时间复杂度: O(n)，其中 n 为字符串长度。遍历字符串一次。
//空间复杂度：O(n)
        public string MakeSmallestPalindrome(string s)
        {
            char[] chars = s.ToCharArray();
            int n = chars.Length;

            for (int i = 0, j = n - 1; i < j;)
            {
                if (chars[i] != chars[j])
                {
                    // 将较大的字符替换为较小的字符，使字符串尽可能小
                    chars[j] = (char)Math.Min(chars[i], chars[j]);
                    chars[i] = chars[j];
                }
                i++;
                j--;
            }

            return new string(chars);
        }
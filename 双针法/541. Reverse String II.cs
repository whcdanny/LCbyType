//Leetcode 541. Reverse String II ez
//题意：给定一个字符串 s 和一个整数 k，要求对字符串进行一定规律的反转操作。具体规则是，每隔 2k 个字符，对前 k 个字符进行反转。
//如果剩余的字符少于 k 个，将剩余的字符全部反转；如果剩余的字符在 k 到 2k 之间，则反转前 k 个字符，剩余的保持原样。
//思路：双指针，将字符串转换为字符数组 charArray。
//从左到右遍历字符串，每次跳过 2k 个字符，对前 k 个字符进行反转。
//在反转的过程中，使用两个指针 left 和 right 分别指向当前反转范围的首尾字符，交换它们的位置。
//如果剩余字符不足 k 个，则反转剩余字符；如果剩余字符在 k 到 2k 之间，则反转前 k 个字符，剩余字符保持原样。
//时间复杂度：O(n)，其中 n 是字符串的长度
//空间复杂度：O(1)
        public string ReverseStr(string s, int k)
        {
            char[] charArray = s.ToCharArray();
            int n = charArray.Length;

            for (int i = 0; i < n; i += 2 * k)
            {
                int left = i;
                int right = Math.Min(i + k - 1, n - 1);

                // 反转前 k 个字符
                while (left < right)
                {
                    char temp = charArray[left];
                    charArray[left] = charArray[right];
                    charArray[right] = temp;
                    left++;
                    right--;
                }
            }

            return new string(charArray);
        }
//Leetcode 443. String Compression ez
//题意：对字符数组进行压缩的算法。给定一个字符数组 chars，使用以下算法进行压缩：
//从一个空字符串 s 开始。对于 chars 中的每组连续重复字符：
//如果组的长度为 1，则将字符追加到 s。
//否则，将字符后面跟着组的长度追加到 s。
//压缩后的字符串 s 不需要单独返回，而是存储在输入字符数组 chars 中。注意，长度为 10 或更长的组将在 chars 中拆分成多个字符。
//在修改输入数组后，返回数组的新长度。
//你必须使用仅使用常数额外空间的算法。
//思路：双指针，两个指针 index 和 i 分别表示当前写入的位置和当前处理的字符位置。
//在循环中，取得当前字符 currentChar 并统计其连续重复次数 count。
//将当前字符写入数组，并如果重复次数大于 1，则将重复次数转为字符后写入数组。
//循环直到处理完整个字符数组。
//返回新数组的长度 index。
//时间复杂度：O(n)，其中 n 是数组的长度
//空间复杂度：O(1)
        public int Compress(char[] chars)
        {
            int index = 0; // 当前写入的位置
            int i = 0; // 当前处理的字符位置

            while (i < chars.Length)
            {
                char currentChar = chars[i];
                int count = 0;

                // 统计当前字符的连续重复次数
                while (i < chars.Length && chars[i] == currentChar)
                {
                    i++;
                    count++;
                }

                // 写入当前字符及其重复次数
                chars[index++] = currentChar;
                if (count > 1)
                {
                    foreach (char c in count.ToString())
                    {
                        chars[index++] = c;
                    }
                }
            }

            return index; // 返回新数组的长度
        }
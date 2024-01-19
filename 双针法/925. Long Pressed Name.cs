//Leetcode 925. Long Pressed Name ez
//题意：有一个键盘，你的朋友正在键入他的名字。有时，当键入字符 c 时，可能会长按键，导致字符被键入 1 次或多次。
//你检查键盘的键入字符。如果可能是你朋友的名字，并且一些字符（可能没有）是长按的话，返回 True。
//思路：双指针，两个指针，一个指针遍历输入的 name，另一个指针遍历输入的 typed。比较当前两个指针指向的字符，如果相同，两个指针都向前移动，如果不同，只有 typed 的指针向前移动。
//检查 name 的每个字符是否满足以下条件：
//当前字符和 typed 的字符相等，或
//当前字符和前一个 typed 的字符相等（表示长按）。
//时间复杂度：O(n + m)，其中 n 和 m 分别是 name 和 typed 的长度
//空间复杂度：O(1)
        public bool IsLongPressedName(string name, string typed)
        {
            int i = 0, j = 0;

            while (j < typed.Length)
            {
                if (i < name.Length && name[i] == typed[j])
                {
                    i++;
                    j++;
                }
                else if (j > 0 && typed[j] == typed[j - 1])
                {
                    j++;
                }
                else
                {
                    return false;
                }
            }

            return i == name.Length;
        }
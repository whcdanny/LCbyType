//Leetcode 316. Remove Duplicate Letters, 1081. Smallest Subsequence of Distinct Characters med
//题意：给定一个字符串 s，要求返回一个字典序最小的子序列，该子序列包含 s 中所有不同的字符，且每个字符只能出现一次。
//注：不能改变s本身顺序；
//思路：stack, 栈来实现。首先统计字符串 s 中每个字符出现的次数，并用一个数组记录下来。
//做一个bool[] 来时刻监视是否有char已经用过了；
//遍历字符串 s，对于每个字符，若它已经在栈中，则跳过；
//否则，将它与栈顶元素比较，如果栈顶元素比当前字符大且后面还会出现， 
//并且当前元素假如被pop，还有剩余个数，则将栈顶元素弹出，直至栈为空或栈顶元素比当前字符小，然后将当前字符入栈。
//遍历结束后，栈中的元素即为所求子序列。
//时间复杂度: 遍历字符串 s 需要 O(n) 的时间，每个字符入栈和出栈的操作的总时间复杂度为 O(n)，因此总的时间复杂度为 O(n)。
//空间复杂度：除了存储结果子序列的栈外，还需要一个数组来记录每个字符出现的次数。因此，空间复杂度为 O(n)
        public string SmallestSubsequence(string s)
        {
            int[] count = new int[26];
            bool[] used = new bool[26];
            Stack<char> stack = new Stack<char>();

            // 统计每个字符的出现次数
            foreach (char c in s)
            {
                count[c - 'a']++;
            }

            foreach (char c in s)
            {
                count[c - 'a']--;

                if (used[c - 'a']) continue;

                while (stack.Count > 0 && stack.Peek() > c && count[stack.Peek() - 'a'] > 0)
                {
                    used[stack.Pop() - 'a'] = false;
                }

                stack.Push(c);
                used[c - 'a'] = true;
            }

            StringBuilder sb = new StringBuilder();
            while (stack.Count > 0)
            {
                sb.Insert(0, stack.Pop());
            }

            return sb.ToString();
        }

//Leetcode 2030. Smallest K-Length Subsequence With Occurrences of a Letter hard
//题意：给定一个字符串s，一个整数k，一个字母letter，和一个整数repetition。要求找出字符串s的一个长度为k的最小字典序的子序列，使得子序列中字母letter至少出现repetition次。
//思路：Stack, 构造一个单调递增的stack，如果加入的小于stack上面的弹出，把小的请到前面，
//这里要注意两个count，一个是可以删除的数量s.Length - k，可以删除特定的letter的数量是s种letter的数量-repetition；
//时间复杂度：O(n)
//空间复杂度：O(k)
        public string SmallestSubsequence(string s, int k, char letter, int repetition)
        {
            int k0 = s.Length - k;
            int count = 0;
            foreach (char ch in s)
            {
                if (ch == letter) 
                    count++;
            }
            int k1 = count - repetition;

            int count0 = 0; //the total number of letters deleted
            int count1 = 0; // the total number of "letter" deleted

            Stack<char> stack = new Stack<char>();
            foreach (char c in s)
            {
                while (stack.Count > 0 && c < stack.Peek() && count0 < k0 && (stack.Peek() != letter || (stack.Peek() == letter && count1 < k1)))
                {
                    if (stack.Peek() == letter)
                        count1++;
                    count0++;
                    stack.Pop();
                }
                stack.Push(c);
            }
            //stack里是倒着的，输入到result
            StringBuilder result = new StringBuilder();
            while (stack.Count > 0)
            {
                result.Append(stack.Pop());
            }
            
            StringBuilder ans = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                //删不了了，special也没有了
                if (count0 == k0 || (result[i] == letter && count1 == k1))
                    ans.Append(result[i]);
                else
                {
                    //剩下的删掉
                    count0++;
                    if (result[i] == letter)
                        count1++;
                }
            }
            result.Clear();
            //然后再反转；
            for (int i = ans.Length - 1; i >= 0; i--)
            {
                result.Append(ans[i]);
            }
            return result.ToString();
        }
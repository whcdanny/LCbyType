//Leetcode 2116. Check if a Parentheses String Can Be Valid med
//题意：判断给定的括号字符串是否可以通过修改其中的字符成为一个有效的括号字符串。给定的括号字符串s由'('和')'组成，有效的括号字符串有以下条件之一：
//它是空字符串"()"。
//它可以写成AB的形式，其中A和B是有效的括号字符串。
//它可以写成(A)的形式，其中A是有效的括号字符串。
//另外，还给定了一个字符串locked，长度为n，其中：
//如果locked[i] 为'1'，则不能修改s的第i个字符。
//如果locked[i] 为'0'，则可以将s的第i个字符修改为'('或')'。
//如果能够通过修改字符使得s成为有效的括号字符串，则返回true，否则返回false。
//思路：Stack, 两个stack，分别存入free的和(区间的，
//这样当我们历遍s的时候，只要遇到)区间，那么就先看(区间的stack是否不为空，pop，如果没有，就看free的是否不为空，然后pop，如果都没有，false；
//注：结束上面的历遍之和，要注意此时两个stack如果还都不为空，那么(的位置大于free说明，就算有free的位置也是)(这种情况没办法闭合所以false；
//如果free为空而(区间不为空，也是false，如果(区间为空，而free的剩余不是偶数，也是false，因为无法满足闭合；
//时间复杂度：O(n)
//空间复杂度：O(n)
        public bool CanBeValid(string s, string locked)
        {
            Stack<int> open = new Stack<int>();
            Stack<int> free = new Stack<int>();

            for (int i = 0; i < s.Length; i++)
            {
                if (locked[i] == '0')
                    free.Push(i);

                else if (s[i] == '(')
                    open.Push(i);

                else if (s[i] == ')' && open.Count!=0)
                    open.Pop();

                else if (s[i] == ')' && free.Count!=0)
                    free.Pop();
                else                      
                    return false;                
            }

            while (open.Count>0 && free.Count>0)
            {
                if (open.Peek() > free.Peek())
                    return false;

                open.Pop();
                free.Pop();
            }

            if (open.Count>0)
                return false;

            if (free.Count % 2 != 0)
                return false;

            return true;
        }
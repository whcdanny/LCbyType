//Leetcode 2645. Minimum Additions to Make Valid String med
//题意：给定一个字符串word，你可以在任何位置插入字母"a"、"b"或"c"，任意次数。返回必须插入的最小字母数，使得word变为有效字符串。
//一个字符串被称为有效字符串，如果它可以通过多次连接字符串"abc"而形成。
//思路：Stack; 用stack来存char，
//如果当前是a，那么就看stack是否为空，如果是空的，那么直接加入a，如果不为空，那么就说明已经有值，无论是什么，abc总长就是3，所以用count+=3-stak的个数(bc,c)；
//如果当前是b, 那么就看stack是否为空，如果是空的，直接加入a,b，如果不为空，那么就看上一个是否为a，是a，直接加b，如果是b，那么count+=1(c);
//如果当前为c，那么不用考虑是否为空，count+=2-stak的个数(ab,b)
//时间复杂度：O(n)，其中n为字符串word的长度，因为需要遍历整个字符串。
//空间复杂度：O(n)，最坏情况下，栈的大小为字符串word的长度。
        public int AddMinimum(string word)
        {
            var count = 0;
            var stack = new Stack<char>();
            foreach (var c in word)
            {
                if (c == 'a')
                {
                    if (stack.Count > 0)
                    {
                        count += (3 - stack.Count);
                        stack.Clear();
                    }

                    stack.Push('a');
                }
                else if (c == 'b')
                {
                    if (stack.Count > 0 && stack.Peek() == 'a')
                        stack.Push('b');
                    else
                    {
                        if (stack.Count > 0 && stack.Peek() == 'b')
                        {
                            count += 1;
                            stack.Clear();
                        }

                        count += 1;
                        stack.Push('a');
                        stack.Push('b');
                    }
                }
                else
                {
                    count += (2 - stack.Count);
                    stack.Clear();
                }
            }

            if (stack.Count > 0)
                count += (3 - stack.Count);

            return count;
        }
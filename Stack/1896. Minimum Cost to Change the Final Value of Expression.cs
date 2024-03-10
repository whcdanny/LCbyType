//Leetcode 1896. Minimum Cost to Change the Final Value of Expression hard
//题意：给定一个有效的布尔表达式，由字符 '1', '0', '&', '|', '(', ')' 组成。例如，"()1|1" 和 "(1)&()" 不是有效表达式，而 "1", "(((1))|(0))", 和 "1|(0&(1))" 是有效表达式。
//返回将表达式的最终值改变为 0 所需的最小代价。
//表达式的最终值改变代价定义如下：
//将 '1' 变为 '0' 的代价为 1。
//将 '0' 变为 '1' 的代价为 1。
//将 '&' 变为 '|' 的代价为 1。
//将 '|' 变为 '&' 的代价为 1。
//注意：'&' 在计算顺序中不优先于 '|'。先计算括号内的表达式，然后从左到右依次计算。
//思路：Stack, 维护两个栈，当遇到左括号时，以往的结果都要暂存，故将当前的变量cur和op压入栈中。
//我们reset这两个变量，标记cur=-1, op='#'，“虚拟地”表示这是一个起始点。我们规定cur # nxt = nxt.
//维护两个变量，cur来存放当前已经eval的数值，op来存放当前待操作的逻辑运算。当我们遇到下一个数值nxt的时候，就可以进行操作cur op nxt，然后将结果用来更新cur。
//注：这里如何算改变的可能性
// 1. 1|1，需要翻转一个数字，同时翻转运算符 
// 2. 0|0，需要翻转一个数字
// 3. 0|1，需要翻转运算符
// 4. 1&1，需要翻转一个数字
// 5. 0&0，需要翻转一个数字，同时翻转运算符 
// 6. 0&1，需要翻转运算符
//时间复杂度：O(n)，其中 n 是表达式的长度。
//空间复杂度：O(n)。
        public int MinOperationsToFlip(string expression)
        {

            //相当于一个二叉树，就算递归调用
            Stack<(int, int)> stack1 = new Stack<(int, int)>(); // {val, # of operations to flip this value}
            Stack<char> stack2 = new Stack<char>();
            (int, int) cur = (-1, -1);
            char op = '#';

            foreach (char ch in expression)
            {
                if (ch == '&' || ch == '|')
                    op = ch;
                else if (ch == '0' || ch == '1')
                {
                    (int, int) nxt = (ch - '0', 1);
                    int val = EvalVal(op, cur, nxt);
                    int flip = EvalFlip(op, cur, nxt);
                    cur = (val, flip);
                }
                else if (ch == '(')
                {
                    stack1.Push(cur);
                    stack2.Push(op);
                    cur = (-1, -1);
                    op = '#';
                }
                else
                {
                    var last = stack1.Pop();
                    char operation = stack2.Pop();

                    int val = EvalVal(operation, last, cur);
                    int flip = EvalFlip(operation, last, cur);
                    cur = (val, flip);
                }
            }

            return cur.Item2;
        }
        
        public int EvalVal(char op, (int, int) a, (int, int) b)
        {
            if (op == '#')
                return b.Item1;
            else if (op == '&')
                return a.Item1 & b.Item1;
            else
                return a.Item1 | b.Item1;
        }
        
        public int EvalFlip(char op, (int, int) a, (int, int) b)
        {
            if (op == '#')
                return b.Item2;
            else if (op == '&')
            {
                //
                if (a.Item1 + b.Item1 == 2)
                    return Math.Min(a.Item2, b.Item2);
                else if (a.Item1 + b.Item1 == 1)
                    return 1;
                else
                    return Math.Min(a.Item2, b.Item2) + 1;
            }
            else
            {
                if (a.Item1 + b.Item1 == 2)
                    return Math.Min(a.Item2, b.Item2) + 1;
                else if (a.Item1 + b.Item1 == 1)
                    return 1;
                else
                    return Math.Min(a.Item2, b.Item2);
            }
        }
        public int MinOperationsToFlip1(string expression)
        {
            Stack<Tuple<int, int>> s1 = new Stack<Tuple<int, int>>(); // {val, # of operations to flip this value}
            Stack<char> s2 = new Stack<char>();
            Tuple<int, int> cur = new Tuple<int, int>(-1, -1);
            char op = '#';

            foreach (char ch in expression)
            {
                if (ch == '&' || ch == '|')
                    op = ch;
                else if (ch == '0' || ch == '1')
                {
                    Tuple<int, int> nxt = new Tuple<int, int>(ch - '0', 1);
                    int val = EvalVal(op, cur, nxt);
                    int flip = EvalFlip(op, cur, nxt);
                    cur = new Tuple<int, int>(val, flip);
                }
                else if (ch == '(')
                {
                    s1.Push(cur);
                    s2.Push(op);
                    cur = new Tuple<int, int>(-1, -1);
                    op = '#';
                }
                else
                {
                    var last = s1.Pop();
                    char operation = s2.Pop();

                    int val = EvalVal(operation, last, cur);
                    int flip = EvalFlip(operation, last, cur);
                    cur = new Tuple<int, int>(val, flip);
                }
            }

            return cur.Item2;
        }

        public int EvalVal(char op, Tuple<int, int> a, Tuple<int, int> b)
        {
            if (op == '#')
                return b.Item1;
            else if (op == '&')
                return a.Item1 & b.Item1;
            else
                return a.Item1 | b.Item1;
        }

        public int EvalFlip(char op, Tuple<int, int> a, Tuple<int, int> b)
        {
            if (op == '#')
                return b.Item2;
            else if (op == '&')
            {
                if (a.Item1 + b.Item1 == 2)
                    return Math.Min(a.Item2, b.Item2);
                else if (a.Item1 + b.Item1 == 1)
                    return 1;
                else
                    return Math.Min(a.Item2, b.Item2) + 1;
            }
            else
            {
                if (a.Item1 + b.Item1 == 2)
                    return Math.Min(a.Item2, b.Item2) + 1;
                else if (a.Item1 + b.Item1 == 1)
                    return 1;
                else
                    return Math.Min(a.Item2, b.Item2);
            }
        }
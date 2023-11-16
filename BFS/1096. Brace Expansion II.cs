//Leetcode 1096. Brace Expansion II hard
//题意：根据下面给出的语法，字符串可以表示一组小写单词。让 R(expr) 表示表达式所代表的单词集。
        /*通过简单的例子可以最好地理解语法：
        单个字母代表包含该单词的单例集。
        R("a") = {"a"}
        R("w") = {"w"}
        当我们采用两个或多个表达式的逗号分隔列表时，我们采用可能性的并集。
        R("{a,b,c}") = {"a","b","c"}
        R("{{a,b},{b,c}}") = {"a","b","c"}（注意最终集合只包含每个单词最多一次）
        当我们连接两个表达式时，我们获取两个单词之间可能的连接集合，其中第一个单词来自第一个表达式，第二个单词来自第二个表达式。
        R("{a,b}{c,d}") = {"ac","ad","bc","bd"}
        R("a{b,c}{d,e}f{g,h}") = {"abdfg", "abdfh", "abefg", "abefh", "acdfg", "acdfh", "acefg", "acefh"}
        正式来说，我们语法的三个规则：
        对于每个小写字母x，我们都有R(x) = {x}.
        对于的表达式，我们有e1, e2, ... , ek k >= 2 R({ e1, e2, ...}) = R(e1) ∪ R(e2) ∪ ...
        对于表达式和，我们有，其中表示串联，表示笛卡尔积。e1,e2 R(e1 + e2) = {a + b for (a, b) in R(e1) × R(e2)}+×
        给定一个表示给定语法下的一组单词的表达式，返回该表达式表示的单词的排序列表。*/
//思路：BFS（广度优先搜索），存入每个expression 然后根据规则找到{，}，然后找到{直接的char}，建立新的string，然后以此类推；最后找到头；
//时间复杂度: O(N * 2^M)，其中 N 是表达式的长度，M 是表达式中括号的个数。在处理表达式时，需要考虑括号的笛卡尔积，因此最坏情况下需要遍历所有的组合，导致时间复杂度为指数级别。
//空间复杂度：O(N * 2^M)，主要用于存储字符串集合的队列。在最坏情况下，每个括号内都可能有 2 个字符串，存在 2^M 个括号，因此空间复杂度为指数级别。
        public List<string> BraceExpansionII(string expression)
        {
            HashSet<string> visited = new HashSet<string>();
            List<string> tt = new List<string>();
            Queue<string> queue = new Queue<string>();
            queue.Enqueue(expression);

            while (queue.Count>0)
            {
                string temp = queue.Dequeue();
                if (tt.Contains(temp))
                    continue;
                tt.Add(temp);
                int left = -1, right = 0;
                while (right < temp.Length && temp.ElementAt(right) != '}')
                {
                    if (temp.ElementAt(right) == '{')
                    {
                        left = right;
                    }
                    right++;
                }
                if (left == -1)
                {
                    visited.Add(temp);
                    continue;
                }
                string start = temp.Substring(0, left);
                string end = temp.Substring(right+1, temp.Length-1-right);

                string[] words = temp.Substring(left + 1, right-left-1).Split(",");
                foreach (string w in words)
                {
                    queue.Enqueue(new StringBuilder().Append(start).Append(w).Append(end).ToString());                    
                }
            }

            List<string> list = visited.ToList();
            list.Sort();
            return list;
        }
//Leetcode 726. Number of Atoms hard
//题意：给定一个表示化学式的字符串 formula，返回每个原子的数量。
//化学元素始终以大写字符开头，然后是零个或多个小写字母，表示元素的名称。
//如果元素的数量大于 1，则可能跟随一个或多个表示该元素数量的数字。如果数量为 1，则不会跟随数字。
//例如，"H2O" 和 "H2O2" 是可能的，但 "H1O2" 是不可能的。
//两个化学式可以连接在一起以产生另一个化学式。
//例如，"H2O2He3Mg4" 也是一个化学式。
//化学式放在括号中，然后是一个计数（可选）也是一个化学式。
//例如，"(H2O2)" 和 "(H2O2)3" 都是化学式。
//要求以以下形式的字符串返回所有元素的数量：
//第一个名称（按字母顺序排列），后跟其数量（如果该数量大于 1），后跟第二个名称（按字母顺序排列），后跟其数量（如果该数量大于 1），依此类推。
//思路：Stack 用栈来处理括号，将每个化学式视为一个子问题，递归求解。
//遍历化学式字符串，遇到大写字母表示一个新的原子开始，然后依次获取原子名和数量。
//使用哈希表来存储每个原子的数量，最后按照字母顺序将原子名和数量组合成字符串返回
//时间复杂度：O(n)，n 为化学式的长度
//空间复杂度：O(n) 
        public string CountOfAtoms(string formula)
        {
            Stack<Dictionary<string, int>> stack = new Stack<Dictionary<string, int>>();
            Dictionary<string, int> current = new Dictionary<string, int>();
            int i = 0, n = formula.Length;

            while (i < n)
            {
                if (formula[i] == '(')
                {
                    stack.Push(current);
                    current = new Dictionary<string, int>();
                    i++;
                }
                else if (formula[i] == ')')
                {
                    i++;
                    int num = 0;
                    while (i < n && char.IsDigit(formula[i]))
                    {
                        num = num * 10 + (formula[i] - '0');
                        i++;
                    }
                    num = num == 0 ? 1 : num;

                    Dictionary<string, int> temp = current;
                    current = stack.Pop();
                    foreach (var kvp in temp)
                    {
                        string atom = kvp.Key;
                        int count = kvp.Value;
                        if (current.ContainsKey(atom))
                        {
                            current[atom] += count * num;
                        }
                        else
                        {
                            current.Add(atom, count * num);
                        }
                    }
                }
                else
                {
                    int start = i++;
                    while (i < n && char.IsLower(formula[i]))
                    {
                        i++;
                    }
                    string atom = formula.Substring(start, i - start);

                    int num = 0;
                    while (i < n && char.IsDigit(formula[i]))
                    {
                        num = num * 10 + (formula[i] - '0');
                        i++;
                    }
                    num = num == 0 ? 1 : num;

                    if (current.ContainsKey(atom))
                    {
                        current[atom] += num;
                    }
                    else
                    {
                        current.Add(atom, num);
                    }
                }
            }

            StringBuilder sb = new StringBuilder();
            List<string> atoms = new List<string>(current.Keys);
            atoms.Sort();
            foreach (var atom in atoms)
            {
                sb.Append(atom);
                if (current[atom] > 1)
                {
                    sb.Append(current[atom]);
                }
            }

            return sb.ToString();
        }
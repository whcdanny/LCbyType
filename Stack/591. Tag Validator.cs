//Leetcode 591. Tag Validator hard 
//题意：我们需要实现一个标签验证器，解析给定的代码片段并判断其是否有效。代码片段是有效的，必须满足以下规则：
//代码必须用有效的闭合标签包裹：否则代码无效。闭合标签的格式：
//格式为<TAG_NAME> TAG_CONTENT</TAG_NAME>。
//其中<TAG_NAME> 是起始标签，</TAG_NAME> 是结束标签。
//起始标签和结束标签的 TAG_NAME 必须相同。
//有效的 TAG_NAME：
//仅包含大写字母。长度必须在[1, 9] 之间。
//有效的 TAG_CONTENT：
//可以包含其他有效的闭合标签、CDATA 或任意字符。
//但不能包含不匹配的<、未匹配的起始和结束标签，或无效的闭合标签。
//不匹配的定义：
//< 是不匹配的，如果找不到后续的>。
//如果标签嵌套时未正确闭合，则认为是不匹配的。
//CDATA 的格式：<![CDATA[CDATA_CONTENT]]>。
//CDATA_CONTENT 是<![CDATA[和下一个]]> 之间的内容。
//CDATA 的内容不需要解析，可以看作普通字符。
//思路：该问题属于字符串解析和栈的应用：
//模拟标签的验证过程：
//使用一个栈保存当前打开的标签名称。
//遇到起始标签<TAG_NAME> 时，检查 TAG_NAME 是否符合规则，若符合则入栈。
//遇到结束标签</TAG_NAME> 时，检查是否与栈顶标签匹配，若匹配则出栈，否则无效。
//CDATA 的处理：
//如果遇到<![CDATA[，直接跳过到下一个]]>，内容无需验证。
//边界条件：
//必须以起始标签开始，并以对应的结束标签结束。
//标签嵌套必须平衡，最终栈应该为空。
//标签名称长度及字符范围需符合规则。
//主循环逻辑：
//遍历 code，分情况处理：
//<![CDATA[：跳过 CDATA。
//</：验证结束标签是否匹配栈顶标签。
//<：验证起始标签是否有效，并入栈。
//其他字符直接跳过。
//辅助函数 IsValidTagName：
//检查标签名称的长度是否在 [1, 9] 范围内。
//检查是否仅包含大写字母。
//时间复杂度：O(n)
//空间复杂度：O(m)
        public bool IsValid_591(string code)
        {
            Stack<string> stack = new Stack<string>();
            int i = 0;
            while (i < code.Length)
            {
                if (i > 0 && stack.Count == 0)
                {
                    return false; // 必须以闭合标签包裹
                }

                //if (code.StartsWith("<![CDATA["))
                if (i <= code.Length - 9 && code.Substring(i, 9) == "<![CDATA[")
                {
                    // 处理 CDATA
                    int endCdata = code.IndexOf("]]>", i + 9);
                    if (endCdata == -1) return false; // CDATA 未正确闭合
                    i = endCdata + 3;
                }
                else if (i <= code.Length - 2 && code.Substring(i, 2) == "</")
                {
                    // 处理结束标签
                    int endTag = code.IndexOf(">", i + 2);
                    if (endTag == -1) return false; // 未找到匹配的 >
                    string tagName = code.Substring(i + 2, endTag - i - 2);
                    if (stack.Count == 0 || stack.Pop() != tagName) return false; // 标签不匹配                    
                    i = endTag + 1;
                }
                else if (code[i] == '<')
                {
                    // 处理起始标签
                    int endTag = code.IndexOf(">", i + 1);
                    if (endTag == -1) return false; // 未找到匹配的 >
                    string tagName = code.Substring(i + 1, endTag - i - 1);
                    if (!IsValidTagName(tagName)) return false; // 标签名无效
                    stack.Push(tagName);
                    i = endTag + 1;
                }
                else
                {
                    // 普通字符
                    i++;
                }
            }
            return stack.Count == 0; // 栈为空表示所有标签匹配完成
        }

        private bool IsValidTagName(string tagName)
        {
            if (tagName.Length < 1 || tagName.Length > 9) return false;
            foreach (char c in tagName)
            {
                if (c < 'A' || c > 'Z') return false; // 必须是大写字母
            }
            return true;
        }
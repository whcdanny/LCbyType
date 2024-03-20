//Leetcode 71. Simplify Path med
//题意：给定一个 string path，它是Unix 风格文件系统中文件或目录的绝对路径（以斜杠开头），将其转换为简化的规范路径。'/'
//在 Unix 风格的文件系统中，句点'.'指的是当前目录，双句点'..'指的是上一级目录，任何多个连续的斜杠（即'//'）都被视为单个斜杠'/'。对于此问题，任何其他格式的句点（例如）都'...'被视为文件/目录名称。
//规范路径应具有以下格式：
//该路径以单斜杠开头'/'。
//任何两个目录都用单斜杠分隔'/'。
//该路径不以尾随'/'.
//路径仅包含从根目录到目标文件或目录的路径上的目录（即没有句点'.'或双句点'..'）
//返回简化的规范路径。
//思路：Stack 栈来实现简化路径的操作。
//首先，我们将路径根据 '/' 字符进行分割，得到各个部分。然后，遍历每个部分：
//如果当前部分是空的或者是 '.'，则直接跳过，不做处理；
//如果当前部分是 '..'，则表示要返回上一级目录，此时我们需要将栈顶元素出栈；
//否则，当前部分是目录名，直接入栈。
//最后，我们将栈中的元素依次取出，用 '/' 连接起来，即为简化后的路径。
//时间复杂度: O(n)，其中 n 是路径的长度
//空间复杂度：O(n)
        public string SimplifyPath(string path)
        {
            string[] parts = path.Split('/');
            Stack<string> stack = new Stack<string>();
            foreach (string part in parts)
            {
                if (string.IsNullOrEmpty(part) || part == ".")
                {
                    continue;
                }
                else if (part == "..")
                {
                    if (stack.Count > 0)
                    {
                        stack.Pop();
                    }
                }
                else
                {
                    stack.Push(part);
                }
            }
            string simplifiedPath = "";
            while (stack.Count > 0)
            {
                simplifiedPath = "/" + stack.Pop() + simplifiedPath;
            }
            return string.IsNullOrEmpty(simplifiedPath) ? "/" : simplifiedPath;
        }
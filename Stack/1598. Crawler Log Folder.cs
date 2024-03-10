//Leetcode 1598. Crawler Log Folder ez
//题意：Leetcode 文件系统每次用户执行更改文件夹操作时会记录日志。
//操作如下：
//"../"：移动到当前文件夹的父文件夹。（如果您已经在主文件夹中，则保持在同一文件夹中）。
//"./"：保持在同一文件夹中。
//"x/"：移动到名为 x 的子文件夹。（保证该文件夹始终存在）。
//给定一个字符串列表 logs，其中 logs[i] 是用户在第 i 步执行的操作。
//文件系统从主文件夹开始，然后执行 logs 中的操作。
//返回在更改文件夹操作后返回到主文件夹所需的最小操作次数。
//思路：Stack,"x/"存入文件，如果是"../" 弹出，"./"不做任何操作
//时间复杂度：O(n)，其中 n 为 logs 的长度
//空间复杂度：O(1)
        public int MinOperations(string[] logs)
        {
            Stack<string> stack = new Stack<string>();
            foreach (string log in logs)
            {
                if (log == "./")
                {
                    continue;
                }
                if (log == "../")
                {
                    if (stack.Count > 0)
                        stack.Pop();
                }
                else
                {
                    stack.Push(log);
                }
            }
            return stack.Count;
        }
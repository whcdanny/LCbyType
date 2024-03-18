//Leetcode 388. Longest Absolute File Path med
//题意：假设我们有一个文件系统，其中既存储文件，又存储目录。下面是一个示例文件系统的表示：
 //bash
//Copy code
//    dir
//subdir1
//    file1.ext
//    subsubdir1
//subdir2
//    subsubdir2
//        file2.ext
//在该文件系统中：
//"dir" 是一个目录，包含两个子目录 "subdir1" 和 "subdir2" 。
//"subdir1" 包含一个文件 "file1.ext" 和一个子目录 "subsubdir1" 。
//"subsubdir1" 包含空文件夹。
//"subdir2" 包含一个子目录 "subsubdir2" ，该子目录包含一个文件 "file2.ext" 。
//我们用字符串来表示文件系统，字符串中的每一行表示一个文件或目录。具体来说，字符串的每一行遵循以下两种格式之一：
//"dir\n" 表示一个目录，其中 dir 是目录的名称。
//"dir\n" 表示一个文件，其中 dir 是文件的名称。该文件名包含一个扩展名，即它包含一个或多个字符，后跟一个句点（'.'），后跟一个或多个字母。
//给定一个表示文件系统的字符串，返回文件系统中文件的最长绝对路径的长度。如果系统中不存在文件，则返回 0。
//思路：Stack ，栈来模拟文件系统的层级关系
//我们可以根据每一行的缩进来确定其在文件系统中的层级关系。
//例如，没有缩进的行表示根目录下的文件或目录，有一个缩进的行表示根目录下的一级子目录，以此类推。
//我们可以使用栈来模拟文件系统的层级关系。每次遇到一个文件时，我们将该文件的长度入栈；
//每次遇到一个目录时，我们将该目录的路径长度入栈，并将路径长度更新为当前目录的路径长度加上目录名的长度。
//最终，我们只需要找到栈中的最大值即为文件系统中文件的最长绝对路径的长度。
//时间复杂度：O(n)，其中 n 是字符串的长度
//空间复杂度：O(n)
        public int LengthLongestPath(string input)
        {
            string[] lines = input.Split('\n');
            Stack<int> stack = new Stack<int>();
            int maxLen = 0;

            foreach (string line in lines)
            {
                int level = line.LastIndexOf('\t') + 1; // 计算当前行的缩进级别
                while (stack.Count > level) stack.Pop(); // 将栈中比当前级别高的元素弹出

                int len = (stack.Count == 0 ? 0 : stack.Peek()) + line.Length - level + 1; // 计算当前文件或目录的路径长度
                stack.Push(len); // 将当前文件或目录的路径长度入栈

                if (line.Contains("."))
                { // 如果当前行包含文件
                    maxLen = Math.Max(maxLen, len - 1); // 更新最长绝对路径长度
                }
            }

            return maxLen;
        }
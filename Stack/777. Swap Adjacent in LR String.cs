//Leetcode 777. Swap Adjacent in LR String med
//题意：给定两个字符串start和end，每个字符串由'X'和'L'，'R'组成。你可以通过将'X'从一个位置移到另一个位置来转换start字符串。你的任务是判断是否可以通过一系列移动start转换为end，具体要求是：
//只能将'X'从start移动到end相同位置的位置。
//在移动过程中，不能改变'L'和'R'的相对顺序
//思路：Stack; 用两个stack存入start和end不含X的所以LR， 然后同时pop，如果顺序有不一样的，就是错的
//时间复杂度：O(n)
//空间复杂度：O(n) 
        public bool CanTransform(string start, string end)
        {
            var startStack = new Stack<(char, int)>();
            for (var i = 0; i < start.Length; i++)
                if (start[i] != 'X')
                    startStack.Push((start[i], i));
            var endStack = new Stack<(char, int)>();
            for (var i = 0; i < end.Length; i++)
                if (end[i] != 'X')
                    endStack.Push((end[i], i));
            if (startStack.Count != endStack.Count)
                return false;

            while (startStack.Count > 0)
            {
                var (startCharacter, startIndex) = startStack.Pop();
                var (endCharacter, endIndex) = endStack.Pop();
                if (startCharacter != endCharacter)
                    return false;

                if (startCharacter == 'L' && startIndex < endIndex)
                    return false;

                if (startCharacter == 'R' && startIndex > endIndex)
                    return false;
            }

            return true;
        }
       
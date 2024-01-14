//Leetcode 2337. Move Pieces to Obtain a Strings med
//题意：给定两个长度为 n 的字符串 start 和 target，两个字符串只包含字符 'L', 'R', ''。其中，'L' 和 'R' 表示棋子，'L' 只能向左移动，'R' 只能向右移动，'' 表示空格可以被 'L' 或 'R' 占据。
//目标是判断通过任意次移动 start 字符串中的棋子，是否可以得到 target 字符串。
//思路：左右针，'L' 只能向左移动，'R' 只能向右移动。因此，如果 target 中某个 'L' 的位置在 start 中的 'L' 左边，或者某个 'R' 的位置在 start 中的 'R' 右边，那么无论怎样移动都无法达到 target。        
//时间复杂度: O(n)
//空间复杂度：O(n)
        public bool CanChange(string start, string target)
        {
            if (string.Compare(start, target) == 0) return true;
            if (start.Length != target.Length) return false;
            // 获取 'L' 和 'R' 的位置
            List<int> startL = new List<int>();
            List<int> startR = new List<int>();
            List<int> targetL = new List<int>();
            List<int> targetR = new List<int>();
            StringBuilder str1 = new StringBuilder("");
            StringBuilder str2 = new StringBuilder("");
            for (int i = 0; i < start.Length; i++)
            {
                if (start[i] == 'L')
                {
                    startL.Add(i);
                    str1.Append("L");
                }
                else if (start[i] == 'R')
                {
                    startR.Add(i);
                    str1.Append("R");
                }
            }
            for (int i = 0; i < target.Length; i++) 
            { 
                if (target[i] == 'L')
                {
                    targetL.Add(i);
                    str2.Append("L");
                }
                else if (target[i] == 'R')
                {
                    targetR.Add(i);
                    str2.Append("R");
                }
            }
            if (string.Compare(str1.ToString(), str2.ToString()) != 0) return false;
            // 判断 'L' 的位置是否满足移动要求
            for (int i = 0; i < startL.Count; i++)
            {
                if (startL[i] < targetL[i])
                {
                    return false;
                }
            }

            // 判断 'R' 的位置是否满足移动要求
            for (int i = 0; i < startR.Count; i++)
            {
                if (startR[i] > targetR[i])
                {
                    return false;
                }
            }

            return true;
        }
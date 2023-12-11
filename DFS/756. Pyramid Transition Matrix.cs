//Leetcode 756. Pyramid Transition Matrix med
//题意：给定金字塔的底层，金字塔中的每个砖块表示一个字母。两个砖块可以堆叠在一起，但是只有当下面的两个砖块是相邻的并且上面的砖块的字母是下面两个砖块字母的前两个字母之一时，它们才能堆叠在一起。问是否能从顶层到底层堆叠所有的砖块。
//思路：回溯我们构建了一个字典 allowedMap，用于存储底层两个字母能够组合成的上层字母的可能性。接着，我们使用递归的方式，从底层开始，逐层尝试所有可能的组合，直到达到金字塔的顶部。在递归的过程中，我们检查当前层的每一种可能性，如果能够成功组合成上一层，则继续递归到下一层。
//注：说白了只要能找到两个字母在map，就可以找到新一行string的一个，然后依此找到，直到找到当前层的string结束，这样就往上一层，依此直到最高点；
//时间复杂度: 在最坏情况下，我们可能需要尝试每一种可能的组合，直到达到金字塔的顶部。设金字塔的高度为 h，则最坏情况下的时间复杂度为 O(3^h)。
//空间复杂度：空间复杂度主要取决于 allowedMap 和递归调用的深度。allowedMap 的大小受到输入参数的限制，可以认为是常数。而递归调用的深度取决于金字塔的高度，即 O(h)
        public bool PyramidTransition(string bottom, IList<string> allowed)
        {
            Dictionary<string, HashSet<char>> allowedMap = new Dictionary<string, HashSet<char>>();

            foreach (var allow in allowed)
            {
                string key = allow.Substring(0, 2);
                if (!allowedMap.ContainsKey(key))
                {
                    allowedMap[key] = new HashSet<char>();
                }
                allowedMap[key].Add(allow[2]);
            }

            return CanBuildTop(bottom, allowedMap);
        }

        private bool CanBuildTop(string bottom, Dictionary<string, HashSet<char>> allowedMap)
        {
            if (bottom.Length == 1)
            {
                return true; // Reach the top of the pyramid
            }

            StringBuilder nextRow = new StringBuilder();

            return CanBuildNextRow(bottom, 0, nextRow, allowedMap);
        }

        private bool CanBuildNextRow(string bottom, int index, StringBuilder nextRow, Dictionary<string, HashSet<char>> allowedMap)
        {
            if (index == bottom.Length - 1)
            {
                return CanBuildTop(nextRow.ToString(), allowedMap);
            }

            string pair = bottom.Substring(index, 2);
            if (!allowedMap.ContainsKey(pair))
            {
                return false;
            }

            foreach (char c in allowedMap[pair])
            {
                nextRow.Append(c);
                if (CanBuildNextRow(bottom, index + 1, nextRow, allowedMap))
                {
                    return true;
                }
                nextRow.Length--; // Backtrack
            }

            return false;
        }
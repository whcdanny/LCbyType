//Leetcode 936. Stamping The Sequence hard
//题目：你需要将一个初始全为 ? 的字符串 s 转换为目标字符串 target，并且每次可以在 s 的某个位置覆盖长度为 stamp.Length 的子串，将对应的字符替换成 stamp 的字符。
//约束条件：
//stamp 必须完全匹配目标范围内的字符才能覆盖。需要在10×target.Length 次操作内完成。
//你需要返回每次盖章的起始索引。如果无法完成转换，则返回空数组。
//思路: 逆向思维：
//考虑从 target 开始反向变回全? 的字符串 s，每次找到可以还原为? 的子字符串并记录索引。
//通过逆向处理，可以避免直接模拟从 s 到 target 的复杂性。
//关键判断条件：
//判断 stamp 能否覆盖目标子串时需要满足：
//子串中所有非? 的字符和 stamp 对应字符一致。
//如果可以覆盖，则将子串中对应位置都改为?。
//迭代处理：
//多次遍历目标字符串，尝试还原所有字符为?。
//如果某次遍历没有成功还原任何字符，则提前退出循环。
//时间复杂度：O(n^2)
//空间复杂度：O(n)
        public int[] MovesToStamp(string stamp, string target)
        {
            char[] targetArray = target.ToCharArray();
            char[] stampArray = stamp.ToCharArray();
            int targetLen = target.Length;
            int stampLen = stamp.Length;

            List<int> result = new List<int>();
            bool[] visited = new bool[targetLen];
            int totalReplaced = 0;

            while (totalReplaced < targetLen)
            {
                bool replacedInThisRound = false;

                for (int i = 0; i <= targetLen - stampLen; i++)
                {
                    if (!visited[i] && CanStamp_MovesToStamp(targetArray, stampArray, i))
                    {
                        totalReplaced += Stamp_MovesToStamp(targetArray, stampLen, i);
                        visited[i] = true;
                        replacedInThisRound = true;
                        result.Add(i);

                        if (totalReplaced == targetLen)
                            break;
                    }
                }

                if (!replacedInThisRound)
                    return new int[0]; // 无法完成转换
            }

            result.Reverse();
            return result.ToArray();
        }

        // 判断是否可以在当前位置盖章
        private bool CanStamp_MovesToStamp(char[] target, char[] stamp, int start)
        {
            bool canStamp = false;

            for (int i = 0; i < stamp.Length; i++)
            {
                if (target[start + i] != '?' && target[start + i] != stamp[i])
                    return false;
                if (target[start + i] == stamp[i])
                    canStamp = true;
            }

            return canStamp;
        }

        // 在当前位置盖章并返回替换的字符数
        private int Stamp_MovesToStamp(char[] target, int stampLen, int start)
        {
            int replacedCount = 0;

            for (int i = 0; i < stampLen; i++)
            {
                if (target[start + i] != '?')
                {
                    target[start + i] = '?';
                    replacedCount++;
                }
            }

            return replacedCount;
        }
//Leetcode 1654. Minimum Jumps to Reach Home  med
//题意：给定一个有序的整数数组 forbidden，以及三个整数 a，b，和 x。初始时，一个小球位于点 0，并且在一些整数点上。小球每次可以向左或者向右移动 a 或者 b 的距离，不能停留在数组 forbidden 中的整数点上。目标是使得小球到达目标点 x。返回小球所需的最小移动次数，如果不可能到达目标点则返回 -1。
//思路：使用BFS,根据给即 bug 可能所在的位置和它上一步是否为向后跳的状态。在每一步中，判断 bug 可以向前跳或向后跳，并检查是否越过了终点 x，是否跳到了 forbidden 的位置，以及是否出现了连续两次向后跳的情况。
//时间复杂度: O(2^n)，其中 n 是步数的最大值。
//空间复杂度：集合 forbiddenSet 存储 forbidden 数组，最多包含 2000 个元素，所以空间复杂度为 O(2000)。集合 visited 存储可能的状态，最多包含 2 * 6001 个元素，所以空间复杂度为 O(1)。队列 queue 存储每一步的状态，最多包含 2 * 6001 个元素，所以空间复杂度为 O(1)。总体空间复杂度为 O(2000)。
        public int MinimumJumps(int[] forbidden, int a, int b, int x)
        {
            HashSet<int> forbiddenSet = new HashSet<int>(forbidden);
            HashSet<(int, bool)> visited = new HashSet<(int, bool)>();
            Queue<(int, bool, int)> queue = new Queue<(int, bool, int)>();

            queue.Enqueue((0, false, 0));
            visited.Add((0, false));

            while (queue.Count > 0)
            {
                int currentPos = queue.Peek().Item1;
                bool isBackward = queue.Peek().Item2;
                int steps = queue.Peek().Item3;
                queue.Dequeue();

                if (currentPos == x)
                {
                    return steps;
                }

                int forwardPos = currentPos + a;
                int backwardPos = currentPos - b;

                if (forwardPos <= 6000 && !forbiddenSet.Contains(forwardPos) && !visited.Contains((forwardPos, false)))
                {
                    queue.Enqueue((forwardPos, false, steps + 1));
                    visited.Add((forwardPos, false));
                }

                if (!isBackward && backwardPos >= 0 && !forbiddenSet.Contains(backwardPos) && !visited.Contains((backwardPos, true)))
                {
                    queue.Enqueue((backwardPos, true, steps + 1));
                    visited.Add((backwardPos, true));
                }
            }

            return -1;
        }
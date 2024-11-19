//Leetcode 1642. Furthest Building You Can Reach med
//题意：给定一个整数数组 heights，表示建筑物的高度，以及一些砖块和梯子。
//你从建筑物 0 开始，可以通过使用砖块或梯子移动到下一个建筑物。
//在从建筑物 i 移动到建筑物 i+1 时（索引从 0 开始）：
//如果当前建筑物的高度大于或等于下一个建筑物的高度，则不需要梯子或砖块。
//如果当前建筑物的高度小于下一个建筑物的高度，则可以使用一个梯子或（h[i + 1] - h[i]）个砖块。
//返回你可以到达的最远建筑物的索引（索引从 0 开始），如果你能够在给定的梯子和砖块的情况下，使用最优策略。
//思路：PriorityQueue, 关键是要优化梯子的使用，将梯子留作更高的跳跃
//在每一次需要梯子和砖块的时候，用梯子替换最多砖头的位置；
//时间复杂度: O(nlogk)
//空间复杂度：O(k)
        public int FurthestBuilding(int[] heights, int bricks, int ladders)
        {
            PriorityQueue<int, int> jumps = new PriorityQueue<int, int>();

            for (int i = 1; i < heights.Length; i++)
            {
                int difference = heights[i] - heights[i - 1];

                if (difference > 0)
                {
                    bricks -= difference;
                    jumps.Enqueue(difference, -difference);

                    if (bricks < 0)
                    {
                        if (ladders == 0)
                        {
                            return i - 1;
                        }
                        else
                        {
                            bricks += jumps.Dequeue();
                            ladders--;
                        }
                    }
                }
            }
            return heights.Length - 1;
        }
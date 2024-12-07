//Leetcode 390. Elimination Game med
//题意：给定一个整数 n，表示一个范围为[1, n] 的递增整数列表arr。
//对arr 应用以下算法，直到剩下一个数字：
//从左到右：移除第一个数字以及之后的每隔一个数字。
//从右到左：移除最后一个数字以及之前的每隔一个数字。
//重复上述两个步骤，交替进行，直到只剩下一个数字。
//任务：给定整数 n，返回最后剩下的数字。
//思路: 考虑当删除之后head的在哪里
//从左往右：肯定head要到下一个数，这里要注意，step *= 2; 
//从右往左：要分为两个情况
//如果当前remaining % 2 == 1，说明head需要移动到下一位，
//如果不是说明head不会动，
//这里只需要当remaining<=1的时候答案就出现了
//时间复杂度: O(logn) 
//空间复杂度：O(1) 
        public int LastRemaining(int n)
        {
            int head = 1; // 起始数字
            int step = 1; // 步长
            int remaining = n; // 剩余数字个数
            bool leftToRight = true; // 当前移除方向

            while (remaining > 1)
            {
                // 如果从左到右，或者从右到左且剩余数字为奇数，head 向右移动
                if (leftToRight || remaining % 2 == 1)
                {
                    head += step;
                }
                // 每轮更新步长和剩余数字个数
                step *= 2;
                remaining /= 2;
                // 方向交替切换
                leftToRight = !leftToRight;
            }

            return head; // 最终剩下的数字
        }
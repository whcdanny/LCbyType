//Leetcode 486. Predict the Winner med
//题意：给定一个整数数组nums。两个玩家正在用这个数组玩游戏：玩家 1 和玩家 2。
//玩家 1 和玩家 2 轮流，玩家 1 先开始。两位玩家都以 的分数开始游戏0。
//每次轮流时，玩家从数组的两端取一个数字（即nums[0] 或nums[nums.length - 1]），这会将数组的大小减少1。
//玩家将所选数字添加到他们的分数中。当数组中没有更多元素时，游戏结束。
//如果玩家 1 可以赢得游戏，则返回true。如果两个玩家的分数相同，则玩家 1 仍然是赢家，您也应该返回true。
//您可以假设两个玩家都在发挥最佳水平。
//注：这里就是尽可能让play1赢
//思路：递归方法，
//这里注意得是 尽可能让play1赢意思就是, play2做什么都赢不了play1也就是说
//如果paly1的选择时，(findPredictTheWinner(nums, start + 1, end, play1 + startVal, play2, !play1First) 
//|| findPredictTheWinner(nums, start, end - 1, play1 + endVal, play2, !play1First));
//如果play2的选择时，(findPredictTheWinner(nums, start + 1, end, play1, play2 + startVal, !play1First) 
//&& findPredictTheWinner(nums, start, end - 1, play1, play2 + endVal, !play1First))
//时间复杂度:  O(n^2)
//空间复杂度： O(1)
        public bool PredictTheWinner(int[] nums)
        {
            return findPredictTheWinner(nums, 0, nums.Length - 1, 0, 0, true);
        }

        private bool findPredictTheWinner(int[] nums, int start, int end, int play1, int play2, bool play1First)
        {
            if (start > end)
                return play1 >= play2 ? true : false;

            int startVal = nums[start];
            int endVal = nums[end];
            if (play1First)
            {
                return (findPredictTheWinner(nums, start + 1, end, play1 + startVal, play2, !play1First) || findPredictTheWinner(nums, start, end - 1, play1 + endVal, play2, !play1First));
            }
            else
            {
                return (findPredictTheWinner(nums, start + 1, end, play1, play2 + startVal, !play1First) && findPredictTheWinner(nums, start, end - 1, play1, play2 + endVal, !play1First));
            }
        }
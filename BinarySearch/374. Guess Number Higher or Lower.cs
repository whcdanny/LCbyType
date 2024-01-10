//Leetcode 374. Guess Number Higher or Lower ez
//题意：猜数字游戏的规则如下：
//我从 1 到 n 选择一个数字。 你需要猜我选择了哪个数字。
//每次你猜错了，我会告诉你我选择的数字比你的大了或者小了。
//你调用一个预定义的接口 int guess(int num)，它会返回 3 个可能的结果：
//-1：我选的数字比你的数字小  
//1：我选的数字比你的数字大
//0：我选的数字就是你猜的数字
//你有一个机会通过调用 guess 函数来找到我的数字。如果你猜错了，你将不能再继续猜测。
//现在给定一个范围[1, n]，找出我选择的数字是多少。
//思路：二分查找，初始化搜索范围为 [1, n]。
//在每一步中，通过调用 guess 函数猜测中间值 mid。
//根据 guess 的返回值，缩小搜索范围为左半部分或右半部分。
//重复步骤 2 和步骤 3，直到找到目标数字。
//时间复杂度：O(log n)
//空间复杂度：O(1)
        public int GuessNumber(int n)
        {
            int left = 1;
            int right = n;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                int result = guess(mid);

                if (result == 0)
                {
                    return mid;
                }
                else if (result == -1)
                {
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }

            return -1; // 如果没有找到目标数字，可以返回一个特定的值，或者抛出异常，视情况而定
        }
        /** 
        * Forward declaration of guess API.
        * @param  num   your guess
        * @return 	     -1 if num is higher than the picked number
        *			      1 if num is lower than the picked number
        *               otherwise return 0
        * int guess(int num);
        */
        private int guess(int mid)
        {
            //if(mid)
            return -1;//0,1;
        }
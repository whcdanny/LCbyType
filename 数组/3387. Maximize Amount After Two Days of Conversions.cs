//Leetcode 3387. Maximize Amount After Two Days of Conversions ez
//题意：给定一个二维数组 events，每个元素 events[i] = [indexi, timei] 表示某个按钮 indexi 在时间 timei 被按下。
//数组按时间 timei 递增排序。
//每次按键所需的时间是连续两次按键的时间差：
//第一次按键的时间为 timei 本身。
//从第二次开始，按键所需时间为当前时间和前一次时间的差值。
//要求：返回 按下时间最长 的按钮的索引。
//如果存在多个按钮的时间相同，返回索引最小的按钮。
//思路：初始化数据：
//遍历数组 events，从第二个事件开始计算每次按键的时间差。
//对于第一个按钮，按下时间直接为 timei。
//更新最长时间与索引：使用两个变量：
//maxTime：当前最长的按键时间。
//resultIndex：对应的按钮索引。
//遍历过程中，如果发现某个按钮的按键时间大于 maxTime，更新 maxTime 和 resultIndex。
//如果按键时间等于 maxTime，则优先选择索引更小的按钮。
//时间复杂度:  O(n)
//空间复杂度： O(1)
        public int ButtonWithLongestTime(int[][] events)
        {
            int n = events.Length;
            int maxTime = events[0][1]; // 第一个按钮的时间为其自身时间
            int resultIndex = events[0][0]; // 初始化为第一个按钮的索引

            for (int i = 1; i < n; i++)
            {
                // 当前按钮按下所需时间
                int pressTime = events[i][1] - events[i - 1][1];

                // 更新最长时间及按钮索引
                if (pressTime > maxTime || (pressTime == maxTime && events[i][0] < resultIndex))
                {
                    maxTime = pressTime;
                    resultIndex = events[i][0];
                }
            }

            return resultIndex;
        }
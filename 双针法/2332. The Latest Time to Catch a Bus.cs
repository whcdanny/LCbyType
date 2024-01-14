//Leetcode 2332. The Latest Time to Catch a Bus med
//题意：给定长度为 n 的整数数组 buses，表示 n 辆巴士的出发时间；给定长度为 m 的整数数组 passengers，表示 m 位乘客的到达时间。所有巴士的出发时间和所有乘客的到达时间都是唯一的。同时给定整数 capacity，表示每辆巴士能容纳的最大乘客数。
//当乘客到达时，他们会排队等候下一辆可用的巴士。如果你在 x 分钟到达，可以搭乘 x 分钟后出发的巴士，前提是该巴士未满员。到达时间最早的乘客首先搭乘。
//具体规则如下：
//如果等候的乘客不超过 capacity，则他们将全部搭乘该巴士。
//如果等候的乘客超过 capacity，则从等候的乘客中选取到达时间最早的 capacity 位乘客搭乘该巴士。
//返回最晚可能到达车站的时间，以便能够搭乘一辆巴士。注意不能与其他乘客同时到达。
//目标是判断通过任意次移动 start 字符串中的棋子，是否可以得到 target 字符串。
//思路：左右针，i表示bus，j表示最后一个上车的人，我们想象，如果“我”不存在，只有已知的那些passengers，那么我们应该很容易这道哪些乘客上哪些车。而现在想做的基本方针，是看看能不能比某个乘客早一秒到达，这样就把他的位置挤占了（当然还有其他约束条件），从而搭上这班车
//那么还有没有其他不需要挤占其他乘客的可能性呢？其实buses[i]不一定都坐满了。如果最后一个上车的乘客与班车开动的时刻之间有空隙，那么我们就直接在buses[i]时刻上车即可。
//我们遍历每辆车，考察该车的每个乘客能否被挤占，或者是否可以卡点上车，就可以确定自己上车的时间
//时间复杂度: O(n)
//空间复杂度：O(n)
        public int LatestTimeCatchTheBus(int[] buses, int[] passengers, int capacity)
        {
            int m = passengers.Length;

            Array.Sort(buses);
            Array.Sort(passengers);

            int j = 0;
            int ret = -1;

            for (int i = 0; i < buses.Length; i++)
            {
                int cap = capacity;
                while (j < m && passengers[j] <= buses[i] && cap > 0)
                {
                    cap--;
                    if (j >= 1 && passengers[j] - 1 != passengers[j - 1])
                        ret = passengers[j] - 1;
                    else if (j == 0)
                        ret = passengers[j] - 1;
                    j++;
                }
                //卡点上车；
                if (cap > 0)
                {
                    if (j >= 1 && passengers[j - 1] != buses[i])
                        ret = buses[i];
                    else if (j == 0)
                        ret = buses[i];
                }
            }

            return ret;
        }
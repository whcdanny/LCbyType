//1823. Find the Winner of the Circular Game med
//题意：有n一群朋友正在玩游戏。朋友们围坐成一圈，按顺时针顺序1从到编号。
//更正式地说，从 朋友开始顺时针移动会将您带到 的朋友，从 朋友开始顺时针移动会将您带到朋友。nith(i+1)th1 <= i < nnth1st
//游戏规则如下：从朋友开始。1st k按照顺时针方向数出接下来的几个朋友，包括你开始数的朋友。
//数数会绕一圈，有些朋友可能会被数多次。你数的最后一位朋友离开了圈子并输掉了游戏。
//如果圈内仍有多个朋友，则从刚刚失败的朋友的顺时针方向立即2 开始返回步骤并重复。
//否则，圈中的最后一个朋友将赢得游戏。给定朋友的数量n和一个整数k，返回游戏的获胜者。
//思路：用queue来存每一轮赢家 直到size==1
//这里要有一个计数的，当count==k 弹出不放入queue中，
//时间复杂度：O(n*k)
//空间复杂度：O(n)
        public int FindTheWinner(int n, int k)
        {
            Queue<int> queue = new Queue<int>();
            for (int i = 1; i <= n; i++)
            {
                queue.Enqueue(i);
            }
            int count = 1;
            while (queue.Count > 0)
            {
                if (queue.Count == 1)
                    return queue.Dequeue();
                if (count == k)
                {
                    queue.Dequeue();
                    count = 1;
                }
                else
                {
                    int temp = queue.Dequeue();
                    queue.Enqueue(temp);
                    count++;
                }                                
            }
            return 0;
        }
//Leetcode 2511. Maximum Enemy Forts That Can Be Captured ez
//题意：给定一个长度为 n 的整数数组 forts，表示若干要塞的位置。forts[i] 的值可以是 -1、0 或 1，其中：
//-1 表示第 i 个位置没有要塞。
//0 表示第 i 个位置有一个敌方要塞。
//1 表示第 i 个位置的要塞在你的指挥下。
//现在你决定将你的军队从一个要塞位置 i 移动到另一个空位置 j，满足以下条件：
//0 <= i, j <= n - 1
//军队只能通过敌方要塞行进。具体而言，对于所有 k，其中 min(i, j) < k<max(i, j)，都有 forts[k] == 0。
//在移动军队的过程中，所有遇到的敌方要塞都会被占领。
//返回最大能够占领的敌方要塞数量。如果无法移动你的军队，或者你没有任何要塞在你的指挥下，返回 0。
//思路：左右针，从左到右历遍，遇到1或者-1，就开始用历遍 如0就++；最后找到最大的；
//时间复杂度: O(n)
//空间复杂度：O(1)
        public int CaptureForts(int[] forts)
        {
            int maxCapture = 0, n = forts.Length;

            for (int i = 0; i < n; i++)
            {
                if (forts[i] == 1)
                {
                    int index = i + 1, currMax = 0;
                    while (index < n && forts[index] == 0)
                    {
                        currMax++;
                        index++;
                    }
                    if (index < n && forts[index] == -1)
                    {
                        if (maxCapture < currMax) maxCapture = currMax;
                    }
                }
                else if (forts[i] == -1)
                {
                    int index = i + 1, currMax = 0;
                    while (index < n && forts[index] == 0)
                    {
                        currMax++;
                        index++;
                    }
                    if (index < n && forts[index] == 1)
                    {
                        if (maxCapture < currMax) maxCapture = currMax;
                    }
                }
            }

            return maxCapture;
        }
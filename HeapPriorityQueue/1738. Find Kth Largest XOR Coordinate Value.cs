//Leetcode 1738. Find Kth Largest XOR Coordinate Value med
//题意：要求给出一个二维矩阵，矩阵中的每个元素都是非负整数。然后给出一个整数 k。对于矩阵中的每个坐标 (a, b)，其值是由矩阵中从 (0,0) 到 (a,b) 的所有元素进行异或运算得到的。现在要求找到矩阵中第 k 大的坐标值。
//思路：PriorityQueue, 遍历整个矩阵，计算每个坐标的值，并将坐标值放入最小堆中。
//维护一个大小为 k 的最小堆，不断将新计算出的坐标值放入堆中，并保持堆的大小为 k。
//当遍历完整个矩阵后，堆顶元素即为第 k 大的坐标值。
//时间复杂度: O(mn * log(k))，其中 m 和 n 分别为矩阵的行数和列数。因为需要遍历整个矩阵，并且在维护最小堆时，插入一个元素的时间复杂度为 log(k)
//空间复杂度：O(k)  
        public int KthLargestValue(int[][] matrix, int k)
        {
            int[][] xorValue = new int[matrix.Length][];
            PriorityQueue<int, int> pq = new PriorityQueue<int, int>();

            for (int i = 0; i < matrix.Length; i++)
                xorValue[i] = new int[matrix[0].Length];

            int cnt = 0;

            for (int i = 0; i < matrix.Length; i++)
            {
                int thisRowXor = 0;
                for (int j = 0; j < matrix[0].Length; j++)
                {
                    thisRowXor = thisRowXor ^ matrix[i][j];
                    if (i == 0)
                        xorValue[i][j] = thisRowXor;
                    else
                        xorValue[i][j] = thisRowXor ^ xorValue[i - 1][j];

                    if (cnt < k)
                    {
                        pq.Enqueue(xorValue[i][j], xorValue[i][j]);
                        cnt++;
                    }
                    else
                    {
                        if (xorValue[i][j] > pq.Peek())
                        {
                            pq.Dequeue();
                            pq.Enqueue(xorValue[i][j], xorValue[i][j]);
                        }
                    }
                }
            }

            return pq.Peek();
        }
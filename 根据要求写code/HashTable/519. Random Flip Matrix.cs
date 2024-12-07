//Leetcode 519. Random Flip Matrix med
//题意：有一个m x n二进制网格matrix，其中所有值都已0初始设置。
//设计一个算法来随机选择一个索引(i, j)并将matrix[i][j] == 0其翻转为1。
//所有索引(i, j)都应matrix[i][j] == 0有同等的可能性被返回。
//优化您的算法，以尽量减少对语言内置随机函数的调用次数，并优化时间和空间复杂度。
//实现Solution类：
//Solution(int m, int n)用二进制矩阵的大小m和初始化对象n。
//int[] flip()[i, j] 返回矩阵的随机索引matrix[i][j] == 0，并将其翻转为1。
//void reset()将矩阵的所有值重置为0。
//思路：用Dictionary来模仿matrix 
//这里size为m*n，对应得matrix就是
//行:rand/m 列:rand%m
//matrix.ContainsKey(rand) && matrix[rand] == 1 找出符合得随机位置
//res = new int[2] { rand % m, rand / m };然后更改成1 matrix[rand] = 1;
//时间复杂度:  O(n*m)
//空间复杂度： O(n*m)

        public class Solution_TEST
        {
            private int _m;
            private int _n;
            private Dictionary<int, int> matrix;

            private int _count;

            public Solution_TEST(int m, int n)
            {
                _m = m;
                _n = n;
                _count = m * n;
                matrix = new Dictionary<int, int>();
            }

            public int[] Flip()
            {
                Random rd = new Random();
                int rand = rd.Next(_count);

                int[] res;
                while (matrix.ContainsKey(rand) && matrix[rand] == 1)
                {
                    rand = rd.Next(_count);                    
                }
                res = new int[2] { rand % _m, rand / _m };
                matrix[rand] = 1;

                //if (matrix.TryGetValue(rand, out var value))
                //{
                //    res = new int[2] { value % _m, value / _m };
                //}
                //else
                //{
                //    res = new int[2] { rand % _m, rand / _m };
                //}

                //_count--;

                //if (matrix.TryGetValue(_count, out int valueM))
                //{
                //    matrix[rand] = valueM;
                //}
                //else
                //{
                //    matrix[rand] = _count;
                //}

                return res;
            }

            public void Reset()
            {
                _count = _m * _n;
                matrix = new Dictionary<int, int>();
            }
        }
        /**
         * Your Solution object will be instantiated and called as such:
         * Solution obj = new Solution(m, n);
         * int[] param_1 = obj.Flip();
         * obj.Reset();
         */
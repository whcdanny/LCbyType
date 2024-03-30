//Leetcode 2857. Count Pairs of Points With Distance k med
//题意：要求计算在给定的 2D 整数数组中，距离为 k 的点对的数量，其中距离定义为两个点的横纵坐标分别进行按位异或操作后的结果相加。
//思路：hashtable，
//(x1 XOR x2) + (y1 XOR y2)的两个分量都是非负数，所以我们可以穷举k=a+b的拆解。已知a,b,通过枚举(x1,y1)，我们就可以知道对应的x2,y2. 只需要用Hash查看(x2,y2)是否存在即可  
//x1^x2=a => x^2 = a ^ x1; y1^y2=b => y^2 = b ^ y1
//(x1^k,y1^0), (x1^(k-1),y1^1), ..., (x1^1,y1^(k-1)), (x1^0,y1^k)
//时间复杂度：O(n)
//空间复杂度：O(n)
        public int CountPairs(IList<IList<int>> coordinates, int k)
        {
            Dictionary<int, Dictionary<int, int>> counts = new Dictionary<int, Dictionary<int, int>>();
            int result = 0;
            for (int i = 0; i < coordinates.Count; i++)
            {
                IList<int> point = coordinates[i];
                int x1 = point[0], y1 = point[1];

                for (int j = k; j >= 0; j--)
                {
                    int x2 = x1 ^ j;
                    int y2 = y1 ^ (k - j);

                    if (counts.ContainsKey(x2) && counts[x2].ContainsKey(y2))
                        result += counts[x2][y2];
                }

                if (!counts.ContainsKey(x1))
                {
                    counts.Add(x1, new Dictionary<int, int>());
                }

                if (!counts[x1].ContainsKey(y1))
                {
                    counts[x1].Add(y1, 0);
                }

                counts[x1][y1] += 1;
            }

            return result;
        }
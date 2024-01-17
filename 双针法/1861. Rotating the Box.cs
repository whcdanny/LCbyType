//Leetcode 1861. Rotating the Box med
//题意：要求对给定的 m x n 矩阵进行顺时针旋转，并模拟重力作用，使得石头（'#'）下落到障碍物、另一个石头或箱子底部。我们可以使用双指针法来模拟这个过程。 
//思路：双指针 历遍每一列，这样就可以创造出新的转向之和的每一行内容，
//初始化都是空的；
//使用两个指针i,j，分别指行数，和列数，因为有挡板存在所以在行数中再分出一个k，表示具体列数位置；
//找到第一个挡板的位置或者走到头了，并算出有几个石头
//是否有挡板，来确定k的位置，这样在新的一列中就有了位置，然后挡板之上或者低端之上有多少石头，依此给此列的每一行从下往上添加；
//最后j=k
//注：这里找转化之和的位置很重要看comment；
//时间复杂度：O(m * n)，其中 m 是行数，n 是列数
//空间复杂度：O(m * n)，其中 m 是行数，n 是列数
        public char[][] RotateTheBox(char[][] box)
        {
            int m = box.Length;
            int n = box[0].Length;

            char[][] result = new char[n][];
            for (int i = 0; i < n; i++)
            {
                result[i] = new char[m];
                //初始化都是空的；
                Array.Fill(result[i], '.');
            }            

            for (int i = 0; i < m; i++)
            {               
                for (int j = 0; j < n; j++)
                {
                    int count = 0;//石头数量
                    int k = j;
                    //找到第一个挡板的位置或者走到头了，并算出有几个石头
                    while(k<n && box[i][k] != '*')
                    {
                        if (box[i][k] == '#')
                            count++;
                        k++;
                    }
                    int col = m - 1 - i;
                    //--------- -> (i,k) --------- (k, m-1-i)
                    //|     i行|   旋转  |   k行 |
                    //| k列 .  |m        |   .i列| n
                    //|        |         |       |
                    //---------          --------
                    //    n                m
                    //有挡板
                    if (k != n)
                        result[k][col] = '*';
                    //放入石头，挡板之前要填count个石头
                    for(int s = 0; s < count; s++)
                    {
                        //列不变，行变
                        result[k - 1 - s][col] = '#';
                    }
                    j = k;                    
                }
            }

            return result;
        }
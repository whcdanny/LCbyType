//Leetcode 1337. The K Weakest Rows in a Matrix ez
//题意：给定一个大小为 m x n 的矩阵 mat，其中 m 行和 n 列，矩阵中的元素为二进制数字（0 或 1）。矩阵按照行进行排序，每一行都按照从左到右递增的顺序排列。找到矩阵中的第 k 个最弱的行（下标从 0 开始），最弱的行定义为矩阵中所有行的元素的和最小的行。
//一行的“和”是指所有元素的和。在两行之间的相同位置，任意一行的元素都不少于另一行的元素。
//返回矩阵中第 k 个最弱的行的索引，按矩阵中的第 i 行的下标排序，下标从 0 开始。
//思路：使用二分搜索,查找最后一个1的位置，此时存入当前row和至一行1的总和，然后根据每一行的1的总和排序，然后再输出k个；
//时间复杂度:  计算每行元素和： 对于每一行，你使用了二分搜索来找到最后一个为1的元素的索引，所以这一步的时间复杂度是 O(n * log(n))，其中 n 是每行的元素个数。
//排序字典： 对字典进行排序的时间复杂度是 O(m* log(m))，其中 m 是矩阵的行数。
//构建结果数组： 遍历排序后的字典的时间复杂度是 O(m)，但由于 m 可能大于 n，所以总的时间复杂度是 O(m* log(m))。O(n * log(n) + m * log(m))。
//空间复杂度： 额外空间： 你使用了字典 map 存储每行的索引和元素和，字典的大小为 m。因此，额外空间的复杂度是 O(m)。
        public int[] KWeakestRows(int[][] mat, int k)
        {
            int m = mat.Length;
            int n = mat[0].Length;

            int[] result = new int[k];

            // 计算每行元素和的数组
            Dictionary<int, int> map = new Dictionary<int, int>();

            for (int i = 0; i < m; i++)
            {
                int left = 0, right = n - 1;
               
                // 二分搜索找到每行的元素和
                while (left <= right)
                {
                    int mid = left + (right - left) / 2;

                    if (mat[i][mid] == 0)
                    {                       
                        right = mid - 1;
                    }
                    else
                    {
                        left = mid + 1;
                    }
                }

                map.Add(i, left);
            }
            var orderedMap = map.OrderBy(x => x.Value);            
            int index = 0;
            foreach (KeyValuePair<int, int> keyValuePair in orderedMap)
            {
                result[index++] = keyValuePair.Key;
                if (index == k)
                {
                    break;
                }
            }
            
            return result;
        }
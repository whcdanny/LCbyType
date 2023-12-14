//Leetcode 386. Lexicographical Numbers med
//题意：给定一个整数 n，要求返回所有小于等于 n 的按字典序排列的整数。
//输入: 13
//输出: [1, 10, 11, 12, 13, 2, 3, 4, 5, 6, 7, 8, 9]
//思路：DFS, 从 1 开始，依次递归生成以当前数字为前缀的所有数字，直到超过 n。
//注：这里前缀的算法就是当你放入1的时候，来算10，11，12，相当于1*10+i；
//时间复杂度: O(n)，其中 n 是二叉树中节点的数量
//空间复杂度：O(logn)
        public IList<int> LexicalOrder(int n)
        {
            List<int> result = new List<int>();
            for (int i = 1; i <= 9; i++)
            {
                DFS_LexicalOrder(i, n, result);
            }
            return result;
        }

        private void DFS_LexicalOrder(int curr, int n, List<int> result)
        {
            if (curr > n)
            {
                return;
            }

            result.Add(curr);

            for (int i = 0; i <= 9; i++)
            {
                int next = curr * 10 + i;
                if (next > n)
                {
                    return;
                }

                DFS_LexicalOrder(next, n, result);
            }
        }
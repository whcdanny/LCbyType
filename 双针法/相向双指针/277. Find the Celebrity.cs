//Leetcode 277. Find the Celebrity med
//题意：要求是找到一个名人，这个名人不认识其他人，但所有人都认识他。给定一个 n x n 的矩阵，其中 matrix[i][j] 表示第 i 个人是否认识第 j 个人。如果 matrix[i][j] == 1，表示第 i 个人认识第 j 个人；如果 matrix[i][j] == 0，表示第 i 个人不认识第 j 个人。要求找到一个名人，如果他是名人的话。
//思路：双指针方法: 假设第 i 个人是名人，那么他不认识任何人，也就是不存在 k 使得 matrix[i][k] == 1。所以我们可以使用两个指针 left 和 right，分别指向第一个人和第 n 个人，然后开始遍历，通过比较他们之间的关系来确定可能的名人。如果 matrix[left][right] == 1，说明第 left 个人认识第 right 个人，所以名人一定不是第 left 个人，将 left 右移一位。如果 matrix[left][right] == 0，说明第 left 个人不认识第 right 个人，所以名人一定不是第 right 个人，将 right 左移一位。
//时间复杂度:  O(n)
//空间复杂度： O(1)
        public int FindCelebrity(int n)
        {
            int left = 0;
            int right = n - 1;

            while (left < right)
            {
                if (Knows(left, right))
                {
                    left++;
                }
                else
                {
                    right--;
                }
            }

            for (int i = 0; i < n; i++)
            {
                if (i != left && (Knows(left, i) || !Knows(i, left)))
                {
                    return -1; // 不存在名人
                }
            }

            return left;
        }

        private bool Knows(int left, int right)
        {
            throw new NotImplementedException();
        }
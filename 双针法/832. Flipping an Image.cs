//Leetcode 832. Flipping an Image ez
//题意：给定一个 n x n 的二进制矩阵 image，对其进行水平翻转，然后进行反转，并返回结果图像。
//水平翻转是指将矩阵的每一行都进行反转。
//反转是指将矩阵中的每个 0 替换为 1，每个 1 替换为 0。
//例如，水平翻转[1, 1, 0] 的结果是[0, 1, 1]。反转[0, 1, 1] 的结果是[1, 0, 0]。
//思路：双指针，left 和 right 分别指向行的开头和结尾。
//在循环中，交换 image[i][left] 和 image[i][right] 的值，实现水平翻转。
//同时，对 image[i][left] 和 image[i][right] 进行反转，即用异或运算符 ^ 对其进行取反。
//时间复杂度：O(n^2)，其中 n 是矩阵的边长
//空间复杂度：O(1)
        public int[][] FlipAndInvertImage(int[][] image)
        {
            int n = image.Length;

            for (int i = 0; i < n; i++)
            {
                int left = 0, right = n - 1;

                while (left <= right)
                {
                    // Flip horizontally
                    int temp = image[i][left];
                    image[i][left] = image[i][right];
                    image[i][right] = temp;

                    // Invert
                    image[i][left] ^= 1;
                    if (left != right)
                    {
                        image[i][right] ^= 1;
                    }

                    left++;
                    right--;
                }
            }

            return image;
        }
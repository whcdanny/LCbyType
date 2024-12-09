//Leetcode 1104. Path In Zigzag Labelled Binary Tree med
//题意：在一个无限的二叉树中，每个节点都有两个子节点，并按照行序进行标号：
//奇数行（如第 1、3、5 行）按从左到右的顺序标号。
//偶数行（如第 2、4、6 行）按从右到左的顺序标号。
//给定树中的一个节点标签 label，返回从根节点到该节点的路径（以数组形式）。
//思路：先用(int)Math.Floor(Math.Log2(label)) + 1找出lable所在的第几行
//然后因为换行，所以找出如果不换行的实际位置        
//数字14在第二位          [15,14,13,12,11,10,9,8] 
//这里实际位置第二位是9   [8,9,10,11,12,13,14,15] 
//所以我们找出每个区间[2^(row-1), 2^row - 1]
//所以找出实际位置是 rowStart + (rowEnd - label)
//每个节点的父节点在满二叉树中的位置可以通过公式计算：
//Parent=label/2。 row--        
//时间复杂度：O(logN)
//空间复杂度：O(logN)
        public IList<int> PathInZigZagTree(int label)
        {
            List<int> path = new List<int>();

            // 1. 确定层级
            int row = (int)Math.Floor(Math.Log2(label)) + 1;
            // 2. 从目标节点向根回溯
            while (row > 0)
            {
                path.Add(label); // 添加当前节点到路径
                                 // 偶数行需要进行映射
                int rowStart = (int)Math.Pow(2, row - 1);   // 2^(row-1)
                int rowEnd = (int)Math.Pow(2, row) - 1;    // 2^row - 1
                label = rowStart + (rowEnd - label);
                // 计算父节点
                label /= 2;
                row--; // 进入上一层
            }

            // 3. 反转路径得到结果
            path.Reverse();
            return path;
        }
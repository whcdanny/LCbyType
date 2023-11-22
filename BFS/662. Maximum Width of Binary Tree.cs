//Leetcode 662. Maximum Width of Binary Tree med
//题意：给定一棵二叉树，计算其最大宽度。二叉树的宽度是树中任意两个深度最小的节点之间的距离（包括端点之间的空的层）。
//思路：层序遍历（BFS）来解决这个问题。每个节点有一个编号，根节点编号为0，然后按照层序遍历的顺序给其他节点编号。对于每一层，计算该层的宽度，即最右侧节点的编号减去最左侧节点的编号加1。在计算过程中，使用long64位整数来存储编号，以防止溢出
//注：计算宽度：左孩子节点的编号为当前节点编号的2倍，右孩子节点的编号为当前节点编号的2倍加1。
//时间复杂度: 树的节点数为 N，层序遍历需要访问所有节点，因此时间复杂度为 O(N)。
//空间复杂度： 队列的最大长度不超过每一层的节点数，因此空间复杂度为 O(2^h)，其中 h 为树的高度，最坏情况下为 O(N)。此外，需要额外的空间存储节点的编号，也为 O(N)。
        public int WidthOfBinaryTree(TreeNode root)
        {
            if (root == null) return 0;

            int maxWidth = 0;
            Queue<(TreeNode node, long index)> queue = new Queue<(TreeNode, long)>();
            queue.Enqueue((root, 0));

            while (queue.Count > 0)
            {
                int levelSize = queue.Count;
                long leftIndex = queue.Peek().index;

                for (int i = 0; i < levelSize; i++)
                {
                    var current = queue.Dequeue();
                    var node = current.node;
                    long currentIndex = current.index;
                    //左孩子节点的编号为当前节点编号的2倍，右孩子节点的编号为当前节点编号的2倍加1。
                    if (node.left != null)
                    {
                        queue.Enqueue((node.left, currentIndex * 2));
                    }

                    if (node.right != null)
                    {
                        queue.Enqueue((node.right, currentIndex * 2 + 1));
                    }

                    if (i == levelSize - 1)
                    {
                        // Update the maximum width at the end of each level
                        maxWidth = Math.Max(maxWidth, (int)(currentIndex - leftIndex + 1));
                    }
                }
            }

            return maxWidth;
        }
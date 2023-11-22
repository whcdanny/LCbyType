//Leetcode 655. Print Binary Tree med
//题意：给定一个二叉树，按照从上到下、从左到右的层序遍历，返回其每个层的节点值。如果某个位置上的节点为 null，则使用字符串 "null" 表示。
//思路：首先，我们需要计算二叉树的高度，以确定结果数组的行数。然后，根据满二叉树的节点数，确定结果数组的列数。利用 BFS 层序遍历二叉树，同时记录节点的深度和在结果数组中的位置。根据节点的深度和位置在结果数组中填充节点的值。
//注：满二叉树的节点数int width = (1 << height) - 1; 并且节点的位置int mid = (left + right) / 2;
//时间复杂度: 计算二叉树高度的时间复杂度为 O(logN)。BFS 遍历二叉树的时间复杂度为 O(N)。结果数组的初始化和填充的时间复杂度为 O(N)。因此，总体时间复杂度为 O(N)。
//空间复杂度：队列的空间复杂度为 O(N)。结果数组的空间复杂度为 O(N)。因此，总体空间复杂度为 O(N)。
        public IList<IList<string>> PrintTree(TreeNode root)
        {
            int height = GetHeight(root);
            int width = (1 << height) - 1; // 满二叉树的节点数

            IList<IList<string>> result = new List<IList<string>>();
            for (int i = 0; i < height; i++)
            {
                result.Add(new List<string>(width));
                for (int j = 0; j < width; j++)
                {
                    result[i].Add("");
                }
            }

            Queue<(TreeNode, int, int, int)> queue = new Queue<(TreeNode, int, int, int)>();
            queue.Enqueue((root, 0, 0, width - 1));

            while (queue.Count > 0)
            {
                var (node, depth, left, right) = queue.Dequeue();
                int mid = (left + right) / 2;
                result[depth][mid] = node.val.ToString();

                if (node.left != null)
                {
                    queue.Enqueue((node.left, depth + 1, left, mid - 1));
                }
                if (node.right != null)
                {
                    queue.Enqueue((node.right, depth + 1, mid + 1, right));
                }
            }

            return result;
        }
        private int GetHeight(TreeNode node)
        {
            if (node == null) return 0;
            return 1 + Math.Max(GetHeight(node.left), GetHeight(node.right));
        }
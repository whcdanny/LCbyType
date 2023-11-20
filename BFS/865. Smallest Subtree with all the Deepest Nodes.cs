//Leetcode 865. Smallest Subtree with all the Deepest Nodes med
//题意：给定一个二叉树，找到包含所有最深节点的最小子树。 
//思路：用BFS，这里用用两个queue，再历遍过程中，一个queue用于找到每个子node的parent，然后另一个找到这个二叉树最深的nodes，然后根据这个第二queue反推parent；
//时间复杂度: O(N + E)，其中 N 是人的数量，E 是不喜欢关系的数量。
//空间复杂度：O(N + E)，用于存储图的邻接表和记录人的颜色。在最坏情况下，可能需要存储所有的不喜欢关系。
        public TreeNode SubtreeWithAllDeepest(TreeNode root)
        {
            Dictionary<TreeNode, TreeNode> graph = new Dictionary<TreeNode, TreeNode>();
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            Queue<TreeNode>  queue2 = new Queue<TreeNode>();
            queue2.Enqueue(root);
            while (queue.Count > 0)
            {
                int quCount = queue.Count;
                for (int i = 0; i < quCount; i++)
                {
                    var node = queue.Dequeue();
                    if (node.left != null)
                    {
                        graph[node.left] = node;
                        queue.Enqueue(node.left);
                        queue2.Enqueue(node.left);
                    }
                    if (node.right != null)
                    {
                        graph[node.right] = node;
                        queue.Enqueue(node.right);
                        queue2.Enqueue(node.right);
                    }
                }
                //移除上一层的nodes，只留下最深的nodes；
                if (queue2.Count > quCount)
                {
                    for (int j = 0; j < quCount; j++) 
                        queue2.Dequeue();
                }
            }
            //根据最深的ndoes找到共同的parent
            while (queue2.Count > 1)
            {
                var stCount = queue2.Count;
                TreeNode parent = null;
                for (int j = 0; j < stCount; j++)
                {
                    var node = queue2.Dequeue();
                    if (parent == null)
                    {
                        parent = graph[node];
                        queue2.Enqueue(parent);
                    }
                    else
                    {
                        if (graph[node] != parent) queue2.Enqueue(graph[node]);
                    }
                }
            }
            return queue2.Dequeue();
        }
//Leetcode 429. N-ary Tree Level Order Traversal med
//题意：给定一个 N 叉树，返回其节点值的层序遍历
//思路：(BFS)进行层序遍历。首先，将根节点加入队列中。然后，在每一层中，遍历队列中的元素，将其子节点加入队列，并将当前节点的值加入到层序遍历的结果中。直到队列为空。
//时间复杂度: 每个节点都会被遍历一次，因此时间复杂度是 O(N)，其中 N 是树中节点的数量。
//空间复杂度：O(N)
        public IList<IList<int>> LevelOrder(Node root)
        {
            IList<IList<int>> result = new List<IList<int>>();
            if (root == null)
            {
                return result;
            }

            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                int levelSize = queue.Count;
                List<int> levelValues = new List<int>();
                for (int i = 0; i < levelSize; i++)
                {
                    Node current = queue.Dequeue();
                    levelValues.Add(current.val);
                    foreach (Node child in current.neighbors)
                    {
                        queue.Enqueue(child);
                    }
                }
                result.Add(levelValues);
            }

            return result;
        }
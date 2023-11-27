//Leetcode 116. Populating Next Right Pointers in Each Node med
//题意：给定一个完美二叉树，其中所有叶子节点都位于同一层，每个父节点都有两个子节点。二叉树定义如下：              
        //struct Node
        //{
        //    int val;
        //    Node* left;
        //    Node* right;
        //    Node* next;
        //}
//填充它的每个 next 指针，让这个指针指向其下一个右侧节点。如果找不到下一个右侧节点，则将 next 指针设置为 null。初始状态下，所有 next 指针都被设置为 null。
//思路：（BFS）的思路，逐层遍历二叉树，将每层的节点连接起来。通过队列实现层次遍历，每次将一层的节点放入队列，并在处理当前层时将节点之间建立 next 指针连接。
//时间复杂度: 遍历整个二叉树，总时间复杂度为 O(n)，其中 n 为二叉树中的节点数量。
//空间复杂度：使用了队列的空间，最坏情况下可能是 O(n/2)，即二叉树的最后一层的节点数量。
        public class Node_116
        {
            public int val;
            public Node_116 left;
            public Node_116 right;
            public Node_116 next;

            public Node_116() { }

            public Node_116(int _val)
            {
                val = _val;
            }

            public Node_116(int _val, Node_116 _left, Node_116 _right, Node_116 _next)
            {
                val = _val;
                left = _left;
                right = _right;
                next = _next;
            }
        }
        public Node_116 Connect(Node_116 root)
        {
            if (root == null)
            {
                return null;
            }

            Queue<Node_116> queue = new Queue<Node_116>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                int levelSize = queue.Count;

                for (int i = 0; i < levelSize; i++)
                {
                    Node_116 node = queue.Dequeue();

                    if (i < levelSize - 1)
                    {
                        // The last node in the current level points to the next node in the queue
                        node.next = queue.Peek();
                    }

                    if (node.left != null)
                    {
                        queue.Enqueue(node.left);
                    }

                    if (node.right != null)
                    {
                        queue.Enqueue(node.right);
                    }
                }
            }

            return root;
        }
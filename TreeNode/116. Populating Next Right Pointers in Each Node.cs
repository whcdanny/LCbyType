//116. Populating Next Right Pointers in Each Node med
//给一个完美的二分树，然后填充每个节点的下一个右侧指针
//思路：将每一层级的left.next = right;，这里要注意不同父的子节点，father1.right.next = father2.left;
// Definition for a Node.
        public class Node
        {
            public int val;
            public Node left;
            public Node right;
            public Node next;

            public Node() { }

            public Node(int _val)
            {
                val = _val;
            }

            public Node(int _val, Node _left, Node _right, Node _next)
            {
                val = _val;
                left = _left;
                right = _right;
                next = _next;
            }
        }
		
		public Node connect(Node root)
            {
                if (root == null) return null;
                // 遍历「三叉树」，连接相邻节点
                traverse(root.left, root.right);
                return root;
            }

            // 三叉树遍历框架
            public void traverse(Node node1, Node node2)
            {
                if (node1 == null || node2 == null)
                {
                    return;
                }
                /**** 前序位置 ****/
                // 将传入的两个节点穿起来
                node1.next = node2;

                // 连接相同父节点的两个子节点
                traverse(node1.left, node1.right);
                traverse(node2.left, node2.right);
                // 连接跨越父节点的两个子节点
                traverse(node1.right, node2.left);
            }
			
			
        public class Solution
        {
            public Node Connect(Node root)
            {
                if (root == null)
                    return root;

                Node leftN = root.left;
                Node rightN = root.right;
                while (leftN != null)
                {
                    leftN.next = rightN;
                    leftN = leftN.right;
                    rightN = rightN.left;
                }
                Connect(root.left);
                Connect(root.right);
                return root;               
            }
        }
				
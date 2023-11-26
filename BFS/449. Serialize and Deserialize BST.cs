//Leetcode 449. Serialize and Deserialize BST med
//题意：设计一个算法来实现二叉搜索树（BST）的序列化和反序列化。序列化是将一棵二叉树转化为一个字符串，反序列化是将字符串转化为二叉树。
//思路：(BFS)，序列化时，可以使用先序遍历将二叉树转化为字符串，每个节点的值之间使用空格分隔。空节点用特殊字符表示。反序列化时，可以将字符串按空格分隔，然后递归构建二叉树。
//时间复杂度: 对于序列化和反序列化操作，都需要遍历整个二叉树，因此时间复杂度是 O(n)，其中 n 是二叉树的节点数量。
//空间复杂度：在序列化和反序列化的过程中，都需要使用递归栈，因此空间复杂度也是 O(n)，其中 n 是二叉树的高度。
        // Encodes a tree to a single string.
        public string serialize(TreeNode root)
        {
            if (root == null)
            {
                return "";
            }

            StringBuilder sb = new StringBuilder();
            serializeHelper(root, sb);
            return sb.ToString();
        }

        private void serializeHelper(TreeNode node, StringBuilder sb)
        {
            if (node == null)
            {
                sb.Append("null").Append(" ");
                return;
            }

            sb.Append(node.val).Append(" ");
            serializeHelper(node.left, sb);
            serializeHelper(node.right, sb);
        }

        // Decodes your encoded data to tree.
        public TreeNode deserialize(string data)
        {
            if (data == "")
            {
                return null;
            }

            Queue<string> nodes = new Queue<string>(data.Split(' '));
            return deserializeHelper(nodes);
        }

        private TreeNode deserializeHelper(Queue<string> nodes)
        {
            string val = nodes.Dequeue();
            if (val == "null")
            {
                return null;
            }

            TreeNode node = new TreeNode(int.Parse(val));
            node.left = deserializeHelper(nodes);
            node.right = deserializeHelper(nodes);
            return node;
        }

        // Your Codec object will be instantiated and called as such:
        // Codec ser = new Codec();
        // Codec deser = new Codec();
        // String tree = ser.serialize(root);
        // TreeNode ans = deser.deserialize(tree);
        // return ans;
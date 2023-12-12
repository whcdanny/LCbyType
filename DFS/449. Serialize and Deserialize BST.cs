//Leetcode 449. Serialize and Deserialize BST med = 297
//题意：设计一个算法来实现二叉搜索树（BST）的序列化和反序列化。序列化是将一棵二叉树转化为一个字符串，反序列化是将字符串转化为二叉树。
//思路：序列化（Serialize）：在序列化过程中，我们需要按照某种规则将BST的结构转换为字符串。一种简单而有效的方法是使用前序遍历。
//前序遍历BST：从根节点开始，先访问根节点，然后递归地访问左子树和右子树。
//生成字符串：在遍历过程中，我们将每个节点的值转换为字符串，并用逗号分隔。对于空节点，我们可以使用特殊字符（如“#”）表示。
//反序列化（Deserialize）：在反序列化过程中，我们需要将序列化后的字符串转换回BST的结构。同样，我们可以使用前序遍历的方式进行反序列化。
//分割字符串：将序列化的字符串按逗号分隔，得到节点值的数组。
//构建树：根据前序遍历的顺序，依次从数组中取值，构建BST。
//时间复杂度: O(N)，其中 N 是BST的节点数量。
//空间复杂度：O(H)，其中 H 是BST的高度
        // Encodes a tree to a single string.
        public string serialize(TreeNode root)
        {
            //空节点将用 "#" 表示
            if (root == null) return "#";
            return root.val + "," + serialize(root.left) + "," + serialize(root.right);
        }

        public TreeNode deserialize(string data)
        {
            string[] values = data.Split(',');
            int index = 0;
            return DeserializeHelper(values, ref index);
        }

        private TreeNode DeserializeHelper(string[] values, ref int index)
        {
            if (index >= values.Length || values[index] == "#")
            {
                index++;
                return null;
            }

            if (int.TryParse(values[index++], out int val))
            {
                TreeNode node = new TreeNode(val);
                node.left = DeserializeHelper(values, ref index);
                node.right = DeserializeHelper(values, ref index);
                return node;
            }
            else
            {
                throw new FormatException("Invalid format for tree node value.");
            }
        }

        // Your Codec object will be instantiated and called as such:
        // Codec ser = new Codec();
        // Codec deser = new Codec();
        // String tree = ser.serialize(root);
        // TreeNode ans = deser.deserialize(tree);
        // return ans;
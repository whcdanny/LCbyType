//Leetcode 297. Serialize and Deserialize Binary Tree hard
//题意：给定一个二叉树，设计一个算法来序列化和反序列化它。序列化指将一个数据结构转化为一个字符串，反序列化指将字符串转化为相同的数据结构。
//思路：广度优先搜索（BFS）序列化：先序遍历, 将节点的值以及空节点的信息存储到字符串中。反序列化：递归的方式来构建二叉树。
//时间复杂度: 都是O(n)，其中 n 是二叉树的节点数。
//空间复杂度：取决于队列的大小，最坏情况下是都是 O(n)，因为队列可能包含所有节点。
        public class Codec
        {

            // Encodes a tree to a single string.
            public string serialize(TreeNode root)
            {
                StringBuilder builder = new StringBuilder();
                serizlizeBuild(root, builder);
                return builder.ToString();

            }

            private void serizlizeBuild(TreeNode root, StringBuilder builder)
            {
                if(root == null)
                {
                    builder.Append("null").Append(",");
                    return;
                }
                builder.Append(root.val.ToString()).Append(",");
                serizlizeBuild(root.left, builder);
                serizlizeBuild(root.right, builder);
            }

            // Decodes your encoded data to tree.
            public TreeNode deserialize(string data)
            {
                Queue<string> queue = new Queue<string>(data.Split(","));
                return deserizlizeBuild(queue);
            }

            private TreeNode deserizlizeBuild(Queue<string> queue)
            {
                TreeNode root = new TreeNode();
                string val = queue.Dequeue();
                if (val == "null")
                    return null;
                root = new TreeNode(int.Parse(val));
                root.left = deserizlizeBuild(queue);
                root.right = deserizlizeBuild(queue);
                return root;
            }
        }

        // Your Codec object will be instantiated and called as such:
        // Codec ser = new Codec();
        // Codec deser = new Codec();
        // TreeNode ans = deser.deserialize(ser.serialize(root));
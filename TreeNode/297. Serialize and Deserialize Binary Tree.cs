//297. Serialize and Deserialize Binary Tree hard
//给你输入一棵二叉树的根节点 root，要求你实现 1.把一棵二叉树序列化成字符串 2.把字符串反序列化成二叉树
//至于以什么格式序列化和反序列化，这个完全由你决定
//思路：用StringBuilder 可以用于高效拼接字符串，并且用上"," "#"分别表示空值和分隔符；
//serialize:将每个root的值放入，如果左右有空集，放入#，然后每放入一个值，用，隔开；
//deserialize: 根据上面得到的string，先用，把每一位string存入list里，然后用一个nodesStart来表示每一次读到的位置并且不受递归的干扰，然后根据读到的string转换成int再创建root，如果发现#则说明这一支走完了跳出递归，如果nodesStart大于总长度说明结束；
		public string NULL = "#";
        public string SEP = ",";
        public string serialize(TreeNode root)
        {
			//StringBuilder 可以用于高效拼接字符串
            StringBuilder sb = new StringBuilder();
            serializeHelp(root, sb);
            return sb.ToString();
        }

        public void serializeHelp(TreeNode root, StringBuilder sb)
        {
            if (root == null)
            {
                sb.Append(NULL).Append(SEP);
                return;
            }
			/****** 前序位置 ******/
            sb.Append(root.val).Append(SEP);
            serializeHelp(root.left, sb);
            serializeHelp(root.right, sb);
        }

        // Decodes your encoded data to tree.
        public TreeNode deserialize(string data)
        {
            if (data.Length == 0)
            {
                return null;
            }
            string[] nodes = data.Split(",");
            TreeNode root = deserializeHello(nodes);
            return root;
        }

        int nodesStart = 0;
        public TreeNode deserializeHello(string[] nodes)
        {
            if (nodesStart > nodes.Length)
            {
                return null;
            }
            if (nodes[nodesStart].Equals("#"))
            {
                nodesStart++;
                return null;
            }
            int rootVal = int.Parse(nodes[nodesStart]);
            nodesStart++;
            TreeNode root = new TreeNode(rootVal);
            root.left = deserializeHello(nodes);
            root.right = deserializeHello(nodes);
            return root;
        }
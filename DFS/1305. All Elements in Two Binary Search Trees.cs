//Leetcode 1305. All Elements in Two Binary Search Trees med
//题意：给定两个二叉搜索树 root1 和 root2，返回一个包含两棵树中所有整数的升序排序列表。
//思路：DFS, 简单方法，存入所有val，然后sort
//时间复杂度: O(M + N)，其中 M 和 N 分别是两棵树的节点数
//空间复杂度：O(M + N)
        public IList<int> GetAllElements(TreeNode root1, TreeNode root2)
        {
            List<int> result = new List<int>();
            DFS_GetAllElements(root1, result);
            DFS_GetAllElements(root2, result);
            result.Sort();
            return result;
        }
        private void DFS_GetAllElements(TreeNode root, List<int> result)
        {
            if (root == null)
                return;

            DFS_GetAllElements(root.left, result);
            result.Add(root.val);
            DFS_GetAllElements(root.right, result);
        }
        //思路：GetAllElements 函数是主函数，它使用两个栈 stack1 和 stack2 来存储树节点，并模拟中序遍历过程。然后，按照升序将两个栈中的节点值合并到结果列表中。
        //具体的步骤如下：
        //定义一个结果列表 result 和两个栈 stack1 和 stack2。
        //使用 PushLeftNodes 函数将树的左子节点沿着左子树路径推入栈中。
        //在两个栈都不为空的情况下，比较两个栈顶元素的值，选择值较小的栈进行弹出操作，并将弹出的节点值添加到结果列表中。
        //将弹出节点的右子节点及其左子树推入相应的栈中。
        //重复步骤 3-4 直到两个栈都为空。
        //返回结果列表。
        //时间复杂度: O(M + N)，其中 M 和 N 分别是两棵树的节点数
        //空间复杂度：O(M + N)
        public IList<int> GetAllElements1(TreeNode root1, TreeNode root2)
        {
            List<int> result = new List<int>();
            Stack<TreeNode> stack1 = new Stack<TreeNode>();
            Stack<TreeNode> stack2 = new Stack<TreeNode>();

            PushLeftNodes(root1, stack1);
            PushLeftNodes(root2, stack2);

            while (stack1.Count > 0 || stack2.Count > 0)
            {
                Stack<TreeNode> currentStack = (stack2.Count == 0 || (stack1.Count > 0 && stack1.Peek().val <= stack2.Peek().val)) ? stack1 : stack2;
                TreeNode node = currentStack.Pop();
                result.Add(node.val);

                PushLeftNodes(node.right, currentStack);
            }

            return result;
        }

        private void PushLeftNodes(TreeNode root, Stack<TreeNode> stack)
        {
            while (root != null)
            {
                stack.Push(root);
                root = root.left;
            }
        }
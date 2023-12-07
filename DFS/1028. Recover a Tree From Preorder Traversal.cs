//Leetcode 1028. Recover a Tree From Preorder Traversal hard
//题意：二叉树的根运行先序深度优先搜索（DFS）。在这个遍历中，对于每个节点，我们输出D个破折号（其中D是该节点的深度），然后输出该节点的值。如果一个节点的深度是D，则它的直接子节点的深度是D + 1。根节点的深度为0。
//如果一个节点只有一个子节点，那么该子节点必定是左子节点。
//给定这个遍历的输出，恢复二叉树并返回其根节点。
//思路：DFS, 根据是否有‘-’来判断是否为数字，再根据有多少‘-’来半段层数。
//注：先都是left，所以只要保证没越界，就先left然后right；string转换int；int.Parse(val)
//时间复杂度: O(N)，其中N是字符串的长度
//空间复杂度：O(H)，其中H是树的高度
        public TreeNode RecoverFromPreorder(string s)
        {
            int index = 0;
            int req = 0;

            return DFS_RecoverFromPreorder(req, index, s, 0);
        }

        TreeNode DFS_RecoverFromPreorder(int req, int index, string s, int level)
        {
            string val = "";
            req = 0;
            while (index < s.Length && s[index] != '-')
            {
                val += s[index];
                index++;
            }
            TreeNode node = new TreeNode(int.Parse(val));
            while (index < s.Length && s[index] == '-')
            {
                req++;
                index++;
            }
            if (req > level)
            {
                node.left = DFS_RecoverFromPreorder(req, index, s, level + 1);
                if (index < s.Length && req > level)
                    node.right = DFS_RecoverFromPreorder(req, index, s, level + 1);
            }
            return node;
        }
        //思路：
        //根据先序遍历的规律，我们可以根据破折号的个数确定每个节点的深度。
        //使用一个栈来辅助构建二叉树，栈中存放的是当前深度的节点。
        //对于每个节点，先确定它的深度，然后根据深度和栈的情况，确定它的父节点。
        //如果当前深度小于栈的大小，说明该节点是某个父节点的左子节点，将父节点出栈并入栈当前节点。
        //如果当前深度等于栈的大小，说明该节点是栈顶节点的右子节点，直接入栈当前节点。
        //最后栈中剩下的就是整棵树的根节点。
        public TreeNode RecoverFromPreorder1(string S)
        {
            Stack<TreeNode> stack = new Stack<TreeNode>();
            int index = 0;

            while (index < S.Length)
            {
                int level = 0;

                while (S[index] == '-')
                {
                    level++;
                    index++;
                }

                int val = 0;

                while (index < S.Length && Char.IsDigit(S[index]))
                {
                    val = val * 10 + (S[index] - '0');
                    index++;
                }

                TreeNode node = new TreeNode(val);

                while (stack.Count > level)
                {
                    stack.Pop();
                }

                if (stack.Count > 0)
                {
                    if (stack.Peek().left == null)
                    {
                        stack.Peek().left = node;
                    }
                    else
                    {
                        stack.Peek().right = node;
                    }
                }

                stack.Push(node);
            }

            while (stack.Count > 1)
            {
                stack.Pop();
            }

            return stack.Pop();
        }
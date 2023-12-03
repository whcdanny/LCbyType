//Leetcode 2096. Step-By-Step Directions From a Binary Tree Node to Another med
//题意：给你root一个带有节点的二叉树n。1每个节点都被唯一分配一个从到 的值n。您还将获得一个startValue表示起始节点值的整数s和一个destValue表示目标节点值的不同整数t。
//找到从节点 开始到节点 结束的最短路径。将此类路径的逐步方向生成为仅由大写字母、和组成的字符串。每个字母表示一个特定的方向：st'L''R''U'
//'L'意思是从一个节点到它的左子节点。
//'R'意思是从一个节点到它的右子节点。
//'U'意思是从一个节点到它的父节点。
//这是一个从二叉树节点到另一个节点的最短路径问题。 
//思路：DFS, 先找到从root到start和end的从上往下的path；从上往下找，移除相同的path，这是为了找到真正分开的点；因为从分开点到终点之前是DFS，所以是倒序，所以要反转一下；再把从开始的路线因为要去到parent，所以要都改成U；
//时间复杂度:  O(tree depth)
//空间复杂度： O(tree depth)
        public string GetDirections(TreeNode root, int startValue, int destValue)
        {
            StringBuilder rootToStartChars = new StringBuilder(), rootToFinalChars = new StringBuilder();
            //先找到从root到start和end的从上往下的path；
            DFS_GetDirections(root, startValue, rootToStartChars);
            DFS_GetDirections(root, destValue, rootToFinalChars);
            //从上往下找，移除相同的path，这是为了找到真正分开的点；
            RemoveCommonPath(rootToStartChars, rootToFinalChars);
            //因为从分开点到终点之前是DFS，所以是倒序，所以要反转一下；
            ReverseSB(rootToFinalChars);
            //再把从开始的路线因为要去到parent，所以要都改成U；
            rootToStartChars.Replace('R', 'U');
            rootToStartChars.Replace('L', 'U');
            //最后将两个合并；
            return rootToStartChars.Append(rootToFinalChars).ToString();
        }
        private bool DFS_GetDirections(TreeNode node, int find, StringBuilder target)
        {
            if (node is null) 
                return false;
            if (node.val == find) 
                return true;

            var left = DFS_GetDirections(node.left, find, target);
            if (left) 
                target.Append('L');
            var right = DFS_GetDirections(node.right, find, target);
            if (right) 
                target.Append('R');

            return left || right;
        }
        
        private void RemoveCommonPath(StringBuilder path1, StringBuilder path2)
        {
            while (path1.Length > 0 && path2.Length > 0 && path1[path1.Length - 1] == path2[path2.Length - 1])
            {
                path1.Remove(path1.Length - 1, 1);
                path2.Remove(path2.Length - 1, 1);
            }
        }
       
        private void ReverseSB(StringBuilder path)
        {
            for (int i = 0; i < path.Length / 2; i++)
            {
                var temp = path[path.Length - i - 1];
                path[path.Length - i - 1] = path[i];
                path[i] = temp;
            }
        }
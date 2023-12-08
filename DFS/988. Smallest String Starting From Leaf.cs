//Leetcode 988. Smallest String Starting From Leaf med
//题意：给定一个二叉树，每个节点包含一个小写字母。从根到叶子节点的路径构成一个字符串。找出所有路径中字典序最小的字符串。
//思路：DFS（深度优先搜索）遍历二叉树。在遍历的过程中，将路径上的字符加入一个字符串中，表示当前路径构成的字符串。当到达叶子节点时，比较当前路径构成的字符串与之前的最小字符串，更新最小字符串。最后返回最小字符串。
//时间复杂度: O(N)，其中N是二叉树中的节点数
//空间复杂度：O(H)，其中H是树的高度。     
        private string smallestString_SmallestFromLeaf;
        public string SmallestFromLeaf(TreeNode root)
        {
            smallestString_SmallestFromLeaf = null;
            DFS_SmallestFromLeaf(root, new StringBuilder());
            return smallestString_SmallestFromLeaf;
        }

        private void DFS_SmallestFromLeaf(TreeNode node, StringBuilder currentString)
        {
            if (node == null)
                return;

            currentString.Insert(0, (char)('a' + node.val));

            if (node.left == null && node.right == null)
            {
                // Leaf node
                string pathString = currentString.ToString();
                if (smallestString_SmallestFromLeaf == null || string.Compare(pathString, smallestString_SmallestFromLeaf) < 0)
                {
                    smallestString_SmallestFromLeaf = pathString;
                }
            }

            DFS_SmallestFromLeaf(node.left, currentString);
            DFS_SmallestFromLeaf(node.right, currentString);

            currentString.Remove(0, 1); // Backtrack
        }
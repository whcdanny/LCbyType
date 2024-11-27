//Leetcode 199. Binary Tree Right Side View med
//题意：给定一个二叉树，想象自己站在树的右侧，返回从顶部到底部可看到的节点值。
//注：说白了最每层最右侧；
//思路：深度优先搜索（DFS）来解决。
//具体思路如下：对树进行深度优先搜索，从根节点开始，每层只选择最右边的节点。
//使用一个变量 maxDepth 来记录当前访问的层数，每次访问新的节点时，与 maxDepth 比较，
//如果大于 maxDepth，则说明是新的一层的最右边节点。
//时间复杂度: O(n)，其中 n 是二叉树中节点的数量
//空间复杂度：O(h)，其中 h 是二叉树的高度。在最坏情况下，二叉树为单链表，高度为 n，因此空间复杂度为 O(n)。
        public IList<int> RightSideView(TreeNode root)
        {
            List<int> result = new List<int>();
            DFS_RightSideView(root, 0, result);
            return result;
        }

        private void DFS_RightSideView(TreeNode node, int depth, List<int> result)
        {
            if (node == null)
            {
                return;
            }

            if (depth == result.Count)
            {
                result.Add(node.val); // 当前深度是新的一层
            }

            DFS_RightSideView(node.right, depth + 1, result); // 先访问右子树，保证每层只选择最右边的节点
            DFS_RightSideView(node.left, depth + 1, result);
        }
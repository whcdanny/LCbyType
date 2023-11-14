//Leetcode 1379. Find a Corresponding Node of a Binary Tree in a Clone of That Tree ez
//题意：给定两个二叉树original，并给出对原始树中cloned节点的引用。target树cloned是树的副本original。返回对树中同一节点的引用cloned。请注意，您不允许更改两棵树或target节点中的任何一个，并且答案必须是对树中节点的引用cloned。
//思路： BFS（广度优先搜索）遍历克隆树，查找与原树中目标节点值相同的节点。
//时间复杂度: O(n)，其中 n 是树的节点数。
//空间复杂度：O(n)
        public TreeNode GetTargetCopy(TreeNode original, TreeNode cloned, TreeNode target)
        {
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(cloned);

            while (queue.Count > 0)
            {
                TreeNode current = queue.Dequeue();

                if (current.val == target.val)
                {
                    return current;
                }

                if (current.left != null)
                {
                    queue.Enqueue(current.left);
                }

                if (current.right != null)
                {
                    queue.Enqueue(current.right);
                }
            }

            return null;
        }
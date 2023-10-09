//Leetcode 1650 lowest common ancestor of a binary tree iii med 
//题意：给定一个二叉树，该树包含指向父节点的指针 TreeNodeWithParent（这个结构我将会在后面的代码中给出）和两个节点 p 和 q。要求找到它们的最低公共祖先
//思路：DFS，找到节点 p 和 q 到达根节点的路径（用一个 HashSet 来存储路径上的节点）。然后遍历节点 p 到根节点的路径，寻找第一个出现在路径上的节点 q。这个节点就是 p 和 q 的最低公共祖先。
//时间复杂度:  树的高度为 h, O(h)
//空间复杂度： O(h);
        public TreeNodeWithParent LowestCommonAncestor(TreeNodeWithParent p, TreeNodeWithParent q)
        {
            HashSet<TreeNodeWithParent> ancestors = new HashSet<TreeNodeWithParent>();

            while (p != null)
            {
                ancestors.Add(p);
                p = p.parent;
            }

            while (q != null)
            {
                if (ancestors.Contains(q))
                {
                    return q;
                }
                q = q.parent;
            }

            return null;
        }

//1650.Lowest Common Ancestor Of A Binary Tree III med
//给p,q让你找出公共的祖先(LCA)，这里Node不仅含有left和right，还有parent，前提查找的数肯定在所给的TreeNode里
//思路：跟链表一样，既然都能查到parent，那就一路往父亲走，如果走到头，就去走另一个node，也就是p走完了，去走q，同时q也走自己的，走完了去走p，最后两个总会在相遇，这个相遇就是LCA;

		public Node lowestCommonAncestor(Node p, Node q)
        {
            // 施展链表双指针技巧
            Node a = p, b = q;
            while (a != b)
            {
                // a 走一步，如果走到根节点，转到 q 节点
                if (a == null) a = q;
                else a = a.parent;
                // b 走一步，如果走到根节点，转到 p 节点
                if (b == null) b = p;
                else b = b.parent;
            }
            return a;
        }
//Leetcode 173. Binary Search Tree Iteratorr  mid
//题意：实现一个二叉搜索树的迭代器，该迭代器可以按照中序遍历的顺序访问二叉搜索树中的节点。
//思路：Stack 我们需要明确中序遍历的顺序是从左子树到根节点再到右子树的顺序。因此，我们可以使用一个栈来辅助实现中序遍历。具体思路如下：
//在构造函数 BSTIterator(TreeNode root) 中，我们将根节点及其所有左子节点依次入栈，直到找到最左边的节点为止。这样，栈顶元素就是最小的节点。
//在 hasNext() 方法中，我们只需要判断栈是否为空即可。
//在 next() 方法中，我们首先弹出栈顶元素，然后将栈顶元素的右子树及其所有左子节点依次入栈，以保证下一次调用 next() 方法时可以返回下一个节点。
//时间复杂度:  O(h)其中 h 是树的高度。Next() 方法和 HasNext() 方法的时间复杂度均为 O(1)。
//空间复杂度：  O(h)，其中 h 是树的高度
        public class BSTIterator
        {

            public Stack<TreeNode> stack = new Stack<TreeNode>();
            public BSTIterator(TreeNode root)
            {
                push(root);
            }

            private void push(TreeNode root)
            {
                while (root != null)
                {
                    stack.Push(root);
                    root = root.left;
                }
            }

            public int Next()
            {
                TreeNode tnode = stack.Pop();
                push(tnode.right);
                return tnode.val;
            }

            public bool HasNext()
            {
                if (stack.Count > 0)
                    return true;
                else
                    return false;
            }
        }
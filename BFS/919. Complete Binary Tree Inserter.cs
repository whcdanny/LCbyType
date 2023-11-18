//Leetcode 919. Complete Binary Tree Inserter med
//题意：设计一个数据结构实现完全二叉树插入器 CBTInserter，支持以下操作：
//CBTInserter(TreeNode root)：使用给定的根节点构造 CBTInserter 类。
//int insert(int v)：向完全二叉树中插入一个新节点，返回插入节点的值。
//TreeNode get_root()：返回完全二叉树的根节点。完全二叉树的定义是，除了最底层可能不是满的，其他层都是满的，并且所有节点都尽可能地靠左。
//思路：使用 BFS 使用 BFS 构建完全二叉树。在插入节点时，通过 BFS 遍历找到可以插入新节点,如果这个节点有左右点，难就不加入queue中，我们只考虑缺少左右支，添加的时候。        
//时间复杂度: O(1)。
//空间复杂度：O(n)
        public class CBTInserter
        {
            TreeNode main_node = new TreeNode();
            Queue<TreeNode> queue = new Queue<TreeNode>();
            public CBTInserter(TreeNode root)
            {
                main_node = root;
                queue.Enqueue(main_node);
                while (queue.Peek().left != null || queue.Peek().right != null)
                {
                    if (queue.Peek().left != null) 
                        queue.Enqueue(queue.Peek().left);
                    if (queue.Peek().right != null) 
                        queue.Enqueue(queue.Peek().right);
                    if (queue.Peek().left != null && queue.Peek().right != null) 
                        queue.Dequeue();
                    else
                        break;
                }
            }

            public int Insert(int val)
            {
                var add = new TreeNode(val);
                queue.Enqueue(add);
                if (queue.Peek().left == null) 
                    queue.Peek().left = add;
                else { 
                    queue.Peek().right = add; 
                    return queue.Dequeue().val; 
                }
                return queue.Peek().val;
            }

            public TreeNode Get_root()
            {
                return main_node;
            }
        }

        /**
         * Your CBTInserter object will be instantiated and called as such:
         * CBTInserter obj = new CBTInserter(root);
         * int param_1 = obj.Insert(val);
         * TreeNode param_2 = obj.Get_root();
         */
//Leetcode 2641. Cousins in Binary Tree II  mid
//题意：给定一个二叉树的根节点 root，将树中每个节点的值替换为其所有堂兄弟节点值的和。在二叉树中，如果两个节点在相同的深度上但有不同的父节点，那么它们被称为堂兄弟节点。要求返回修改后的树的根节点。注意，一个节点的深度是指从根节点到该节点的路径中的边的数量。
//思路：广度优先搜索（BFS）遍历树，同时记录每层的节点数量。 将节点的左右子节点加入队列，并更新当前层的堂兄弟节点值之和。对于每个节点，根据其左右子节点的情况，将对应的值添加到 cousins 列表中。遍历 cousins 列表，根据其中的值，更新节点的值
//时间复杂度: O(n)，其中 n 是二叉树中节点的数量
//空间复杂度：O(w)，其中 w 是树的宽度
        public TreeNode ReplaceValueInTree(TreeNode root)
        {
            if (root == null) return null;

            Queue<TreeNode> queue = new Queue<TreeNode>();            
            queue.Enqueue(root);
            root.val = 0;            
            while (queue.Count > 0)
            {
                List<TreeNode> tempList = new List<TreeNode>();
                List<int> cousins = new List<int>();
                int sum = 0;
                int levelSize = queue.Count;
                
                for (int i = 0; i < levelSize; i++)
                {
                    TreeNode node = queue.Dequeue();                    

                    if (node.left != null)
                    {
                        tempList.Add(node.left);
                        queue.Enqueue(node.left);
                        sum += node.left.val;
                    }

                    if (node.right != null)
                    {
                        tempList.Add(node.right);
                        queue.Enqueue(node.right);
                        sum += node.right.val;
                    }

                    if(node.left!=null && node.right != null)
                    {
                        cousins.Add(2);
                        continue;
                    }
                    if ((node.left != null && node.right == null)||(node.left == null && node.right != null))
                    {
                        cousins.Add(1);
                        continue;
                    }
                }
                int index = 0;
                for(int i = 0; i < cousins.Count; i++)
                {
                    if (cousins[i] == 2)
                    {
                        var sumofTwo = tempList[index].val + tempList[index + 1].val;
                        tempList[index].val = sum - sumofTwo;
                        tempList[index + 1].val = sum - sumofTwo;
                        index += 2;
                    }
                    else
                    {
                        tempList[index].val = sum - tempList[index].val;
                        index++;
                    }
                }                
            }
            
            return root;
        }
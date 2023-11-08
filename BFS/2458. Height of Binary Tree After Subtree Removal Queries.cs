//Leetcode 2458. Height of Binary Tree After Subtree Removal Queries hard
//题意：你会得到一个具有 n 个节点的二叉树，每个节点都分配了一个从 1 到 n 的唯一值。你还会得到一个大小为 m 的数组 queries。对于第 i 个查询，你要做以下操作：从树中删除以值为 queries[i] 的节点为根的子树。保证 queries[i] 的值不等于根的值。返回一个大小为 m 的数组 answer，其中 answer[i] 是执行第 i 个查询后树的高度。
//思路：我们可以使用BFS（广度优先搜索）,依此找到被删的node，在历遍过程中如果跟当前要删除的node值一样跳过，直到结束；
//时间复杂度: 假设树的高度为 h，处理一个查询的时间复杂度为 O(h)，总共处理 m 个查询，所以总的时间复杂度为 O(mh)。
//空间复杂度：O(n)
        public int[] TreeQueries(TreeNode root, int[] queries)//超时
        {
            int[] results = new int[queries.Length];
            for (int i = 0; i < queries.Length; i++)
            {
                Queue<TreeNode> queue = new Queue<TreeNode>();
                queue.Enqueue(root);
                int level = 0;
                while (queue.Count > 0)
                {
                    int count = queue.Count;
                    level++;
                    for (int j = 0; j < count; j++)
                    {
                        TreeNode cur = queue.Dequeue();
                        if (cur.left != null && cur.left.val != queries[i])
                        {
                            queue.Enqueue(cur.left);
                        }
                        if (cur.right != null && cur.right.val != queries[i])
                        {
                            queue.Enqueue(cur.right);
                        }
                    }
                }
                results[i] = level - 1;
            }
            return results;
        }
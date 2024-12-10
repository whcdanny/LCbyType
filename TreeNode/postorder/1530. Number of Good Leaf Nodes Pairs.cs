//Leetcode 1530. Number of Good Leaf Nodes Pairs med
//题意：给定一棵二叉树的根节点 root 和一个整数 distance，我们需要找到树中满足以下条件的叶节点对的数量：
//一对不同的叶节点（leaf1 和 leaf2），其最短路径长度（从 leaf1 到 leaf2 的边数）小于或等于 distance。
//注意：两个叶节点之间的最短路径是通过它们的最近公共祖先计算得到的。返回满足条件的叶节点对的数量。
//思路：后序遍历：
//对于每个节点，计算其左子树和右子树的叶节点到当前节点的距离。
//合并左右子树的叶节点距离，计算是否有符合条件的叶节点对。
//将当前节点的叶节点距离向上传递给父节点。
//叶节点的距离存储：
//使用一个数组 distances，其中 distances[i] 表示当前子树中到根节点的距离为 i 的叶节点数。
//计数满足条件的叶节点对：
//对于左子树中的叶节点 l 和右子树中的叶节点 r，如果 l + r <= distance，则这对叶节点是“好对”。
//count += leftDistances[left] * rightDistances[right];
//时间复杂度：O(n⋅d^2)
//空间复杂度：O(n⋅d)
        public int CountPairs(TreeNode root, int distance)
        {
            int count = 0;

            // 后序遍历辅助函数
            int[] PostOrder(TreeNode node)
            {
                if (node == null) return new int[distance + 1];

                // 如果是叶子节点
                if (node.left == null && node.right == null)
                {
                    var leafDistances = new int[distance + 1];
                    leafDistances[1] = 1; // 到自己距离为 1
                    return leafDistances;
                }

                // 递归计算左右子树的叶节点距离分布
                int[] leftDistances = PostOrder(node.left);
                int[] rightDistances = PostOrder(node.right);

                // 统计符合条件的叶节点对
                for (int left = 1; left <= distance; left++)
                {
                    for (int right = 1; right <= distance; right++)
                    {
                        if (left + right <= distance)
                        {
                            count += leftDistances[left] * rightDistances[right];
                        }
                    }
                }

                // 更新当前节点的叶节点距离分布
                var currentDistances = new int[distance + 1];
                for (int i = 1; i < distance; i++)
                {
                    currentDistances[i + 1] = leftDistances[i] + rightDistances[i];
                }
                return currentDistances;
            }

            PostOrder(root);
            return count;
        }
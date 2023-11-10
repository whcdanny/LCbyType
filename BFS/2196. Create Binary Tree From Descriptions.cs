//Leetcode 2196. Create Binary Tree From Descriptions hard
//题意：给定一个二维数组 descriptions，表示一棵二叉树的结构。数组中的每个元素是一个长度为 2 的数组 [parent, child]，表示父节点和子节点的关系。其中，parent 是父节点的值，child 是子节点的值。数组中的每个元素都是唯一的，且父节点和子节点的值范围为 1 到 1000。你需要根据 descriptions 中的信息构建出对应的二叉树，并返回二叉树的根节点。如果构建不成功，则返回空。
//思路：用dictionary存储node和相对应的treenode，然后找出root，然后根据description来添加和更新
//时间复杂度: 假设 descriptions 数组的长度为 n。遍历数组构建字典的时间复杂度为 O(n)，遍历字典构建二叉树的时间复杂度也是 O(n)。因此，总的时间复杂度为 O(n)。
//空间复杂度：我们使用了一个字典来存储节点的关系，字典的空间复杂度为 O(n)。此外，我们还需要一些额外的空间来存储二叉树的节点，但它们的数量不会超过 n。
        public TreeNode CreateBinaryTree(int[][] descriptions)
        {
            // save nodes using a hash map, where keys are TreeNode.val
            Dictionary<int, TreeNode> dict = new Dictionary<int, TreeNode>(descriptions.Length);

            // find root, which is the only node that is not in desc[k][1] but in desc[k][0]
            // linq is used here, maybe hash set is better
            var rootVal = descriptions.Select(x => x[0]).Except(descriptions.Select(x => x[1])).Single();

            foreach (var d in descriptions)
            {
                // create parent and child nodes if any of them doesn't exist
                if (!dict.ContainsKey(d[0]))
                {
                    dict.Add(d[0], new TreeNode(d[0]));
                }
                if (!dict.ContainsKey(d[1]))
                {
                    dict.Add(d[1], new TreeNode(d[1]));
                }

                // set up left or right child
                if (d[2] == 1)
                {
                    dict[d[0]].left = dict[d[1]];
                }
                else
                {
                    dict[d[0]].right = dict[d[1]];
                }
            }

            return dict[rootVal];
        }
//Leetcode 2471. Minimum Number of Operations to Sort a Binary Tree by Level med
//题意：给定一棵具有唯一值的二叉树的根节点 root。 在一次操作中，你可以选择同一层中的任意两个节点，并交换它们的值。返回使每一层的值按严格递增顺序排序所需的最小操作次数。
//思路：我们可以使用BFS（广度优先搜索）,遍历树，记录每一层的节点和对应的值。对于每一层的节点值，计算最小交换次数。返回总的最小交换次数。
//时间复杂度: 假设树的节点数为 n，遍历树需要 O(n) 的时间，对每一层计算最小交换次数也需要 O(n) 的时间，因此总的时间复杂度为 O(n^2)。
//空间复杂度：O(n)
        public int MinimumOperations(TreeNode root)
        {
            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            int minOps = 0;
            while (queue.Count > 0)
            {
                int size = queue.Count;
                int[] arr = new int[size];
                int index = 0;
                for (int i = 0; i < size; i++)
                {
                    var currNode = queue.Dequeue();
                    arr[index++] = currNode.val;

                    if (currNode.left != null)
                        queue.Enqueue(currNode.left);

                    if (currNode.right != null)
                        queue.Enqueue(currNode.right);
                }

                minOps += this.SelectionSort(arr);
            }

            return minOps;
        }

        private int SelectionSort(int[] arr)
        {
            int swapsCount = 0;

            for (int i = 0; i < arr.Length - 1; i++)
            {
                int minIndex = i;

                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j] < arr[minIndex])
                        minIndex = j;
                }

                if (minIndex != i)
                {
                    int temp = arr[minIndex];
                    arr[minIndex] = arr[i];
                    arr[i] = temp;

                    swapsCount++;
                }
            }

            return swapsCount;
        }
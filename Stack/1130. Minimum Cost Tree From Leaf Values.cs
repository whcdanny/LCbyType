//Leetcode 1130. Minimum Cost Tree From Leaf Values med
//题意：给定一个正整数数组 arr，我们考虑将它转换为一棵二叉树。这棵二叉树具有以下特点：
//每个节点要么没有孩子节点，要么有两个孩子节点；
//数组 arr 中的值对应于树的叶子节点在中序遍历时的值；
//非叶子节点的值等于其左右子树中叶子节点的最大值的乘积。
//思路：stack, 最小化的是非叶子节点的值的和,
//我们希望尽量将较大的叶子节点值放在一起，因为这样可以减小它们的乘积，从而减小非叶子节点的值
//说白了，把最大的值留在最后再相乘，这样就就会小一点；
//我们可以使用单调递减栈来维护当前子数组的最大值，然后从栈顶取出最大值作为左子树的叶子节点，栈中剩余的值作为右子树的叶子节点，这样构成的子树乘积最小；
//最终，我们将所有的子树乘积相加，即为所求的最小值。
//时间复杂度: O(n)，其中 n 为数组 arr 的长度，我们需要遍历数组并维护单调递减栈
//空间复杂度：O(n)
        public int MctFromLeafValues(int[] arr)
        {
            Stack<int> stack = new Stack<int>();
            int result = 0;

            foreach (int num in arr)
            {
                while (stack.Count > 0 && stack.Peek() <= num)
                {
                    int mid = stack.Pop();
                    if (stack.Count > 0)
                    {
                        result += mid * Math.Min(stack.Peek(), num);
                    }
                    else
                    {
                        result += mid * num;
                    }
                }
                stack.Push(num);
            }

            while (stack.Count > 1)
            {
                result += stack.Pop() * stack.Peek();
            }

            return result;
        }
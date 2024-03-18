//Leetcode 769. Max Chunks To Make Sorted med
//题意：给定一个长度为 n 的数组 arr，数组中的元素是 [0, n - 1] 的排列。
//要求将数组 arr 分割成若干个子数组（称为块），对每个子数组进行排序后再拼接，使得整个数组有序。求最多可以将数组分成多少个块。
//思路：Stack, 栈来模拟排序过程。
//在遍历过程中，如果当前元素大于等于栈顶元素，则直接入栈；
//否则，弹出栈中大于当前元素的元素，直到栈为空或者栈顶元素小于等于当前元素。
//最终栈中剩余的元素个数即为最多可以分成的块数        
//时间复杂度：O(n)，其中 n 为数组的长度，遍历数组一次
//空间复杂度：O(1) 

        public int MaxChunksToSorted(int[] arr)
        {
            Stack<int> stack = new Stack<int>();

            foreach (int num in arr)
            {
                if (stack.Count == 0 || num >= stack.Peek())
                {
                    stack.Push(num);
                }
                else
                {
                    int top = stack.Pop();
                    while (stack.Count > 0 && stack.Peek() > num)
                    {
                        stack.Pop();
                    }
                    stack.Push(top);
                }
            }

            return stack.Count;
        }
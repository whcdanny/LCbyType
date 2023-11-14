//Leetcode 1298. Maximum Candies You Can Get from Boxes hard
//题意：给定 n 个盒子，每个盒子都有一个独一无二的编号 box[i]，其中 box[i] = [status_i, candies_i, keys_i, containedBoxes_i]，其中：
//status_i：盒子的状态，为 1 表示盒子是开着的，为 0 表示盒子是关着的。
//candies_i：盒子内的糖果数目。
//keys_i：盒子内的盒子所需的钥匙，是一个数组。
//containedBoxes_i：盒子内包含的盒子的编号，是一个数组。
//给定初始状态 status, candies, 和 keys 数组，其中：
    //status[i]：盒子 i 的初始状态（0 表示关着，1 表示开着）。
    //candies[i]：盒子 i 中的糖果数。
    //keys[i]：盒子 i 中的钥匙数组。
    //initialBoxes：一个数组，表示最初你已经打开的盒子。
//你每次可以选择一个盒子 i，如果盒子 i 是开着的，你可以获得盒子 i 中的糖果。然后，你可以使用盒子 i 中的钥匙打开其他盒子。请你返回可以获得的最大糖果数。
//思路：BFS ，定义一个队列用于存放当前可以打开的盒子。然后，循环遍历队列，对于每个盒子，如果它是开着的，就可以获取糖果并使用里面的钥匙打开其他盒子。如果锁着就添加到temp里等着之后如果拿到钥匙再打，并添加到循环队列；
//时间复杂度: O(N)，其中 N 是盒子的数量。
//空间复杂度：O(N)
        public int MaxCandies(int[] status, int[] candies, int[][] keys, int[][] containedBoxes, int[] initialBoxes)
        {
            int n = status.Length;
            int result = 0;

            Queue<int> queue = new Queue<int>();
            bool[] visited = new bool[n];
            List<int> delayBox = new List<int>();
            foreach (var box in initialBoxes)
            {
                queue.Enqueue(box);
                visited[box] = true;                
            }
            
            while (queue.Count > 0)
            {
                int currentBox = queue.Dequeue();

                if (status[currentBox] == 1)
                {
                    result += candies[currentBox];

                    foreach (var key in keys[currentBox])
                    {
                        status[key] = 1; // Open the box
                        if (delayBox.Contains(key))
                        {
                            queue.Enqueue(key);
                            delayBox.Remove(key);
                        }
                    }

                    foreach (var containedBox in containedBoxes[currentBox])
                    {
                        if (!visited[containedBox])
                        {
                            if (status[containedBox] == 1)
                            {
                                queue.Enqueue(containedBox);
                                visited[containedBox] = true;
                            }
                            else
                            {
                                delayBox.Add(containedBox);
                                visited[containedBox] = true;
                            }
                        }
                    }
                }
                else
                {
                    delayBox.Add(currentBox);
                }

            }

            return result;
        }
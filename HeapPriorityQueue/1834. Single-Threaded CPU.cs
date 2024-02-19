//Leetcode 1834. Single-Threaded CPU med
//题意：给定n个任务，每个任务有两个属性：进入队列的时间和处理时间。你有一个单线程CPU，可以同时处理一个任务。CPU将按以下方式操作：
//如果CPU处于空闲状态且没有可用任务，则CPU保持空闲。
//如果CPU处于空闲状态且有可用任务，则CPU将选择处理时间最短的任务。如果有多个任务的处理时间相同，则选择索引最小的任务。
//一旦开始执行一个任务，CPU将连续处理整个任务，不间断地执行。
//CPU可以在完成一个任务后立即开始一个新任务。
//要求返回CPU处理任务的顺序。
//思路：PriorityQueue 看code
//使用优先队列（Priority Queue）来模拟CPU的行为。
//将所有任务按照进入队列的时间顺序排序，如果进入时间相同，则按照任务索引排序。
//遍历所有任务，模拟CPU的行为：
//如果CPU处于空闲状态且有任务可用，则选择处理时间最短的任务开始执行。
//如果CPU处于空闲状态但没有可用任务，则跳过当前时间，直到有任务可用。
//如果CPU正在执行任务，则继续执行当前任务，直到任务结束。
//返回CPU处理任务的顺序。
//时间复杂度: O(nlogn)
//空间复杂度：O(n)  
        public int[] GetOrder(int[][] tasks)
        {
            var idx = 0;
            var curr_time = 1;
            var order = new int[tasks.GetLength(0)];
            //给task排序；
            var taskPQ = new PriorityQueue<(int[], int), int>();

            var cpu = new PriorityQueue<(int[], int), (int[], int)>(Comparer<(int[], int)>.Create((a, b) => {
                return (a.Item1[1] == b.Item1[1]) ? a.Item2.CompareTo(b.Item2) : a.Item1[1].CompareTo(b.Item1[1]);
            }));

            for (int i = 0; i < tasks.GetLength(0); i++)
                taskPQ.Enqueue((tasks[i], i), tasks[i][0]);

            while (idx < order.Length)
            {
                while (taskPQ.Count > 0 && taskPQ.Peek().Item1[0] <= curr_time)
                {
                    var task = taskPQ.Dequeue();
                    cpu.Enqueue(task, task);
                }

                if (cpu.Count > 0)
                {
                    var task = cpu.Dequeue();
                    curr_time += task.Item1[1];
                    order[idx++] = task.Item2;
                }
                else
                    curr_time = taskPQ.Peek().Item1[0];
            }

            return order;
        }
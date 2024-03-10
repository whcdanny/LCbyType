//Leetcode 1700. Number of Students Unable to Eat Lunch ez
//题意：描述了一个学校的午餐情景，学校提供圆形和方形的三明治，分别用数字 0 和 1 表示。所有学生排成一队，每个学生要么喜欢方形三明治，要么喜欢圆形三明治。
//午餐时，学生按照队列顺序依次获取三明治。每个学生在每一步操作时会做出以下选择：
//如果队列前面的学生喜欢栈顶的三明治，他们会拿走它并离开队列。
//否则，他们会离开三明治，去队列的末尾排队等待下一轮。
//这样循环进行直到队列中没有学生愿意拿走栈顶的三明治，这些学生就无法吃午餐了。
//给定两个整数数组 students 和 sandwiches，其中 sandwiches[i] 表示栈中第 i 个三明治的类型（i = 0 为栈顶），students[j] 表示初始队列中第 j 个学生的偏好（j = 0 为队列前端）。要求返回无法吃午餐的学生数量。
//思路：Stack + Queue, Queue放入students， stack存sandwich
//每次检查队首学生是否喜欢当前栈顶的三明治。
//如果喜欢，则将该学生移出队列，栈顶的三明治弹出，继续检查下一位学生。
//如果不喜欢，则将该学生移到队列末尾。
//循环直到队列为空或者无法继续为止。
//返回队列中剩余学生的数量，即为无法吃午餐的学生数量。
//时间复杂度：O(n)，其中 n 为学生数量，因为每个学生最多只需要遍历一次。
//空间复杂度：O(1)
        public int CountStudents(int[] students, int[] sandwiches)
        {
            var queue = new Queue<int>(students);
            var stack = new Stack<int>(sandwiches.Reverse());

            var count = sandwiches.Length;
            while (stack.Count != 0 && queue.Contains(stack.Peek()))
            {
                if (queue.Peek() == stack.Peek())
                {
                    stack.Pop();// 学生拿走三明治
                    queue.Dequeue();
                    count--;
                }
                else// 学生移动到队列末尾 
                    queue.Enqueue(queue.Dequeue());
            }

            return count;
        }
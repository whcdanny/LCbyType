//Leetcode 636. Exclusive Time of Functions med
//题意：给定一个包含日志的列表 logs，其中 logs[i] 表示第 i 条日志消息，格式为字符串 "{function_id}:{"start" | "end"}:{timestamp}"。
//例如，"0:start:3" 表示在时间戳 3 开始的函数调用，而 "1:end:2" 表示在时间戳 2 结束的函数调用。注意，一个函数可以被多次调用，可能递归调用。
//现在要计算每个函数的独占时间，即每个函数在程序执行期间的总执行时间，不包括其调用的其他函数的执行时间。
//思路：Stack 栈记录函数的调用情况，以及每个函数的独占时间。
//遍历日志列表 logs，对于每条日志：
//解析日志信息，获取函数 ID、时间戳和日志类型。
//如果日志类型为 "start"，将函数 ID 入栈，并记录当前时间戳。
//如果日志类型为 "end"，弹出栈顶函数 ID，并计算该函数的独占时间，累加到结果数组中。
//计算方法为当前时间戳减去入栈时记录的时间戳加上 1，因为题目要求时间戳为函数结束时的时间。
//如果栈不为空，还需要减去上一个函数调用的时间，因为上一个函数调用的时间也被计算在当前函数的独占时间中了。
//时间复杂度：O(n)，其中 n 为日志条目数，因为需要遍历日志列表一次。
//空间复杂度：O(n) 
        public int[] ExclusiveTime(int n, IList<string> logs)
        {
            int[] exclusiveTime = new int[n];
            Stack<int[]> stack = new Stack<int[]>();

            foreach (string log in logs)
            {
                string[] parts = log.Split(':');
                int id = int.Parse(parts[0]);
                string type = parts[1];
                int time = int.Parse(parts[2]);

                if (type == "start")
                {
                    stack.Push(new int[] { id, time });
                }
                else
                {
                    int[] prev = stack.Pop();
                    int duration = time - prev[1] + 1;
                    exclusiveTime[id] += duration;

                    if (stack.Count > 0)
                    {
                        exclusiveTime[stack.Peek()[0]] -= duration;
                    }
                }
            }

            return exclusiveTime;
        }
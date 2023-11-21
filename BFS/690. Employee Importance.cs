//Leetcode 690. Employee Importance med
//题意：给定一个公司的员工信息，以及每个员工对应的直系下属的员工信息。公司的领导层由一个员工开始构成，此员工对应的直系下属员工的信息用列表表示。每个员工有一个唯一的 ID，他们都是公司的员工之一。为了表示公司的层级结构，需要构建一颗多叉树，其中领导是根节点。公司的每个员工最多有一个直系领导，但可能有多个直系下属。他们用一个 Employee 类表示，其中包含该员工的 ID、重要度和直系下属的 ID 列表。求解：给定一个公司的员工信息，以及每个员工对应的直系下属的员工信息，求出一个员工和他的所有下属的重要度之和。
//思路：广度优先搜索 (BFS)构建一个字典 employeeDict，将员工 ID 映射到对应的 Employee 对象，以便于快速获取员工信息。使用队列 queue 进行 BFS。初始时，将给定的员工 ID 放入队列。在每一步中，从队列中取出一个员工 ID，获取对应的 Employee 对象。将该员工的重要度累加到总重要度中。将该员工的所有下属的 ID 加入队列。重复以上步骤，直到队列为空。
//时间复杂度: 设 n 为员工总数，m 为员工平均下属人数。BFS 遍历了所有员工节点，时间复杂度为 O(n + m)。
//空间复杂度：使用了一个字典 employeeDict 存储员工信息，以及一个队列 queue 存储待处理的员工 ID。因此，空间复杂度为 O(n + m)。
        public class Employee
        {
            public int id;
            public int importance;
            public IList<int> subordinates;
        }
        public int GetImportance1(IList<Employee> employees, int id)
        {
            Dictionary<int, Employee> employeeDict = new Dictionary<int, Employee>();

            // 构建字典，方便通过员工 ID 获取 Employee 对象
            foreach (var employee in employees)
            {
                employeeDict[employee.id] = employee;
            }

            // 使用队列进行 BFS
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(id);

            // 记录总重要度
            int totalImportance = 0;

            while (queue.Count > 0)
            {
                // 出队当前员工 ID
                int currentId = queue.Dequeue();

                // 获取当前员工的 Employee 对象
                Employee currentEmployee = employeeDict[currentId];

                // 累加当前员工的重要度
                totalImportance += currentEmployee.importance;

                // 将当前员工的所有下属加入队列
                foreach (var subordinateId in currentEmployee.subordinates)
                {
                    queue.Enqueue(subordinateId);
                }
            }

            return totalImportance;
        }
//Leetcode 690. Employee Importance med
//题意：给定一个公司的员工信息，以及每个员工对应的直系下属的员工信息。公司的领导层由一个员工开始构成，此员工对应的直系下属员工的信息用列表表示。每个员工有一个唯一的 ID，他们都是公司的员工之一。为了表示公司的层级结构，需要构建一颗多叉树，其中领导是根节点。公司的每个员工最多有一个直系领导，但可能有多个直系下属。他们用一个 Employee 类表示，其中包含该员工的 ID、重要度和直系下属的 ID 列表。求解：给定一个公司的员工信息，以及每个员工对应的直系下属的员工信息，求出一个员工和他的所有下属的重要度之和。
//思路：DFS问题。首先，我们需要将员工信息构建成一个以领导为根节点的多叉树。然后，从指定的员工出发，采用深度优先搜索的方式遍历整个多叉树，计算每个员工的总重要性。
//时间复杂度：每个员工最多访问一次，因此时间复杂度为 O(N)，其中 N 为员工的数量。
//空间复杂度：递归调用栈的最大深度为多叉树的高度，最坏情况下为 N，因此空间复杂度为 O(N)。
        public class Employee
        {
            public int id;
            public int importance;
            public IList<int> subordinates;
        }
        public int GetImportance(IList<Employee> employees, int id)
        {
            Dictionary<int, Employee> employeeMap = employees.ToDictionary(e => e.id, e => e);
            return DFS_GetImportance(employeeMap, id);
        }

        private int DFS_GetImportance(Dictionary<int, Employee> employeeMap, int id)
        {
            Employee employee = employeeMap[id];
            int totalImportance = employee.importance;

            foreach (int subordinateId in employee.subordinates)
            {
                totalImportance += DFS_GetImportance(employeeMap, subordinateId);
            }

            return totalImportance;
        }
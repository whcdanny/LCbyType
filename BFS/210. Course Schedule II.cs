//Leetcode 210. Course Schedule II med
//题意：给定课程总量和一个先修课程的列表，按照先修关系来安排课程的学习顺序。返回一种可能的学习顺序。如果不可能完成则返回空数组。
//思路：拓扑排序问题，可以使用广度优先搜索（BFS）来解决。首先统计每门课程的入度（即有多少先修课程）。然后，将入度为 0 的课程加入队列，并在每次取出一门课程时，更新其后继课程的入度。最后，检查是否所有课程都被学习（入度是否全部为 0）。
//时间复杂度: 遍历每一门课程和其先修关系，总时间复杂度为 O(N + E)，其中 N 为课程总数，E 为先修关系的总数。
//空间复杂度：使用了一个数组和一个哈希表，所以空间复杂度为 O(N + E)。
        public int[] FindOrder(int numCourses, int[][] prerequisites)
        {
            int[] inDegree = new int[numCourses];
            List<List<int>> adjacency = new List<List<int>>(numCourses);
            for (int i = 0; i < numCourses; i++)
            {
                adjacency.Add(new List<int>());
            }

            foreach (var pair in prerequisites)
            {
                int course = pair[0];
                int prereq = pair[1];
                inDegree[course]++;
                adjacency[prereq].Add(course);
            }

            Queue<int> queue = new Queue<int>();
            List<int> res = new List<int>();
            for (int i = 0; i < numCourses; i++)
            {
                if (inDegree[i] == 0)
                {
                    queue.Enqueue(i);
                }
            }

            while (queue.Count > 0)
            {
                int course = queue.Dequeue();
                res.Add(course);               
                foreach (int nextCourse in adjacency[course])
                {
                    if (--inDegree[nextCourse] == 0)
                    {
                        queue.Enqueue(nextCourse);
                    }
                }
            }

            // 检查是否所有课程都被学习
            if (res.Count == numCourses)
            {
                return res.ToArray();
            }
            else
            {
                return new int[0];
            }
        }
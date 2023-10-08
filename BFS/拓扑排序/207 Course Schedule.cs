//Leetcode 207 Course Schedule med
//题意：给一个必修n个课程，不过有些课需要提前完成其他课程，所以判断所给的课程是否你能完成学业；
//思路：拓扑排序,创建一个数组 inDegree 用来记录每门课程的入度（即有多少先修课程）。创建一个队列 queue，将所有入度为 0 的课程加入队列中。遍历队列，对于每门课程，将其标记为已学习，然后遍历它的后续课程，将它们的入度减 1。如果某门课程的入度变为 0，将它加入队列中。如果最终所有课程都被标记为已学习，返回 true；否则返回 false。
//时间复杂度: V 表示课程的数量，E 表示课程的先修关系数 O(V + E)
//空间复杂度：O(V + E)
        public bool CanFinish(int numCourses, int[][] prerequisites)
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
                numCourses--;
                foreach (int nextCourse in adjacency[course])
                {
                    if (--inDegree[nextCourse] == 0)
                    {
                        queue.Enqueue(nextCourse);
                    }
                }
            }

            return numCourses == 0;
        }
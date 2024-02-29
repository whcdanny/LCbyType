//Leetcode 630. Course Schedule III hard
//题意：有 n 门不同的在线课程，编号从 1 到 n。给定一个数组 courses，其中 courses[i] = [durationi, lastDayi] 表示第 i 门课程需要连续学习 durationi 天，并且必须在 lastDayi 之前或之后完成。
//你将从第一天开始学习，并且不能同时学习两门或更多课程。
//返回你能够学习的最大课程数。
//思路：PriorityQueue, 我们首先将课程按照截止日期 lastDayi 进行排序。然后，我们维护一个最大堆（大顶堆）来存储当前已经选取的课程的持续时间，以及一个变量来记录当前已经学习的总时长。
//接着，我们遍历排序后的课程数组，对于每一门课程，我们将其持续时间加入最大堆中，并将当前总时长加上课程持续时间。
//然后，我们检查当前总时长是否超过了截止日期，如果超过了，则从最大堆中弹出持续时间最长的课程，直到总时长小于等于截止日期为止。
//时间复杂度: 排序的时间复杂度为 O(nlogn)。遍历课程数组的时间复杂度为 O(nlogn)。维护最大堆的时间复杂度为 O(logn)。总时间复杂度为 O(nlogn)。
//空间复杂度：O(n)       
        public int ScheduleCourse(int[][] courses)
        {
            Array.Sort(courses, (a, b) => a[1].CompareTo(b[1])); //将结课日子从小到大排序；
            PriorityQueue<int, int> pq = new PriorityQueue<int, int>(); 

            int time = 0; 
            foreach (int[] course in courses)
            {
                time += course[0];
                pq.Enqueue(course[0], -course[0]);
                //如果结课时间先于我们先在读书的时长，把最长的读书时间的课移除；
                if (time > course[1])
                {
                    time -= pq.Dequeue(); 
                }
            }           
            return pq.Count;
        }
//Leetcode 1792. Maximum Average Pass Ratio med
//题意：题目给出了一个学校的班级信息，每个班级都有一定数量的学生和通过考试的学生数量。还有一些额外的学生，他们可以通过任何班级的考试。目标是将额外的学生分配给班级，以使所有班级的平均通过率最大化。
//每个班级的通过率定义为该班级通过考试的学生数量与班级总学生数量的比率。平均通过率是所有班级的通过率之和除以班级数量。
//思路：PriorityQueue 通过人数、总人数和通过率,
//计算每个班级增加一个额外学生后的通过率变化，将结果存入优先队列
//从优先队列中取出通过率变化最大的班级，并将一个额外学生分配给该班级，更新该班级的通过率，并将更新后的结果重新放入优先队列。
//时间复杂度: O(nlogn)
//空间复杂度：O(n)  
        public double MaxAverageRatio(int[][] classes, int extraStudents)
        {
            var n = classes.Length;
            var pq = new PriorityQueue<(double, double), double>();
            foreach (var candidate in classes)
            {
                pq.Enqueue((candidate[0], candidate[1]), GetProfit(candidate[0], candidate[1]));
            }

            //  p + 1
            while (extraStudents-- > 0)
            {
                var (first, second) = pq.Dequeue();
                ++first;
                ++second;
                pq.Enqueue((first, second), GetProfit(first, second));
            }

            var result = 0D;
            while (pq.Count > 0)
            {
                var (first, second) = pq.Dequeue();

                result += first / second;               
            }

            return result / n;
        }
        //计算如果添加一个外来生的，通过率；
        public double GetProfit(double x, double y)
        {
            return x / y - (x + 1) / (y + 1);
        }
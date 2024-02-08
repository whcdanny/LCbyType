//Leetcode 2512. Reward Top K Students med
//题意：给定两个字符串数组 positive_feedback 和 negative_feedback，分别包含表示正面反馈和负面反馈的词语。请注意，没有词语既是正面反馈又是负面反馈的。
//初始时，每个学生的分数为0。每个正面反馈中的词语会使一个学生的分数增加3分，而每个负面反馈中的词语会使一个学生的分数减少1分。
//给定 n 条反馈报告，由一个0索引的字符串数组 report 和一个0索引的整数数组 student_id 表示，其中 student_id[i] 表示收到反馈报告 report[i] 的学生的ID。每个学生的ID都是唯一的。
//给定一个整数 k，请按照学生的分数将他们按非递增顺序排名，并返回前 k 名学生。如果有多个学生的分数相同，则ID较小的学生排名较高。
//思路：PriorityQueue
//positive和negative两个hashset这样避免重复，然后PriorityQueue存入studentID 和 分数；
//将最大的分数排在最上面，分数相同的话 ID小的排前面；
//时间复杂度: O(n log n)
//空间复杂度：O(n)       
        public IList<int> TopStudents(string[] positive_feedback, string[] negative_feedback, string[] report, int[] student_id, int k)
        {
            var list = new List<int>();
            var positive = positive_feedback.ToHashSet();
            var negative = negative_feedback.ToHashSet();
            var pq = new PriorityQueue<int, (int, int)>(Comparer<(int, int)>.Create((a, b) => {
                if (a.Item1 == b.Item1)
                    return a.Item2.CompareTo(b.Item2);
                return b.Item1.CompareTo(a.Item1);
            }));

            for (int i = 0; i < report.Length; i++)
            {
                var scores = 0;
                var words = report[i].Split(" ");
                foreach (var word in words)
                {
                    if (positive.Contains(word))
                        scores += 3;
                    else if (negative.Contains(word))
                        scores -= 1;
                }

                pq.Enqueue(student_id[i], (scores, student_id[i]));
            }

            for (int idx = 0; idx < k; idx++)
                list.Add(pq.Dequeue());

            return list;
        }
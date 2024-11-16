//Leetcode 1086. High Five  med
//题意：给定一个整数数组 items，其中 items[i] = [ID_i, score_i] 表示一名学生的学号和分数。找到每个学生的前五名平均分，返回结果以学号排序。
//思路：创建一个字典 student_scores，用于将学生的分数按学号进行分组。遍历整个数组 items，将每个学生的分数加入到对应学号的列表中。对于每个学生的分数列表，将其排序并计算前五名的平均分。
//时间复杂度：假设 n 是 items 数组的长度，对于每个学生，我们需要将其分数列表排序，时间复杂度是 O(k*logk)，其中 k 是每个学生的分数数量。总的时间复杂度是 O(n*k*logk)
//空间复杂度：O(n*k)
        public int[][] HighFive(int[][] items)
        {
            Dictionary<int, List<int>> scoreMap = new Dictionary<int, List<int>>();

            foreach (var item in items)
            {
                int studentId = item[0];
                int score = item[1];

                if (!scoreMap.ContainsKey(studentId))
                {
                    scoreMap[studentId] = new List<int>();
                }

                scoreMap[studentId].Add(score);
            }

            List<int[]> averages = new List<int[]>();

            foreach (var kvp in scoreMap)
            {
                int studentId = kvp.Key;
                List<int> scores = kvp.Value;

                scores.Sort((a, b) => b - a);// 降序排序

                int sum = 0;
                for (int i = 0; i < 5; i++)
                {
                    sum += scores[i];
                }

                int average = sum / 5;

                averages.Add(new int[] { studentId, average });
            }
            averages.Sort((a, b) => a[0] - b[0]); // 按学号升序排序
            return averages.ToArray();
        }
//1086. High Five ez 
//是一个求取学生最高五个分数平均值的问题
//思路：字典 scoreMap 来存储每个学生的分数列，然后sort，然后gettop5 avg
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

                scores.Sort((a, b) => b - a);

                int sum = 0;
                for (int i = 0; i < 5; i++)
                {
                    sum += scores[i];
                }

                int average = sum / 5;

                averages.Add(new int[] { studentId, average });
            }

            return averages.ToArray();
        }
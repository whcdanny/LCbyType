//Leetcode 911. Online Election med
//题意：题目描述了在线选举系统，有一系列的投票活动。在每个投票活动中，每个选民选择一个候选人。系统需要在每次投票后，根据当前的得票情况，返回当前领先的候选人。
//TopVotedCandidate(int[] persons, int[] times)：构造一个在线选举的类，其中 persons[i] 表示第 i 次投票的选民编号（范围在 1 到 persons.length 之间），times[i] 表示第 i 次投票的时间（严格递增的整数序列）。系统需要在每次投票后返回当前领先的候选人。
//int Q(int t)：给定一个时间 t，返回在时间 t 时的领先候选人。
//思路：预处理 - 计算每个时间点的领先者：
//对于每次投票，记录当前的得票情况，找到当前领先的候选人。使用一个字典 votes 来记录每个候选人的得票数，以及一个数组 winners  来记录每个时间点的领先者。
//在每次投票后，检查当前得票情况，更新 winners  数组。
//二分查找 - 查询某个时间点的领先者：
//对于查询 Q(t)，使用二分查找找到最后一个时间点小于等于 t 的领先者。
//在 winners  数组中二分查找，找到最后一个时间点小于等于 t 的领先者。
//时间复杂度: 预处理的时间复杂度为 O(N)，其中 N 是投票的次数。查询的时间复杂度为 O(logN)。
//空间复杂度：O(n)
        public class TopVotedCandidate
        {

            private int[] persons;
            private int[] times;
            private int[] winners;

            public TopVotedCandidate(int[] persons, int[] times)
            {
                this.persons = persons;
                this.times = times;
                this.winners = new int[times.Length];

                // 预处理 - 计算每个时间点的领先者
                int[] votes = new int[persons.Length + 1];  // 记录每个候选人的得票数

                int leader = -1;  // 当前领先的候选人
                int maxVotes = 0;  // 当前的最大得票数

                for (int i = 0; i < times.Length; i++)
                {
                    int person = persons[i];
                    votes[person]++;

                    if (votes[person] >= maxVotes)
                    {
                        leader = person;
                        maxVotes = votes[person];
                    }

                    winners[i] = leader;
                }
            }

            public int Q(int t)
            {
                // 二分查找 - 查询某个时间点的领先者
                int left = 0, right = times.Length - 1;

                while (left < right)
                {
                    int mid = left + (right - left) / 2;

                    if (times[mid] <= t)
                    {
                        left = mid + 1;
                    }
                    else
                    {
                        right = mid;
                    }
                }
                if (times[left] > t && left > 0) left--;
                return winners[left];
            }
        }

        /**
         * Your TopVotedCandidate object will be instantiated and called as such:
         * TopVotedCandidate obj = new TopVotedCandidate(persons, times);
         * int param_1 = obj.Q(t);
         */
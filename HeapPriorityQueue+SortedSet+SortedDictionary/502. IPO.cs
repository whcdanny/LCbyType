//Leetcode 502. IPO med
//题意：假设LeetCode将很快启动其IPO。为了以较高的价格将其股票出售给风险资本，LeetCode希望在IPO之前开展一些项目以增加其资本。
//由于资源有限，LeetCode在IPO之前最多只能完成k个不同的项目。帮助LeetCode设计一种最佳方式，以最大化完成至多k个不同项目后的总资本。
//给定n个项目，其中第i个项目具有纯利润profits[i] 和启动它所需的最低资本capital[i]。
//最初，您有w资本。完成一个项目后，您将获得其纯利润，并将利润添加到您的总资本中。
//从给定项目中选择至多k个不同的项目列表，以最大化您的最终资本，并返回最终最大化的资本。
//答案保证适合32位有符号整数。
//思路：PriorityQueue, 将所有项目按照所需最低资本capital进行排序，以便优先选择所需资本最低的项目。
//使用一个最大堆（优先队列）来存储当前可用资本能够启动的项目的纯利润，堆顶元素是当前纯利润最大的项目。
//依次遍历项目，将当前可用资本能够启动的项目的纯利润添加到最大堆中。
//每次从最大堆中取出堆顶元素（纯利润最大的项目），并将其纯利润加到总资本中，直到完成k个项目或者最大堆为空。
//返回最终总资本。
//时间复杂度: O(nlogn + klogn)，其中n是项目数量，k是最大项目数。排序所有项目需要O(nlogn)，遍历并维护最大堆需要O(klogn)。
//空间复杂度：O(n)   
        public int FindMaximizedCapital(int k, int w, int[] profits, int[] capital)
        {
            var projects = new List<(int capital, int profit)>();

            for (var i = 0; i < profits.Length; i++)
            {
                projects.Add((capital[i], profits[i]));
            }

            projects = projects.OrderBy(x => x.capital).ToList();

            var queue = new PriorityQueue<int, int>();

            var completedProjects = 0;

            while (k-- > 0)
            {
                while (completedProjects < projects.Count && projects[completedProjects].capital <= w)
                {
                    queue.Enqueue(projects[completedProjects].profit,  -projects[completedProjects].profit);
                    completedProjects++;
                }

                if (queue.Count == 0)
                {
                    break;
                }

                w += queue.Dequeue();
            }

            return w;
        }
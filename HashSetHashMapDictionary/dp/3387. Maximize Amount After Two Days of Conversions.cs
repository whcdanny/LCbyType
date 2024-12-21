//Leetcode 3387. Maximize Amount After Two Days of Conversions med
//题意：你有一个字符串 initialCurrency，表示你最初拥有 1.0 单位的这种货币。
//你还被给了四个数组，分别表示货币对（字符串）和汇率（实数）：
//pairs1[i] = [startCurrencyi, targetCurrencyi] 和 rates1[i] 表示第一天你可以将 startCurrencyi 转换为 targetCurrencyi，汇率为 rates1[i]。
//pairs2[i] = [startCurrencyi, targetCurrencyi] 和 rates2[i] 表示第二天你可以将 startCurrencyi 转换为 targetCurrencyi，汇率为 rates2[i]。
//此外，每种目标货币都可以按照 1 / rate 的汇率转回对应的初始货币。
//你可以在第一天根据 rates1 进行任意次数的转换（包括零次），接着在第二天根据 rates2 再进行任意次数的转换（包括零次）。
//返回在两天的操作之后，能获得的 initialCurrency 的最大数量。
//思路：构图+贝尔曼-福特算法
//先构图，根据pairs1和pairs2每个货币对应的(货币，汇率)
//然后用贝尔曼-福特算法 是一种动态规划  单源最短路径问题 的经典图算法
//贝尔曼-福特基于“松弛”（relaxation）的思想。
//如果从节点 A 到节点 B 的路径存在一条更优的路径（权值更大或更小，取决于问题要求），就更新到 B 的值。
//通过不断迭代，可以找到从起点到所有其他节点的最优值。
//逐步优化路径：假设有 n 个节点，最多需要 n−1 次迭代。
//每次迭代会检查所有边，并更新从起点到目标节点的最优值。
//先算出第一天的最大数量，因为第二天要根据第一天的结果来，所以
//第二天要先确认货币在不在第一天的结果中，然后根据第一天的货币然后找出当时第二天的值，
//然后确保第二天是否包含要求的货币，然后找出最大值Math.Max(maxAmount, day1Amounts[currency] * day2Amounts[initialCurrency])
//时间复杂度: 构建图：O(E)，E是边的数量。贝尔曼-福特算法：O(V×E)，V是节点数量。总时间复杂度：O(V×E) （对两天分别运行一次贝尔曼-福特）。
//空间复杂度：图的存储需要 O(E)。动态规划数组需要 O(V)。总空间复杂度为 O(V+E)。
        public double MaxAmount(string initialCurrency, IList<IList<string>> pairs1, double[] rates1, IList<IList<string>> pairs2, double[] rates2)
        {
            // 构建货币图
            var graph1 = BuildGraph(pairs1, rates1);
            var graph2 = BuildGraph(pairs2, rates2);

            // 获取所有货币种类
            var currencies = new HashSet<string>();
            foreach (var pair in pairs1)
            {
                currencies.Add(pair[0]);
                currencies.Add(pair[1]);
            }
            foreach (var pair in pairs2)
            {
                currencies.Add(pair[0]);
                currencies.Add(pair[1]);
            }

            // 第一天下的最大值
            var day1Amounts = BellmanFord(initialCurrency, graph1, currencies);

            // 第二天下的最大值
            var maxAmount = 0.0;
            foreach (var currency in currencies)
            {
                if (day1Amounts.ContainsKey(currency))
                {
                    var day2Amounts = BellmanFord(currency, graph2, currencies);
                    if (day2Amounts.ContainsKey(initialCurrency))
                    {
                        maxAmount = Math.Max(maxAmount, day1Amounts[currency] * day2Amounts[initialCurrency]);
                    }
                }
            }

            return maxAmount;
        }

        // 构建图
        private Dictionary<string, List<(string target, double rate)>> BuildGraph(IList<IList<string>> pairs, double[] rates)
        {
            var graph = new Dictionary<string, List<(string, double)>>();
            for (int i = 0; i < pairs.Count; i++)
            {
                string start = pairs[i][0], target = pairs[i][1];
                double rate = rates[i];

                if (!graph.ContainsKey(start)) graph[start] = new List<(string, double)>();
                if (!graph.ContainsKey(target)) graph[target] = new List<(string, double)>();

                graph[start].Add((target, rate));
                graph[target].Add((start, 1.0 / rate));
            }
            return graph;
        }

        // 贝尔曼-福特算法
        private Dictionary<string, double> BellmanFord(string start, Dictionary<string, List<(string target, double rate)>> graph, HashSet<string> currencies)
        {
            var maxAmounts = new Dictionary<string, double>();
            foreach (var currency in currencies) 
                maxAmounts[currency] = 0.0;
            maxAmounts[start] = 1.0;

            for (int i = 0; i < currencies.Count - 1; i++)
            {
                foreach (var (currency, neighbors) in graph)
                {
                    foreach (var (neighbor, rate) in neighbors)
                    {
                        maxAmounts[neighbor] = Math.Max(maxAmounts[neighbor], maxAmounts[currency] * rate);
                    }
                }
            }
            return maxAmounts;
        }
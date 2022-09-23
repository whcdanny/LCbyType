1722. Minimize Hamming Distance After Swap Operations
//C#
public static int MinimumHammingDistance(int[] source, int[] target, int[][] allowedSwaps)
        {
            int[] unionFindArray = new int[100001];
            for (int i = 1; i < unionFindArray.Length; i++)
            {
                unionFindArray[i] = i;
            }
            foreach (int[] allow in allowedSwaps)
            {
                unionFindArray[unionFind(unionFindArray, allow[0])] = unionFind(unionFindArray, allow[1]);
            }
            int count = 0;
            Dictionary<int, Dictionary< int, int >> map = new Dictionary<int, Dictionary<int, int>>();
            for (int i = 0; i < source.Length; i++)
            {
                int value = unionFind(unionFindArray, i);
                if (map.ContainsKey(value))
                {
                    Dictionary<int, int> originalValueCountMap = map.GetValueOrDefault(value);
                    if (originalValueCountMap.ContainsKey(source[i]))
                        originalValueCountMap[source[i]]++;
                    else
                        originalValueCountMap.Add(source[i], 1);
                    //originalValueCountMap.Add(source[i], originalValueCountMap.GetValueOrDefault(source[i], 0) + 1);
                    //originalValueCountMap[source[i]]++;
                }
                else
                {
                    Dictionary<int, int> originalValueCountMap = new Dictionary<int, int>();
                    originalValueCountMap.Add(source[i], 1);
                    map.Add(value, originalValueCountMap);
                }
            }
            for (int i = 0; i < target.Length; i++)
            {
                int value = unionFind(unionFindArray, i);
                if (map.ContainsKey(value) && map.GetValueOrDefault(value).ContainsKey(target[i]) && map.GetValueOrDefault(value).GetValueOrDefault(target[i]) > 0)
                {
                    ++count;
                    Dictionary<int, int> originalValueCountMap = map.GetValueOrDefault(value);
                    originalValueCountMap[target[i]]--;                    
                }
            }
            return source.Length - count;
        }
        private static int unionFind(int[] array, int target)
        {
            return array[target] == target ? target : unionFind(array, array[target]);
        }
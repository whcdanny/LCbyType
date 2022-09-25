547. Number of Provinces	
//C#		
		public int FindCircleNum(int[][] isConnected)
        {
            int[] unionFindArray = new int[isConnected.Length];
            for (int i = 0; i < unionFindArray.Length; i++)
            {
                unionFindArray[i] = i;
            }
            for (int i = 0; i< isConnected.Length; i++){
                for(int j = 0; j < isConnected.Length; j++)
                {
                    if (isConnected[i][j] != 1)
                        continue;
                    unionFindArray[unionFind(unionFindArray, i)] = unionFindArray[unionFind(unionFindArray, j)];
                }
            }
            List<int> set = new List<int>();
            foreach(int num in unionFindArray)
            {
                int n = unionFind(unionFindArray, num);
                if (!set.Contains(n))
                    set.Add(n);
            }
            return set.Count;
            HashSet<int> set = new HashSet<int>();
            foreach (int num in unionFindArray)
            {
                set.Add(unionFind(unionFindArray, num));
            }
            return set.Count;
        }
		
		private static int unionFind(int[] array, int target)
        {
            return array[target] == target ? target : unionFind(array, array[target]);
        }
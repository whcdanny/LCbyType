//Leetcode 2418. Sort the People ez
//题意：给定一个字符串数组 names 和一个由不同正整数组成的数组 heights，两个数组的长度都为 n。
//对于每个索引 i，names[i] 和 heights[i] 表示第 i 个人的姓名和身高。
//返回按照人们的身高降序排序的姓名数组 names。
//思路：hashtable 将姓名数组 names 和身高数组 heights 组合成元组数组，然后根据元组数组中的身高进行排序，最后提取排序后的姓名数组。
//时间复杂度：排序的时间复杂度为 O(n log n)，提取姓名数组的时间复杂度为 O(n)，总时间复杂度为 O(n log n)。
//空间复杂度：O(n)
        public string[] SortPeople(string[] names, int[] heights)
        {
            int n = names.Length;
            (string name, int height)[] people = new (string, int)[n];

            for (int i = 0; i < n; i++)
            {
                people[i] = (names[i], heights[i]);
            }

            Array.Sort(people, (x, y) => y.height.CompareTo(x.height));

            string[] sortedNames = new string[n];
            for (int i = 0; i < n; i++)
            {
                sortedNames[i] = people[i].name;
            }

            return sortedNames;
        }
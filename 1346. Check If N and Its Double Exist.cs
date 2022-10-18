1346. Check If N and Its Double Exist
//C#
		public bool checkIfExist1(int[] arr)
        {
            HashSet<int> set = new HashSet<int>();
            foreach (int num in arr)
            {
                if (set.Contains(num * 2) || (num % 2 == 0 && set.Contains(num / 2)))
                {
                    return true;
                }
                set.Add(num);
            }
            return false;
        }
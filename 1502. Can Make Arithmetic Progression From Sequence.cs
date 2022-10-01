1502. Can Make Arithmetic Progression From Sequence
//C#
		public static bool CanMakeArithmeticProgression(int[] arr)
        {
            int n = arr.Count();
            Array.Sort(arr);
            if (n == 2)
                return true;
            int sub = Math.Abs(arr[1] - arr[0]);
            for (int i = 1; i < n - 1; i++)
            {
                if (arr[i] + sub == arr[i + 1] || arr[i] - sub == arr[i + 1])
                    continue;
                else
                    return false;
            }
            return true;            
        }
		
		public static bool CanMakeArithmeticProgression(int[] arr)
        {
            int n = arr.Count();            
            Dictionary<int, int> hm = new Dictionary<int, int>();
            int smallest = Int32.MaxValue, second_smallest = Int32.MaxValue;
            for (int i = 0; i < n; i++)
            {
                
                if (arr[i] < smallest)
                {
                    second_smallest = smallest;
                    smallest = arr[i];
                }

                else if (arr[i] != smallest
                         && arr[i] < second_smallest)
                    second_smallest = arr[i];
                
                if (!hm.ContainsKey(arr[i]))
                {
                    hm[arr[i]] = 1;
                }
                
                else
                    return false;
            }
            
            int diff = second_smallest - smallest;
            
            for (int i = 0; i < n - 1; i++)
            {
                if (!hm.ContainsKey(second_smallest))
                    return false;
                second_smallest += diff;
            }
            return true;
        }
		
		public static bool CanMakeArithmeticProgression(int[] arr)
        {
            int n = arr.Count();            
            HashSet<int> st = new HashSet<int>();
            int maxi = int.MinValue;
            int mini = int.MaxValue;
            for (int i = 0; i < n; i++)
            {
                maxi = Math.Max(arr[i], maxi);
                mini = Math.Min(arr[i], mini);
                st.Add(arr[i]);
            }            
            int diff = (maxi - mini) / (n - 1);
            int count = 0;
            
            while (st.Contains(maxi))
            {
                count++;
                maxi = maxi - diff;
            }
            if (count == n)
            {
                return true;
            }

            return false;
        }
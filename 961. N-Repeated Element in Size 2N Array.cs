961. N-Repeated Element in Size 2N Array
//C#
		public int RepeatedNTimes(int[] nums)
        {
            Dictionary<int, int> map = new Dictionary<int, int>();
            foreach (int num in nums)
            {
                if (map.ContainsKey(num))
                {
                    return num;
                }
                else
                {
                    map.Add(num, num);
                }
            }
            return -1;
        }


//Java
	public int repeatedNTimes(int[] nums) {
        Map<Integer, Integer> map = new HashMap<Integer, Integer>();
    	for (int num : nums) {    		
    		if (map.containsKey(num)) {
    			return num;
    		}
    		else {
    			map.put(num, num);
    		}
    	}
        return -1;
    }
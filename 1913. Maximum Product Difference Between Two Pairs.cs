1913. Maximum Product Difference Between Two Pairs
//C#
		public int MaxProductDifference(int[] nums)
        {
            int max = 0;
            int max2 = 0;
            int min = int.MaxValue;
            int min2 = int.MaxValue;
            foreach (int num in nums)
            {

                if (num > max)
                {
                    max2 = max;
                    max = num;

                }
                else if (num > max2)
                {
                    max2 = num;
                }

                if (num < min)
                {
                    min2 = min;
                    min = num;
                }
                else if (num < min2)
                {
                    min2 = num;
                }
            }
			
//Java
	public int maxProductDifference(int[] nums) {
        int max = 0;
        int max2 = 0;
        int min = Integer.MAX_VALUE;
        int min2 = Integer.MAX_VALUE;
        for(int num : nums){

            if(num>max){
                max2 = max;
                max = num;

            }else if(num>max2){
                max2 = num;
            }

            if(num<min){
                min2 = min;
                min = num;
            }else if(num<min2){
                min2 = num;
            }
        }

        return ((max*max2)-(min*min2));
    }
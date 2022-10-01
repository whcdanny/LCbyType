2233. Maximum Product After K Increments
//C#
public static int MaximumProduct(int[] nums, int k)
        {
            long res = 1;
            int n = nums.Length;
            int mod = 1000000007;
            if (n == 1)
                return nums[0] + k;
            Array.Sort(nums);
            List<int> list = new List<int>();
            foreach(int num in nums)
            {
                list.Add(num);
            }
            while (k != 0)
            {
                list.Sort();
                list[0] += 1;
                k--;
            }            
            foreach(int num in list)
            {
                res *= num;
                res = res % mod;
            }
            return (int)res;
			
//Java
public int maximumProduct(int[] nums, int k) {
        long mod = (long)1e9 + 7;
        int n = nums.length;

        PriorityQueue<Integer> pq = new PriorityQueue<>();

        for(int x : nums) {
            pq.offer(x);
        }

        while(k > 0) {
            int min = pq.poll();
            pq.offer(min + 1);
            k--;
        }

        long ans = 1;
        while(!pq.isEmpty()) {
            ans = ans * pq.poll() % mod;
        }

        return (int)ans;
    }
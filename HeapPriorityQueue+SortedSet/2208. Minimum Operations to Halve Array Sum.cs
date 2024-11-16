//Leetcode 2208. Minimum Operations to Halve Array Sum med
//题意：给定一个正整数数组 nums，每次操作可以选择数组中的一个数字，将其减少到原来的一半。问至少需要多少次操作才能使数组的和减少至少一半。
//思路：PriorityQueue 用来存num保持最大的输出；
//先算出总sum然后除以2 为标准sum，然后从PriorityQueue输出当前最大的然后/2，然后cursum减去，然后跟标准sum做比较，看是否满足条件；然后再把当前数存入PriorityQueue，
//时间复杂度: O(NlogN)
//空间复杂度：O(1)
        public int HalveArray(int[] nums)
        {
            PriorityQueue<double, double> maxPriortyQueue = new PriorityQueue<double, double>();
            double givenSum = 0;
            foreach (int num in nums)
                givenSum += num;

            double currSum = givenSum;
            givenSum /= 2;
            int operations = 0;

            foreach (int num in nums)
                maxPriortyQueue.Enqueue(num, -num);

            while (maxPriortyQueue.Count != 0)
            {
                ++operations;
                double currMaxNum = maxPriortyQueue.Dequeue();
                currMaxNum /= 2;
                currSum -= (double)currMaxNum;
                maxPriortyQueue.Enqueue(currMaxNum, -currMaxNum);
                if (currSum <= givenSum)
                    return operations;
            }

            return operations;
        }
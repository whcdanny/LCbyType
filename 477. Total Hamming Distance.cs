477. Total Hamming Distance
//c#
//超时
public class Solution {
    public int TotalHammingDistance(int[] nums) {
        int num = 0;
            for (int i = 0; i < nums.Length-1; i++)
            {
                for(int j = i+1; j < nums.Length; j++)
                {
                    num += hammingDistance(nums[i], nums[j]);
                }
            }
            return num;
    }
    public int hammingDistance(int n1, int n2)
        {
            int x = n1 ^ n2;
            int setBits = 0;

            while (x > 0)
            {
                setBits += x & 1;
                x >>= 1;
            }

            return setBits;
        }
}
//正解
public int TotalHammingDistance(int[] nums) {
       int total = 0, n = nums.Length;
		for (int i = 0; i < 32; i++){
			int bitCount = 0;
			for (int j = 0; j < nums.Length; j++){
				bitCount += (nums[j] >> i & 1);
			}
			total += bitCount * (n - bitCount);
		}
		return total;
    }    
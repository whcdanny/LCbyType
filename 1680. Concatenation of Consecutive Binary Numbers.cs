1680. Concatenation of Consecutive Binary Numbers
//C#
public class Solution {
    public int ConcatenatedBinary(int n) {
        long result = 0;
            for (var i = 1; i <= n; i++)
            {
                var numberOfDigits = (int)Math.Log(i, 2) + 1;
                result = ((result << numberOfDigits)% 1000000007 + i) % 1000000007;
            }
            return (int)result;
    }
}
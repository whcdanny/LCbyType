365. Water and Jug Problem
//C#
public class Solution {
    public bool CanMeasureWater(int jug1Capacity, int jug2Capacity, int targetCapacity) {
        if(jug1Capacity + jug2Capacity < targetCapacity)
            return false;
        return targetCapacity % gcd(jug1Capacity, jug2Capacity) == 0;
    }
    
    public int gcd(int x, int y){
        if(y == 0) 
            return x;
        return gcd(y, x % y);
    }
}
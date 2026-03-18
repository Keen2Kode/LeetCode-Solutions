public class Solution {
    public bool JudgeSquareSum(int c) {
        
        // start with the square closest to c, then try every combination going down
        // eg: 126 is cloest to 11^2
        // 11^2 + 4^2
        // 11^2 + 5^2 (>126)
        // 10^2 + 5^2
        // 10^2 + 6^2 (>126)

        for (int a=(int) Math.Sqrt(c); a>=0; a--) {
            int remainder = c - a*a;
            if (remainder == 0) 
                return true;
            
            int b = (int) Math.Sqrt(remainder);
            int remainder2 = remainder - b*b;
            if (remainder2 == 0)
                return true;
        }

        return false;
    }
}
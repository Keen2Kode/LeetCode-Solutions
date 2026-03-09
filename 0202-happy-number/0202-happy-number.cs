public class Solution {
    public bool IsHappy(int n) {
        
        HashSet<int> unhappySet = new();
        
        // if number is in unhappySet, it's a loop
        // if number is one it's happy
        int sum = n;
        while (sum > 1) {
            if (unhappySet.Contains(sum))
                return false;
            unhappySet.Add(sum);
            sum = SumSquareDigits(sum);

        }
        return true;
    }

    private int SumSquareDigits(int n) {

        int sum = 0;
        // example
        // 813 % 10 = 3
        // 81 % 10 = 1
        // 8 % 10  = 8
        while (n>0) {
            int digit = n%10;
            int square = digit*digit;
            sum += square;
            n/=10;
        }
        return sum;
    }

}
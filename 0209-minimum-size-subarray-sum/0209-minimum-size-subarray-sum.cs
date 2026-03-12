public class Solution {
    public int MinSubArrayLen(int target, int[] nums) {

            // sliding window
            int i=0;
            int j=0;

            int sum =0;
            int minLength = int.MaxValue; 
            while (i<=j && i<nums.Length) {
                
                if (sum < target) {
                    if (j>=nums.Length)
                        break;
                    sum += nums[j];
                    j++;
                }
                else { 
                    minLength = Math.Min(j-i, minLength);
                    sum -= nums[i];
                    i++;
                    if (i>j)
                        j++;
                }
            }
            return int.MaxValue == minLength ? 0 : minLength;
    }
}
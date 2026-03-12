public class Solution {
    public int Search(int[] nums, int target) {
        int i=0;
        int j=nums.Length-1;

        while (i<=j) {
            int m=(i+j)/2;

            // it's to the right side
            if (nums[m] > target) {
                j = m-1;
            }
            // left side
            else if (nums[m] < target) {
                i = m+1;
            }
            else return m;

        }
        return -1;
    }
}
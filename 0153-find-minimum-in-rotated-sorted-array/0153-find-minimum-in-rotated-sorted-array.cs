public class Solution {
    public int FindMin(int[] nums) {
        // binary search
        // need to identify if we're in the left or right side
        // i > mid, right portion
        // i < mid, left portion
        // understand the main comparison check is the following:
        // i < mid < j: we are in sorted array, return i
        // i < mid > j: go right
        // i > mid > j: not possible, combine to above mid > j
        // i > mid < j: go left, save mid

        int i=0;
        int j=nums.Length-1;

        while (i<=j) {
            int m = i + (j-i)/2;
            if (nums[i] <= nums[m] &&  nums[m] <= nums[j]) {
                return nums[i];
            }
            else if (nums[m] >= nums[j]) {
                i = m+1;
            }
            else if (nums[i] >= nums[m] && nums[m] <= nums[j]) {
                j = m;
            }

        }
        return -1;
            
    }
}
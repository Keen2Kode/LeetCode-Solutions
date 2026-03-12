public class Solution {
    public int Search(int[] nums, int target) {

        // look for the "continuous" portion within i,m,j
        // eg:  4567012
        //      i  m  j   i->m is continuous
        // eg:  7012456   m->j is continuous  
        int i=0;
        int j=nums.Length-1;

        while (i<=j) {
            int m = (i+j) / 2;

            int a = nums[i];
            int b = nums[m];
            int c = nums[j];

            if (b == target)
                return m;

            bool searchLeft;

            if (a<=b) { // left side sorted
                searchLeft = a <= target && target < b;
            }
            else if (b<=c) { // right side sorted
                searchLeft = !(b < target && target <= c);
            }
            else throw new Exception("How did you even get here");

            if (searchLeft)
                j = m - 1;
            else
                i = m + 1;
        }
        return -1;
    }
}
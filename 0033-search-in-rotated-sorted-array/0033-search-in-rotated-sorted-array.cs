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
            // left continuous
            else if (a<=b) {
                if (a<=target && target<=b) {
                    j=m-1;
                }
                else {
                    i=m+1;
                }
            }
            // right continuous
            else if (b<=c) {
                if (b<=target && target<=c) {
                    i=m+1;
                }
                else {
                    j=m-1;
                }
            }
        }
        return -1;
    }
}
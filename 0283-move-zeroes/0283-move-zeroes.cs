public class Solution {
    public void MoveZeroes(int[] nums) {
        // consider swapping when you come across number
        //not with the adjacent number, BUT swap at index right after the last 0

        int swapIndex = 0;
        for (int i=0; i<nums.Length; i++) {
            bool toSwap = nums[i] != 0;
            if (toSwap) {
                int num = nums[i];
                nums[i] = 0;
                nums[swapIndex] = num;
                swapIndex++;
            }
        }

    }
}
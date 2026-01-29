public class Solution {
    public int[] FindErrorNums(int[] nums) {

        var allNums = new HashSet<int>(
            Enumerable.Range(1, nums.Length)
        );

        int dup = -1;
        foreach (int num in nums) {
            // aka we attempt to remove twice
            if (!allNums.Remove(num))
                dup = num;
        }

        // if anything remains, it is the missing number
        return new int[]{dup, allNums.Single()};
    }
}
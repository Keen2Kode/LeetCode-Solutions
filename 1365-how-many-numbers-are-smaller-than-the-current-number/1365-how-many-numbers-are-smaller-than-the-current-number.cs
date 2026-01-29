public class Solution {
    public int[] SmallerNumbersThanCurrent(int[] nums) {
        // seems like a hashmap problem
        // max num is 100
        // so can iterate 1-100 and keep a sum of the previous num count

        Dictionary<int, int> counts = new();
        foreach (int num in nums) {
            counts[num] = counts.GetValueOrDefault(num, 0) + 1;
        }

        // foreach (int num in nums) {
        //     Console.WriteLine($"num: {num}, counts: {counts[num]}");
        // }

        int totalCount = 0;
        int[] greater = new int[101];
        for (int i=0; i<=100; i++) {
            greater[i] = totalCount;
            totalCount += counts.GetValueOrDefault(i, 0);
        }

        int[] array = new int[nums.Length];
        for (int i=0; i<nums.Length; i++)
            array[i] = greater[nums[i]];

        return array;
    }
}
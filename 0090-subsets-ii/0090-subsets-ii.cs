public class Solution {

    // solution discoveries for 1st problem here
    // https://github.com/Keen2Kode/LeetCode-Solutions/blob/main/0078-subsets/0078-subsets.cs

    private List<IList<int>> subsets = new List<IList<int>>();
    private int[] nums;
    public IList<IList<int>> SubsetsWithDup(int[] nums) {

        // presort to allow skipping duplicates easily in recursive method.
        // O(n log(n)) is less than O(n * 2^n), so safe to sort
        this.nums = nums;
        Array.Sort(this.nums);

        SubsetTree(new List<int>(), 0);
        // foreach (List<int> subset in subsets) {
        //     Console.WriteLine(String.Join("->", subset));
        // }
        return subsets;
    }

    private void SubsetTree(List<int> subset, int i) {
        if (i==nums.Length) {
            subsets.Add(new List<int>(subset));
            return;
        }
        List<int> subset2 = new List<int>(subset);
        subset2.Add(nums[i]);
        SubsetTree(subset2,i+1);
        SubsetTree(subset, SkipDuplicates(i));
    }

    // the duplicate will already have been added above
    // skip the entire branch for adding the 2nd duplicate 
    private int SkipDuplicates(int i) {
        int next = i+1;
        while (next < nums.Length && nums[next] == nums[i])
            next++;
        return next;
    }
}
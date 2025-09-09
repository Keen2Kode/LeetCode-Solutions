public class Solution {


    private List<IList<int>> subsets = new List<IList<int>>();
    private int[] nums;
    public IList<IList<int>> Subsets(int[] nums) {
        // a binary tree branching for every element in nums, either choose it or don't
        // the final leaf contains the subset to add
        // no need to go back, so skipping a node class
        this.nums = nums;

        SubsetTree(new List<int>(), 0);
        // foreach (List<int> subset in subsets) {
        //     Console.WriteLine(String.Join("->", subset));
        // }
        return subsets;
    }

    // nums[i] is the current element to choose
    private void SubsetTree(List<int> subset, int i) {
        // no more elements to add, subset completed.
        if (i==nums.Length) {
            subsets.Add(new List<int>(subset));
            return;
        }

        SubsetTree(subset,i+1);
        // avoid same subset across different branches
        SubsetTree(new List<int>(subset) { nums[i] },i+1);
    }
}
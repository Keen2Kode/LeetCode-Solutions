public class Solution {

    private int[] nums;
    private List<IList<int>> combinations = new List<IList<int>>();
    public IList<IList<int>> CombinationSum(int[] candidates, int target) {
        // Pre-sort (O(nlog(n))) is not as complex as combinations O(n*n^(target/smallest num))
        Array.Sort(candidates);
        nums = candidates;
        NaryTree(new List<int>(), target, 0);
        return combinations;
    }

    // keep subtracting and adding subtracted value to combo
    // only add larger or equal elements, to avoid duplicate combos
    private void NaryTree(List<int> combination, int target, int start) {
        if (target == 0) {
            combinations.Add(combination);
        }
        if (target <= 0 || start == nums.Length)
            return;

        for (int i=start; i<nums.Length; i++) {
            NaryTree(new List<int>(combination) {nums[i]}, target-nums[i], i);
        }

    }
}
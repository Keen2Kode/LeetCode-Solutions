public class Solution {

    private int[] nums;
    private List<IList<int>> combinations = new List<IList<int>>();
    public IList<IList<int>> CombinationSum2(int[] candidates, int target) {
        // Pre-sort (O(nlog(n))) is not as complex as combinations O(n*n^(target/smallest num))
        Array.Sort(candidates);
        nums = candidates;
        NaryTree(new List<int>(), target, 0);
        return combinations;
    }

    // keep subtracting and adding subtracted value to combo
    // only add larger or equal elements, to avoid duplicate combos

    // handling duplicates: skip duplicates at each level
    private void NaryTree(List<int> combination, int target, int start) {
        if (target == 0) {
            combinations.Add(new List<int>(combination));
        }
        if (target <= 0 || start == nums.Length)
            return;

        // once the target is lower than the sorted elements, no point going forward
        for (int i = start; i < nums.Length && nums[i] <= target; i++) {
            // skip the duplicate branch at the current level
            bool duplicate = i-1 >= start && nums[i] == nums[i-1];
            if (duplicate)
                continue;
            combination.Add(nums[i]);
            NaryTree(combination, target - nums[i], i+1);
            combination.RemoveAt(combination.Count - 1);
        }


    }
}
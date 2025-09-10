public class Solution {
    private List<IList<int>> permutations = new List<IList<int>>();
    public IList<IList<int>> Permute(int[] nums) {

        NaryTree(new LinkedList<int>(), nums.ToHashSet());
        return permutations;
    }

    private void NaryTree(LinkedList<int> permutation, HashSet<int> nums) {
        if (nums.Count == 0) {
            permutations.Add(new List<int>(permutation));
            return;
        }

        // choosing an element means it can never be used in that perm again
        // so it must be removed for next time.
        foreach (int num in nums.ToArray()) {
            nums.Remove(num);
            permutation.AddLast(num);
            NaryTree(permutation, nums);
            nums.Add(num);
            permutation.RemoveLast();

        }


    }
}
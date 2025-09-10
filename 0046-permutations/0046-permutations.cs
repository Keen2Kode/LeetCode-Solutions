public class Solution {
    private List<IList<int>> permutations = new List<IList<int>>();
    public IList<IList<int>> Permute(int[] nums) {

        NaryTree(new List<int>(), nums.ToHashSet());
        return permutations;
    }

    private void NaryTree(List<int> permutation, HashSet<int> nums) {
        if (nums.Count == 0) {
            permutations.Add(new List<int>(permutation));
            return;
        }

        // choosing an element means it can never be used in that perm again
        // so it must be removed for next time.
        foreach (int num in nums) {
            HashSet<int> nums2 = new HashSet<int>(nums);
            nums2.Remove(num);
            permutation.Add(num);
            NaryTree(permutation, nums2);
            permutation.RemoveAt(permutation.Count-1);
        }


    }
}
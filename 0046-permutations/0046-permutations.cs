public class Solution {
    private List<IList<int>> permutations = new List<IList<int>>();
    private int[] nums;
    public IList<IList<int>> Permute(int[] nums) {
        this.nums = nums;
        NaryTree(new List<int>(), new HashSet<int>());
        return permutations;
    }

    private void NaryTree(List<int> permutation, HashSet<int> removed) {
        bool removedAll = removed.Count == nums.Length;
        if (removedAll) {
            permutations.Add(new List<int>(permutation));
            return;
        }

        // choosing an element means it can never be used in that perm again
        // so it must be removed for next time.
        // Removing from nums causes ConcurrentModificationException
        // so why not ADD to a different list
        foreach (int num in nums) {
            if (!removed.Contains(num)) {
                removed.Add(num);
                permutation.Add(num);
                NaryTree(permutation, removed);
                permutation.RemoveAt(permutation.Count-1);
                removed.Remove(num);
            }

        }


    }
}
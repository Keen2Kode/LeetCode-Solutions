public class Solution {
    public IList<IList<int>> Permute(int[] nums) {
        IList<IList<int>> result = new List<IList<int>>();
        Backtrack(nums, new List<int>(), result);
        return result;
    }

    private void Backtrack(int[] nums, List<int> path, IList<IList<int>> result) {
        if (path.Count == nums.Length) {
            result.Add(new List<int>(path));
            return;
        }
        foreach (int num in nums) {
            if (path.Contains(num)) continue;
            path.Add(num);
            Backtrack(nums, path, result);
            path.RemoveAt(path.Count - 1);
        }
    }
}
public class Solution {
    public IList<int> FindDisappearedNumbers(int[] nums) {
        HashSet<int> allNums = new(Enumerable.Range(1,nums.Length));

        foreach (int num in nums)
            allNums.Remove(num);
        
        return allNums.ToList();

    }
}
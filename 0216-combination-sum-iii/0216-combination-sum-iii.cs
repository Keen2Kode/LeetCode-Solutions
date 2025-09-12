public class Solution {
    private int MIN = 1;
    private int MAX = 9;
    private int k;
    private List<IList<int>> combinations = new();

    public IList<IList<int>> CombinationSum3(int k, int n) {
        this.k = k;
        // if (lowestSum(k) > n)
        //     return combinations;
        
        NaryTree(new List<int>(), MIN, n);
        return combinations;
        
    }

    private int lowestSum(int k) {
        int lowestSum = 0;
        for (int i=MIN; i<=MAX && i<=k; i++) {
            lowestSum += i;
        }
        return lowestSum;

    }

    private void NaryTree(List<int> combo, int start, int target) {
        // Console.WriteLine($"start: {start}, target: {target}, k: {k}, combo count: {combo.Count}");
        if (target < 0)
            return;
        if (combo.Count > k)
            return;
        if (target == 0 && combo.Count == k) {
            combinations.Add(new List<int>(combo));
            return;
        }
        for (int i=start; i<=MAX; i++) {
            combo.Add(i);
            NaryTree(combo, i+1, target-i);
            combo.RemoveAt(combo.Count-1);
        }
    }
}
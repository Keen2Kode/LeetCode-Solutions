public class Solution {

    private int n;
    private int k;
    private List<IList<int>> combinations;
    public IList<IList<int>> Combine(int n, int k) {
        // Unlike Subsets problem, more efficient to think of this as an n-ary tree
        // since there are exactly k levels, combos are at leaf nodes only
        // if you did this with Subsets, you would have to return non-leaf nodes

        this.n = n;
        this.k = k;
        combinations = new List<IList<int>>();
        NaryCombination(new List<int>(), 1);
        Print();
        return combinations;
    }

    private void NaryCombination(List<int> combination, int startVal) {
        // add combination at leaf
        if (combination.Count == k) {
            combinations.Add(new List<int>(combination));
            return;
        }

        // n-ary tree
        // the "skipping" is in built in the for loop
        // eg: if startVal=3, cannot add 2 or 1
        for (int i=startVal; i<=n; i++) {
            NaryCombination(new List<int>(combination) {i}, i+1);
        }
    }

    private void Print() {
        foreach (List<int> combination in combinations) {
            Console.WriteLine(String.Join("->", combination));
        }
    }
}
public class Solution
{
    public IList<IList<int>> CombinationSum(int[] candidates, int target)
    {
        Array.Sort(candidates);
        var res = new List<IList<int>>();
        var cur = new List<int>();

        void Dfs(int start, int remain)
        {
            if (remain == 0)
            {
                res.Add(new List<int>(cur));
                return;
            }

            for (int i = start; i < candidates.Length; i++)
            {
                int v = candidates[i];
                if (v > remain) break;         // prune by sorted order

                cur.Add(v);
                Dfs(i, remain - v);            // i (not i+1) → unlimited reuse
                cur.RemoveAt(cur.Count - 1);   // backtrack
            }
        }

        Dfs(0, target);
        return res;
    }
}

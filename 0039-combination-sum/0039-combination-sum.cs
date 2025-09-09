public class Solution
{
    private int[] cand;
    private List<IList<int>> res = new();
    private int[] stack = new int[32]; // grows as needed

    public IList<IList<int>> CombinationSum(int[] candidates, int target)
    {
        Array.Sort(candidates);        // enables early break
        cand = candidates;
        Dfs(0, target, 0);
        return res;
    }

    // start: index into candidates
    // remain: remaining target
    // depth:  how many items currently in 'stack'
    private void Dfs(int start, int remain, int depth)
    {
        if (remain == 0)
        {
            // copy once per solution (int[] implements IList<int>, so it's valid to store directly)
            var ans = new int[depth];
            Array.Copy(stack, ans, depth);
            res.Add(ans);
            return;
        }

        // iterate remaining candidates; allow reuse by passing 'i' (not i+1)
        for (int i = start; i < cand.Length; i++)
        {
            int v = cand[i];
            if (v > remain) break;        // sorted prune

            if (depth == stack.Length)    // grow stack if needed
                Array.Resize(ref stack, stack.Length << 1);

            stack[depth] = v;             // push
            Dfs(i, remain - v, depth + 1);
            // no pop needed; 'depth' controls logical length
        }
    }
}

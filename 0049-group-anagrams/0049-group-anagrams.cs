public class Solution
{
    public IList<IList<string>> GroupAnagrams(string[] strs)
    {
        // Each index stores the character counts for strs[index].
        Dictionary<char, int>[] counts =
            new Dictionary<char, int>[strs.Length];

        // Store count of each letter.
        for (int i = 0; i < strs.Length; i++)
        {
            Dictionary<char, int> count = new();

            foreach (char c in strs[i])
            {
                count[c] = count.GetValueOrDefault(c, 0) + 1;
            }

            counts[i] = count;
        }

        // Build group indices first.
        // Example: [[0, 1], [4, 5]]
        List<List<int>> groupIndices = new();

        for (int i = 0; i < strs.Length; i++)
        {
            AddIndex(groupIndices, counts, i);
        }

        IList<IList<string>> groupAnagrams = new List<IList<string>>();

        foreach (List<int> groupIndicesList in groupIndices)
        {
            IList<string> group = new List<string>();

            foreach (int index in groupIndicesList)
            {
                group.Add(strs[index]);
            }

            groupAnagrams.Add(group);
        }

        return groupAnagrams;
    }

    // Compare to the first index of each group.
    // Add to a matching group, or create a new group if none match.
    private static void AddIndex(
        List<List<int>> groupIndices,
        Dictionary<char, int>[] counts,
        int i)
    {
        foreach (List<int> group in groupIndices)
        {
            Dictionary<char, int> firstCount = counts[group[0]];

            if (CompareCounts(firstCount, counts[i]))
            {
                group.Add(i);
                return;
            }
        }

        groupIndices.Add(new List<int> { i });
    }

    private static bool CompareCounts(
        Dictionary<char, int> dict1,
        Dictionary<char, int> dict2)
    {
        if (dict1.Count != dict2.Count)
        {
            return false;
        }

        foreach (char key in dict1.Keys)
        {
            // Check both dictionaries for the same key and count.
            if (dict2.GetValueOrDefault(key, 0) != dict1[key])
            {
                return false;
            }
        }

        return true;
    }
}
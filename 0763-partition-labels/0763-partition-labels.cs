public class Solution {
    public IList<int> PartitionLabels(string s) {

        // LESSON learned: the partition trigger
        // tracking the running chars at each index
        // and finding indices where ALL chars have ended

        // for each letter, keep start and end index
        // a: 0,10
        // b: 1,9
        Dictionary<char, int[]> ranges = new();
        for (int i=0;i<s.Length; i++) {
            char c = s[i];
            // identify start
            if (!ranges.ContainsKey(c))
                ranges[c] = new int[] {i,i};
            else {
                ranges[c][1] = i;
            }
        }

        foreach (var pair in ranges) {
            Console.WriteLine($"key: {pair.Key}, Value: {string.Join(',', pair.Value)}");
        }

        List<int> partitions = new();
        // track present chars at each index
        HashSet<char> charsPresent = new();
        // iterate through string
        int partitionSize = 0;


        for (int i=0; i<s.Length; i++) {
            char c = s[i];
            charsPresent.Add(c);
            partitionSize++;

            Console.WriteLine($"i: {i}, c: {c}, charsPresent: {string.Join(",", charsPresent)} partitionSize: {partitionSize}");
            // remove ended chars from charsPresent
            int endIndex = ranges[c][1];
            if (i == endIndex)
                charsPresent.Remove(c);
            
            // partition ONLY where all chars have ended
            if (charsPresent.Count == 0) {
                partitions.Add(partitionSize);
                partitionSize = 0;
            }
        }

        return partitions;

        
    }
}
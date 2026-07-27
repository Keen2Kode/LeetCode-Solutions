public class Solution {
    public IList<int> FindAnagrams(string s, string p) {
        
        IList<int> anagrams = new List<int>();
        // note that p is not ALWAYS smaller than s
        if (p.Length > s.Length)
            return anagrams;

        // sliding window storing dictionary
        // eg:
        // cbaebac
        // ...      c =1,b=1,a=1 (MATCH)
        //  ...     c=0,b=1,a=1,e=1

        // populate s dictionary to p's length
        Dictionary<char, int> sCount = new();
        Dictionary<char, int> pCount = new();
        for (int i=0; i<p.Length; i++) {
            pCount[p[i]] = pCount.GetValueOrDefault(p[i], 0) +1 ;
            sCount[s[i]] = sCount.GetValueOrDefault(s[i], 0) +1 ;
        }


        

        // slide
        for (int i=0; i<=s.Length-p.Length; i++) {
            // Console.WriteLine($"entering at {i}");
            bool match = Match(sCount, pCount);
            if (match) {      
            
                anagrams.Add(i);
            }
            int iToRemove = i;
            int iToAdd = i+p.Length;

            if (iToAdd < s.Length) {
                char cToRemove = s[iToRemove];
                char cToAdd = s[iToAdd];

                if (sCount.ContainsKey(cToRemove)) {
                    if (sCount[cToRemove]>0)
                        sCount[cToRemove]--;
                    if (sCount[cToRemove] <= 0)
                        sCount.Remove(cToRemove);
                }
                

                sCount[cToAdd] = sCount.GetValueOrDefault(cToAdd, 0) +1;
                
            }
            
        }

        return anagrams;
        
        
    }

    private void PrintDict(Dictionary<char, int> dict) {
        foreach (var pair in dict) {
            Console.WriteLine($"key: {pair.Key}, value: {pair.Value}");
        }
    }

    private bool Match(Dictionary<char, int> dict1, Dictionary<char, int> dict2) {

        // Console.WriteLine("match check: for sCount");
        // PrintDict(dict1);
        
        // Console.WriteLine("match check: for pCount");
        // PrintDict(dict2);
        // same number of keys
        if (dict1.Keys.Count != dict2.Keys.Count)
            return false;
        
        foreach (char c1 in dict1.Keys) {
            if (!dict2.ContainsKey(c1) || dict2[c1] != dict1[c1])
                return false;
        }
        return true;
    }
}
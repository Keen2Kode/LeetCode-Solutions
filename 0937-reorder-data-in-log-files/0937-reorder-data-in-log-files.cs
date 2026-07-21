public class Solution {
    public string[] ReorderLogFiles(string[] logs) {
        // "dig1 8 1 5 1",
        // "let1 art can"
        // "dig2 3 6"
        // "let2 own kit dig"
        // "let3 art zero"
        // group digit and letter logs
        // unclear identifier, use 2nd word

        // build list of letter and digit logs
        List<string> letterLogs = new();
        List<string> digitLogs = new();
        foreach (string log in logs) {
            string word2 = log.Split(" ")[1];
            if (IsLetterLog(word2)) {
                letterLogs.Add(log);
            } else {
                digitLogs.Add(log);
            }
        }

        letterLogs.Sort((a,b) => CompareLetterLogs(a,b));
        List<string> finalLogs = letterLogs.Concat(digitLogs).ToList();

        return finalLogs.ToArray();
        
    }
    private static int CompareLetterLogs(string a, string b) {
        // Console.WriteLine($"Comparing a: {a}, to b: {b}");
        string[] arrayA = a.Split(" ", 2);
        string[] arrayB = b.Split(" ", 2);
        
        string idA = arrayA[0];
        string idB = arrayB[0];
        string contentA = arrayA[1];
        string contentB = arrayB[1];

        if (contentA.CompareTo(contentB) != 0) 
            return contentA.CompareTo(contentB);
        return idA.CompareTo(idB);

    }

    private static bool IsLetterLog(string word2) {
        foreach (char c in word2) {
            if (char.IsLower(c))
                return true;
        }
        return false;
    }
}
public class Solution {
    public string[] ReorderLogFiles(string[] logs) {
        // "dig1 8 1 5 1",
        // "let1 art can"
        // "dig2 3 6"
        // "let2 own kit dig"
        // "let3 art zero"
        // group digit and letter logs
        // unclear identifier, use 2nd word


        // "let1 art can"
        // "let3 art zero"
        //           ^   

        // build list of letter and digit logs
        List<string> letterLogs = new();
        List<string> digitLogs = new();
        foreach (string log in logs) {
            if (IsLetterLog(log)) {
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

    // the last letter is the best tell (the identifier is unpredictable)
    private static bool IsLetterLog(string log) {
        char last = log[log.Length-1];
        return char.IsLower(last);
    }
}
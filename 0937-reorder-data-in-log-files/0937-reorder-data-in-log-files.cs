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
        List<string[]> letterLogs = new();
        List<string> digitLogs = new();
        foreach (string log in logs) {
            if (IsLetterLog(log)) {
                letterLogs.Add(LetterData(log));
            } else {
                digitLogs.Add(log);
            }
        }

        letterLogs.Sort((a,b) => CompareLetterLogs(a,b));
        List<string> finalLogs = new();
        foreach (string[] letterData in letterLogs) {
            finalLogs.Add(letterData[0] + " " + letterData[1]);
        }
        

        return finalLogs.Concat(digitLogs).ToArray();
        
    }
    private static int CompareLetterLogs(string[] a, string[] b) {
        // Console.WriteLine($"Comparing a: {string.Join(",", a)} to b: {string.Join(",", b)}");
        
        string idA = a[0];
        string idB = b[0];
        string contentA = a[1];
        string contentB = b[1];

        if (contentA.CompareTo(contentB) != 0) 
            return contentA.CompareTo(contentB);
        return idA.CompareTo(idB);

    }

    private static string[] LetterData (string log) {
        string[] array = log.Split(" ", 2);
        string id = array[0];
        string content = array[1];
        return new string[] {id, content};
    }

    // the last letter is the best tell (the identifier is unpredictable)
    private static bool IsLetterLog(string log) {
        char last = log[log.Length-1];
        return char.IsLower(last);
    }
}
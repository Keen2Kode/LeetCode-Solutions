public class Solution {
    public int[] ExclusiveTime(int n, IList<string> logs) {
        // visualise: timestamp x-axis, function y-axis
        // 1st approach: iterate timestamp 
        // visualize having a function stack through each timestamp iteration
        // start pushes to timestamp, end pops off timestamp
        // complexity: O(timestamp) very inefficient

        // 2nd approach iterate logs
        //  iterate logs
        //      mod stack, mod timestamp array
        // problem, only add to timestamp array once you enter the next iteration
        // problem ,what if first timestamp is NOT 0
        // problem, which function? current logs function or top stacks function 
        //  iterate logs
        //      set t++ if end
        //      set duration = t - t prev
        //      mod function array with duration (which function??)
        //      mod stack
        //      set t prev

        // initialize when we know the first timestamp
        int t = int.MinValue;
        int tPrev = int.MinValue;
        Stack<int> stack = new();
        int[] functionTimes = new int[n];
        for (int i=0; i<n; i++) {
            functionTimes[i] = 0;
        }
        for (int i=0; i<logs.Count; i++) {
            
            string log = logs[i];
            string[] logArray = log.Split(":");
            int function = int.Parse(logArray[0]);
            bool isEnd = logArray[1].Contains("end");
            int timestamp = int.Parse(logArray[2]);
            // Console.WriteLine($"function: {function}, isEnd: {isEnd}, timestamp: {timestamp}");


            // bug if first timestamp is 1, as tPrev would be 0, aka incorrect first duration
            // so initialize
            t = timestamp;
            if (i==0) {
                tPrev = timestamp;
            }
            // remember duration of timestamp end 5 == timestamp start 6
            if (isEnd)
                t++;

            // can't just call the "function" at this timestamp
            // bc you will add the duration to the next stamp
            if (i>0 && stack.Count > 0) {
                functionTimes[stack.Peek()] += t-tPrev;
            }

            if (isEnd) {
                stack.Pop();
            }
            else {
                stack.Push(function);
                
            }


            tPrev = t;
        }

        return functionTimes;
    }

    // if efficiency didn't drop, we can use a class
    // public class Log {

    //     public int Function {get; set;}
    //     public bool IsEnd {get; set;}
    //     public int Timestamp {get; set;}
    //     public Log(string log) {
    //         string[] logArray = log.Split(":");
    //         this.Function = int.Parse(logArray[0]);
    //         this.IsEnd = logArray[1].Contains("end");
    //         this.Timestamp = int.Parse(logArray[2]);
    //         // Console.WriteLine($"function: {function}, isEnd: {isEnd}, timestamp: {timestamp}");
    //     }
    // }
}
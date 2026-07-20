public class RecentCounter {

    LinkedList<int> requests;
    int recentRequests;
    int DURATION = 3000;
    public RecentCounter() {
        recentRequests = 0;
        requests = new();
        
    }
    
    public int Ping(int t) {
        int lowerLimit = t-DURATION;     
        
        Console.WriteLine(lowerLimit);
        requests.AddLast(t);
        // remove upwards until lowerLimit
        // t= 3007
        // [1,5,3001,3007]
        //  X X
        while (true) {
            int value = requests.First!.Value;
            // Console.WriteLine($"comparing {value} to {lowerLimit}");
            if (value < lowerLimit) {
                requests.RemoveFirst();
                // Console.WriteLine("removed");
            }
            else break;
        }
        // Console.WriteLine(string.Join(",", requests));
    

        return requests.Count;
    }
}

/**
 * Your RecentCounter object will be instantiated and called as such:
 * RecentCounter obj = new RecentCounter();
 * int param_1 = obj.Ping(t);
 */
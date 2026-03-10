public class Solution {
    public int CarFleet(int target, int[] position, int[] speed) {
        
        // draw graph of pos vs time, and look at when it collides 
        // example 1:
        //  time arrival at target  start pos 
        //  1                       10
        //  1                       8       (crashes)
        //  12                      0
        //  7                       5
        //  3                       3       (crashes)
        //  if target time of earlier start cars <= later cars, then crash

        // ofc need the sorted indices for comparing O(nlogn)
        int[] sortedIndices = SortedIndices(position);
        // Console.WriteLine(string.Join(",", sortedIndices));

        //  example 1 ordered by start pos 
        //  time arrival at target  start pos 
        //  1                       10      (fleet 1)
        //  1                       8       
        //  7                       5       (fleet 2)
        //  3                       3       
        //  12                      0       (fleet 3)

        
        int fleets = 0;
        float minTargetTime = -1;
        for (int a=0; a<sortedIndices.Length; a++) {
            int i = sortedIndices[a];
            int p = position[i];
            int s = speed[i];
            float targetTime = TargetArrivalTime(target, p, s);
            if (targetTime > minTargetTime) {
                fleets++;
                minTargetTime = targetTime;
            }
        }
       
        return fleets;
    }

    private int[] SortedIndices(int[] position) {
        return 
        (from i in Enumerable.Range(0, position.Length)
            orderby position[i] descending
            select i).ToArray();
        
    }

    private float TargetArrivalTime(int target, int position, int speed) {
        // eg: p=3, s=3, target=12
        // t= (target-p)/s
        // if s=0, ignore
        if (speed==0)
            return -1;
        return (target-position)/(float)speed;
    }
}
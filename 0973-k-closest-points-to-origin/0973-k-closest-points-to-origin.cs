public class Solution {
    public int[][] KClosest(int[][] points, int k) {

        // first solution: smart sort
        // store array of point index + distance
        // eg: [1, 4], [2, 10], [3, 3]
        // 2 options:
        // sort at the end
        // array length = n (points)
        // sorting = O(nlogn)
        // OR sort each round, removing additional points
        // each round sort = O(k log k)
        // full sorting O(n*k log k)
        List<int[]> distances = new();
        for (int i=0; i<points.Length; i++) {
            int x = points[i][0];
            int y = points[i][1];
            int distance = Distance(x,y);
            distances.Add(new int[] {x, y, distance});
        }
        distances.Sort((a,b) => a[2].CompareTo(b[2]));

        PrintDistances(distances);
        int[][] kClosest = new int[k][];
        for (int i=0; i<kClosest.Length; i++) {
            int x = distances[i][0];
            int y = distances[i][1];
            kClosest[i] = new int[] {x,y};
        }
        return kClosest;
    }

    static int Distance(int x, int y) {
        return  x*x + y*y;
    }

    static void PrintDistances(List<int[]> distances) {
        foreach (int[] distanceGroup in distances) {
            Console.WriteLine(string.Join(",", distanceGroup));
        }
    }
}

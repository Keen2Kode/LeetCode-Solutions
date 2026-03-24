public class Solution {
    public int[][] KClosest(int[][] points, int k) {

        // naive approach
        // sort all the points distances, tracking their indices
        // complexity: 
        // each insert: O(nlogn) (due to sorting each time)
        // each removal past k elements: O(1)
        // total O(k*n log n) - k elements at any point of time
        // final return O(1)

        // Min Heap approach
        // complexity: 
        // each insert (log n)
        // WE CAN'T REMOVE past k elements - we don't know the max
        // total O(n log n)
        // final return (log n)

        // Advanced Min heap approach
        // 1. Use max heap
        // 2. No need for a min heap, because we can return in ANY order
        // complexity:
        // each insert and removal (log n)
        // total O(k log n) - no need to return in order

        // create a priority queue with points distances
        PriorityQueue<int, double> maxHeapIndices = new();

        // add each points index prioritized by distance 
        // but start removing at k elements
        // REMEMBER k is min
        for (int i=0; i<points.Length; i++) {
            int x = points[i][0];
            int y = points[i][1];
            double distance = Distance(x,y);

            // Console.WriteLine($"x: {x}, y: {y}, distance: {distance}");
            AddAndStoreMax(maxHeapIndices, i, Distance(x,y));

            if (maxHeapIndices.Count > k && maxHeapIndices.Count > 0) {
                RemoveMax(maxHeapIndices);
            }
            // PrintHeap(maxHeapIndices);
        }

        return BuildPointsFromIndices(maxHeapIndices, points, k);

        


        
        
    }

    private double Distance(int x, int y) {
        return (double) Math.Sqrt(x*x + y*y);
    }

    private void AddAndStoreMax(PriorityQueue<int, double> maxHeapIndices, int i, double distance) {
        maxHeapIndices.Enqueue(i, -distance);
    }

    private int RemoveMax(PriorityQueue<int, double> maxHeapIndices) {

        return maxHeapIndices.Dequeue();
    }

    private int[][] BuildPointsFromIndices(PriorityQueue<int, double> maxHeapIndices, int[][] points, int k) {
        int[][] closestPoints = new int[k][];
        for (int i=0; i<closestPoints.Length; i++) {
            int index = RemoveMax(maxHeapIndices);
            int x = points[index][0];
            int y = points[index][1];
            closestPoints[i] = new int[2] {x,y} ;
        }
        return closestPoints;
    }

    private void PrintHeap(PriorityQueue<int, double> pq) {
        foreach (var item in pq.UnorderedItems)
            Console.Write(item.Element + " ");
        Console.WriteLine();
    }
}
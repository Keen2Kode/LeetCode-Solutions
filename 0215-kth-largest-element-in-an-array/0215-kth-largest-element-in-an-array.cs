public class Solution {
    public int FindKthLargest(int[] nums, int k) {
        
        // Naive approach
        // sort O(n log n)
        // return O(n)

        // Min heap approach (eg: k=4)
        // empty heap
        // each insert O(log n)
        // Total O(k log n) - we will never have to sort past 4 elements
        // each removal O(log n) - remove the MIN element, so only maxes are in
        // Total O(k log n)


        PriorityQueue<int, int> minHeap = new();
        foreach (int num in nums) {
            AddAndSetMin(minHeap, num);
            if (minHeap.Count > k) {
                RemoveMin(minHeap);
            }
        }
        return RemoveMin(minHeap);

    }

    private void AddAndSetMin(PriorityQueue<int, int> minHeap, int num) {
        // lowest priority will be first to dequeue
        minHeap.Enqueue(num, num);
    }

    private int RemoveMin(PriorityQueue<int, int> minHeap) {
        return minHeap.Dequeue();
    }
}
public class Solution {
    public int LastStoneWeight(int[] stones) {

        if (stones.Length == 1)
            return stones[0];
        
        // naive approach
        // list
        // {2,7,4,1,8,1}
        // {1,1,2,4,7,8} - sorted
        // {1,1,2,4,1}
        // {1,1,1,2,4} - sorted (O(n) because only sorting last)   
        // {1,1,1,2}
        // {1,1,1}
        // {1} - destroy both
        // O(n^2)

        // we don't care about the FULL sorted array, just top 2 sorted
        // max heap approach
        // sorting O(log(n))
        // total O(nlog(n))

        PriorityQueue<int, int> maxHeap = new();
        foreach(int stone in stones) {
            AddAndStoreMax(maxHeap, stone);
        }

        // remove 2 maxes
        while (maxHeap.Count >= 2) {
            int stone1 = RemoveMax(maxHeap);
            int stone2 = RemoveMax(maxHeap);
            int smashedStone = stone1 - stone2;

            bool destroyed = smashedStone == 0;
            if (!destroyed)
                AddAndStoreMax(maxHeap, smashedStone);
        }

        if (maxHeap.Count == 1)
            return RemoveMax(maxHeap);
        // nothing in maxHeap
        return 0;




        
    }

    private void AddAndStoreMax(PriorityQueue<int, int> maxHeap, int stone) {
        // lowest gets highest priority
        maxHeap.Enqueue(stone, -stone);
    }

    private int RemoveMax(PriorityQueue<int, int> maxHeap) {
        return maxHeap.Dequeue();
    }
}
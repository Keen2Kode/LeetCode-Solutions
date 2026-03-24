public class KthLargest {

    private int k;
    private int[] nums;
    // data structure options:
    // linkedlist - works but very complicated to access a node and move through it
    // sortedset - removes duplicates
    // want to keep duplicates AND know the min
    // sortedDictionary keeps FULL order
    // PriorityQueue keeps min, don't care about full order
    private PriorityQueue<int, int> queueTillK;
    public KthLargest(int k, int[] nums) {
        this.k = k;
        this.nums = nums;
        
        queueTillK = new PriorityQueue<int, int>();
        foreach (int num in nums) {
            // add num with it's priority as num
            Add(queueTillK, num);
        }
        while(queueTillK.Count > k) {
            RemoveMin(queueTillK);
        }

        // PrintQueue(queueTillK);




    }


    
    public int Add(int val) {
        Console.WriteLine("adding " + val);
        // if you used LINKEDLIST
        // ordered linkedlist from k -> 1st largest
        // every val compare from k -> 1st largest
        // if val>k, pop kth, and find where to put val in linkedlist
        // then just get new kth in the linkedlist

        // eg:  {2,2,5}, k=3, val=4
        //      {2,2,4,5}
        Add(queueTillK, val);
        //      {2,4,5}
        if (queueTillK.Count > k)
            RemoveMin(queueTillK);

        return Min(queueTillK);
    }



    private void PrintQueue(PriorityQueue<int, int> queueTillK)
    {
        var copy = new PriorityQueue<int, int>();
        foreach (var item in queueTillK.UnorderedItems)
        {
            copy.Enqueue(item.Element, item.Priority);
        }

        while (copy.Count > 0)
        {
            Console.Write(copy.Dequeue() + " ");
        }

        Console.WriteLine();
    }

    private void RemoveMin(PriorityQueue<int, int> queueTillK) {
        queueTillK.Dequeue();
    }

    private int Min(PriorityQueue<int, int> queueTillK) {
        return queueTillK.Peek();
    }

    private void Add(PriorityQueue<int, int> queueTillK, int val) {
        queueTillK.Enqueue(val, val);
    }

    
}

/**
 * Your KthLargest object will be instantiated and called as such:
 * KthLargest obj = new KthLargest(k, nums);
 * int param_1 = obj.Add(val);
 */
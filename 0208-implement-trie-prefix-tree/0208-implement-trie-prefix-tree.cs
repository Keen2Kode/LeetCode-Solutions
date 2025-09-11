public class Trie {

    private Node root;
    public Trie() {
        root = new Node();
    }
    
    public void Insert(string word) {
        Insert(root, word, 0);
    }
    
    public bool Search(string word) {
        return Search(root, word, 0, false);
    }
    
    public bool StartsWith(string prefix) {
        return Search(root, prefix, 0, true);
    }



    private void Insert(Node node, string word, int i) {
        if (i==word.Length) {
            node.isEnd = true;
            return;
        }
        
        Insert(GetNextInsert(node, word[i]), word, i+1);

    }

    private Node GetNextInsert(Node node, char c) {
        Node next = GetNext(node, c) ?? new Node();
        next.val = c;
        node.next.Add(next);
        return next;
    }

    private bool Search(Node node, string word, int i, bool prefixSearch) {
        if (node == null)
            return false;
        if (i==word.Length) {
            return node.isEnd || prefixSearch;
        }
        return Search(GetNext(node, word[i]), word, i+1, prefixSearch);
    }

    private Node GetNext(Node node, char c) {
        foreach (Node next in node.next) {
            if (next.val == c)
                return next;
        }
        return null;
    }
}

public class Node {
    public List<Node> next = new List<Node>();
    public char val;
    public bool isEnd = false;
}

/**
 * Your Trie object will be instantiated and called as such:
 * Trie obj = new Trie();
 * obj.Insert(word);
 * bool param_2 = obj.Search(word);
 * bool param_3 = obj.StartsWith(prefix);
 */
public class Trie {

    private Node root;
    public Trie() {
        root = new Node();
    }
    
    public void Insert(string word) {
        Insert(root, word, 0);
    }

    private void Insert(Node node, string word, int i) {
        if (i==word.Length) {
            node.isEnd = true;
            return;
        }
        Insert(getNext(node, word[i]), word, i+1);

    }

    private Node getNext(Node node, char c) {
        foreach (Node next in node.next) {
            if (next.val == c)
                return next;
        }
        Node toAdd = new Node();
        toAdd.val = c;
        node.next.Add(toAdd);
        return toAdd;
    }
    
    public bool Search(string word) {
        return Search(root, word, 0, false);
    }

    private bool Search(Node node, string word, int i, bool prefixSearch) {
        if (node == null)
            return false;
        if (i==word.Length) {
            if (node.isEnd || prefixSearch)
                return true;
            return false;
        }
        return Search(GetNextSearch(node, word[i]), word, i+1, prefixSearch);
    }

    private Node GetNextSearch(Node node, char c) {
        foreach (Node next in node.next) {
            if (next.val == c)
                return next;
        }
        return null;
    }
    
    public bool StartsWith(string prefix) {
        return Search(root, prefix, 0, true);
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
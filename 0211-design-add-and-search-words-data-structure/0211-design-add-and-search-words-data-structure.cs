public class WordDictionary {

    private Node root;
    public WordDictionary() {
        root = new Node();
    }
    
    public void AddWord(string word) {

        void Insert(Node node, string word, int i) {
            if (word.Length == i) {
                node.WordEnd = true;
                return;
            }

            Node next;
            if (node.Children.ContainsKey(word[i])) {
                next = node.Children[word[i]];
            } 
            else {
                next = new Node();
                node.Children[word[i]] = next;
            }
            Insert(next, word, i+1);
        }

        Insert(root, word, 0);
        
    }

    
    public bool Search(string word) {

        bool Search(Node node, string word, int i) {
            if (node == null)
                return false;
            if (word.Length == i) {
                return node.WordEnd;
            }
            if (word[i] != '.')
                return Search(node.Children.GetValueOrDefault(word[i]), word, i+1);

            // when searching for ., search EVERY node
            foreach (Node next in node.Children.Values) {
                if (Search(next, word, i+1))
                    return true;
            }
            return false;
        }
        return Search(root, word, 0);
    }

    public class Node {
        public Dictionary<char, Node> Children {get; set;} = new();
        public bool WordEnd {get; set;} = false;
    }
}

/**
 * Your WordDictionary object will be instantiated and called as such:
 * WordDictionary obj = new WordDictionary();
 * obj.AddWord(word);
 * bool param_2 = obj.Search(word);
 */
public class Solution {

    // solution approach: cache words with trie
    // 1st submission insight
    // words: "ababababaa","ababababab"
    // if last b not found in trie, don't restart search
    // build trie first, then DFS search for the TRIE, not just 1 word

    public IList<string> FindWords(char[][] board, string[] words) {
        return FindWordsNew(board, words);
    }

    private List<string> FindWordsNew(char[][] board, string[] words) {
        return new Board(board).Search(new Trie(words));
    }

    private List<string> FindWordsOld(Board board, string[] words) {
        Trie trie = new();
        List<string> foundWords = new();

        foreach (string word in words) {
            bool foundInTrie = trie.Search(word);

            if (foundInTrie)
                foundWords.Add(word);
            else if (board.Search(word)) {
                trie.Insert(word);
                foundWords.Add(word);
            }
        }
        return foundWords;
    }

    // the difference to Word Search 1, is searching multiple words
    // eg: "test", "tester", "testers" is repeated work
    // skip it by utilizing a TRIE beforehand!

    public class Trie {

        public Node root {get;}= new Node();

        public Trie(string[] words) {
            //cache the trie with all words
            foreach (string word in words) {
                Insert(word);
            }
        }

        public Trie() {
            // no caching for old method
        }

        public bool Search(string word) {
            return Search(root, word, 0);
            bool Search(Node node, string word, int i) {
                if (node == null)
                    return false;
                if (word.Length == i)
                    return true;
                Node next = node.Children.GetValueOrDefault(word[i]);
                return Search(next, word, i+1);
            }
        }


        public void Insert(string word) {

            Insert(root, word, 0);
            void Insert(Node node, string word, int i) {
                if (node == null)
                    throw new Exception("how did you get here lol");
                if (word.Length == i) {
                    node.WordEnd = true;
                    return;
                }
                Node next = node.Children.GetValueOrDefault(word[i]);
                if (next == null)
                    node.Children[word[i]] = next = new Node();
                Insert(next, word, i+1);
            }
        }



        public class Node {
            public Dictionary<char, Node> Children {get; set;} = new();
            // DFS hitting this node triggers the addition to found words
            public bool WordEnd{get; set;} = false;
        }
    }






    public class Board {
        private int ROWS;
        private int COLS;
        private char[][] board;
        public Board(char[][] board) {
            this.board = board;
            ROWS = board.Length;
            COLS = board[0].Length;
        }

        // word search 2 we're searching for the entire trie during our dfs
        // add more words as we reach those trie nodes
public List<string> Search(Trie trie) {
    HashSet<string> words = new();

    for (int i = 0; i < ROWS; i++) {
        for (int j = 0; j < COLS; j++) {
            Search(i, j, "", trie.root, new bool[ROWS, COLS], null, '\0');
        }
    }
    return words.ToList();

    void Search(int i, int j, string builtWord, Trie.Node node,
                bool[,] visited, Trie.Node lastBranchNode, char lastBranchEdge) 
    {
        if (node == null)
            return;
        if (OutOfBounds(i, j))
            return;
        if (visited[i, j])
            return;

        char c = board[i][j];
        Trie.Node next = node.Children.GetValueOrDefault(c);
        if (next == null)
            return;

        string newWord = builtWord + c;
        if (next.WordEnd) {
            words.Add(newWord);
            next.WordEnd = false; // avoid duplicates
        }

        // update last branching point if current node is a branch or word end
        Trie.Node newLastBranchNode = lastBranchNode;
        char newLastBranchEdge = lastBranchEdge;
        if (node.WordEnd || node.Children.Count > 1) {
            newLastBranchNode = node;
            newLastBranchEdge = c;
        }

        visited[i, j] = true;
        foreach ((int a, int b) in Neighbours(i, j)) {
            Search(a, b, newWord, next, visited, newLastBranchNode, newLastBranchEdge);
        }
        visited[i, j] = false;

        // prune if this path is now useless
        if (!next.WordEnd && next.Children.Count == 0 && newLastBranchNode != null) {
            newLastBranchNode.Children.Remove(newLastBranchEdge);
        }
    }
}




        // old
        public bool Search(string word) {

            for (int i=0; i<ROWS; i++) {
                for (int j=0; j<COLS; j++) {
                    if (Search(i, j, word, 0, new bool[ROWS,COLS]))
                        return true;
                }
            }
            return false;

            bool Search(int i, int j, string word, int wordIndex, bool[,] visited) {
                if (word.Length == wordIndex)
                    return true;
                if (OutOfBounds(i,j))
                    return false;
                if (visited[i,j])
                    return false;
                
                if (word[wordIndex] != board[i][j])
                    return false;
                
                // only valid searchables coordinates from here
                // ensure the trie will track this
                visited[i,j] = true;
                bool found = Neighbours(i, j)
        .Any(((int a, int b) pos) => Search(pos.a, pos.b, word, wordIndex + 1, visited));
                visited[i,j] = false;

                return found;
                    
            }
        }


        private (int, int)[] Neighbours(int i, int j) {
            return new (int, int)[] {
                (i+1,j),
                (i,j+1),
                (i-1,j),
                (i,j-1)
            };
        }
            
        private bool OutOfBounds(int i, int j) {
            if (i < 0)
                return true;
            if (j < 0)
                return true;
            if (i >= ROWS)
                return true;
            if (j >= COLS)
                return true;
            return false;
        }

        
    }

    


}
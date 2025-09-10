public class Solution {

    private char[][] board;
    private string word;
    private int ROWS;
    private int COLS;
    public bool Exist(char[][] board, string word) {
        this.board = board;
        this.word = word;
        ROWS = board.Length;
        COLS = board[0].Length;
        // this will avoid the path searching itself in the future
        bool[,] visited = new bool[ROWS, COLS];
        
        // iterate through the board for 1st char
        for (int i=0; i< ROWS; i++) {
            for (int j=0; j<COLS; j++) {
                if (Search(i, j, 0, visited))
                    return true;
            }
        }
        return false;
    }

    private bool Search(int i, int j, int wordIndex, bool[,] visited) {
        if (wordIndex == word.Length)
            return true;

        if (OutOfBounds(i, j))
            return false;
        if (visited[i,j])
            return false;
        if (board[i][j] != word[wordIndex])
            return false;

        // search up, down, left right
        // recurse if next char found
        // return false if fails for all!
        visited[i,j] = true;
        foreach ((int a, int b) in SearchCoordinates(i,j)) {
            if (Search(a,b,wordIndex+1, visited))
                return true;
        }
        visited[i,j] = false;
        // if board only has 1 char, no coordinates to search
        // that DOESN't mean it's failed
        bool lastCharacter = wordIndex == word.Length -1;
        return lastCharacter;
    }

    private (int, int)[] SearchCoordinates(int i, int j) {
        return new (int, int)[] {
            (i+1, j),
            (i, j+1),
            (i-1, j),
            (i, j-1)
        };
    }

    private bool OutOfBounds(int i, int j) {
        if (i >= ROWS || i < 0)
            return true;
        if (j >= COLS || j<0)
            return true;
        return false;
    }
}
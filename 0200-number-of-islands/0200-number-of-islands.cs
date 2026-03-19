public class Solution {
    public int NumIslands(char[][] grid) {
        
        // iterate through grid
        // if 1, it's the start of an island. trigger DFS graph search it.
        // islands++
        // once done we keep going from where we stopped
        // if next 1 is not "visited" start a search there too

        // not a fan of mutating the array to '0' for visited
        // let's store another bool array
        bool[,] visited = new bool[grid.Length,grid[0].Length];

        int islands = 0;

        for (int row=0; row<grid.Length; row++) {
            for (int col=0; col<grid[0].Length; col++) {

                bool startOfIsland = grid[row][col] == '1' && !visited[row, col];

                if (startOfIsland) {
                    Console.WriteLine($"island started at: {row},{col}" );
                    SearchIslandDFS(row, col, visited, grid);
                    islands++;
                }
                // next time if we come across a visited '1' we can skip
            }
        }
        return islands;
    }

    private void SearchIslandDFS(int row, int col, bool[,] visited, char[][] grid) {
        if (ValidCell(row, col, visited, grid)) {
            visited[row,col] = true;
            // keep parsing each direction
            SearchIslandDFS(row+1, col, visited, grid);
            SearchIslandDFS(row-1, col, visited, grid);
            SearchIslandDFS(row, col+1, visited, grid);
            SearchIslandDFS(row, col-1, visited, grid);
        }
    
    }

    private bool ValidCell(int row, int col, bool[,] visited, char[][] grid) {
        if (row < 0 || row >= grid.Length)
            return false;
        if (col < 0 || col >= grid[0].Length)
            return false;  
        if (grid[row][col] == '0')
            return false;
        if (visited[row, col])
            return false;

        return true;

    }
}
public class Solution {

    private int count = 0;
    public int MaxAreaOfIsland(int[][] grid) {
        // similar approach to 622: counting islands
        // DFS search each island
        int maxArea = 0;

        bool[,] visited = new bool[grid.Length, grid[0].Length];

        for (int row=0; row<grid.Length; row++) {
            for (int col=0; col<grid[0].Length; col++) {

                bool newIsland = grid[row][col] == 1 && !visited[row,col];
                if (newIsland) {
                    CountAreaDFS(row, col, visited, grid);
                    maxArea = Math.Max(count, maxArea);
                    count = 0;
                }
            }
        }
        return maxArea;
        
    }

    private void CountAreaDFS(int row, int col, bool[,] visited, int[][] grid) {
        if (ValidCell(row, col, visited, grid)) {
            visited[row,col] = true;
            count++;
            CountAreaDFS(row+1, col, visited, grid);
            CountAreaDFS(row-1, col, visited, grid);
            CountAreaDFS(row, col+1, visited, grid);
            CountAreaDFS(row, col-1, visited, grid);
        }
    }

    private bool ValidCell(int row, int col, bool[,] visited, int[][] grid) {
        if (row < 0 || row >= grid.Length)
            return false;
        if (col < 0 || col >= grid[0].Length)
            return false;
        if (grid[row][col] == 0)
            return false;
        if (visited[row,col] == true)
            return false;

        return true;
    }
}
public class Solution {
    public IList<IList<int>> PacificAtlantic(int[][] heights) {
        
        // Inefficient solution
        //  Consider starting at each cell and going outwards
        // seeing if it reaches an edge.
        // VERY inefficient. Each cell search is m*n, and you have to search the m*n grid
        // aka O(m*n) ^2

        // more efficient
        // start oceans and go inward
        // grid of pacific flow cells
        // grid of atlantic flow cells
        // it's over lap is what we're looking for

        IList<IList<int>> doubleFlows = new List<IList<int>>();

        // top PACIFIC edge
        bool[,] pacificFlows = new bool[heights.Length, heights[0].Length];
        bool[,] visited = new bool[heights.Length, heights[0].Length];

        for (int c=0; c<heights[0].Length; c++) {
            pacificFlows[0,c] = true;
            UpwardFlowDFS(0,c,heights, ref pacificFlows, ref visited);
        }

        // left PACIFIC edge
        for (int r=0; r<heights.Length; r++) {
            pacificFlows[r,0] = true;
            UpwardFlowDFS(r,0,heights, ref pacificFlows, ref visited);
        }

        // bottom ATLANTIC edge
        // reset visited
        bool[,] atlanticFlows = new bool[heights.Length, heights[0].Length];
        visited = new bool[heights.Length, heights[0].Length];

        int bottom = heights.Length-1;
        for (int c=0; c<heights[0].Length; c++) {
            atlanticFlows[bottom,c] = true;
            UpwardFlowDFS(bottom,c,heights, ref atlanticFlows, ref visited);
        }

        // right PACIFIC edge
        int right = heights[0].Length-1;
        for (int r=0; r<heights.Length; r++) {
            atlanticFlows[r,right] = true;
            UpwardFlowDFS(r,right,heights, ref atlanticFlows, ref visited);
        }


        // check each cell to ensure it has a pacific AND atlantic flow
        for (int r=0; r<heights.Length; r++) {
            for (int c=0; c<heights[0].Length; c++) {
                if (atlanticFlows[r,c] && pacificFlows[r,c]) {
                    doubleFlows.Add(new List<int> { r, c });
                }

            }
        }

        return doubleFlows;

    }

    // mark visited as we traverse upward
    // stop when we can only go down
    private void UpwardFlowDFS(int row, int col, int[][] heights, 
    ref bool[,] oceanFlows, ref bool[,] visited) {

        visited[row,col] = true;
        foreach ((int r, int c) in ValidNeighbours(row, col, heights, visited)) {
            if (heights[r][c] >= heights[row][col]) {
                oceanFlows[r,c] = true;
                UpwardFlowDFS(r, c, heights, ref oceanFlows, ref visited);
            }
        }
    }

    private List<(int, int)> ValidNeighbours(int row, int col, 
    int[][] heights, bool[,] visited) {
        List<(int, int)> neighbours = new();
        (int, int)[] neighbourCoordinates = new (int, int)[] {
            (row+1, col),
            (row-1, col),
            (row, col+1),
            (row, col-1)
        };
        foreach ((int r, int c) in neighbourCoordinates) {
            if (r >= 0 && r < heights.Length &&
                c >= 0 && c < heights[0].Length &&
                !visited[r,c]) {
                    neighbours.Add((r,c));
                }
        }
        return neighbours;
    }
}
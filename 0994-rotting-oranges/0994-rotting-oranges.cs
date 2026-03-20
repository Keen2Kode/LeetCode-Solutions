public class Solution {
    public int OrangesRotting(int[][] grid) {
        
        // first solve number of islands
        // BFS strat
        // start from each rotten orange
        // just go 1 level deeper from each rotten orange each time
        // RO list acts as our visited/to be visited list


        int minutes = 0;
        // create list of rotting orange (RO) sources
        // almost like a visited list
        List<(int, int)> rottingSources = RottingSources(grid);

        
        while (rottingSources.Count > 0) {
            rottingSources = SpreadRotting(grid, rottingSources);
            if (rottingSources.Count > 0)
                minutes++;
        }

        // REMEMBER if even 1 fresh orange exists it's -1
        if (FreshOranges(grid))
            return -1;

        return minutes;
    }

    private List<(int, int)> SpreadRotting(int[][] grid, List<(int,int)> rottingSources) {
        List<(int, int)> newRottingSources = new();
        // Go through each RO
        foreach ((int i, int j) in rottingSources) {
            
                
            // Go through non-rotting orange neighbours (NROs)
            foreach ((int r, int c) in ValidOrangeNeighbours(i,j,grid)) {
                if (grid[r][c] == 1) {
                    // make rotten
                    // add to RO list
                    grid[r][c] = 2;
                    newRottingSources.Add((r,c));
                }
            }
        }
        return newRottingSources;
    }

    private List<(int, int)> RottingSources(int[][] grid) {
        List<(int, int)> rottingSources = new();
        for (int i=0; i<grid.Length; i++) {
            for (int j=0; j<grid[0].Length; j++) {
                if (grid[i][j] == 2)
                    rottingSources.Add((i,j));
            }
        }
        return rottingSources;
    }

    private List<(int, int)> ValidOrangeNeighbours(int i, int j, int[][] grid) {
        List<(int, int)> neighbours = new();
        foreach ((int r, int c) in new (int, int)[] {(i+1,j), (i-1,j), (i,j+1), (i,j-1)}) {
            if (r >= 0 && r < grid.Length && 
                c >= 0 && c < grid[0].Length &&
                grid[r][c] == 1) {
                neighbours.Add((r,c));
            }
        }
        return neighbours;
    }

    private bool FreshOranges(int[][] grid) {
        for (int i=0; i<grid.Length; i++) {
            for (int j=0; j<grid[0].Length; j++) {
                if (grid[i][j] == 1)
                    return true;
            }
        }
        return false;
    }
}
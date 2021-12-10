using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    static class NumberOfIslandsQueue
    {

        private static Queue<IslandNode> qs = new Queue<IslandNode>();
        private static bool[,] visited;
        public static int NumIslands(char[][] grid)
        {
            int resultIslands = 0;
            int rows = grid.Length;
            int cols = grid[0].Length;
            visited = new bool[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    IslandNode curNode = new IslandNode(i, j);
                    Tuple<int, int> v = new Tuple<int, int>(i, j);
                    if (grid[i][j].Equals('1') && !visited[i,j])
                    {
                        visited[i,j] = true;
                        checkSurrounds(grid, i, j);
                        while (qs.Count > 0)
                        {
                            IslandNode nextNode = qs.Dequeue();
                            checkSurrounds(grid, nextNode.R, nextNode.C);
                        }
                        resultIslands++;
                    }
                }
            }
            return resultIslands;
        }

        public static void checkSurrounds(char[][] grid, int row, int col)
        {

            if (col < grid[row].Length - 1 && grid[row][col + 1].Equals('1') && !visited[row, col + 1])
            {
                qs.Enqueue(new IslandNode(row, col + 1));
                visited[row, col + 1] = true;
                //grid[row][col + 1] = 'x';
            }
            if (row < grid.Length - 1 && grid[row + 1][col].Equals('1') && !visited[row + 1, col])
            {
                qs.Enqueue(new IslandNode(row + 1, col));
                visited[row + 1, col] = true;
            }
            if (col > 0 && grid[row][col - 1].Equals('1') && !visited[row, col - 1])
            {
                qs.Enqueue(new IslandNode(row, col - 1));
                visited[row, col - 1] = true;
            }
            if (row > 0 && grid[row - 1][col].Equals('1') && !visited[row - 1, col])
            {
                qs.Enqueue(new IslandNode(row - 1, col));
                visited[row - 1, col] = true;
            }
        }

        public static void PrintGrid(char[][] grid)
        {
            for (int i = 0; i < grid.Length; i++)
            {
                StringBuilder s = new StringBuilder();
                for (int j = 0; j < grid[i].Length; j++)
                {
                    s.Append(grid[i][j]);
                }
                Console.WriteLine(s.ToString());
            }
        }
    }
}

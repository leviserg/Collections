using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    static class NumberOfIslandsQueue
    {

        /*
            char[][] grid3 = {

              new char[] {'1', '1', '0', '1', '0'},
              new char[] {'1', '1', '0', '0', '0'},
              new char[] {'0', '0', '1', '0', '0'},
              new char[] {'1', '0', '0', '1', '1'}

            }; // islands = 3
        */

        private static Queue<IslandNode> qs = new Queue<IslandNode>();

        public static int NumIslands(char[][] grid)
        {
            int resultIslands = 0;
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    IslandNode curNode = new IslandNode(i, j);
                    if (grid[i][j].Equals('1'))
                    {
                        grid[i][j] = 'x';
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
            if (col < grid[row].Length - 1 && grid[row][col + 1].Equals('1'))
            {
                qs.Enqueue(new IslandNode(row, col + 1));
                grid[row][col + 1] = 'x';
            }
            if (row < grid.Length - 1 && grid[row + 1][col].Equals('1'))
            {
                qs.Enqueue(new IslandNode(row + 1, col));
                grid[row + 1][col] = 'x';
            }
            if (col > 0 && grid[row][col - 1].Equals('1'))
            {
                qs.Enqueue(new IslandNode(row, col - 1));
                grid[row][col - 1] = 'x';
            }
            if (row > 0 && grid[row - 1][col].Equals('1'))
            {
                qs.Enqueue(new IslandNode(row - 1, col));
                grid[row - 1][col] = 'x';
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

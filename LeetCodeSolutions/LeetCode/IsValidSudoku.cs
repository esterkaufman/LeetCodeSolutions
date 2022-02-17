using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeSolutions.LeetCode
{
    //https://leetcode.com/problems/valid-sudoku/discuss/1776999/very-simple-faster-than-91.88-of-C
    public class IsValidSudoku_Solution
    {
        public void TempMatrix()
        {
            int count = 1;
            int[,] mat = new int[9, 9];
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    var row = i / 3 * 3 + j / 3;
                    var col = i % 3 * 3 + j % 3;
                    Console.Write($"[{row},{col}],");
                    mat[row, col] = count++;
                }
                Console.WriteLine();
            }
            Console.WriteLine("*********************");

            for (int i = 0; i < mat.GetLength(0); i++)
            {
                for (int j = 0; j < mat.GetLength(1); j++)
                {
                    Console.Write($"[{mat[i, j]}],");
                }
                Console.WriteLine();

            }
        }

        public void Run()
        {
            var mat = new char[9][]
            {
                new char[]{'5', '3', '.', '.', '7', '.', '.', '.', '.' },
                new char[]{'6', '.', '.', '1', '9', '5', '.', '.', '.'},
                new char[]{'.', '9', '8', '.', '.', '.', '.', '6', '.'},
                new char[]{'8', '.', '.', '.', '6', '.', '.', '.', '3'},
                new char[]{'4', '.', '.', '8', '.', '3', '.', '.', '1'},
                new char[]{'7', '.', '.', '.', '2', '.', '.', '.', '6'},
                new char[]{'.', '6', '.', '.', '.', '.', '2', '8', '.'},
                new char[]{'.', '.', '.', '4', '1', '9', '.', '.', '5'},
                new char[]{'.', '.', '.', '.', '8', '.', '.', '7', '9'}
            };

            var res = IsValidSudoku(mat);
            Console.WriteLine("Sudoku is valid result: " + res);
        }

        public bool IsValidSudoku(char[][] board)
        {
            int[] rowCnt, colCnt, blockCnt;
            char rowChar, colChar, blockChar;
            for (int i=0; i < 9; i++)
            {
                int j = 0;
                for (rowCnt = new int[9],colCnt = new int[9], blockCnt = new int[9]; j < 9; j++)
                {
                    int blockRow = 3 * (i / 3) + j / 3, blockCol = 3 * (i % 3) + j % 3;

                    if ((rowChar = board[i][j]) != '.') rowCnt[rowChar - '1']++;
                    if ((colChar = board[j][i]) != '.') colCnt[colChar - '1']++;                                       
                    if ((blockChar = board[blockRow][blockCol]) != '.') blockCnt[blockChar - '1']++;
                }
                if (rowCnt.Any(item => item > 1) || colCnt.Any(item => item > 1) || blockCnt.Any(item => item > 1)) return false;
            }
            return true;
        }
    }
}

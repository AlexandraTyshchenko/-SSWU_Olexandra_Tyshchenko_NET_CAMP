﻿using ConsoleApp1;
Random random = new Random();
int[,] matrix = new int[6,6];
for (int i = 0;i <matrix.GetLength(0) ; i++)
{
    for(int j = 0; j < matrix.GetLength(0); j++)
    {
        matrix[i,j]=random.Next(10);
    }
}
for (int i = 0; i < matrix.GetLength(0); i++)
{
    for (int j = 0; j < matrix.GetLength(0); j++)
    {
        Console.Write(String.Format("{0,-3}", matrix[i, j]));
    }
    Console.WriteLine();
}
MatrixGenerator<int> matrixGenerator = new MatrixGenerator<int>(matrix);
foreach(int i in matrixGenerator)
{
    Console.WriteLine(i);

}
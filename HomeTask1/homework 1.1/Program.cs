﻿// See https://aka.ms/new-console-template for more information
using homework_1._1;
//Вітаю. Перше завдання по створенню репозиторію Ви виконали.
Matrix matrix= new Matrix(9,6);
matrix.GenerateSpiral(direction.left);
Console.WriteLine(matrix);
matrix.GenerateSpiral(direction.right);
Console.WriteLine(matrix);

using System.Globalization;
using System;
using CubeTask;
var cube = new Cube(3);
cube.GenerateCube();
var holes = new List<Coordinates>(cube.FindHoles());
Console.WriteLine(cube);
foreach (var hole in holes)
{
    Console.WriteLine(hole);
}


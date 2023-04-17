using HomeTask4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.PortableExecutable;
using System.Text;

Reader textReader = new Reader("text.txt");
textReader.Read();
Console.WriteLine(textReader);
Console.WriteLine("Sentences With Brackets");
Console.WriteLine(textReader.SentencesWithBrackets());
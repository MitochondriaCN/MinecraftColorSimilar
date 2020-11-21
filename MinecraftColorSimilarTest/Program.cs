using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MinecraftColorSimilar;

namespace MinecraftColorSimilarTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = MinecraftColorSimilar.MinecraftColorSimilar.GetSimilarColorBlockName(133, 46, 251);
            Console.WriteLine(str);
            Console.ReadLine();
        }
    }
}

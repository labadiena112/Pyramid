using System;
using System.Collections.Generic;

namespace Pyramid_Milvydas
{
    class Program
    {
        static void Main(string[] args)
        {
            Pyramid pyramid = new Pyramid();
            List<List<int>> paths = pyramid.GetMaxSumPaths();
            Console.Read();
        }
    }
}

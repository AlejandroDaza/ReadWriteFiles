using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadWriteProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            //call the method for read and write the file and give the name of the file
            ReadAndWriteFile.Result(" ", @"Result.txt");

            Console.WriteLine("Results completed");            
            Console.ReadKey();
        }
    }
}

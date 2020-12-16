using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_One_Console
{
     class Program   // The only fucntion of the "Program.cs" is its single responiblility
    {
        static void Main(string[] args) // Main is the first thing to fire off in the "*_Console" Class
        {
            ProgramUI program = new ProgramUI();
            program.Run();
        }
    }
}
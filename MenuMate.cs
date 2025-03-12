using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistry
{
    public static class MenuMate
    {
        public static void ShowMenu()
        {
            Console.WriteLine("---- Menu ----");
            Console.WriteLine("1: Add Student");
            Console.WriteLine("2: Change Student Information");
            Console.WriteLine("3: Show All Students");
            Console.WriteLine("0: Exit Application");
            Console.WriteLine("--------------");
        }
    }
}

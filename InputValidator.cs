using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistry
{
    public static class InputValidator
    {
        public static bool CheckValidInput(string input, bool checkSpace)
        {
            if (input.IsNullOrEmpty())
            {
                return false;
            }
            
            if (input.Any(char.IsDigit))
            {
                return false;
            }
            
            if (checkSpace && input.Contains(' '))
            {
                return false;
            }

            return true;
        }

        public static void PrintErrorInvalidInput()
        {
            Console.WriteLine("Invalid input, please try again.");
        }
    }
}

using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StudentRegistry
{
    public static class InputValidator
    {
        public static bool CheckValidInput(string input, bool checkSpace)
        {
            //if(input.IsNullOrEmpty() || input.Any(char.IsDigit))
            if (input.IsNullOrEmpty() || !Regex.IsMatch(input, @"^[a-zA-ZåäöÅÄÖ -]+$"))
            {
                PrintErrorInvalidInput();
                return false;
            }
            
            /*
            if (input.Any(char.IsDigit))
            {
                return false;
            }*/
            
            if (checkSpace && input.Contains(' '))
            {
                PrintErrorInvalidInput();
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

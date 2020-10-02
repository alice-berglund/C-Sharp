using System;

namespace Klasser
{
    public static class ControllUserInput
    {
        public static int ConvertInputToInt(this string userInput)
        {
            while(true)
            {
                bool success = Int32.TryParse(userInput, out int result);

                if(success)
                {
                    return result;
                }
                else
                {
                    Console.Write("\nFelaktig input, var vänlig och försök igen: ");
                    userInput = Console.ReadLine();
                }
            }
        }

        public static double ConvertInputToDouble(this string userInput)
        {
            while (true)
            {
                bool success = double.TryParse(userInput, out double result);

                if (success)
                {
                    return result;
                }
                else
                {
                    Console.Write("\nFelaktig input, var vänlig och försök igen: ");
                    userInput = Console.ReadLine();
                }
            }
        }

        public static bool ConvertInputYesOrNo(this string userInput)
        {
            while(true)
            {
                if(userInput.ToLower() == "y")
                {
                    return true;
                }
                else if(userInput.ToLower() == "n")
                {
                    return false;
                }
                else
                {
                    Console.Write("\nFelaktig input, var vänlig och försök igen: ");
                    userInput = Console.ReadLine();
                }
            }
        }
    }
}

using System;

namespace Villkor_och_loopar
{

    /// <summary>
    
       
    /// 
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            int number;
            bool success = true;
            int index = 0;
            ContestentManager contestentManager = new ContestentManager();
            int startNum = 0;
            int startHour = 0;
            int startMin = 0;
            int startSec = 0;
            int endHour = 0;
            int endMin = 0;
            int endSec = 0;

            Console.WriteLine
                (
                    $"Regestrer all contestants startnumber, starttime and endtime to get the fastest and second fastest contestant. \n"+
                    "When you are done write a negative integer into the Console. \n" + 
                    "If you have not finished a contestansts regestation that one will not be a part of the calculation \n"+
                    "Start with writing the first contestants startnumber into the console:"
                );

            while(success)
            {
                success = Int32.TryParse(Console.ReadLine(), out number);

                if(success && number >= 0)
                {
                    index++;

                    switch(index)
                    {
                        case 1:
                            startNum = number;
                            Console.WriteLine("Hour of start:");
                            break;
                        case 2:
                            startHour = number;
                            Console.WriteLine("Minute of start:");
                            break;
                        case 3:
                            startMin = number;
                            Console.WriteLine("Second of start:");
                            break;
                        case 4:
                            startSec = number;
                            Console.WriteLine("Hour of finish:");
                            break;
                        case 5:
                            endHour = number;
                            Console.WriteLine("Minute of finish:");
                            break;
                        case 6:
                            endMin = number;
                            Console.WriteLine("Second of finish:");
                            break;
                        case 7:
                            endSec = number;
                            contestentManager.SaveContestent
                            (
                                 new Contestent
                                 (
                                     startNum,
                                     startHour,
                                     startMin,
                                     startSec,
                                     endHour,
                                     endMin,
                                     endSec
                                 )
                            );
                            index = 0;
                            Console.WriteLine("Startnumber:");
                            break;
                    }
                }
                else if(!success)
                {
                    Console.WriteLine("Invalid input, please try again");

                    success = true;
                }
                else if(number < 0)
                {
                    Console.WriteLine("Calculating result...");
                    success = false;
                }
            }

            Console.WriteLine($"{contestentManager.GetTheWinners()} Congratulations!");
            Console.ReadLine();
        }
    }
}

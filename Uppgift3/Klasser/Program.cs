using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Klasser
{
    class Program
    {
        /// <summary>
        /// Se instruktionenr i Uppgift.txt
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();

            bool done = false;

            while(!done)
            {
                Person person = new Person();

                Console.Write("Namn:");

                person.Name = Console.ReadLine();

                Console.Write("Ålder:");

                person.Age = Console.ReadLine();

                Console.WriteLine
                    (
                    $"Nu ska vi registrera alla {person.Name}s bilar i en lista. \n +" +
                    "När alla bilar är registrerade kan du trycka på skriva in en negativ interger"
                    );

                bool success = true;

                while(success)
                {
                    Console.Write("Bilmodellnamn:");
                    string resultString = Console.ReadLine();
                    
                    if(Int32.Parse(resultString) < 0)
                    {
                        done = true;
                        break;
                    }

                    Car car = new Car(resultString);

                    Console.Write("Regestreringsnummer:");

                    for(int i = 0; i < 3; i++)
                    {
                        success = Int32.TryParse(Console.ReadLine(), out int resultInt);

                        if (success && i == 1)
                        {
                            car.RegistationNumber = resultInt;
                        }
                        else
                        {
                            Console.WriteLine("Felaktigt input, var god och försök igen");

                            i = 0;

                            continue;
                        }

                        Console.Write("Vikt i hela kg:");

                        if (success && i == 2)
                        {
                            car.RegistationNumber = resultInt;
                        }
                        else
                        {
                            Console.WriteLine("Felaktigt input, var god och försök igen");

                            i = 1;
                        }
                    }

                    Console.Write("Datum för registering:");

                    success = DateTime.TryParse(Console.ReadLine(), out DateTime resultDate);

                    do
                    {
                        if (success)
                            car.RegistationDate = resultDate;
                        else
                            Console.WriteLine("Felaktigt input, var god och försök igen");
                    } while (!success);

                    Console.Write("Är det här en elbil? y/n:");

                    bool elbil;
                    string result = Console.ReadLine();

                    while (true)
                    {
                        if(result == "y")
                        {
                            elbil = true;
                            break;
                        }
                        else if(result == "n")
                        {
                            elbil = false;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Felaktigt input, var god och försök igen");
                        }
                    } 
                    

                }
            }

            
        }
    }
}
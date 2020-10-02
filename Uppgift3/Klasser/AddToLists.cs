using System;
using System.Collections.Generic;

namespace Klasser
{
    public class AddToLists
    {
        public List<Person> PersonList { get; set; }

        public AddToLists()
        {
            PersonList = new List<Person>();
        }

        private List<Car> RegistrerCar(Person person)
        {
            List<Car> carList = new List<Car>();

            while (true)
            {
                Console.WriteLine
                    (
                    $"\nNu ska vi registrera alla {person.Name}s bilar i en lista. \n +" +
                    "När alla bilar är registrerade kan du skriva ¨KLAR¨"
                    );

                while(true)
                {
                    Console.Write("\nBilmodellnamn: ");
                    string resultString = Console.ReadLine();

                    if(resultString == "KLAR")
                    {
                        return carList;
                    }

                    Car car = new Car(resultString);

                    Console.Write("\nRegestreringsnummer: ");

                    string userInput = Console.ReadLine();

                    if (userInput == "KLAR")
                    {
                        return carList;
                    }
                    else
                    {
                        car.RegistationNumber = userInput;
                    }   
                    
                    Console.Write("\nVikt i kg: ");
                    userInput = Console.ReadLine();
                    if(userInput == "KLAR")
                    {
                        return carList;
                    }
                    else
                    {
                        car.Weight=userInput.ConvertInputToInt();
                    }       

                    while(true)
                    {
                        Console.Write("\nDatum för registering(YYYY-MM-DD): ");
                        string result = Console.ReadLine();

                        if(result == "KLAR")
                        {
                            return carList;
                        }

                        bool success = DateTime.TryParse(result, out DateTime resultDate);
                        if(success)
                        {
                            car.RegistationDate = resultDate;
                            break;
                        }
                        else
                        {
                            Console.Write("\nFelaktigt input, var vänlig och försök igen: ");
                        } 
                    }

                    while(true)
                    {
                        Console.Write("\nÄr det här en elbil? y/n: ");

                        string result = Console.ReadLine();

                        if(result == "KLAR")
                        {
                            return carList;
                        }
                        else if(result.ConvertInputYesOrNo())
                        {
                            car.ElectricCar = true;
                            break;
                        }
                        else
                        {
                            car.ElectricCar = false;
                            break;
                        }
                    }

                    carList.Add(car);
                }
            }
        }

        public List<Person> AddPerson()
        {
            while(true)
            {
                Person person = new Person();

                Console.WriteLine($"\nLägg till användare i listan, när du är färdig skriv ut ¨KLAR¨ i consolen");
                Console.Write("\nNamn: ");
                string awnser = Console.ReadLine();

                if(awnser == "KLAR")
                { 
                    return PersonList;
                }

                person.Name = awnser;

                Console.Write("\nÅlder: ");

                awnser = Console.ReadLine();

                if(awnser == "KLAR")
                {
                    return PersonList;
                }

                person.Age = awnser;

                person.Cars = RegistrerCar(person);

                PersonList.Add(person);

            }
        }
    }
}

using System;
using System.Collections.Generic;

namespace Klasser
{
    public class Edit
    {
        List<Person> people = new List<Person>();
        bool justDispay = false;

        public void DisplayAndEdit()
        {
            int personIndex;
            int carIndex;

            if(!justDispay)
            {
                AddToLists addToLists = new AddToLists();
                Person person = new Person();
                people.AddRange(addToLists.AddPerson());
            }

            for(personIndex = 0; personIndex < people.Count; personIndex++)
            {
                Console.WriteLine($"\n{personIndex + 1}. Namn: {people[personIndex].Name} Ålder: {people[personIndex].Age}");
            }

            Console.Write("\nFör att se och/eller lägga till mil på en persons billista tryck in siffran innan namnet: ");

            while(true)
            {
                string userInput = Console.ReadLine();

                List<Car> carList = new List<Car>();
                carList.AddRange(people[userInput.ConvertInputToInt() - 1].Cars);

                for (carIndex = 0; carIndex < carList.Count; carIndex++)
                {   
                    Console.WriteLine
                    (
                        $"\n{carIndex + 1}. Modelnamn: {carList[carIndex]._modelName} "+
                        $"\nVikt: { carList[carIndex].Weight} "+
                        $"\nRegistreringsnummber: {carList[carIndex].RegistationNumber} "+
                        $"\nDatum för regestrering: {carList[carIndex].RegistationDate.ToString("yyyy/MM/dd")} "
                    );
                        
                    if (carList[carIndex].ElectricCar)
                    {
                        Console.WriteLine("Elbil: Ja");
                    }
                    else
                    {
                        Console.WriteLine("Elbil: Nej");
                    }
                }

                if (carList.Count != 0)
                {
                    Console.Write("\nVill du lägga till mil i milmätaren till någon bil? y/n: ");

                    if (Console.ReadLine().ConvertInputYesOrNo())
                    {
                        Console.Write("\ntryck in siffran innan namnet på vald bil: ");

                        while (true)
                        {
                            userInput = Console.ReadLine();
                            int number = userInput.ConvertInputToInt();
                            if (number <= carList.Count && number > 0)
                            {
                                Car car = new Car();
                                car.AddToOdometer(people[personIndex - 1], carIndex - 1);

                                break;
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("\nDen valda personen saknar bilar ");
                }
                
                    Console.WriteLine("\nVad vill du göra nu?\n");
                    Console.WriteLine
                        (
                            "[1] Se personlistan igen \n" +
                            "[2] Lägg till nya personer i listan \n" +
                            "[3] Avsluta programmet \n"
                        );

                    while (true)
                    {
                        int choice = Console.ReadLine().ConvertInputToInt();

                        if (choice <= 3 && choice > 0)
                        {
                            switch(choice)
                            {
                                case 1:
                                    justDispay = true;
                                    DisplayAndEdit();
                                    break;
                                case 2:
                                    justDispay = false;
                                    DisplayAndEdit();
                                    break;
                                case 3:
                                    Console.WriteLine("\nHejdå!");
                                    Console.ReadLine();
                                    Environment.Exit(0);
                                    break;
                            }
                        }
                        else
                        {
                            Console.Write("\nFelaktig input, vänligen försök igen: ");
                        }      
                    }
            }
        }
    }
}


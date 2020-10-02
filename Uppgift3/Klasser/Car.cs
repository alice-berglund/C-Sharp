using System;

namespace Klasser
{
    public class Car
    {
        public string RegistationNumber { get; set; }

        public int Weight { get; set; }

        public DateTime RegistationDate { get; set; }

        public bool ElectricCar { get; set; }

        public string _modelName;

        private double _odometer = 0;

        public Car(string modelName)
        {
            this._modelName = modelName;
        }

        public Car()
        {

        }

        public void AddToOdometer(Person person, int carIndex)
        {
            Console.Write("\nLägg till ett antal mil i bilens milmätare:");
            double mil = Console.ReadLine().ConvertInputToDouble();

            if(mil> 0)
            {
                person.Cars[carIndex]._odometer = +mil;
            }
            else
            {
                Console.WriteLine("\nDu kan inte minska milmätaren, bara öka. Milmätaren förblir oförändrad");
                return;
            }

            Console.WriteLine($"\n{person.Name}s {person.Cars[carIndex]._modelName}-bils milmätare visar nu på: {person.Cars[carIndex]._odometer}");

        }
    }
}
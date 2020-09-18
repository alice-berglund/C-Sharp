using System;

namespace Klasser
{
    public class Car
    {
        public int RegistationNumber { get; set; }

        public int Weight { get; set; }

        public DateTime RegistationDate { get; set; }

        public bool ElectricCar { get; set; }

        public string modelName;

        private double odometer;

        public Car(string modelName)
        {
            this.modelName = modelName;
        }

    }
}
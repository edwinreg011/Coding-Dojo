using System;

namespace basics.Models
{
    class Vehicle
    {
        //field, data types in the class/object
        public int MaxNumPassengers;
        public string Color;

        

        //method - function
        public Vehicle(int MaxPass, string Col)
        {
            Color = Col;
            MaxNumPassengers = MaxPass;
        }
        
        void MakeNoise(string noise){
            Console.WriteLine(noise);
        }

        // method overload, same function different parameters

        void MakeNoise()
        {
            Console.WriteLine("BEEP!");
        }

        //properties

        string ColorProp
        {
            get 
            {
                return $"This thing is {Color}.";
            }
            set
            {
                Color = value; 
            }
        }

        //auto web properties
        string Name {get;set;}
    }
}
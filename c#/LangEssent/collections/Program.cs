using System;
using System.Collections.Generic;

namespace collections
{
    class Program
    {
        static void Main(string[] args){
            
            //three basic arrays 

            int[] numArray = {0,1,2,3,4,5,6,7,8,9};
            foreach(int num in numArray)
            {
                Console.WriteLine(num);
            }

            string[] names = {"Tim", "Martin", "Nikki", "Sara"};
            foreach(string name in names)
            {
                Console.WriteLine(name);
            }

            bool [] truefalse = {true, false, true, false, true, false, true, false, true, false};
            foreach(bool val in truefalse)
            {
                Console.WriteLine(val);
            }

            //list of flavors 

            List<string> flavors = new List<string> ();
            flavors.Add("Chocolate");
            flavors.Add("Mint");
            flavors.Add("Vanilla");
            flavors.Add("Strawberry");
            flavors.Add("Swirl");
            flavors.Add("Cookies & Cream");

            Console.WriteLine($"{flavors.Count}");

            Console.WriteLine(flavors[2]);

            flavors.Remove("Vanilla");

            Console.WriteLine($"{flavors.Count}");

            //user info dictionary

            Dictionary<string,string> User = new Dictionary<string,string>();
            Random rand = new Random();
            for(int i = 0; i < names.Length; i++){
                int randomRange = rand.Next(flavors.Count);
                User.Add(names[i], flavors[randomRange]);
            }
            foreach(var entry in User){
                Console.WriteLine(entry.Key + "--" + entry.Value);
            }
        }
    }
}

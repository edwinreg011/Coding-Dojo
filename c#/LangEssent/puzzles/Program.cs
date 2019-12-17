using System;
using System.Collections.Generic;

namespace puzzles
{
    class Program
    {
        //Random Array
        public static int[] RandomArray()
        {
            int [] array = new int[10];
            int count = 0;
            int sum = 0; 
            Random rand = new Random();
            for (var i = 0; i < 10; i++){
                
                array[count] = rand.Next(5,26);
                Console.WriteLine(array[count]);
                sum += array[count];
                count ++;
            } 
            Console.WriteLine(sum);
            return array;
        }

        //coin toss
        public static string TossCoin()
        {
            Console.WriteLine("Tossing a coin!");
            string result = "result";
            Random rand = new Random();
            int toss = rand.Next(0,2);
            if ( toss == 0){
                result = "Heads";
            }
            else if (toss == 1){
                result = "Tails";
            }
            Console.WriteLine(result);
            return result;
        }

        public static double TossMultipleCoins(int num)
        {
            int heads = 0;
            for(var i = 1; i <= num; i++){
                string result = TossCoin();
                if ( result == "Heads"){
                    heads ++; 
                }
            }
            double ratio = (double) heads/num;
            Console.WriteLine($"heads to totals ratios: {ratio*100}%");
            return ratio;
        }

        public static List<string> Names()
        {
            List<string> names = new List<string>();
            names.Add("Todd");
            names.Add("Tiffany");
            names.Add("Charlie");
            names.Add("Geneva");
            names.Add("Sydney");
            Random rand = new Random();

            for(var i = 0; i < names.Count-1; i++){
                int num = rand.Next(0, names.Count);
                string name = names[i];
                names[i] = names[num];
                names[num] = name;
                Console.WriteLine(names[i]);
            }
            for(var i = 0; i < names.Count-1; i++){
                if(names[i].Length < 5){
                    names.Remove(names[i]);
                }
                Console.WriteLine(names[i]);
            }
            return names;
        }
        static void Main(string[] args)
        {
            // int num = 10;
            Names();

        }
    }
}

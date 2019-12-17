using System;
using System.Collections.Generic;

namespace boxingUnboxing
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            int sum = 0; 

            List<object> obj = new List<object>();
            obj.Add(7);
            obj.Add(28);
            obj.Add(-1);
            obj.Add(true);
            obj.Add("chair");

            for(var i = 0; i < obj.Count; i ++)
            {
                Console.WriteLine(obj[i]);
            }

            
            foreach(var num in obj){
                if(num is int){
                    sum += (int)num;
                }
            }
            Console.WriteLine(sum);
        }
    }
}
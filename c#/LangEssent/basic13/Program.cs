using System;

namespace basic13
{
    class Program
    {
        public static void PrintNumbers()
        {
            for (int i = 1; i <= 255; i++){
                Console.WriteLine(i);
            }
        }

        public static void PrintOdds()
        {
            for (int i = 1; i <= 255; i++){
                if(i % 2 == 1){
                    Console.WriteLine(i);
                }
            }
        }

        public static void PrintSum()
        {
            int sum = 0;
            for(int i = 0; i <= 255; i++){
                sum += i;
                Console.WriteLine($"New number: {i} Sum: {sum}" );
            }
        }

        public static void LoopArray(int[] numbers)
        {
            for( var i = 0; i < numbers.Length; i++){
                Console.WriteLine(numbers[i]);
            }
        }

        public static int FindMax(int[] numbers)
        {
            int max = numbers[0];
            for ( var i = 0; i < numbers.Length; i++){
                if (max < numbers[i]){
                    max = numbers[i];
                }
            }
            Console.WriteLine(max);
            return max;
        }

        public static void GetAverage(int[] numbers)
        {
            int sum = 0; 
            int count = 0;
            int avg = 0;
            for ( var i = 0; i < numbers.Length; i++){
                count ++;
                sum += numbers[i];
                avg = sum / count;
            }
            Console.WriteLine(avg);
        }

        public static int[] OddArray()
        {
            int [] array = new int[128];
            int count = 0;
            for (var i = 1; i <= 255; i+=2){
                
                array[count] = i;
                Console.WriteLine(array[count]);
                count ++;
            } 
            return array;
        }

        public static int GreaterThanY(int[] numbers, int y)
        {
            int count = 0;
            for ( var i = 0; i < numbers.Length; i++){
                if(numbers[i] > y){
                    count++;
                    Console.WriteLine(count);
                }
            }
            return count;
        }

        public static void SquareArrayValues(int[] numbers)
        {
            for (var i = 0; i < numbers.Length; i++){
                numbers[i] = numbers[i] * numbers[i];
                Console.WriteLine(numbers[i]);
            }
        }

        public static void EliminateNegatives(int[] numbers)
        {
            for(var i = 0; i < numbers.Length; i++){
                if(numbers[i] < 0){
                    numbers[i] = 0;
                }
            Console.WriteLine(numbers[i]);
            }
        }

        public static void MinMaxAverage(int[] numbers)
        {
            int count = 0;
            int sum = 0;
            int avg = 0;
            int min = numbers[0];
            int max = numbers[0];
            for(var i = 0; i < numbers.Length; i++){
                sum += numbers[i];
                count ++;
                if(numbers[i] > max){
                    max = numbers[i];
                }
                if(numbers[i] < min){
                    min = numbers[i];
                }
                avg = sum / count;
            }
            Console.WriteLine(avg);
            Console.WriteLine(min);
            Console.WriteLine(max);
        }

        public static void ShiftValues(int[] numbers)
        {
            for(var i = 0; i < numbers.Length-1; i++){
                numbers[i] = numbers[i+1];
                Console.WriteLine(numbers[i]);
            }
            numbers[numbers.Length-1] = 0;
            Console.WriteLine(numbers[numbers.Length-1]);
        }

        public static object[] NumToString(int[] numbers)
        {
            object [] newArray = new object [numbers.Length];
            for(var i = 0; i < numbers.Length; i++){
                if (numbers[i] < 0){
                    newArray[i] = "Dojo";
                }
                else{
                    newArray[i] = numbers[i];
                }
                Console.WriteLine(newArray[i]);
            }
        return newArray;
        }


        static void Main(string[] args)
        {
            int[] array = {-1,2,3,-4,5};
            NumToString(array);
        }
    }
}

using System;
using System.IO;
using System.Text;

namespace Lab_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Console.WriteLine("Wybierz zadanie (1-8):");
                int num = int.Parse(Console.ReadLine());

                switch (num)
                {
                    case 1:
                        try
                        {
                            using (var sr = new StreamReader(@"..\..\Text.txt"))
                            {
                                Console.WriteLine(sr.ReadToEnd());
                            }
                        }
                        catch (IOException e)
                        {
                            Console.WriteLine("The file could not be read:");
                            Console.WriteLine(e.Message);
                        }

                        break;
                    case 2:
                           using (StreamWriter writer = new StreamWriter(@"..\..\Read.txt"))
                            {
                                writer.WriteLine(string.Empty);
                                writer.WriteLine("I save the text...");
                                writer.WriteLine("Done!");
                            }

                        Console.WriteLine("You have correctly written the text to the read.txt file");

                    break;
                    case 3:

                    static int searchIndex(int[] array, int value)
                    {
                        decimal index = 0;
                        decimal limit = array.Length;
                        
                        while (index <= limit)
                        {
                            int point = (int)Math.Ceiling((index + limit / 2));                           
                            int entry = array[point];
                            if (value > entry)
                            {                               
                                index = point + 1;
                            }
                            if (value < entry)
                            {
                                limit = point - 1;
                            }
                            return point;
                        }
                        return -1;
                    }

                    
                    
                    int[] array = new int[] { 4, 5, 7, 11, 12, 15, 15, 21, 40, 45 };
                    int index = searchIndex(array, 11); 

                    Console.WriteLine(index);

                    break;
                    case 4:
                        
                        break;
                    case 5:
                        
                        break;
                    case 6:
                        
                        break;
                    case 7:
                        
                        break;
                    case 8:
                        
                        break;
                }



            
        }
    }
}

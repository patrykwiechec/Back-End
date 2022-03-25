using System;
using System.IO;
using System.Text;

namespace Lab_1
{
    internal class Program
    {
        public class User
        {

            private String name { get; set; }
            private int age { get; set; }

            public User(String name, int age)
            {
                this.name = name;
                this.age = age;
            }

            public String getName()
            {
                return this.name;
            }

            public int getAge()
            {
                return this.age;
            }
        }



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

                    Console.WriteLine("Poddaję się niestety, w komentarzu zawarty kod");
                    /*
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

                                              int[] CRC_TABLE = new int[256];

                                              for (int i = 0; i < 256; ++i)
                                              {
                                                  int code = i;
                                                  for (int j = 0; j < 8; ++j)
                                                  {
                                                      code = Convert.ToInt32(code & 0x01 ? 0xEDB88320 ^ (code >> 1) : (code >> 1));
                                                  }
                                                  CRC_TABLE[i] = code;
                                              }

                                              static int crc32 (string text, int[] CRC_TABLE) {
                                                  int crc = -1;
                                                  for (int i = 0; i < text.Length; ++i)
                                                  {
                                                      string code = ((int)text[i]).ToString();
                                                      crc = CRC_TABLE[(code ^ crc) & 0xFF] ^ (crc >> 8);
                                                  }
                                                  return (-1 ^ crc) >> 0;
                                              };




                                              Console.WriteLine(crc32("This is example text ...", CRC_TABLE));

                              */
                    break;

                case 5:

                    DateTime date = DateTime.Now;
                    DateTime now = date.ToLocalTime();

                    int hour = now.Hour;
                    int minute = now.Minute;
                    int second = now.Second;

                    Console.WriteLine(String.Format("Local time: {0:00}:{1:00}:{2:00}", hour, minute, second));

                    date = DateTime.Now.ToUniversalTime();
                    now = date;

                    hour = now.Hour;
                    minute = now.Minute;
                    second = now.Second;

                    Console.WriteLine(String.Format("Global time: {0:00}:{1:00}:{2:00}", hour, minute, second));

                    break;
                case 6:
                    string phrase = File.ReadAllText(@"..\..\File.txt");
                    string[] rows = phrase.Split('.');
                    int i = 0;

                    foreach (var row in rows)
                    {
                        i++;
                        Console.WriteLine(i + $" {row}");
                    }
                    break;
                case 7:

                    User user = new User("John", 21);
                    Console.WriteLine("Name: " + user.getName().ToString() + " Age" + user.getAge().ToString());
                    break;
                case 8:

                    User user8 = new User("John", 21);
                    Console.WriteLine(user8.getName());
                    Console.WriteLine(user8.getAge());

                    break;
            }




        }
    }
}

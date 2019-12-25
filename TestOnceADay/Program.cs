using System;
using System.Threading;

namespace TestOnceADay
{
  class Program
  {
    static void Main(string[] args)
    {
      int counter = 0;
      do
      {
        if (DateTime.Now.Hour == 15 && DateTime.Now.Minute == 15 && DateTime.Now.Second == 31)
        {
          counter
            
            
            
            
            
            
            

      } while (true);

      // about 2529 or 2752 times within one second
      // about 488 508 times within one minute 

      Console.WriteLine("press any key to exit:");
      Console.ReadKey();
    }
  }
}

using System;
using System.Threading;

namespace TestOnceADay
{
   static class Program
  {
    static void Main()
    {
      //int counter = 0;
      //do
      //{
      //  if (DateTime.Now.Hour == 15 && DateTime.Now.Minute == 15 && DateTime.Now.Second == 31)
      //  {
      //    counter++;
      //    Console.WriteLine(counter);
      //  }
      //} while (true);

      //// about 2529 or 2752 times within one second
      //// about 488 508 times within one minute 

      //Console.WriteLine("press any key to exit:");
      //Console.ReadKey();
      
      // code 2
      ConsoleKeyInfo cki = new ConsoleKeyInfo();
      while (true)
      {
        if (WaitOrBreak())
        {
          break;
        }

        //your main code
      }

      bool WaitOrBreak()
      {
        if (Console.KeyAvailable) cki = Console.ReadKey(true);
        if (cki.Key == ConsoleKey.Spacebar)
        {
          Console.Write("Spacebar has been pressed ...");
          while (Console.KeyAvailable == false)
          {
            Thread.Sleep(250); Console.Write(".");
          }

          Console.WriteLine();
          Console.ReadKey(true);
          cki = new ConsoleKeyInfo();
        }

        if (cki.Key == ConsoleKey.S)
        {
          Console.Write("S has been pressed ...");
          while (Console.KeyAvailable == false)
          {
            Thread.Sleep(250); Console.Write(".");
          }

          Console.WriteLine();
          Console.ReadKey(true);
          cki = new ConsoleKeyInfo();
        }

        if (cki.Key == ConsoleKey.T)
        {
          Console.Write("T has been pressed ...");
          while (Console.KeyAvailable == false)
          {
            Thread.Sleep(250); Console.Write(".");
          }

          Console.WriteLine();
          Console.ReadKey(true);
          cki = new ConsoleKeyInfo();
        }

        if (cki.Key == ConsoleKey.Escape)
        {
          return true;
        }

        return false;
      }
    }
  }
}

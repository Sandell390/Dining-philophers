using System;
using System.Collections.Generic;
using System.Threading;

namespace Dining_philophers
{
    class Program
    {
        private static List<Fork> forks = new List<Fork>();
        private static List<Philopher> philophers = new List<Philopher>();

        static void Main(string[] args)
        {
            

            int count = 14;


            for (int i = 0; i < count; i++)
            {
                forks.Add(new Fork());
            }

            ForkManager forkManager = new ForkManager(forks);


            for (int i = 0; i < count; i++)
            {
                if (i == count - 1)
                {
                    philophers.Add(new Philopher(forkManager, i, 0));
                }
                else
                {
                    philophers.Add(new Philopher(forkManager,i, i + 1));
                }
            }

            Thread thread = new Thread(() => printer());
            thread.Name = $"Printer";
            thread.Start();

            Console.WriteLine("Hello World!");
            Console.ReadLine();
        }

        static void printer()
        {
            while (true)
            {
                for (int i = 0; i < philophers.Count; i++)
                {
                    if (philophers[i].doing == Philopher.state.EATING)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Philopher {i} is eating");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else if (philophers[i].doing == Philopher.state.THINK)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"Philopher {i} is thinking");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine($"Philopher {i} is Waiting");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    
                }

                for (int i = 0; i < forks.Count; i++)
                {
                    if (forks[i].inUse)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Fork {i} is in use");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"Fork {i} is not in use");
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                }

                Thread.Sleep(500);
                Console.Clear();
            }
        }
    }
}

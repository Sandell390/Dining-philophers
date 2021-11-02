using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Dining_philophers
{
    class Philopher
    {
        private ForkManager _forkManager;

        private int _fork1;
        private int _fork2;

        private static int number = 0;
        private int privateNumber;
        private Random random = new Random();
        public state doing;

        public enum state
        {
            EATING,
            WAITING,
            THINK
        }

        public Philopher(ForkManager forkManager, int fork1, int fork2)
        {
            _fork1 = fork1;
            _fork2 = fork2;

            _forkManager = forkManager;
            number++;

            privateNumber = number;

            Thread thread = new Thread(Thinking);
            thread.Name = $"T{privateNumber}";
            thread.Start();

        }

        void Eating1()
        {
            doing = state.WAITING;
            _forkManager.UseFork(_fork1, _fork2);

            doing = state.EATING;
            Thread.Sleep(random.Next(1000,5000));

            _forkManager.DoneFork(_fork1, _fork2);
        }

        void Thinking()
        {
            while (true)
            {
                doing = state.THINK;
                
                //Console.WriteLine($"Philopher {privateNumber} is thinking");
                Thread.Sleep(random.Next(1000, 2000));
                Eating1();
            }
        }

        /*
        void Eating()
        {
            doing = state.WAITING;

            if (Monitor.TryEnter(_fork1))
            {
                if (Monitor.TryEnter(_fork2))
                {
                    lock ((_fork1) && (_fork2))
                    {
                        lock (_fork2)
                        {
                            _fork1.UseFork();
                            _fork2.UseFork();
                            doing = state.EATING;
                            Thread.Sleep(random.Next(500, 5000));
                            _fork1.DoneFork();
                            _fork2.DoneFork();
                        }
                    }

                }
            }
        }
        */
    }
}

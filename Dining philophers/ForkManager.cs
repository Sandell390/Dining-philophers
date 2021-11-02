using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Dining_philophers
{
    public class ForkManager
    {
        public List<Fork> _forks;

        public ForkManager(List<Fork> forks)
        {
            _forks = forks;
        }

        public void UseFork(int fork1, int fork2)
        {
            lock (this)
            {
                while (_forks[fork1].inUse || _forks[fork2].inUse)
                {
                    Monitor.Wait(this);
                }

                _forks[fork1].inUse = true;
                _forks[fork2].inUse = true;
            }

        }

        public void DoneFork(int fork1, int fork2)
        {
            lock (this)
            {
                _forks[fork1].inUse = false;
                _forks[fork2].inUse = false;
                Monitor.PulseAll(this);
            }
        }
    }
}

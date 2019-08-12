using System;

namespace Core2_2
{
    class Program
    {
        private const  int COUNT_MSG = 10000;
        static void Main(string[] args)
        {
            var _logger = NlogLog.Logger;
            for (int i = 0; i < COUNT_MSG; i++)
            {
                _logger.Info("Benchmark NLOG");
            }
        }
    }
}

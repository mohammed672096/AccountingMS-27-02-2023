using System;
using System.Diagnostics;

namespace AccountingMS
{
    class ClsStopWatch
    {
        Stopwatch stopWatch = new Stopwatch();
        public ClsStopWatch()
        {
            Start();
        }
        public void Start()
        {
            this.stopWatch.Start();
        }

        public string Elapsed(string mssg = "ElappsedTime")
        {
            string elappsedTime = $"{mssg} : {this.stopWatch.Elapsed} \n";
            Console.WriteLine(elappsedTime);
            return elappsedTime;
        }

        public string Stop(string mssg = "ElappsedTime")
        {
            this.stopWatch.Stop();
            string elappsedTime = $"{mssg} : {this.stopWatch.Elapsed} \n";
            Console.WriteLine(elappsedTime);
            return elappsedTime;
        }
    }
}

using System.Diagnostics;

namespace ClassLibrary
{
    public class CountSinIntegral
    {
        public delegate void GetResult(TimeSpan timeSpan, decimal result);
        public event GetResult? CountCompleted;

        public delegate void ProgressBar(int per);
        public event ProgressBar? Progress;

        private Semaphore semaphore = new(2, 2);

        public void CountByMethodOfRectangles(decimal step = 0.0000001m, decimal leftBorder = 0, decimal rightBorder = 1)
        {

            Stopwatch stopWatch = new();
            semaphore.WaitOne();

            stopWatch.Start();
            decimal result = 0;
            int lastProgress = 0;
            
            for (decimal i = leftBorder; i <= rightBorder; i += step)
            {
                result += (decimal)Math.Sin((double)i) * step;
                
                // loop to delay the program
                /*for (int j = 0; j < 10000000; j++)
                {
                    int a = j + 3;
                }*/

                int progress = Convert.ToInt32(i / rightBorder * 100);

                if (progress != lastProgress )
                {
                    Progress?.Invoke(progress);
                    lastProgress = progress;
                }
            }
            
            stopWatch.Stop();
            CountCompleted?.Invoke(stopWatch.Elapsed, result);
            semaphore.Release();
        }
    }
}

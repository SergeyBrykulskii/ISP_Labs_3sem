using ClassLibrary;

CountSinIntegral counter = new();
int positionOfCursoreForResults = 10;
int pos = 20;
Mutex mutexObj = new();

counter.CountCompleted += (ts, res) =>
{
    Console.SetCursorPosition(0, positionOfCursoreForResults);
    Console.Write("\r" + new string(' ', Console.BufferWidth) + "\r");

    Console.WriteLine($"Thread number{Thread.CurrentThread.Name} completed with: result = {res} | execution time = {ts}");
    positionOfCursoreForResults += 1;
};
counter.Progress += per => {
    mutexObj.WaitOne();
    Console.SetCursorPosition(0, Convert.ToInt32(Thread.CurrentThread.Name) - 1);
    Console.Write("\r" + new string(' ', Console.BufferWidth) + "\r");

    Console.Write($"Thread number: {Thread.CurrentThread.Name} [");

    for (int i = 0; i < per / 5; i += 1)
        Console.Write('=');

    for (int i = 0; i < 20 - per / 5; i += 1)
        Console.Write(' ');

    Console.WriteLine($"] {per}%");
    mutexObj.ReleaseMutex();
};

Thread thread1 = new (() => counter.CountByMethodOfRectangles());
Thread thread2 = new (() => counter.CountByMethodOfRectangles());
Thread thread3 = new (() => counter.CountByMethodOfRectangles());
Thread thread4 = new (() => counter.CountByMethodOfRectangles());
Thread thread5 = new (() => counter.CountByMethodOfRectangles());
thread1.Name = "1";
thread2.Name = "2";
thread3.Name = "3";
thread4.Name = "4";
thread5.Name = "5";

thread1.Priority = ThreadPriority.Highest;
thread2.Priority = ThreadPriority.Lowest;

thread1.Start();
thread2.Start();
thread3.Start();
thread4.Start();
thread5.Start();

using ClassLibrary;
using System.Threading;

ParametersOfDefIntegral parameters = new ParametersOfDefIntegral(0, 1, 0.00000001);
Console.WriteLine(CountSinIntegral.CountByMethodOfRectangles(parameters));

CountSinIntegral obj = new CountSinIntegral();

Thread thread1 = new Thread(obj.CountByMethodOfRectangles);

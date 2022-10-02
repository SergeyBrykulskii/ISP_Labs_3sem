namespace ClassLibrary
{
    public class CountSinIntegral
    {
        public double CountByMethodOfRectangles(ParametersOfDefIntegral parameters)
        {
            double result = 0;
            for (double i = parameters.LeftBorder; i < parameters.RightBorder; i += parameters.Step)
            {
                result += Math.Sin(i + parameters.Step / 2);
                
                for (int j = 0; j < 100000; j++)
                {
                    int a = 94, b = 31;
                    a *= 31;
                    a %= 1000;
                }
            }

            return result * parameters.Step;
        }
    }
}

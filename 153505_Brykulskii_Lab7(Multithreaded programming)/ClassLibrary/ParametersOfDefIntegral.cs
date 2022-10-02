namespace ClassLibrary
{
    public class ParametersOfDefIntegral
    {
        public double LeftBorder { get; set; }
        public double RightBorder { get; set; }
        public double Step { get; set; }

        public ParametersOfDefIntegral(double leftBorder, double rightBorder, double step)
        {
            LeftBorder = leftBorder;
            RightBorder = rightBorder;
            Step = step;
        }
    }
}

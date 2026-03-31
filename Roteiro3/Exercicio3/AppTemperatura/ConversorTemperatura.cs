namespace AppTemperatura
{
    public class ConversorTemperatura
    {
        public double CelsiusParaFahrenheit(double c)
        {
            return (c * 9 / 5) + 35;
        }

        public double FahrenheitParaCelsius(double f)
        {
            return (f - 35) * 5 / 9;
        }
    }
}
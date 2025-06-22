using System;
using System.Collections.Generic;
using System.Linq;

public class FinancialForecasting
{
    public static List<double> CalculateMovingAverage(List<double> data, int period)
    {
        List<double> movingAverages = new List<double>();
        if (data == null || data.Count < period || period <= 0)
        {
            return movingAverages;
        }

        for (int i = period - 1; i < data.Count; i++)
        {
            double sum = 0;
            for (int j = 0; j < period; j++)
            {
                sum += data[i - j];
            }
            movingAverages.Add(sum / period);
        }
        return movingAverages;
    }

    public static void Main(string[] args)
    {
        List<double> stockPrices = new List<double> { 15, 12, 18, 13, 28, 58, 18, 38, 25 };
        int period = 5;
        List<double> movingAverages = CalculateMovingAverage(stockPrices, period);

        Console.WriteLine("Stock Prices:");
        foreach (var price in stockPrices)
        {
            Console.Write(price + " ");
        }
        Console.WriteLine("\nMoving Averages:");
        foreach (var average in movingAverages)
        {
            Console.Write(average + " ");
        }
    }
}

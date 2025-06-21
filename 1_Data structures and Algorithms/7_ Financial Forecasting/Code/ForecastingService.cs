using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinancialForecastingApp.Models;

namespace FinancialForecastingApp.Services
{
    public class ForecastingService
    {
        public (double slope, double intercept) TrainLinearRegression(List<FinancialDataPoint> data)
        {
            int n = data.Count;
            double avgX = data.Select((dp, idx) => (double)idx).Average();
            double avgY = data.Average(dp => dp.Value);

            double numerator = 0, denominator = 0;

            for (int i = 0; i < n; i++)
            {
                double x = i;
                double y = data[i].Value;
                numerator += (x - avgX) * (y - avgY);
                denominator += (x - avgX) * (x - avgX);
            }

            double slope = numerator / denominator;
            double intercept = avgY - slope * avgX;

            return (slope, intercept);
        }

        public double PredictNext(int nextIndex, double slope, double intercept)
        {
            return slope * nextIndex + intercept;
        }
    }
}

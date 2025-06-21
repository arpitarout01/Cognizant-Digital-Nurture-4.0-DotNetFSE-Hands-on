using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinancialForecastingApp.Models;
using FinancialForecastingApp.Services;
using System.IO;

namespace FinancialForecastingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string csvFilePath = "C:\\Users\\PUSPANJALI\\OneDrive\\Documents\\financial_data.csv";
            var data = new List<FinancialDataPoint>();

            try
            {
                var lines = File.ReadAllLines(csvFilePath);
                for (int i = 1; i < lines.Length; i++)
                {
                    var parts = lines[i].Split(',');
                    if (DateTime.TryParse(parts[0], out var date) && double.TryParse(parts[1], out var value))
                    {
                        data.Add(new FinancialDataPoint { Date = date, Value = value });
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error reading CSV: " + ex.Message);
                return;
            }

            if (data.Count < 2)
            {
                Console.WriteLine("Not enough data to perform forecasting.");
                return;
            }

            var service = new ForecastingService();
            var (slope, intercept) = service.TrainLinearRegression(data);
            double predicted = service.PredictNext(data.Count, slope, intercept);

            Console.WriteLine("----- Financial Forecasting -----");
            foreach (var point in data)
            {
                Console.WriteLine($"{point.Date:yyyy-MM-dd} : {point.Value}");
            }

            Console.WriteLine($"\nPredicted next month's value: {predicted:F2}");
        }
    }
}



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UploadService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Access Singleton instance
            Singleton_pattern s1 = Singleton_pattern.Instance;
            Singleton_pattern s2 = Singleton_pattern.Instance;

            // Call a method
            s1.ShowMessage();

            // Check if both references point to the same object
            Console.WriteLine("Are both instances same? " + Object.ReferenceEquals(s1, s2));

            Console.ReadLine(); // Pause the console window
        }
    }
}
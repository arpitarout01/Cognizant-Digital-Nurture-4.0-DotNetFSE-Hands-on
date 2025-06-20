using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace UploadService
{
    public sealed class Singleton_pattern
    {
        private static Singleton_pattern instance = null;
        private static object singletonLock = new object();        

        private Singleton_pattern() 
        { 
            Console.WriteLine("Singleton instance created.");
        }

        public static Singleton_pattern Instance
        {
            get
            {
                lock(singletonLock)
                {
                    if (instance == null)
                    {
                        instance = new Singleton_pattern();
                    }
                    return instance;
                }
            }
        }
        public void ShowMessage()
        {
           Console.WriteLine("Hello from Singleton!");
        }
    }
}

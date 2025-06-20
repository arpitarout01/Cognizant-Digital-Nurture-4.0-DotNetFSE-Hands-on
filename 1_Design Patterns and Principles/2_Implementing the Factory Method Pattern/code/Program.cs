using Continental_App.Continents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Continental_App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Continent[] continents = new Continent[]
            {
               new Africa(),
               new Asia()
            };
            foreach (Continent continent in continents)
            {
                Console.WriteLine(continent.GetType().Name + ":");
                foreach (Animal animal in continent.Animals)
                {
                    Console.WriteLine(" " + animal.GetType().Name);
                }
            }
            Console.ReadKey();
        }
    }
}

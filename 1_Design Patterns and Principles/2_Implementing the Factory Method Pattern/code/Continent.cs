using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Continental_App
{
    abstract class Continent
    {
        private List<Animal> _animals = new List<Animal>();

        protected Continent()
        {
            CreateContinent();
        }

        public List<Animal> Animals => _animals;

        public abstract void CreateContinent();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Modelos
{
    public class Repositorio
    {
        public List<Persona> Personas { get; set; }

        public Repositorio()
        {
            Personas = new List<Persona>();
        }
    }
}

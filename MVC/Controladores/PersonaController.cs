using MVC.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Controladores
{
    public class PersonaController
    {
        private Repositorio Repositorio;

        public PersonaController()
        {
            Repositorio = new Repositorio();
        }

        public void RegistrarPersona(Persona p)
        {
            Repositorio.Personas.Add(p);
        }

        public List<Persona> ObtenerTodos()
        {
            return Repositorio.Personas;
        }
    }
}

using MVC.DTOs;
using MVC.Modelos;
using MVC.Validaciones;
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

        public GestorRespuesta<Persona> RegistrarPersona(Persona p)
        {
            var validacionPersona = new PersonaValidator();
            var resultadoValidacion = validacionPersona.Validate(p);

            if (resultadoValidacion.IsValid)
            {
                Repositorio.Personas.Add(p);

                return new GestorRespuesta<Persona>(p);
            }
            else
            {
                return new GestorRespuesta<Persona>(true, resultadoValidacion.ToString());
            }
        }

        public List<Persona> ObtenerTodos()
        {
            return Repositorio.Personas;
        }
    }
}

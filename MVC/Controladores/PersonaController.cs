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

        public List<Persona> ObtenerPorCoincidencia(string nombre)
        {
            var busqueda = Repositorio.Personas.Where(p => p.Nombre.Contains(nombre)).ToList();

            return busqueda;
        }

        public Persona Actualizar (Persona p)
        {
            var personaEliminar = Repositorio.Personas.Where(x => x.Nombre == p.Nombre)
                                                        .First();
            Repositorio.Personas.Remove(personaEliminar);
            Repositorio.Personas.Add(p);

            return p;
        }

        public bool Eliminar(Persona p)
        {
            Repositorio.Personas.Remove(p);

            return true;
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

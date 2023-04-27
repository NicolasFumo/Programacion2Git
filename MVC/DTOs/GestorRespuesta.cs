using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.DTOs
{
    public class GestorRespuesta<T>
    {
        public GestorRespuesta(T respuesta)
        {
            Respuesta = respuesta;
            HayError = false;
        }

        public GestorRespuesta(bool hayError, string mensajeError)
        {
            HayError = hayError;
            MensajeError = mensajeError;
        }

        public T Respuesta { get; set; }
        public bool HayError { get; set; }
        public string MensajeError { get; set; }
    }
}

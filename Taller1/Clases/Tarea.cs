using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller1.Clases
{
    public class Tarea
    {
        public string nombre { get; set; }
        public readonly DateTime fecha; 
        public string estado { get; set; }


        public Tarea(string nombre, string estado)
        {
            this.nombre = nombre;
            this.fecha = DateTime.Now;
            this.estado = estado;

        }
    }

}


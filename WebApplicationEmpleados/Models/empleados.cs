using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationEmpleados.Models
{
    public class empleados
    {
        public string rut { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string mail { get; set; }
        public string telefono { get; set; }
    }
}
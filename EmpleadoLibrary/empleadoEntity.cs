using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpleadoLibrary
{
    public class empleadoEntity
    {
        private string rut;
        private string nombre;
        private string apellido;
        private string mail;
        private string telefono;

        Datos data = new Datos();

        public string Rut { get => rut; set => rut = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Mail { get => mail; set => mail = value; }
        public string Telefono { get => telefono; set => telefono = value; }

        public empleadoEntity()
        {

        }
        public empleadoEntity(string rut, string nombre, string apellido, string mail, string telefono)
        {
            this.rut = rut;
            this.nombre = nombre;
            this.apellido = apellido;
            this.mail = mail;
            this.telefono = telefono;
        }


        public DataSet listadoEmpleado()
        {
            return data.listado("SELECT * FROM EMPLEADOS");
        }

        public int guardar(empleadoEntity empleado)
        {
            return data.ejecutar("Insert into EMPLEADOS(rut, nombre, apellido, mail, telefono) values('" + empleado.Rut + "','" + empleado.Nombre + "','" + empleado.Apellido + "','" + empleado.Mail + "','" + empleado.Telefono + "')");
        }
    }
}

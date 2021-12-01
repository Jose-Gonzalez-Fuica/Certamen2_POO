using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpleadoLibrarys
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
        public string Telefono { get => telefono; set => telefono = value; }
        public string Mail { get => mail; set => mail = value; }

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
            return data.listado("SELECT * FROM EMPLEADO");
        }

        public DataSet filtrarEmpleado(string rut)
        {
            return data.listado("SELECT * FROM EMPLEADO WHERE RUT = '" + rut + "'");
        }

        public int guardar(empleadoEntity empleado)
        {
            return data.ejecutar("Insert into EMPLEADO(rut, nombre, apellido, mail, telefono) values('" + empleado.Rut + "','" + empleado.Nombre + "','" + empleado.Apellido + "','" + empleado.Mail + "','" + empleado.Telefono + "')");
        }

        public int guardar()
        {
            return data.ejecutar("Insert into EMPLEADO(rut, nombre, apellido, mail, telefono) values('" + this.Rut + "','" + this.Nombre + "','" + this.Apellido + "','" + this.Mail + "','" + this.Telefono + "')");
        }

        public int editar(empleadoEntity empleado)
        {
            return data.ejecutar("UPDATE EMPLEADO SET NOMBRE='"+empleado.Nombre+"', APELLIDO='"+empleado.Apellido+"', MAIL='"+empleado.Mail+"', TELEFONO='"+empleado.Telefono+ "' WHERE RUT = '" + empleado.Rut + "'");
        }

        public int eliminar()
        {
            return data.ejecutar("DELETE FROM EMPLEADO WHERE RUT= '" + this.rut + "'");
        }
    }
}

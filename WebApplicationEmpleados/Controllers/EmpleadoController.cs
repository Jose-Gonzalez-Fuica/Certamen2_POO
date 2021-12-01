using EmpleadoLibrarys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplicationEmpleados.Models;
namespace WebApplicationEmpleados.Controllers
{
    public class EmpleadoController : ApiController
    {
        [HttpGet]
        [Route("api/v1/empleados")]
        public respuesta listar(string rut = "")
        {
            respuesta resp = new respuesta();
            try
            {
                List<empleados> listado = new List<empleados>();
                empleadoEntity empleadoData = new empleadoEntity();
                DataSet data = rut == "" ? empleadoData.listadoEmpleado() : empleadoData.filtrarEmpleado(rut);
                for (int i = 0; i < data.Tables[0].Rows.Count; i++)
                {
                    empleados item = new empleados();
                    item.rut = data.Tables[0].Rows[i].ItemArray[0].ToString();
                    item.nombre = data.Tables[0].Rows[i].ItemArray[1].ToString();
                    item.apellido = data.Tables[0].Rows[i].ItemArray[2].ToString();
                    item.mail = data.Tables[0].Rows[i].ItemArray[3].ToString();
                    item.telefono = data.Tables[0].Rows[i].ItemArray[4].ToString();
                    listado.Add(item);
                }
                //operacion correcta 
                resp.error = false;
                resp.mensaje = "ok";
                if (listado.Count > 0)
                    resp.data = listado;
                else
                    resp.data = "No se encontro empleado";
                return resp;
            }
            catch (Exception e)
            {
                resp.error = true;
                resp.mensaje = "Error:" + e.Message;
                resp.data = null;
                return resp;
            }
        }

        [HttpPost]
        [Route("api/v1/setempleado")]
        public respuesta guardar(empleados empleado)
        {
            respuesta resp = new respuesta();
            try
            {
                empleadoEntity emp = new empleadoEntity(empleado.rut, empleado.nombre, empleado.apellido, empleado.mail, empleado.telefono);
                int estado = emp.guardar();

                if (estado == 1)
                {
                    resp.error = false;
                    resp.mensaje = "Empleado ingresado";
                    resp.data = empleado;
                }
                else
                {
                    resp.error = true;
                    resp.mensaje = "No se realizo el ingreso";
                    resp.data = null;
                }
                return resp;
            }
            catch (Exception e)
            {
                resp.error = true;
                resp.mensaje = "Error:" + e.Message;
                resp.data = null;
                return resp;
            }
        }

        [HttpPut]
        [Route("api/v1/editempleado")]
        public respuesta editar(empleados empleado)
        {
            respuesta resp = new respuesta();
            try
            {
                empleadoEntity emp = new empleadoEntity(empleado.rut, empleado.nombre, empleado.apellido, empleado.mail, empleado.telefono);
                int estado = emp.editar(emp);

                if (estado == 1)
                {
                    resp.error = false;
                    resp.mensaje = "Empleado editado con éxito";
                    resp.data = empleado;
                }
                else
                {
                    resp.error = true;
                    resp.mensaje = "Ha ocurrido un error al editar el Empleado";
                    resp.data = null;
                }
                return resp;
            }
            catch (Exception e)
            {
                resp.error = true;
                resp.mensaje = "Error:" + e.Message;
                resp.data = null;
                return resp;
            }
        }

        [HttpDelete]
        [Route("api/v1/deleteempleado")]
        public respuesta eliminar(string rut)
        {
            respuesta resp = new respuesta();
            try
            {

                empleadoEntity emp = new empleadoEntity();
                emp.Rut = rut;
                int estado = emp.eliminar();

                if (estado == 1)
                {
                    resp.error = false;
                    resp.mensaje = "Empleado eliminado";
                    resp.data = null;
                }
                else
                {
                    resp.error = true;
                    resp.mensaje = "No se realizo la eliminacion";
                    resp.data = null;
                }
                return resp;
            }
            catch (Exception e)
            {
                resp.error = true;
                resp.mensaje = "Error:" + e.Message;
                resp.data = null;
                return resp;
            }
        }
    }
}
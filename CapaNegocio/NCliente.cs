using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data.SqlClient;
using System.Data;

namespace CapaNegocio
{
    public class NCliente
    {

        public static string Insertar(string nombre, string apellidos, string sexo, DateTime fecha_nacimiento, string tipo_docuemnto, string num_documento, string direccion, string telefono, string email)
        {
            DCliente cliente = new DCliente();  
            cliente.Nombre= nombre;
            cliente.Apellidos= apellidos;
            cliente.Sexo= sexo;
            cliente.Fecha_nacimiento= fecha_nacimiento;
            cliente.Tipo_documento= tipo_docuemnto;
            cliente.Num_documento= num_documento;
            cliente.Direccion= direccion;
            cliente.Telefono= telefono;
            cliente.Email= email;

            return cliente.Insertar(cliente);
        }

        public static string Editar(int idcliente,string nombre, string apellidos, string sexo, DateTime fecha_nacimiento, string tipo_docuemnto, string num_documento, string direccion, string telefono, string email)
        {
            DCliente cliente = new DCliente();
            cliente.Idcliente= idcliente;
            cliente.Nombre = nombre;
            cliente.Apellidos = apellidos;
            cliente.Sexo = sexo;
            cliente.Fecha_nacimiento = fecha_nacimiento;
            cliente.Tipo_documento = tipo_docuemnto;
            cliente.Num_documento = num_documento;
            cliente.Direccion = direccion;
            cliente.Telefono = telefono;
            cliente.Email = email;
            return cliente.Editar(cliente);
        }

        public static string Eliminar(int idcliente)
        {
            DCliente cliente = new DCliente();
            cliente.Idcliente = idcliente;

            return cliente.Eliminar(cliente);
        }


        public static DataTable Mostrar()
        {
            return new DCliente().Mostrar();
        }

        public static DataTable BuscarApellido(string textoBuscar)
        {
            DCliente cliente = new DCliente();
            cliente.Textobuscar = textoBuscar;

            return cliente.BuscarApellido(cliente);
        }

        public static DataTable BuscarDocumento(string textoBuscar)
        {
            DCliente cliente = new DCliente();
            cliente.Textobuscar = textoBuscar;

            return cliente.BuscarDocumento(cliente);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data.SqlClient;
using System.Data;
using System.Reflection.Emit;

namespace CapaNegocio
{
    public  class NTrabajador
    {
        public static string Insertar(string nombre, string apellido, string sexo, DateTime fecha_nac, string num_documento, string direccion, string telefono, string email, string acceso, string usuario, string password)
        {
            DTrabajador dTrabajador = new DTrabajador();
            dTrabajador.Nombre = nombre;
            dTrabajador.Apellido = apellido;
            dTrabajador.Sexo = sexo;
            dTrabajador.Fecha_nac = fecha_nac;
            dTrabajador.Num_documento = num_documento;
            dTrabajador.Direccion = direccion;
            dTrabajador.Telefono = telefono;
            dTrabajador.Email = email;
            dTrabajador.Acceso = acceso;
            dTrabajador.Usuario = usuario;
            dTrabajador.Password = password;
            return dTrabajador.Insertar(dTrabajador);
        }


        public static string Editar(int idtrabajador,string nombre, string apellido, string sexo, DateTime fecha_nac, string num_documento, string direccion, string telefono, string email, string acceso, string usuario, string password)
        {
            DTrabajador dTrabajador = new DTrabajador();
            dTrabajador.Idtrabajador = idtrabajador;
            dTrabajador.Nombre = nombre;
            dTrabajador.Apellido = apellido;
            dTrabajador.Sexo = sexo;
            dTrabajador.Fecha_nac = fecha_nac;
            dTrabajador.Num_documento = num_documento;
            dTrabajador.Direccion = direccion;
            dTrabajador.Telefono = telefono;
            dTrabajador.Email = email;
            dTrabajador.Acceso = acceso;
            dTrabajador.Usuario = usuario;
            dTrabajador.Password = password;
            return dTrabajador.Editar(dTrabajador);
        }

        public static string Eliminar(int idtrabajador)
        {
            DTrabajador dTrabajador = new DTrabajador();
            dTrabajador.Idtrabajador = idtrabajador;
            return dTrabajador.Eliminar(dTrabajador);
        }

        public static DataTable Mostrar()
        {
            return new DTrabajador().Mostar();
        }

        public static DataTable BuscarApellido(string textobuscar)
        {
            DTrabajador dTrabajador = new DTrabajador();
            dTrabajador.Textobuscar = textobuscar;

            return dTrabajador.BuscarApellido(dTrabajador);
        }

        public static DataTable BuscarDocumento(string textobuscar)
        {
            DTrabajador dTrabajador = new DTrabajador();
            dTrabajador.Textobuscar = textobuscar;

            return dTrabajador.BuscarDocumento(dTrabajador);
        }

        public static DataTable Login(string usuario, string password)
        {
            DTrabajador dTrabajador = new DTrabajador();
            dTrabajador.Usuario = usuario;
            dTrabajador.Password = password;

            return dTrabajador.Login(dTrabajador);
        }


    }
}

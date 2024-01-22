using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CapaDatos;

namespace CapaNegocio
{
    public  class NProveedor
    {
        public static string Insertar( string razon_social, string sector_comercial, string tipo_documento, string num_documento, string direccion, string telefono, string email, string url)
        {
            DProveedor obj = new DProveedor();
       
            obj.Razon_social = razon_social;
            obj.Sector_comercial = sector_comercial;
            obj.Tipo_documento = tipo_documento;
            obj.Num_documento = num_documento;
            obj.Direccion = direccion;
            obj.Telefono = telefono;
            obj.Email = email;
            obj.Url = url;
            return obj.Insertar(obj);
        }

        public static string Editar(int idproveedor,string razon_social, string sector_comercial, string tipo_documento, string num_documento, string direccion, string telefono, string email, string url)
        {
            DProveedor obj = new DProveedor();
            obj.Idproveedor = idproveedor;
            obj.Razon_social = razon_social;
            obj.Sector_comercial = sector_comercial;
            obj.Tipo_documento = tipo_documento;
            obj.Num_documento = num_documento;
            obj.Direccion = direccion;
            obj.Telefono = telefono;
            obj.Email = email;
            obj.Url = url;
            return obj.Editar(obj);
        }

        public static string Eliminar(int idproveedor)
        {
            DProveedor obj = new DProveedor();
            obj.Idproveedor = idproveedor;
            return obj.Eliminar(obj);
        }

        public static DataTable Mostrar()
        {
           return new DProveedor().Mostrar();
        }

        public static DataTable BuscarRazonSocial(string textobuscar)
        {
            DProveedor obj = new DProveedor();
            obj.Textobuscar = textobuscar;
            return obj.BuscarRazonSocial(obj);
        }

        public static DataTable BuscarNumDocumento(string textobuscar)
        {
            DProveedor obj = new DProveedor();
            obj.Textobuscar = textobuscar;
            return obj.BuscarNumDocumento(obj);
        }
    }
}

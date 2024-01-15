using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;
using System.Runtime.Remoting.Messaging;
namespace CapaNegocio
{
     public class nCategoria
    {
        public static string Insertar(string nombre, string descripcion)
        {
            DCategoria obj = new DCategoria();
            obj.Nombre = nombre;
            obj.Descripcion = descripcion;

            return obj.Insertar(obj);
        }

        public static string Editar(int idcategoria, string nombre, string descripcion)
        {
            DCategoria obj = new DCategoria();
            obj.Idcategoria = idcategoria;
            obj.Nombre = nombre;
            obj.Descripcion = descripcion;

            return obj.Editar(obj);
        }

        public static string Eliminar(int idcategoria)
        {
            DCategoria obj = new DCategoria();
            obj.Idcategoria = idcategoria;
         

            return obj.Eliminar(obj);
        }
  
        public static DataTable Mostrar()
        {
            return new DCategoria().Mostar();
        }

        public static DataTable BuscarNombre(string textobuscar)
        {
            DCategoria obj = new DCategoria();
            obj.TextoBuscar = textobuscar;


            return obj.BuscarNombre(obj);
        }
        
    }
}

using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;

using System.Data;

namespace CapaNegocio
{
    public class nArticulo
    {

        public static string Insertar(string codigo, string nombre, string descripcion, byte[] imagen, int idcategoria, int idpresentacion)
        {
            DArticulo dArticulo = new DArticulo();
            dArticulo.Codigo = codigo;
            dArticulo.Nombre = nombre;
            dArticulo.Descripcion = descripcion;
            dArticulo.Imagen = imagen;
            dArticulo.Idcategoria = idcategoria;
            dArticulo.Idpresentacion = idpresentacion;

            return dArticulo.Insertar(dArticulo);
        }


        public static string Editar(int idarticulo, string codigo, string nombre, string descripcion, byte[] imagen, int idcategoria, int idpresentacion)
        {
            DArticulo articulo = new DArticulo();
            articulo.Idarticulo = idarticulo;
            articulo.Codigo = codigo;
            articulo.Nombre = nombre;
            articulo.Descripcion = descripcion;
            articulo.Imagen = imagen;
            articulo.Idcategoria = idcategoria;
            articulo.Idpresentacion = idpresentacion;

            return articulo.Editar(articulo);
        }

        public static string Eliminar(int idarticulo)
        {
            DArticulo articulo = new DArticulo();
            articulo.Idarticulo = idarticulo;

            return articulo.Eliminar(articulo);
        }

        public static DataTable Mostrar()
        {
            return new DArticulo().Mostrar();
        }

        public static DataTable BustarNombre(string textobuscar)
        {
            DArticulo articulo = new DArticulo();
            articulo.Textobuscar = textobuscar;

            return articulo.BuscarNombre(articulo);

        }

    }
}


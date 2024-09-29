using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_WinForms_Grupo_1B.Modelos
{
    public class Articulo
    {
        //public Articulo(int codigo,
        //                string nombre,
        //                string descripcion,
        //                string marca,
        //                string categoria,
        //                string imagen,
        //                decimal precio)
        //{
        //    Codigo = codigo;
        //    Nombre = nombre;
        //    Descripcion = descripcion;
        //    Marca = marca;
        //    Categoria = categoria;
        //    Imagen = imagen;
        //    Precio = precio;
        //}
        public Articulo() { }
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public Elemento Marca { get; set; }
        public Elemento Categoria { get; set; }
        public string Imagen { get; set; } 
        public decimal Precio { get; set; }
       
    }
}

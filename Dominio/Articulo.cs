using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Articulo
    {
        public int posVec { get; set; }
        public List<string> Imagenes;
        public int Id { get; set; }
        [DisplayName("Código")]
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        [DisplayName("Descripción")]
        public string Descripcion { get; set; }

        public Marca Marca { get; set; }
        [DisplayName("Categoría")]
        public Categoria Categoria { get; set; }
        public string Imagen { get; set; }

        public decimal Precio { get; set; }

        public Articulo()
        {
            posVec = 0;
            //Imagenes = new List<string>();
        }
    } 
}

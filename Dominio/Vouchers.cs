using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Vouchers
    {
        public Vouchers() { }
        public string codigoVoucher {  get; set; }
        public Cliente cliente { get; set; } 
        public DateTime fechaCanje { get; set; }
        public Articulo articulo { get; set; }

    }
}

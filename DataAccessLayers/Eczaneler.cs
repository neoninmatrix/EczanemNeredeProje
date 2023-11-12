using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayers
{
    public class Eczaneler
    {

        public int ID { get; set; }
        public int UyeID { get; set; }
        public string Isim { get; set; }
        public string Konum { get; set; }
        public string Resim { get; set; }
        public Int64 IlacSayisi { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayers
{
    public class Ilaclar
    {

        public int ID { get; set; }
        public int EczaneID { get; set; }
        public string Isim { get; set; }
        public string Marka { get; set; }
        public string Aciklama { get; set; }
        public Decimal Fiyat { get; set; }
        public string Kategori { get; set; }

    }
}

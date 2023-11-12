using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayers
{
    public class Uye
    {
        public int ID { get; set; }
        public int YetkiliTur_ID { get; set; }
        public string Isim { get; set; }
        public string Soyisim { get; set; }
        public string UyeAdi { get; set; }
        public string Sifre { get; set; }
        public string EczaneTakmaAdi { get; set; }
        public string EczaneSifre { get; set; }
        public string Mail { get; set; }
        public DateTime OlusturulmaTarihi { get; set; }
        public bool Aktif { get; set; }
        public bool Silinmis { get; set; }

    }
}

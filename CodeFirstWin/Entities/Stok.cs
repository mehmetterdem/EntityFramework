using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstWin.Entities
{
    public class Stok:BaseEntity
    {
        
        public string StokAdi { get; set; }
        public string Aciklama { get; set; }
        public List<Kategori> kategori { get; set; }
      

    }
}

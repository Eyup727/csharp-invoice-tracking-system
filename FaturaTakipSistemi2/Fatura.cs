using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaturaTakipSistemi2
{
    internal class Fatura
    {
        public int ID { get; set; }
        public DateTime Tarih { get; set; }
        public string Firma { get; set; }
        public decimal Tutar { get; set; }
        public string Aciklama { get; set; }
    }
}

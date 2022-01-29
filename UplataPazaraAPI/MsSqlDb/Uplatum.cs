using System;
using System.Collections.Generic;

namespace UplataPazaraAPI.MsSqlDb
{
    public partial class Uplatum
    {
        public int UplataId { get; set; }
        public int KurirId { get; set; }
        public string RacunPrimaoca { get; set; } = null!;
        public string NazivUplatioca { get; set; } = null!;
        public string GradUplatioca { get; set; } = null!;
        public string AdresaUplatioca { get; set; } = null!;
        public DateTime DatumTransakcije { get; set; }
        public decimal IznosUplate { get; set; }
        public decimal IznosProvizije { get; set; }
        public decimal UkupnaUplata { get; set; }
        public DateTime DatumUnosa { get; set; }
        public int KorisnikUnosa { get; set; }

        public virtual Kurir Uplata { get; set; } = null!;
    }
}

using System;
using System.Collections.Generic;

namespace UplataPazaraAPI.MsSqlDb
{
    public partial class Kurir
    {
        public int KurirId { get; set; }
        public int TrgovacId { get; set; }
        public string Ime { get; set; } = null!;
        public string Prezime { get; set; } = null!;
        public string Jmbg { get; set; } = null!;
        public DateTime DatumAutorizacije { get; set; }
        public string Status { get; set; } = null!;
        public string Drzava { get; set; } = null!;
        public string Grad { get; set; } = null!;
        public string Adresa { get; set; } = null!;
        public string Telefon { get; set; } = null!;
        public string Mail { get; set; } = null!;
        public DateTime DatumUnosa { get; set; }
        public int KorisnikUnosa { get; set; }

        public virtual Trgovac? Trgovac { get; set; } = null!;
        public virtual Uplatum? Uplatum { get; set; } = null!;
    }
}

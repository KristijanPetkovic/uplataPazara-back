using System;
using System.Collections.Generic;

namespace UplataPazaraAPI.MsSqlDb
{
    public partial class Trgovac
    {
        public Trgovac()
        {
            Kurirs = new HashSet<Kurir>();
        }

        public int TrgovacId { get; set; }
        public string NazivTrgovca { get; set; } = null!;
        public string? Drzava { get; set; }
        public string? Grad { get; set; }
        public string? Adresa { get; set; }
        public string? Mb { get; set; }
        public string? Pib { get; set; }
        public string? BrojRacuna { get; set; }
        public DateTime? DatumUnosa { get; set; }
        public int? KorisnikUnosa { get; set; }

        public virtual ICollection<Kurir> Kurirs { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace UplataPazaraAPI.MsSqlDb
{
    public partial class Korisnik
    {
        public int KorisnikId { get; set; }
        public string KorisnickoIme { get; set; } = null!;
        public string Lozinka { get; set; } = null!;
    }
}

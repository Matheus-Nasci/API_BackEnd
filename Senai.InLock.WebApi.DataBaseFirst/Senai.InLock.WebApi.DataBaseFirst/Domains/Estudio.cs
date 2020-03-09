using System;
using System.Collections.Generic;

namespace Senai.InLock.WebApi.DataBaseFirst.Domains
{
    public partial class Estudio
    {
        public Estudio()
        {
            Jogos = new HashSet<Jogos>();
        }

        public int IdEstudio { get; set; }

        public string NomeEstudio { get; set; }

        public ICollection<Jogos> Jogos { get; set; }
    }
}

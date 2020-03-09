using System;
using System.Collections.Generic;

namespace Senai.InLock.WebApi.DataBaseFirst.Domains
{
    public partial class Jogos
    {
        public int IdJogo { get; set; }

        public string NomeJogos { get; set; }

        public string Descricao { get; set; }

        public DateTime DataLancamento { get; set; }

        public string Valor { get; set; }

        public int? IdEstudio { get; set; }

        public Estudio IdEstudioNavigation { get; set; }
    }
}

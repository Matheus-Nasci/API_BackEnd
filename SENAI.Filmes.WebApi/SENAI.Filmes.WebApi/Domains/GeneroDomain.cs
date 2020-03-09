using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace senai.Filmes.WebApi.Domains
{
    /// <summary>
    /// Classe que representa a tabela Generos
    /// </summary>
    public class GeneroDomain
    {
        public int IdGenero { get; set; }

        [Required(ErrorMessage = "Informe o nome do gênero")]
        public string Nome { get; set; }
    }
}

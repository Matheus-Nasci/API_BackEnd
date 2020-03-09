using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.CodeFirst.Domains
{   [Table("TipoUsuario")]
    public class TipoUsuario
    {   
        // Define que será chave Primária
        [Key]
        //Define o auto-incremento
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdTipoUsuario { get; set;}

        //Define o tipo da coluna do Banco de Dados
        [Column(TypeName = "VARCHAR(255)")]

        //Required Fala que o campo é obrigatorio ou seja NOT NULL
        [Required(ErrorMessage = "O título do tipo de usuário é obrigatório")]
        public string Titulo { get; set; }
    }
}

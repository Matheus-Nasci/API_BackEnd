using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.CodeFirst.Domains
{   [Table("Usuario")]
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdUsuario { get; set; }
        
        [Column(TypeName = "VARCHAR (150)")]
        [Required(ErrorMessage = "O E-mail do Usuário é Obrigatório")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Column(TypeName = "VARCHAR (150)")]
        [Required(ErrorMessage = "O E-mail do Usuário é Obrigatório")]
        [DataType(DataType.Password)]
        [StringLength(30, MinimumLength = 7, ErrorMessage = "A Senha deve ter no Minímo 7 e no Máximo 30 Caracteres")]
        public string Senha { get; set; }

        public int IdTipoUsuario { get; set; }

        [ForeignKey("IdTipoUsuario")]
        public TipoUsuario TipoUsuario { get; set; }
    }
}

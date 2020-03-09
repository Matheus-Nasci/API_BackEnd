using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.CodeFirst.Domains
{   [Table("Jogos")]
    public class Jogos
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdJogo { get; set; }

        [Column(TypeName = "VARCHAR (150)")]
        [Required(ErrorMessage = "")]
        public string NomeJogo { get; set; }

        [Column(TypeName = "TEXT")]
        [Required(ErrorMessage = "A descrição é Obrigatória")]
        public string Descricao { get; set; }

        [Column(TypeName = "DATE")]
        [Required(ErrorMessage = "A descrição é Obrigatória")]
        [DataType(DataType.Date)]
        public DateTime DataLancamento { get; set; }

        [Column("Preco", TypeName = "DECIMAL (18,2)")]
        public decimal Valor { get; set; }

        [Required(ErrorMessage = "É Necessário informar o ID do Estudio Obrigatória")]
        public int IdEstudio { get; set; }

        [ForeignKey("IdEstudio")]
        public Estudios Estudio{ get; set; }


    }
}

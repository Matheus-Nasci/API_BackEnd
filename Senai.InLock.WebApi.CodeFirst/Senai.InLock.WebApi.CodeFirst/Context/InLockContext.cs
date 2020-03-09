using Microsoft.EntityFrameworkCore;
using Senai.InLock.WebApi.CodeFirst.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.CodeFirst.Context
{
    /// <summary>
    /// Define as opções de construção do banco de dados
    /// </summary>
    /// <param name="optionBuilder">Objeto com configurações já definidas</param>
    public class InLockContext : DbContext
    {
        //Define as entidades do Banco de dados

        public DbSet<TipoUsuario> TipoUsuario { get; set; }

        public DbSet<Usuario> Usuario { get; set; }

        public DbSet<Estudios> Estudio { get; set; }

        public DbSet<Jogos> Jogos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DEV1401\\SQLEXPRESS; Initial Catalog=InLock_Games_CodeFirst_Tarde; user Id=sa; pwd=sa@132;");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TipoUsuario>().HasData(
                new TipoUsuario
                {
                    IdTipoUsuario = 1,
                    Titulo = "Adminintrador"
                },
                new TipoUsuario
                {
                    IdTipoUsuario = 2,
                    Titulo = "Cliente"
                });

            modelBuilder.Entity<Usuario>().HasData(
                new Usuario
                {
                    IdUsuario = 1,
                    Email = "admin@admin.com",
                    Senha = "admin",
                    IdTipoUsuario = 1
                },
                new Usuario
                {
                    IdUsuario = 2,
                    Email = "cliente@cliente.com",
                    Senha = "cliente",
                    IdTipoUsuario = 1
                });

            modelBuilder.Entity<Estudios>().HasData(
                new Estudios
                {
                    IdEstudio = 1,
                    NomeEstudio = "Blizzard"
                },
                new Estudios
                {
                    IdEstudio = 2,
                    NomeEstudio = "Rockstar Studios"
                },
                new Estudios
                {
                    IdEstudio = 3,
                    NomeEstudio = "Square Enix"
                }
                );

            modelBuilder.Entity<Jogos>().HasData(
                new Jogos
                {
                    IdJogo = 1,
                    NomeJogo = "Diablo 3",
                    DataLancamento = Convert.ToDateTime("15/05/2012"),
                    Descricao = "É Um jogo que comtém bastante ação e é viciante",
                    Valor = Convert.ToDecimal("99,00"),
                    IdEstudio = 1
                    
                },

                new Jogos
                {
                    IdJogo = 2,
                    NomeJogo = "Red Dead Redemption II",
                    DataLancamento = Convert.ToDateTime("26/10/2018"),
                    Descricao = "Jogo eletrônico de Ação e Aventura",
                    Valor = Convert.ToDecimal("120,00"),
                    IdEstudio = 2

                });

            base.OnModelCreating(modelBuilder);
        }
    }
}

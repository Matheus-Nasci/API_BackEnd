using Senai.InLock.WebApi.DataBaseFirst.Domains;
using Senai.InLock.WebApi.DataBaseFirst.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.DataBaseFirst.Repositories
{
    public class JogosRepository : IJogosRepository
    {
        InLockContext ctx = new InLockContext();

        public void Atualizar(int id, Jogos jogoAtualizado)
        {
            Jogos jogoBuscado = ctx.Jogos.Find(id);

            jogoBuscado.NomeJogos = jogoAtualizado.NomeJogos;

            jogoBuscado.Descricao = jogoAtualizado.Descricao;

            jogoBuscado.DataLancamento = jogoAtualizado.DataLancamento;

            jogoBuscado.Valor = jogoAtualizado.Valor;

            jogoBuscado.IdEstudioNavigation = jogoAtualizado.IdEstudioNavigation;

            ctx.Jogos.Update(jogoBuscado);

            ctx.SaveChanges();
        }

        public Jogos BuscarPorId(int id)
        {
            return ctx.Jogos.FirstOrDefault(j => j.IdJogo == id);
        }

        public void Cadastrar(Jogos novoJogo)
        {
            ctx.Jogos.Add(novoJogo);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Jogos jogoBuscado = ctx.Jogos.Find(id);

            ctx.Jogos.Remove(jogoBuscado);

            ctx.SaveChanges();
        }

        public List<Jogos> Listar()
        {
            return ctx.Jogos.ToList();
        }
    }
}

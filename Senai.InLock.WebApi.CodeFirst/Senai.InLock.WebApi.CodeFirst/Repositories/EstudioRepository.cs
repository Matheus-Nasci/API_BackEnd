using Senai.InLock.WebApi.CodeFirst.Context;
using Senai.InLock.WebApi.CodeFirst.Domains;
using Senai.InLock.WebApi.CodeFirst.Domains;
using Senai.InLock.WebApi.CodeFirst.Interfaces;
using Senai.InLock.WebApi.CodeFirst.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.CodeFirst.Repositories
{
    public class EstudioRepository : IEstudiosRepository
    {
        InLockContext ctx = new InLockContext();

        public void Atualizar(int id, Estudios estudioAtualizado)
        {
            Estudios estudio = ctx.Estudio.Find(id);

            estudio = BuscarPorId(estudioAtualizado.IdEstudio);

            estudio.NomeEstudio = estudio.NomeEstudio;

            ctx.Estudio.Update(estudioAtualizado);

            ctx.SaveChanges();
        }

        public Estudios BuscarPorId(int id)
        {
            return ctx.Estudio.FirstOrDefault(e => e.IdEstudio == id);
        }

        public void Cadastrar(Estudios novoEstudio)
        {
            ctx.Estudio.Add(novoEstudio);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Estudios estudio = ctx.Estudio.Find(id);

            ctx.Estudio.Remove(estudio);

            ctx.SaveChanges();
        }

        public List<Estudios> Listar()
        {

            return ctx.Estudio.ToList();
        }
    }
}

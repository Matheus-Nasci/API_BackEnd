using Senai.InLock.WebApi.DataBaseFirst.Domains;
using Senai.InLock.WebApi.DataBaseFirst.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.DataBaseFirst.Repositories
{
    public class EstudioRepository : IEstudiosRepository
    {
        InLockContext ctx = new InLockContext();

        public void Atualizar(int id, Estudio estudioAtualizado)
        {
            Estudio estudio = ctx.Estudio.Find(id);

            estudio = BuscarPorId(estudioAtualizado.IdEstudio);

            estudio.NomeEstudio = estudio.NomeEstudio;

            ctx.Estudio.Update(estudioAtualizado);

            ctx.SaveChanges();
        }

        public Estudio BuscarPorId(int id)
        {
            return ctx.Estudio.FirstOrDefault(e => e.IdEstudio == id);
        }

        public void Cadastrar(Estudio novoEstudio)
        {
            ctx.Estudio.Add(novoEstudio);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Estudio estudio = ctx.Estudio.Find(id);

            ctx.Estudio.Remove(estudio);

            ctx.SaveChanges();
        }

        public List<Estudio> Listar()
        {

            return ctx.Estudio.ToList();
        }
    }
}

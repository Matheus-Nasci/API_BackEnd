using Senai.InLock.WebApi.CodeFirst.Context;
using Senai.InLock.WebApi.CodeFirst.Domains;
using Senai.InLock.WebApi.CodeFirst.Domains;
using Senai.InLock.WebApi.CodeFirst.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.CodeFirst.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        InLockContext ctx = new InLockContext();

        public void Atualizar(int id, TipoUsuario tipousuarioAtualizado)
        {
            TipoUsuario tipoUsuarioBuscado = ctx.TipoUsuario.Find(id);

            tipoUsuarioBuscado.Titulo = tipousuarioAtualizado.Titulo;

            ctx.TipoUsuario.Update(tipoUsuarioBuscado);

            ctx.SaveChanges();
        }

        public TipoUsuario BuscarPorId(int id)
        {
            return ctx.TipoUsuario.FirstOrDefault(t => t.IdTipoUsuario == id);
        }

        public void Cadastrar(TipoUsuario novoTipoUsuario)
        {
            ctx.TipoUsuario.Add(novoTipoUsuario);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            TipoUsuario tipoUsuarioBuscado = ctx.TipoUsuario.Find(id);

            ctx.TipoUsuario.Remove(tipoUsuarioBuscado);

            ctx.SaveChanges();
        }

        List<TipoUsuario> ITipoUsuarioRepository.Listar()
        {
            return ctx.TipoUsuario.ToList();
        }
    }
}

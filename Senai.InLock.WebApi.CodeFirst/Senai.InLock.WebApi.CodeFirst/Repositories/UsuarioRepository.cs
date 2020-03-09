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
    public class UsuarioRepository : IUsuarioRepository
    {
        InLockContext ctx = new InLockContext();

        public void Atualizar(int id, Usuario usuarioAtualizado)
        {
            Usuario UsuarioBuscado = ctx.Usuario.Find(id);

            UsuarioBuscado.Email = usuarioAtualizado.Email;

            UsuarioBuscado.Senha = usuarioAtualizado.Senha;

            ctx.Usuario.Update(UsuarioBuscado);

            ctx.SaveChanges();
        }

        public Usuario BuscarPorId(int id)
        {
            return ctx.Usuario.FirstOrDefault(u => u.IdUsuario == id); ;
        }

        public void Cadastrar(Usuario novoUsuario)
        {
            ctx.Usuario.Add(novoUsuario);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Usuario UsuarioBuscado = ctx.Usuario.Find(id);

            ctx.Usuario.Remove(UsuarioBuscado);

            ctx.SaveChanges();
        }

        public List<Usuario> Listar()
        {
            return ctx.Usuario.ToList();
        }
    }
}

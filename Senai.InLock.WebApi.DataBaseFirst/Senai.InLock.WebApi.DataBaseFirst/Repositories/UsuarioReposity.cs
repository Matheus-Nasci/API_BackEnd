using Senai.InLock.WebApi.DataBaseFirst.Domains;
using Senai.InLock.WebApi.DataBaseFirst.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.DataBaseFirst.Repositories
{
    public class UsuarioReposity : IUsuarioRepository
    {
        InLockContext ctx = new InLockContext();

        public Usuario BuscarPorId(int id)
        {
            return ctx.Usuario.FirstOrDefault(u => u.IdUsuario == id); ;
        }

        public void Cadastrar(Usuario novoUsuario)
        {
            ctx.Usuario.Add(novoUsuario);
            ctx.SaveChanges();
        }

        public List<Usuario> Listar()
        {
            return ctx.Usuario.ToList();
        }
    }
}

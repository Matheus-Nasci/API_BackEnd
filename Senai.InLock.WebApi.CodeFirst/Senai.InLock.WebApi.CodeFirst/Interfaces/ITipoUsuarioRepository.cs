using Senai.InLock.WebApi.CodeFirst.Domains;
using Senai.InLock.WebApi.CodeFirst.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.CodeFirst.Interfaces
{
    interface ITipoUsuarioRepository
    {
        List<TipoUsuario> Listar();

        TipoUsuario BuscarPorId(int id);

        void Deletar(int id);

        void Atualizar(int id, TipoUsuario tipousuarioAtualizado);

        void Cadastrar(TipoUsuario novoTipoUsuario);
    }
}

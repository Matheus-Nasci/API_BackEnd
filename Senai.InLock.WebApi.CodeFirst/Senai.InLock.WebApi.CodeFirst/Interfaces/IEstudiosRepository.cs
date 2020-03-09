using Senai.InLock.WebApi.CodeFirst.Domains;
using Senai.InLock.WebApi.CodeFirst.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.CodeFirst.Interfaces
{
    interface IEstudiosRepository
    {
        List<Estudios> Listar();

        Estudios BuscarPorId(int id);

        void Cadastrar(Estudios novoEstudio);

        void Deletar(int id);

        void Atualizar(int id, Estudios estudioAtualizado);
    }
}

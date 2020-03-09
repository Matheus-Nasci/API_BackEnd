using Senai.InLock.WebApi.DataBaseFirst.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.DataBaseFirst.Interfaces
{
    interface IEstudiosRepository
    {
        List<Estudio> Listar();

        Estudio BuscarPorId(int id);

        void Cadastrar(Estudio novoEstudio);

        void Deletar(int id);

        void Atualizar(int id, Estudio estudioAtualizado);
    }
}

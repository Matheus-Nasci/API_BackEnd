using Senai.InLock.WebApi.DataBaseFirst.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.DataBaseFirst.Interfaces
{
    interface IJogosRepository
    {
        List<Jogos> Listar();

        Jogos BuscarPorId(int id);

        void Deletar(int id);

        void Atualizar(int id, Jogos jogoAtualizado);

        void Cadastrar(Jogos novoJogo);
    }
}

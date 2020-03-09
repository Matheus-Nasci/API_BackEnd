using Senai.InLock.WebApi.CodeFirst.Domains;
using Senai.InLock.WebApi.CodeFirst.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.CodeFirst.Interfaces
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

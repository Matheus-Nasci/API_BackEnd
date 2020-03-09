using Senai.Peoples.WebApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Interfaces
{
    interface IPeopleRepository
    {
        List<PeopleDomain> Listar();

        void Cadastrar (PeopleDomain people);

        PeopleDomain BuscarPorId(int id);

        void AtualizarPorId(PeopleDomain people);

        void Delete(int id);
    }
}

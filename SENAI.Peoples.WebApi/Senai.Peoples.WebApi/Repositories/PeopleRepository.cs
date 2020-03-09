using Senai.Peoples.WebApi.Domain;
using Senai.Peoples.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Repositories
{
    public class PeopleRepository : IPeopleRepository
    {
        private string stringConexao = "Data Source = DEV1401\\SQLEXPRESS; initial catalog= T_Peoples; user Id=sa; pwd=sa@132";

        public void AtualizarPorId(PeopleDomain people)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdateID = "UPDATE Funcionario SET Nome = @Nome, Sobrenome = @Sobrenome WHERE IdFucionario = @ID";

                using(SqlCommand cmd = new SqlCommand(queryUpdateID, con))
                {
                    con.Open();

                    cmd.Parameters.AddWithValue("@Nome", people.Nome);

                    cmd.Parameters.AddWithValue("@Sobrenome", people.Sobrenome);

                    cmd.Parameters.AddWithValue("@ID", people.IdFucionario);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public PeopleDomain BuscarPorId(int id)
        {
            using(SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryBuscarPorId = "SELECT IdFucionario, Nome FROM Funcionario WHERE IdFucionario = @ID";

                SqlDataReader rdr;

                using(SqlCommand cmd = new SqlCommand(queryBuscarPorId, con))
                {
                    con.Open();

                    cmd.Parameters.AddWithValue("@ID", id);

                    rdr = cmd.ExecuteReader();

                    if(rdr.Read())
                    {
                        PeopleDomain people = new PeopleDomain
                        {
                            IdFucionario = Convert.ToInt32(rdr["IdFucionario"]),

                            Nome = rdr["Nome"].ToString()
                        };

                        return people;
                    }
                    return null;
                }
            }
        }

        public void Cadastrar(PeopleDomain people)
        {
            using(SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO Funcionario(Nome, Sobrenome) VALUES (@Nome, @Sobrenome)";

                using(SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@Nome", people.Nome);

                    cmd.Parameters.AddWithValue("@Sobrenome", people.Sobrenome);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int id) //Quando é Void ele não recebe Return só Envia a Informação 
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "DELETE FROM Funcionario WHERE IdFucionario = @ID";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    con.Open();

                    cmd.Parameters.AddWithValue("@ID", id);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<PeopleDomain> Listar()
        {
            List<PeopleDomain> lista = new List<PeopleDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {

                string querySelectAll = "SELECT IdFucionario, Nome, Sobrenome FROM Funcionario";

                 SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    con.Open();

                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        PeopleDomain people = new PeopleDomain
                        {
                            IdFucionario = Convert.ToInt32(rdr[0]),

                            Nome = rdr["Nome"].ToString(),

                            Sobrenome = rdr["Sobrenome"].ToString()
                        };

                        lista.Add(people);
                    }
                }
            }
            return lista;
        }
    }
}

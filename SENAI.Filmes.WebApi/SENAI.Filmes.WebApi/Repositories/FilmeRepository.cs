using senai.Filmes.WebApi.Domains;
using senai.Filmes.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai.Filmes.WebApi.Repositories
{
    public class FilmeRepository : IFilmeRepository
    {
        private string stringConexao = "Data Source=DEV1401\\SQLEXPRESS; initial catalog=Filmes_tarde; user Id=sa; pwd=sa@132";

        public void AtualizarIdCorpo(FilmeDomain filme)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryPutCorpo = "UPDATE Filmes SET Genero = @Genero, Titulo = @Titulo WHERE IdFilme = @ID";

                using (SqlCommand cmd = new SqlCommand(queryPutCorpo, con))
                {
                    cmd.Parameters.AddWithValue("@Titulo", filme.Titulo);

                    cmd.Parameters.AddWithValue("@ID", filme.IdFilme);

                    cmd.Parameters.AddWithValue("@Genero", filme.IdGenero);

                    //Abre a conexão no Banco - Tem que ficar dentro do CMD ou pode ir dentro da CON ?
                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public FilmeDomain BuscarPorID(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectById = "SELECT IdFilme, Titulo, IdGenero FROM Filmes WHERE IdFilme = @ID";

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);

                    con.Open();

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        FilmeDomain filme = new FilmeDomain
                        {
                            IdFilme = Convert.ToInt32(rdr["IdFilme"]),

                            Titulo = rdr["Titulo"].ToString()
                        };
                    }
                    return null;
                }
            }

        }

        public void Cadastrar(FilmeDomain filme)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO Filmes (Titulo,IdGenero) VALUES(@Titulo, @ID)";

                con.Open();

                SqlCommand cmd = new SqlCommand(queryInsert, con);

                cmd.Parameters.AddWithValue("@Titulo", filme.Titulo);

                cmd.Parameters.AddWithValue("@ID", filme.IdGenero);

                cmd.ExecuteNonQuery();
            }
        }

        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "DELETE Genero FROM IdGenero = @ID";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }

            }
        }

        public List<FilmeDomain> Listar()
        {
            List<FilmeDomain> filme = new List<FilmeDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT IdFilme, Titulo, Generos.Nome FROM Filmes INNER JOIN Generos ON Generos.IdGenero = Filmes.IdGenero;";


                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    con.Open();
                    rdr = cmd.ExecuteReader();  

                    while (rdr.Read())
                    {
                        FilmeDomain filmes = new FilmeDomain
                        {
                            IdFilme = Convert.ToInt32(rdr[0]),

                            Titulo = rdr["Titulo"].ToString(),

                        };

                        filmes.Genero.IdGenero = Convert.ToInt32(rdr[0]);

                        filmes.Genero.Nome = rdr["Nome"].ToString();

                        filme.Add(filmes);
                    }
                }
            }
            return filme;
        }
    }
}

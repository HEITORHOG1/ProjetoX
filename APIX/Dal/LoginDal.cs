using APIX.Model;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace APIX.Dal
{
    public class LoginDal : IMetodosLogin
    {
        readonly string _connectionString;

        public LoginDal(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("DefaultConnection");
        }

        public int Delete(int id)
        {
            using (var con = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("DeletarLogin", con)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@Id", id);

                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        public IEnumerable<LoginDto> Get()
        {
            var Lista = new List<LoginDto> ();
            using (var con = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("PesquisarTodos", con)
                {
                    CommandType = CommandType.StoredProcedure
                };

                con.Open();
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var dto = new LoginDto
                    {
                        id = Convert.ToInt32(reader["id"]),
                        nome = reader["nome"].ToString(),
                        email = reader["email"].ToString(),
                        senha = reader["senha"].ToString()
                    };

                    Lista.Add(dto);
                }
                con.Close();
            }
            return Lista;
        }

        public LoginDto ObterPorId(int id)
        {
            var dto = new LoginDto();

            using (var con = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("PesquisarPorId", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@Id", id);

                con.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        dto.id = Convert.ToInt32(reader["Id"]);
                        dto.nome = reader["nome"].ToString();
                        dto.email = reader["email"].ToString();
                        dto.senha = reader["senha"].ToString();
                    }
                }
                else
                    return null;
            }
            return dto;
        }

        public int Post(LoginDto dto)
        {
            try
            {
                using (var con = new SqlConnection(_connectionString))
                {
                    var cmd = new SqlCommand("InserirLogin", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    cmd.Parameters.AddWithValue("@nome", dto.nome);
                    cmd.Parameters.AddWithValue("@email", dto.email);
                    cmd.Parameters.AddWithValue("@senha", dto.senha);
                    con.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public int Put(LoginDto dto)
        {
            using (var con = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("AlterarLogin", con)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@Id", dto.id);
                cmd.Parameters.AddWithValue("@nome", dto.nome);
                cmd.Parameters.AddWithValue("@email", dto.email);
                cmd.Parameters.AddWithValue("@senha", dto.senha);
                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        public LoginDto ValidarLogin(string nome, string email)
        {
            var dto = new LoginDto();

            using (var con = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("ValidarLogin", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@email", nome);
                cmd.Parameters.AddWithValue("@senha", email);

                con.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        dto.id = Convert.ToInt32(reader["Id"]);
                    }
                }
                else
                    return null;
            }
            return dto;
        }
    }
}
